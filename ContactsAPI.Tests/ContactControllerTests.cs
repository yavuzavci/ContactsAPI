using System;
using System.Reflection;
using Xunit;
using Moq;
using ContactsAPI.Data;
using ContactsAPI.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ContactsAPI.Tests
{
    public class ContactControllerTests
    {
        private const string _connBase = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=postgres;";
        private static readonly string _db = "test_db";
        private static readonly string _conn = $"{_connBase};Database={_db}";

        [Fact]
        public async Task AddContactAsync_SavesContactToDatabase()
        {            
            DbContextOptionsBuilder<DataContext> optionsBuilder = new();
            optionsBuilder.UseNpgsql(_conn);
            using var context = new DataContext(optionsBuilder.Options);
            context.Database.EnsureCreated();
            var controller = new ContactController(context);

            var contact = new Contact
            {
                Id = 1,
                Name = "John",
                Surname = "Kissinger",
                Company = "Amazon",
                Phone = "+18004444449",
                Email = "jksgr.fake@amazon.com",
                Country = "United States"
            };

            var result = await controller.AddContactAsync(contact);

            Assert.IsType<OkObjectResult>(result.Result);
        }        

        [Fact]
        public async Task GetContactAsync_WithUnexistingItem_ReturnsBadRequest()
        {
            DbContextOptionsBuilder<DataContext> optionsBuilder = new();
            optionsBuilder.UseNpgsql(_conn);

            using var context = new DataContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            var controller = new ContactController(context);
            int id = 0;

            var result = await controller.GetContactAsync(id);  
            
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetContactAsync_WithExistingItem_ReturnsOkObject()
        {
            DbContextOptionsBuilder<DataContext> optionsBuilder = new();
            optionsBuilder.UseNpgsql(_conn);

            using var context = new DataContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            var controller = new ContactController(context);
            int id = 1;

            var result = await controller.GetContactAsync(id);

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetAllContactsAsync__ReturnsOkObject()
        {
            DbContextOptionsBuilder<DataContext> optionsBuilder = new();
            optionsBuilder.UseNpgsql(_conn);

            using var context = new DataContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            var controller = new ContactController(context);

            var result = await controller.GetAllContactsAsync();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task ReportContactsByCountry_WithNoItems_ReturnsNotFoundObject()
        {
            DbContextOptionsBuilder<DataContext> optionsBuilder = new();
            optionsBuilder.UseNpgsql(_conn);

            using var context = new DataContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            var controller = new ContactController(context);

            var result = await controller.ReportContactsByCountry();

            Assert.IsType<NotFoundObjectResult>(result);
        }
        [Fact]
        public async Task ReportContactsByCountry_WithItems_ReturnsOkObject()
        {
            DbContextOptionsBuilder<DataContext> optionsBuilder = new();
            optionsBuilder.UseNpgsql(_conn);

            using var context = new DataContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            var controller = new ContactController(context);

            var result = await controller.ReportContactsByCountry();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateContactsAsync_WithExistingItem_ReturnsOkObject()
        {
            DbContextOptionsBuilder<DataContext> optionsBuilder = new();
            optionsBuilder.UseNpgsql(_conn);

            using var context = new DataContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            var controller = new ContactController(context);

            var contact = await context.Contacts.FindAsync(1);
            contact.Name = "Joshua";
            contact.Surname = "Miller";
            contact.Company = "Ubisoft";
            contact.Phone = "+18004444477";
            contact.Email = "jksgr.fake@ubisoft.com";
            contact.Country = "Canada";

            var result = await controller.UpdateContactAsync(contact);

            Assert.IsType<OkObjectResult>(result);
        }        

        [Fact]
        public async Task DeleteContactAsync_WithExistingItem_ReturnsOkObject()
        {
            DbContextOptionsBuilder<DataContext> optionsBuilder = new();
            optionsBuilder.UseNpgsql(_conn);

            using var context = new DataContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            var controller = new ContactController(context);

            var result = await controller.DeleteContactAsync(1);

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task DeleteContactAsync_WithUnexistingItem_ReturnsBadRequestObject()
        {
            DbContextOptionsBuilder<DataContext> optionsBuilder = new();
            optionsBuilder.UseNpgsql(_conn);

            using var context = new DataContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            var controller = new ContactController(context);

            var result = await controller.DeleteContactAsync(0);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }
    }
}