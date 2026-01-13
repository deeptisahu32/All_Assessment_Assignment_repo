using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVC_CODE_FIRST.Models;


namespace MVC_CODE_FIRST.Models
{
    public class MoviesDBContext:DbContext
    {

        public MoviesDBContext() : base("MoviesDbContext") { }

        public DbSet<Movie> Movies { get; set; }

    }
}