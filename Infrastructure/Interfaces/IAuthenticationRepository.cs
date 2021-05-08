using Domain.Common;
using Domain.Dtos;
using Domain.Entities;
using Domain.General;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAuthenticationRepository : IRepository<User>
    {
        Task<ApiResponse<TokenResult>> LoginAsync(LoginDto request);
    }
}
