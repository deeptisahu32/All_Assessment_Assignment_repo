using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVC_CODE_FIRST.Models;


namespace MVC_CODE_FIRST.Repository
{
    public class MovieRepository:IMovieRepository
    {

        MoviesDBContext ctx;


        public MovieRepository(MoviesDBContext db)
        {
            ctx = db;
        }



        public IEnumerable<Movie> GetAll()
                    => ctx.Movies.OrderBy(m => m.MovieName).ToList();

        public Movie Get(int id)
            => ctx.Movies.Find(id);

        public void Add(Movie movie)
        {
            ctx.Movies.Add(movie);
            ctx.SaveChanges();
        }



        public void Update(Movie movie)
        {
            ctx.Entry(movie).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var m = ctx.Movies.Find(id);
            if (m != null)
            {
                ctx.Movies.Remove(m);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<Movie> GetByYear(int year)
                    => ctx.Movies
                           .Where(m => m.DateOfRelease.Year == year)
                           .OrderBy(m => m.MovieName)
                           .ToList();

        public IEnumerable<Movie> GetByDirector(string directorName)
            => ctx.Movies
                   .Where(m => m.DirectorName == directorName)
                   .OrderBy(m => m.DateOfRelease)
                   .ToList();


    }
}