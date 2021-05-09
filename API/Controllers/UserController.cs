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
            if (user.Password != null) user.Password = user.Password.GetMD5();
            return await base.Update(user, id);
        }

        [HttpPost]
        public override async Task<ActionResult<ApiResponse<User>>> Add([FromBody] User user)
        {
            user.Password = user.Password.GetMD5();
            return await base.Add(user);
        }
    }
}
