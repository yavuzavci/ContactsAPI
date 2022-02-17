using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;

        private static List<Contact> contacts = new List<Contact>
        {
            new Contact
            {
                Id = 1,
                Name = "Yavuz",
                Surname = "Avci",
                Company = "",
                Phone = "+903120751223",
                Email = "yavuzavci@gmail.com",
                Country = "Turkey"
            },
            new Contact
            {
                Id = 2,
                Name = "John",
                Surname = "Doe",
                Company = "Microsoft",
                Phone = "+18004444444",
                Email = "john@doe.com",
                Country = "United States"
            },
            new Contact
            {
                Id = 3,
                Name = "Jane",
                Surname = "Doe",
                Company = "Facebook",
                Phone = "+18004444445",
                Email = "jane.doe.test@facebook.com",
                Country = "United States"
            },
            new Contact
            {
                Id = 4,
                Name = "Noah",
                Surname = "Davis",
                Company = "Google",
                Phone = "+18004444446",
                Email = "dav_noah_test123@google.com",
                Country = "United States"
            },
            new Contact
            {
                Id = 5,
                Name = "Oliver",
                Surname = "Schmidt",
                Company = "Siemens GmbH",   
                Phone = "+49152901820",
                Email = "oli_test123@siemens.de",
                Country = "Germany"
            },
            new Contact
            {
                Id = 6,
                Name = "Hanna",
                Surname = "Becker",
                Company = "Facebook",
                Phone = "+49152901821",
                Email = "hanbecker85_test@facebook.com",
                Country = "Germany"
            }
        };

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> Get(int id)
        {
            var contact = contacts.Find(c => c.Id == id);
            if (contact == null)
                return BadRequest("Contact not found.");
            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult> AddContact(Contact contact)
        {
            contacts.Add(contact);
            return Ok(contacts);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateContact(Contact request)
        {
            var contact = contacts.Find(c => c.Id == request.Id);
            if (contact == null)
                return BadRequest("Contact not found.");

            contact.Name = request.Name;
            contact.Surname = request.Surname;
            contact.Company = request.Company;
            contact.Phone = request.Phone;
            contact.Email = request.Email;
            contact.Country = request.Country;

            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Contact>> Delete(int id)
        {
            var contact = contacts.Find(c => c.Id == id);
            if (contact == null)
                return BadRequest("Contact not found.");

            contacts.Remove(contact);
            return Ok(contacts);
        }
    }

        
}
