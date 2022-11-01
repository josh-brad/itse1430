using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibary.Memory
{
    public class MemoryMovieDatabase : MovieDatabase
    {

        public MemoryMovieDatabase ()
        {
            //var movie = new Movie();
            //movie.Title = "Jaws";
            //movie.Rating = "PG";
            //movie.RunLength = 210;
            //movie.Description = "Shaek eat";
            //movie.IsClassic = true;
            //Add(movie, out var error);

            var movie = new Movie() {
                Title = "Dune",
                Rating = "PG",
                RunLength = 210,
                ReleaseYear = 1977,
                Description = "Worm eat",
                IsClassic = true,
            };
            Add(movie, out var error);

            movie = new Movie() {
                Title = "Jaws",
                Rating = "PG",
                RunLength = 210,
                ReleaseYear = 1977,
                Description = "Shaek eat",
                IsClassic = true,
            };
            Add(movie, out error);

            movie = new Movie() {
                Title = "Jaws 2",
                Rating = "PG",
                RunLength = 210,
                ReleaseYear = 1977,
                Description = "Shaek eat",
                IsClassic = true,
            };
            Add(movie, out error);
        }

        protected override Movie AddCore ( Movie movie )
        {  
            movie.Id = _id++;
            _movies.Add(movie.Clone());

            return movie;
        }

        protected override Movie GetCore ( int id )
        {
            foreach (var movie in _movies)
                if (movie?.Id == id)
                    return movie.Clone();  

            return null;
        }


        protected override IEnumerable<Movie> GetAllCore ()
        {
            foreach (var movie in _movies)
            {
                yield return movie.Clone();
            }

            //return items;
        }

        protected override void RemoveCore ( int id )
        {
            //TODO: Switch to foreach
            //Enumerate array looking for match
            for (var index = 0; index < _movies.Count; ++index)
                if (_movies[index]?.Id == id)
                {
                    //_movies[index] = null;
                    _movies.RemoveAt(index);
                    return;
                };
        }

        protected override void UpdateCore ( int id, Movie movie)
        {
            var oldMovie = FindById(id);
            movie.CopyTo(oldMovie);
            oldMovie.Id = id;
        }

        #region Private Members

        private Movie FindById ( int id )
        {
            foreach (var movie in _movies)
                if (movie.Id == id)
                    return movie;

            return null;
        }

        protected override Movie FindByTitle ( string title )
        {
            foreach (var movie in _movies)
                if (String.Equals(movie.Title, title, StringComparison.OrdinalIgnoreCase))
                    return movie;

            return null;
        }

        private int _id = 1;

        private List<Movie> _movies = new List<Movie>();
        #endregion
    }
}
