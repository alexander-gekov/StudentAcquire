using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAcquire.Listing.Service.Data;
using StudentAcquire.Listing.Service.Data.Repositories;
using StudentAcquire.Listing.Service.Data.Repositories.Interfaces;
using StudentAcquire.Listing.Service.Dtos;
using StudentAcquire.Listing.Service.Models;

namespace StudentAcquire.Listing.Service.Controllers
{
    [Route("api/listings")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly IGenericRepository<Models.Listing> _repository;
        private readonly IMapper _mapper;

        public ListingsController(IGenericRepository<Models.Listing> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
        public ActionResult<ListingReadDto> PostListing(ListingCreateDto listing)
        {
            var model = _mapper.Map<Models.Listing>(listing);
            _repository.Add(model);

            var listingReadDto = _mapper.Map<ListingReadDto>(model);

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
