using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibary.Memory
{
    public class MemoryMovieDatabase : MovieDatabase
    {
        protected override Movie AddCore ( Movie movie )
        {  
            movie.Id = _id++;
            _movies.Add(movie.Clone());

            return movie;
        }

        protected override Movie GetCore ( int id )
        {
            return _movies.FirstOrDefault(x => x.Id == id)?.Clone();
            //foreach (var movie in _movies)
            //    if (movie?.Id == id)
            //        return movie.Clone();  

            //return null;
        }


        protected override IEnumerable<Movie> GetAllCore ()
        {
            //return _movies.Select(x => x.Clone());
            //LINQ Syntax
            return from movie in _movies
                   orderby movie.Title, movie.ReleaseYear
                   select movie.Clone();

            //foreach (var movie in _movies)
            //{
            //    yield return movie.Clone();
            //}

            //return items;
        }

        protected override void RemoveCore ( int id )
        {
            var movie = FindById(id);
            _movies.Remove(movie);
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
            return _movies.FirstOrDefault(x => x.Id == id);
        }

        protected override Movie FindByTitle ( string title )
        {
            return _movies.FirstOrDefault(x => String.Equals(x.Title, title, StringComparison.OrdinalIgnoreCase));
            //foreach (var movie in _movies)
            //    if (String.Equals(movie.Title, title, StringComparison.OrdinalIgnoreCase))
            //        return movie;

            //return null;
        }

        private int _id = 1;

        private List<Movie> _movies = new List<Movie>();
        #endregion
    }
}
