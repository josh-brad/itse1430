using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibary
{
    public static class MovieDatabaseExtensions
    {
        //Extension method requirments
        //1. public internal static class/method
        //2. first paramether ,ust be the extended type
        //3. First parameter must be proceeded bt this
        public static void Seed ( this IMovieDatabase database )
        {
            var movies = new Movie[] {
            new Movie() {
                Title = "Dune",
                Rating = "PG",
                RunLength = 210,
                ReleaseYear = 1977,
                Description = "Worm eat",
                IsClassic = true,
            },


            new Movie() {
                Title = "Jaws",
                Rating = "PG",
                RunLength = 210,
                ReleaseYear = 1977,
                Description = "Shaek eat",
                IsClassic = true,
            },

             new Movie() {
                Title = "Jaws 2",
                Rating = "PG",
                RunLength = 210,
                ReleaseYear = 1977,
                Description = "Shaek eat",
                IsClassic = true,
            }
        };
            foreach (var movie in movies)
                database.Add(movie);
        }
    }
}
