using Contactbook.API.Controllers;
using Domain.Common;
using Domain.Dtos;
using Domain.Entities;
using Domain.General;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AuthController : BaseController<IAuthenticationRepository, User>
    {
        private readonly IAuthenticationRepository authenticationRepository;
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger, IAuthenticationRepository authenticationRepository) : base(authenticationRepository, logger)
        {
            _logger = logger;
            this.authenticationRepository = authenticationRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResponse<TokenResult>>> Login([FromBody] LoginDto request)
        {
            try
            {
                var result = await authenticationRepository.LoginAsync(request);

                if (result == null)
                {
                    return StatusCode(404);
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
    }
}
