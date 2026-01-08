using Contact_MVC_Code_first.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_MVC_Code_first.Repository
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync();
        Task CreateAsync(Contact contact);
        Task DeleteAsync(long Id);
    }
}
