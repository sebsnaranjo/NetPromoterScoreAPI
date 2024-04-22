using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetPromoterScoreAPI.DTOs;
using NetPromoterScoreAPI.Interfaces;
using NetPromoterScoreAPI.Models;


namespace NetPromoterScoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
               _userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int id)
        {
            if (!_userRepository.userExists(id))
                return NotFound();

            var user = _userRepository.GetUser(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatUser(User user)
        {
           _userRepository.CreateUser(user);
            return Ok(user);
        }

        [HttpPut]
        [Route("Edit")]
        public IActionResult Edit(User user)
        {
            int rs = _userRepository.UpdateUser(user);
            if (rs <= 0)
            {
                return BadRequest("Failed");
            }
            else
                return Ok("Updated! " + rs);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            int rs = _userRepository.DeleteUser(id);
            if (rs <= 0)
            {
                return BadRequest("Failed");
            }
            else
                return Ok("Deleted! " + rs);
        }


    }
}
