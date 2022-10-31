using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCreator
{
    public class ContactDatabase
    {
        public ContactDatabase ()
        {
            var contact = new Contact() {
                FirstName = "Dune",
                LastName = "PG",
                Notes = "asdasdas",
                Email = "Worm eat",
                IsFavorite = true,
            };
            Add(contact, out var error);

            contact = new Contact() {
                FirstName = "Dune",
                LastName = "PG",
                Notes = "asdasdas",
                Email = "Worm eat",
                IsFavorite = true,
            };
            Add(contact, out error);

            contact = new Contact() {
                FirstName = "Dune",
                LastName = "PG",
                Notes = "asdasdas",
                Email = "Worm eat",
                IsFavorite = true,
            };
            Add(contact, out error);
        }

        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The new movie.</returns>
        /// <remarks>
        /// Fails if:
        ///   - Movie is null
        ///   - Movie is not valid
        ///   - Movie title already exists
        /// </remarks>
        public virtual Contact Add ( Contact contact, out string errorMessage )
        {
            if (contact == null)
            {
                errorMessage = "Movie cannot be null";
                return null;
            };

            //if (!new ObjectValidator().IsValid(contact, out errorMessage))
            //    return null;

            var existing = FindByTitle(contact.LastName);
            if (existing != null)
            {
                errorMessage = "Movie must be unique";
                return null;
            };

            contact.Id = _id++;
            _contacts.Add(contact.Clone());

            errorMessage = null;
            return contact;
        }

        /// <summary>Gets a movie.</summary>
        /// <param name="id">ID of the movie.</param>
        /// <returns>The movie, if any.</returns>
        /// <remarks>
        /// Fails if:
        ///    - Id is less than 1
        /// </remarks>
        public Contact Get ( int id )
        {
            foreach (var movie in _contacts)
                if (movie?.Id == id)
                    return movie.Clone();

            return null;
        }

        /// <summary>Gets all the movies.</summary>
        /// <returns>The movies.</returns>
        public Contact[] GetAll ()
        {
            var items = new Contact[_contacts.Count];
            var index = 0;
            foreach (var contact in _contacts)
                items[index++] = contact.Clone();
            return items;
        }

        public void Remove ( int id )
        {

            for (var index = 0; index < _contacts.Count; ++index)
                if (_contacts[index]?.Id == id)
                {
                    _contacts.RemoveAt(index);
                    return;
                };
        }

        public bool Update ( int id, Contact contact, out string errorMessage )
        {
            if (contact == null)
            {
                errorMessage = "Movie cannot be null";
                return false;
            };
            //if (!new ObjectValidator().IsValid(contact, out errorMessage))
            //    return false;

            var oldContact = FindByLastName(id);
            if (oldContact == null)
            {
                errorMessage = "Movie does not exist";
                return false;
            };
            var existing = FindByTitle(contact.LastName);
            if (existing != null && existing.Id != id)
            {
                errorMessage = "Movie must be unique";
                return false;
            };
            contact.CopyTo(oldContact);
            oldContact.Id = id;

            errorMessage = null;
            return true;
        }

        #region Private Members

        private Contact FindByLastName ( int id )
        {
            foreach (var movie in _contacts)
                if (movie.Id == id)
                    return movie;

            return null;
        }

        private Contact FindByTitle ( string lastName )
        {
            foreach (var contact in _contacts)
                if (String.Equals(contact.LastName, lastName, StringComparison.OrdinalIgnoreCase))
                    return contact;

            return null;
        }

        private int _id = 1;
        private List<Contact> _contacts = new List<Contact>();
        #endregion
    }
}
