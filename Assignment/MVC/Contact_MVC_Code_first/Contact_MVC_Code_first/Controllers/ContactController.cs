using Contact_MVC_Code_first.Models;
using Contact_MVC_Code_first.Repositories;
using Contact_MVC_Code_first.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Contact_MVC_Code_first.Controllers
{
    public class ContactController : Controller
    {
        IContactRepository repos = new ContactRepository();
        // GET: Contacts
        public async Task<ActionResult> Index()
        {
            return View(await repos.GetAllAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await repos.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public async Task<ActionResult> Delete(long id)
        {
            await repos.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}