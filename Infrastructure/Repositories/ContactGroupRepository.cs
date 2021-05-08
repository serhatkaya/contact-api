using Contactbook.Infrastructure.Repositories;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class ContactGroupRepository : Repository<ContactGroup>, IContactGroupRepository
    {
        public ContactGroupRepository(ContactContext context) : base(context)
        { }
    }
}
