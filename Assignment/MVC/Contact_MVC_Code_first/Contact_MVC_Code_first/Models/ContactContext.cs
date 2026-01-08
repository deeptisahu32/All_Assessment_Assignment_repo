using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Contact_MVC_Code_first.Models
{
    public class ContactContext:DbContext
    {
        public ContactContext() : base("name=contactstr") { }
        public DbSet<Contact> contacts { get; set; }
        public object Contacts { get; internal set; }
    }
}