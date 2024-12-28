using IOT_Application.Model;
using IOT_Application.Repository.RegisterRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IOT_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {

        private readonly IRegisterUserRepository _registerRepository;

        public RegisterUserController(IRegisterUserRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }


        [HttpPost]
        [Route("CheckUser")]
        public IActionResult CheckUser(LoginUser user)
        {
            var data = _registerRepository.GetUser(user.UserName);

            if (data != null)
            {
                return Ok(_registerRepository.CheckUser(user));
            }

            return BadRequest("User Not Found");
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(RegisterUser user) 
        {
            return Ok(_registerRepository.AddUser(user));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult GetToken(LoginUser user)
        {
            var data = _registerRepository.CheckUser(user);

            if (data == "True")
            {
                return Ok(_registerRepository.GetToken(user));
            }
            return BadRequest("User not found");
        }


    }
}
