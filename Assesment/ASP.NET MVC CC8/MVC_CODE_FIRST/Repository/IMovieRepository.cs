using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_CODE_FIRST.Models;

namespace MVC_CODE_FIRST.Repository
{
    public interface IMovieRepository
    {

        IEnumerable<Movie> GetAll();
        Movie Get(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);

        IEnumerable<Movie> GetByYear(int year);
        IEnumerable<Movie> GetByDirector(string directorName);

    }
}
