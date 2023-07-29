using AgendaMvc.Data;
using AgendaMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaMvc.Repositories
{
    public class ContactRepository : IContactRepository
    {

        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public Contact Create(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return contact;
        }

        public List<Contact> ReadAll()
        {
            return _context.Contacts.ToList();
        }

        public Contact FindById(int id)
        {
            return _context.Contacts.FirstOrDefault(c => c.Id == id);
        }

        public Contact Update(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();

            return contact;
        }


        public bool Delete(int id)
        {
            var contactDb = FindById(id);
            if (contactDb == null) throw new System.Exception("Id inexistente");

            _context.Contacts.Remove(contactDb);
            _context.SaveChanges();

            return true;
        }

    }
}
