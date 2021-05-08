using Contactbook.API.Controllers;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;


namespace API.Controllers
{
    public class ContactController : BaseController<IContactRepository, Contact>
    {
        private readonly IContactRepository contactRepository;
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger, IContactRepository contactRepository) : base(contactRepository, logger)
        {
            _logger = logger;
            this.contactRepository = contactRepository;
        }
    }
}
