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
                FirstName = "Tim",
                LastName = "Bobby",
                Notes = "CEO of Google",
                Email = "timcook@gmail.com",
                IsFavorite = true,
            };
            Add(contact, out var error);

            contact = new Contact() {
                FirstName = "Larry",
                LastName = "Bobson",
                Notes = "CEO of Apple",
                Email = "dave@apple.com",
                IsFavorite = true,
            };
            Add(contact, out error);

            contact = new Contact() {
                FirstName = "Jessie",
                LastName = "James",
                Notes = "CEO of Younger INC",
                Email = "lawabidingcitizen@train.com",
                IsFavorite = true,
            };
            Add(contact, out error);

            contact = new Contact() {
                FirstName = "Uglyer",
                LastName = "Idunno",
                Notes = "Garbage Collector",
                Email = "sewageisfun@sdkfjslkadjhf.com",
                IsFavorite = false,
            };
            Add(contact, out error);
        }

        /// <summary>Adds a contact to the database.</summary>
        /// <param name="contact">The contact to add.</param>
        /// <returns>The new contact.</returns>
        /// <remarks>
        /// Fails if:
        ///   - contact is null
        ///   - contact is not valid
        ///   - contact lastname already exists
        /// </remarks>
        public virtual Contact Add ( Contact contact, out string errorMessage )
        {
            if (contact == null)
            {
                errorMessage = "Contact cannot be null";
                return null;
            };

            //if (!new ObjectValidator().IsValid(contact, out errorMessage))
            //    return null;

            var existing = FindByTitle(contact.LastName);
            if (existing != null)
            {
                errorMessage = "Contact must be unique";
                return null;
            };

            contact.Id = _id++;
            _contacts.Add(contact.Clone());

            errorMessage = null;
            return contact;
        }

        /// <summary>Gets a contact.</summary>
        /// <param name="id">ID of the contact.</param>
        /// <returns>The contact, if any.</returns>
        /// <remarks>
        /// Fails if:
        ///    - Id is less than 1
        /// </remarks>
        public Contact Get ( int id )
        {
            foreach (var contact in _contacts)
                if (contact?.Id == id)
                    return contact.Clone();

            return null;
        }

        /// <summary>Gets all the contacts.</summary>
        /// <returns>The contacts.</returns>
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
                errorMessage = "Contact cannot be null";
                return false;
            };
            //if (!new ObjectValidator().IsValid(contact, out errorMessage))
            //    return false;

            var oldContact = FindByLastName(id);
            if (oldContact == null)
            {
                errorMessage = "Contact does not exist";
                return false;
            };
            var existing = FindByTitle(contact.LastName);
            if (existing != null && existing.Id != id)
            {
                errorMessage = "Contact must be unique";
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
            foreach (var contact in _contacts)
                if (contact.Id == id)
                    return contact;

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
