using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPISample.Data;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private ApplicationContext _context;
        public MovieController(ApplicationContext context)
        {
            _context = context;
        }
        // GET api/movie
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            // Retrieve all movies from db logic
            return _context.Movies.ToList();
        }


        // GET api/movie/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            // Retrieve movie by id from db logic
            var movieInDb = _context.Movies.Where(m => m.MovieId == id).FirstOrDefault();
            return  movieInDb.ToString();
        }
        
        // POST api/movie
        [HttpPost]
        public void Post([FromBody]Movie value)
        {
            // Create movie in db logic
            var newMovie = value;
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }

        // PUT api/movie/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Movie movie)
        {
            // Update movie in db logic
            //var editMovie = _context.Movies.Where(c => c.MovieId == id).Single();

            var updateMovieInDb = _context.Movies.Where(c => c.MovieId == id).Single();
           
            updateMovieInDb.Title = movie.Title;
            updateMovieInDb.Director = movie.Director;
            updateMovieInDb.Genre = movie.Genre;

            //_context.Update(updateMovieInDb);
            _context.SaveChanges();
        }

        // DELETE api/movie/5
        [HttpDelete("{id}")]
        public void Delete(Movie movie)
        {
            // Delete movie from db logic

            _context.Movies.Remove(movie);
            _context.Update(movie);
            _context.SaveChanges();
        }

    }
}