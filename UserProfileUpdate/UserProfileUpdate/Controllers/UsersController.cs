using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using UserProfileUpdate.Models.InputModel;
using UserProfileUpdate.Models.ViewModel;
using UserProfileUpdate.Services;

namespace UserProfileUpdate.Controllers
{

    [Produces("application/json")]

    public class UsersController : Controller
    {
        IUserService userService;
        private ILoggerManager _logger;

        public UsersController(IUserService _userService, ILoggerManager logger)
        {
            userService = _userService;
            _logger = logger;
        }

        [HttpGet("api/GetException")]
        public ActionResult GetException()
        {
            int a = 1, b = 0;
            return Ok(a / b);
        }

        [HttpGet("api/GetAllUsers")]
        public ActionResult GetAllUsers()
        {
            var result = userService.GetAllUsers();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("api/GetUserById/{userId}")]
        public ActionResult GetUserById(int userId)
        {
            var result = userService.GetUserById(userId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("api/GetUserByUserName/{userName}")]
        public ActionResult GetUserByUserName(string userName)
        {
            var result = userService.GetUserByUserName(userName);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("api/GetUserByEmailId/{email_Id}")]
        public ActionResult GetUserByEmailId(string email_Id)
        {
            var result = userService.GetUserByEmailId(email_Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("api/AddUser")]
        public ActionResult AddUser(UserViewModel userViewModel)
        {
            var result = userService.AddUser(userViewModel);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("api/UpdateUser")]
        public ActionResult UpdateUser(UserInputModel userInputModel)
        {
            var result = userService.UpdateUser(userInputModel);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("api/DeleteUser/{userId}")]
        public ActionResult DeleteUser(int userId)
        {
            var result = userService.DeleteUser(userId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
