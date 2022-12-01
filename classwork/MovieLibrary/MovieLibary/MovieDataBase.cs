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
        public Movie Add ( Movie movie)
        {
            //Validate movie
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            ObjectValidator.Validate(movie);

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
                throw new InvalidOperationException("Movie title must be unique.");
            movie.OldMethod();

            //Add
            movie = AddCore(movie);
            //movie.Id = _id++;
            //_movies.Add(movie.Clone());
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
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

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
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");
            RemoveCore(id);
        }

        protected abstract void RemoveCore ( int id );

        public void Update ( int id, Movie movie )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            ObjectValidator.Validate(movie);

            //Movie must already exist
            var oldMovie = GetCore(id);
            if (oldMovie == null)
                throw new ArgumentException("Movie does not exist", nameof(movie));

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null && existing.Id != id)
                throw new InvalidOperationException("Movie title must be unique.");
            try
            {
                UpdateCore(id, movie);
            }catch(Exception e)
            {
                throw new Exception("Update failed", e);
            };
        }

        protected abstract void UpdateCore ( int id, Movie movie );

        protected abstract Movie FindByTitle ( string title );

    }
}