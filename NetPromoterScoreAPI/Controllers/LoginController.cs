using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetPromoterScoreAPI.DTOs;
using NetPromoterScoreAPI.Interfaces;
using NetPromoterScoreAPI.Repository;

namespace NetPromoterScoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        public bool Login(string email, string password)
        {
            var user = _loginRepository.userLogin(email, password);
            return user;
        }
    }
}
