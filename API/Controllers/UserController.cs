using Contactbook.API.Controllers;
using Domain.Entities;
using Domain.General;
using Infrastructure.Extensions;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class UserController : BaseController<IUserRepository, User>
    {
        private readonly IUserRepository userRepository;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository) : base(userRepository, logger)
        {
            _logger = logger;
            this.userRepository = userRepository;
        }

        [HttpPut]
        public override async Task<ActionResult<ApiResponse<User>>> Update([FromBody] User user, [FromQuery] string id)
        {
            try
            {
                if (user.Password != null) user.Password = user.Password.GetMD5();
                var result = await userRepository.UpdateAsync(user, id);
                if (result == null)
                {
                    return StatusCode(400);
                }
                return StatusCode(200, result);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                         $"{ControllerContext.RouteData.Values["controller"].ToString()} - {ControllerContext.RouteData.Values["action"].ToString()}" +
                         $"Error");
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public override async Task<ActionResult<ApiResponse<User>>> Add([FromBody] User user)
        {
            try
            {
                user.Password = user.Password.GetMD5();
                var result = await _repository.AddAsync(user);

                if (result == null)
                {
                    return StatusCode(404);
                }

                return StatusCode(202, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                         $"{ControllerContext.RouteData.Values["controller"].ToString()} - {ControllerContext.RouteData.Values["action"].ToString()}" +
                         $"Error");
                return StatusCode(500, ex);
            }
        }
    }
}
