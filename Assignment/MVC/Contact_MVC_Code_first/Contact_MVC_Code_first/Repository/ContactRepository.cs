using Contact_MVC_Code_first.Models;
using Contact_MVC_Code_first.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Contact_MVC_Code_first.Repositories
{
    public class ContactRepository :IContactRepository
    {
        ContactContext db = new ContactContext();

        public async Task<List<Contact>> GetAllAsync()
        {
            return await db.contacts.ToListAsync();
        }

        public async Task CreateAsync(Contact contact)
        {
            db.contacts.Add(contact);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var contact = await db.contacts.FindAsync(id);
            if (contact != null)
            {
                db.contacts.Remove(contact);
                await db.SaveChangesAsync();
            }
        }

    }
}
