using Contactbook.Infrastructure.Repositories;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(ContactContext context) : base(context)
        { }
    }
}
