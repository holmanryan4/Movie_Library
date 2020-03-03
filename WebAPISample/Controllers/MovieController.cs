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
        public IEnumerable<string> Get()
        {
            // Retrieve all movies from db logic
            var movieInDb = _context.Movies.Select(m => m.Title).ToList();
            movieInDb.FirstOrDefault();

            return movieInDb; /*new string[] { "movie1 string", "movie2 string" };*/
        }

        // GET api/movie/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            // Retrieve movie by id from db logic
            var movieInDb = _context.Movies.Where(m => m.MovieId == id).FirstOrDefault();
            return movieInDb.ToString();
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
            Movie updateMovie = _context.Movies.Where(c => c.MovieId == id).FirstOrDefault();
            var updateMovieInDb = _context.Movies.Where(c => c.MovieId == updateMovie.MovieId).FirstOrDefault();

            updateMovieInDb.Title = movie.Title;
            updateMovieInDb.Director = movie.Director;
            updateMovieInDb.Genre = movie.Genre;

            _context.Update(updateMovieInDb);
            _context.SaveChanges();
        }

        // DELETE api/movie/5
        [HttpDelete]
        public void Delete(int id)
        {
            // Delete movie from db logic

            Movie movie = _context.Movies.Find(id);

            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

    }
}