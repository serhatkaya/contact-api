using Contactbook.Infrastructure.Repositories;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ContactContext context) : base(context)
        { }
    }
}
