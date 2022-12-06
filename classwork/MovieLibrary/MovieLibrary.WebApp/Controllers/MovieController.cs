using Microsoft.AspNetCore.Mvc;
using MovieLibary;

namespace MovieLibrary.WebApp.Controllers
{
    //[Route("movies")]
    public class MovieController : Controller
    {

        public MovieController(IConfiguration configuration )
        {
            var connString = configuration.GetConnectionString("AppDatabase");
            _database = new MovieLibary.Sql.SqlMovieDatabase(connString);
        }
        //Action = public methods on controller
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Index ()
        {
            var movies =  _database.GetAll();
            return View(movies);
            //return View();
        }

        [HttpGet]
        public ActionResult<Movie> Details (int id )
        {
            var movie = _database.Get(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        private readonly MovieLibary.Sql.SqlMovieDatabase _database;
    }
}
