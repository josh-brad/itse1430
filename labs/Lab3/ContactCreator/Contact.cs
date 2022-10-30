using System.ComponentModel.DataAnnotations;

namespace ContactCreator
{
    public class Contact
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

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            var errors = new List<ValidationResult>();
            if (FirstName.Length == 0)
                errors.Add(new ValidationResult("Title is required", new[] { nameof(FirstName) }));

            if (LastName.Length == 0)
                errors.Add(new ValidationResult("Rating is required", new[] { nameof(LastName) }));

            if (Email.Length == 0)
                errors.Add(new ValidationResult("RunLength is required", new[] { nameof(Email) }));

            if (Notes.Length == 0)
                errors.Add(new ValidationResult("RunLength is required", new[] { nameof(Notes) }));

            return errors;
        }

        public int Id { get; set; }


        public Contact Clone ()
        {
            var movie = new Contact();
            CopyTo(movie);

            return movie;
        }

        public void CopyTo ( Contact contact )
        {
            contact.Id = Id;
            contact.Title = Title;
            contact.Description = Description;
            contact.RunLength = RunLength;
            contact.ReleaseYear = ReleaseYear;
            contact.Rating = Rating;
            contact.IsClassic = IsClassic;
        }
    }
}