using System.ComponentModel.DataAnnotations;

namespace ContactCreator
{
    public class Contact : IValidatableObject
    {
        public string FirstName
        {
            get { return _firstName ?? ""; }
            set { _firstName = value?.Trim() ?? ""; }
        }
        private string _firstName;

        public string LastName
        {
            get { return _lastName ?? ""; }
            set { _lastName = value?.Trim() ?? ""; }
        }
        private string _lastName;
        public string Email
        {
            get { return _email ?? ""; }
            set { _email = value?.Trim() ?? ""; }
        }
        private string _email;

        public string Notes
        {
            get { return _notes ?? ""; }
            set { _notes = value?.Trim() ?? ""; }
        }
        private string _notes;

        public bool IsFavorite { get; set; }

        public int Id { get; set; }


        public Contact Clone ()
        {
            var contact = new Contact();
            CopyTo(contact);

            return contact;
        }

        public void CopyTo ( Contact contact )
        {
            contact.Id = Id;
            contact.LastName = LastName;
            contact.FirstName = FirstName;
            contact.Email = Email;
            contact.Notes = Notes;
            contact.IsFavorite = IsFavorite;
        }
        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            var errors = new List<ValidationResult>();
            if (LastName.Length == 0)
                errors.Add(new ValidationResult("Lastname is required", new[] { nameof(LastName) }));

            if (FirstName.Length == 0)
                errors.Add(new ValidationResult("Firstname is required", new[] { nameof(FirstName) }));

            if (Notes.Length == 0)
                errors.Add(new ValidationResult("Notes is required", new[] { nameof(Notes) }));

            if (Email.Length == 0)
                errors.Add(new ValidationResult("Email is required", new[] { nameof(Email) }));

            return errors;

        }

        public override string ToString ()
        {
            return LastName;
        }
    }
}