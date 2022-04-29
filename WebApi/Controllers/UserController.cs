using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interface;

namespace WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {        
        private readonly IUserRepository _UserRepository;
        public UserController(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                return Ok(await _UserRepository.GetUsers());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }

        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var result = await _UserRepository.GetUser(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }
                var CreateUser = await _UserRepository.AddUser(user);
                return CreatedAtAction(nameof(GetUsers), new { id = CreateUser.Id }, CreateUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<User>> UpdateUser(int id,User user)
        {
            try
            {
                if (id != user.Id)
                {
                    return BadRequest("Id is not match");
                }
                var userUpdated = await _UserRepository.GetUser(id);
                if (userUpdated == null)
                {
                    return NotFound($"User {id} is not found");
                }
                var UpdatedUser = await _UserRepository.UpdateUser(user);
                return UpdatedUser;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {

                var userDelete = await _UserRepository.GetUser(id);

                if (userDelete != null)
                {
                    var user = await _UserRepository.DeleteUser(id);
                    return user;
                }
                return null;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }

        [HttpGet("{Search},User")]
        public async Task<ActionResult<IEnumerable<User>>> Search(string FirstName)
        {
            try
            {
                var result = await _UserRepository.Search(FirstName);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro in retrieving data from database");
            }
        }

    }
}
