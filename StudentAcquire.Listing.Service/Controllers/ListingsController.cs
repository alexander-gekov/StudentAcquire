using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAcquire.Listing.Service.AsyncDataServices;
using StudentAcquire.Listing.Service.Data;
using StudentAcquire.Listing.Service.Data.Repositories;
using StudentAcquire.Listing.Service.Data.Repositories.Interfaces;
using StudentAcquire.Listing.Service.Dtos;
using StudentAcquire.Listing.Service.Models;
using StudentAcquire.Listing.Service.SyncDataServices.Http;

namespace StudentAcquire.Listing.Service.Controllers
{
    [Route("api/listings")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly IGenericRepository<Models.Listing> _repository;
        private readonly IMapper _mapper;
        private readonly IUserDataClient _userDataClient;
        private readonly IMessageBusClient _messageBusClient;

        public ListingsController(
        IGenericRepository<Models.Listing> repository, 
        IMapper mapper, 
        IUserDataClient userDataClient, 
        IMessageBusClient messageBusClient)
        {
            _repository = repository;
            _mapper = mapper;
            _userDataClient = userDataClient;
            _messageBusClient = messageBusClient;
        }

        // GET: api/Listings
        [HttpGet]
        public ActionResult<IEnumerable<ListingReadDto>> GetListing()
        {
            var listings = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<ListingReadDto>>(listings));
        }

        // GET: api/Listings/5
        [HttpGet("{id}", Name="GetListingById")]
        public ActionResult<ListingReadDto> GetListing(int id)
        {
            var listing =  _repository.GetById(id);

            if (listing == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ListingReadDto>(listing));
        }

        // PUT: api/Listings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutListing(int id, ListingCreateDto listing)
        {
            var model = _mapper.Map<Models.Listing>(listing);
            model.Id = id;
            _repository.Update(model);
            var listingReadDto = _mapper.Map<ListingReadDto>(model);

            return CreatedAtAction(nameof(GetListing), new { Id = listingReadDto.Id }, listingReadDto);
        }

        // POST: api/Listings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListingReadDto>> PostListing(ListingCreateDto listing)
        {
            var model = _mapper.Map<Models.Listing>(listing);
            _repository.Add(model);

            var listingReadDto = _mapper.Map<ListingReadDto>(model);

            try
            {
                await _userDataClient.SendListingToUser(listingReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            try
            {
                var ListingPublishDto = _mapper.Map<ListingPublishDto>(listingReadDto);
                ListingPublishDto.Event = "New_Listing";
                _messageBusClient.PublishNewListing(ListingPublishDto);
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"--> Error: {ex.Message}");
            }

            return CreatedAtAction(nameof(GetListing), new { Id = listingReadDto.Id }, listingReadDto);
        }

        // DELETE: api/Listings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListing(int id)
        {
            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
