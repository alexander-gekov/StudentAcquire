using Microsoft.AspNetCore.Mvc;
using StudentAcquire.User.Service.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAcquire.User.Service.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGenericRepository<Models.User> _repository;

        public UsersController(IGenericRepository<Models.User> repository)
        {
            _repository = repository;
        }

        // GET: api/users
        [HttpGet]
        public ActionResult<IEnumerable<Models.User>> GetUsers()
        {
            var users = _repository.GetAll();

            return Ok(users);
        }

        // GET api/users/5
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<Models.User> GetUser(int id)
        {
            var user = _repository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<Models.User>> PostUser(Models.User user)
        {
            _repository.Add(user);

            return CreatedAtAction(nameof(GetUser), new { Id = user.Id }, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult PutUser(int id, Models.User user)
        {
            user.Id = id;
            _repository.Update(user);

            return CreatedAtAction(nameof(GetUser), new { Id = user.Id }, user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
