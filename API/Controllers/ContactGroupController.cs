using Contactbook.API.Controllers;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class ContactGroupController : BaseController<IContactGroupRepository, ContactGroup>
    {
        private readonly IContactGroupRepository contactGroupRepository;
        private readonly ILogger<ContactGroupController> _logger;

        public ContactGroupController(ILogger<ContactGroupController> logger, IContactGroupRepository contactGroupRepository) : base(contactGroupRepository, logger)
        {
            _logger = logger;
            this.contactGroupRepository = contactGroupRepository;
        }
    }
}
