using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContactsAsync()
        {
            return Ok(await _context.Contacts.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
                return BadRequest("Contact not found.");
            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<List<Contact>>> AddContactAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return Ok(await _context.Contacts.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult> UpdateContactAsync(Contact request)
        {
            var dbContact = await _context.Contacts.FindAsync(request.Id);
            if (dbContact == null)
                return BadRequest("Contact not found.");

            dbContact.Name = request.Name;
            dbContact.Surname = request.Surname;
            dbContact.Company = request.Company;
            dbContact.Phone = request.Phone;
            dbContact.Email = request.Email;
            dbContact.Country = request.Country;

            await _context.SaveChangesAsync();

            return Ok(await _context.Contacts.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Contact>> DeleteContactAsync(int id)
        {
            var dbContact = await _context.Contacts.FindAsync(id);
            if (dbContact == null)
                return BadRequest("Contact not found.");

            _context.Contacts.Remove(dbContact);
            await _context.SaveChangesAsync();
            return Ok(await _context.Contacts.ToListAsync());
        }
    }

        
}
