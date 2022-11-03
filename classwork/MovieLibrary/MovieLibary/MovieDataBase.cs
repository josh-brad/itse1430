using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibary;

namespace MovieLibary
{
    /// <summary>Provides a database of movies.</summary>
    public abstract class MovieDatabase : IMovieDatabase
    {
        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The new movie.</returns>
        /// <remarks>
        /// Fails if:
        ///   - Movie is null
        ///   - Movie is not valid
        ///   - Movie title already exists
        /// </remarks>
        public Movie Add ( Movie movie, out string errorMessage )
        {
            //Validate movie
            if (movie == null)
            {
                errorMessage = "Movie cannot be null";
                return null;
            };

            if (!ObjectValidator.IsValid(movie, out errorMessage))
                return null;

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
            {
                errorMessage = "Movie must be unique";
                return null;
            };

            //Add
            movie = AddCore(movie);
            //movie.Id = _id++;
            //_movies.Add(movie.Clone());

            errorMessage = null;
            return movie;
        }

        protected abstract Movie AddCore ( Movie movie );

        /// <summary>Gets a movie.</summary>
        /// <param name="id">ID of the movie.</param>
        /// <returns>The movie, if any.</returns>
        /// <remarks>
        /// Fails if:
        ///    - Id is less than 1
        /// </remarks>
        public Movie Get ( int id )
        {
            if (id <= 0)
                return null;
            //Enumerate array looking for match            
            //for (var index = 0; index < _movies.Length; ++index)
            //if (_movies[index]?.Id == id)
            //return _movies[index].Clone();  //Clone because of ref type
            //foreach (var movie in _movies)
            //    if (movie?.Id == id)
            //        return movie.Clone();  //Clone because of ref type

            return GetCore(id);
        }

        protected abstract Movie GetCore ( int id );

        /// <summary>Gets all the movies.</summary>
        /// <returns>The movies.</returns>
        public IEnumerable<Movie> GetAll ()
        {
            return GetAllCore();
        }

        protected abstract IEnumerable<Movie> GetAllCore ();

        public void Remove ( int id )
        {
            if (id <= 0)
                return;
            RemoveCore(id);
        }

        protected abstract void RemoveCore ( int id );

        public bool Update ( int id, Movie movie, out string errorMessage )
        {
            //Validate movie
            if (movie == null)
            {
                errorMessage = "Movie cannot be null";
                return false;
            };
            if (!ObjectValidator.IsValid(movie, out errorMessage))
                return false;

            //Movie must already exist
            var oldMovie = GetCore(id);
            if (oldMovie == null)
            {
                errorMessage = "Movie does not exist";
                return false;
            };

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null && existing.Id != id)
            {
                errorMessage = "Movie must be unique";
                return false;
            };

            UpdateCore(id, movie);

            errorMessage = null;
            return true;
        }

        protected abstract void UpdateCore ( int id, Movie movie );

        protected abstract Movie FindByTitle ( string title );

    }
}