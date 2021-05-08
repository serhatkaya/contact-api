using Contactbook.Domain.Common;
using Contactbook.Infrastructure.Repositories;
using Domain.Common;
using Domain.Dtos;
using Domain.Entities;
using Domain.General;
using Infrastructure.Extensions;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AuthenticationRepository : Repository<User>, IAuthenticationRepository
    {
        private readonly AppSettings _appSettings;
        private readonly ContactContext _context;

        public AuthenticationRepository(ContactContext context, IOptions<AppSettings> appSettings) : base(context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public async Task<ApiResponse<TokenResult>> LoginAsync(LoginDto request)
        {
            var response = new ApiResponse<TokenResult>();
            try
            {
                request.Password = request.Password.GetMD5();

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == request.Username);

                if (user == null)
                {
                    response.Message = "User not found.";
                    return response;
                }

                if (user.Password != request.Password)
                {
                    response.Message = "Login credentials incorrect";
                    return response;
                }
                var loginuser = new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Username = user.Username,
                    Role = user.Role,
                };

                string generatedToken = GenerateToken(loginuser);
                loginuser.Token = generatedToken;


                response.Result = new TokenResult
                {
                    Token = generatedToken,
                    Expires = DateTime.UtcNow.AddMinutes(_appSettings.JwtExpires),
                    User = loginuser
                };

                response.Message = "Successfully logged in!";
                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.MessageDetail = e.InnerException != null ? e.InnerException.Message : null;
                return response;
            }


            string GenerateToken(UserDto user)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.JwtKey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                        {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Role)

                }),
                    Expires = DateTime.UtcNow.AddMinutes(_appSettings.JwtExpires),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                            SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
        }
    }
}
