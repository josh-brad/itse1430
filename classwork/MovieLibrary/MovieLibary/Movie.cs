/*
 * Name
 * Lab
 * Fall 2022
 */
using System.ComponentModel.DataAnnotations;

namespace MovieLibary
{
    /// <summary>Represents a movie.</summary>
    public class Movie //: IValidatableObject
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="Movie"/> class.</summary>
        public Movie () : this("", "")
        {
        }

        /// <summary>Initializes an instance of the <see cref="Movie"/> class.</summary>
        /// <param name="title">The title.</param>
        public Movie ( string title ) : this(title, "")
        {
        }

        /// <summary>Initializes an instance of the <see cref="Movie"/> class.</summary>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        public Movie ( string title, string description ) : base() // Object.ctor()
        {
            Title = title;
            Description = description;
        }
        #endregion

        /// <summary>Gets the unique ID.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the title.</summary>
        //[RequiredAttribute()]  
        //[Required()]
        [Required(AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 1)]
        public string Title
        {
            //Expression body
            //get { return _title ?? ""; }
            get => _title ?? "";
            set => _title = value?.Trim() ?? "";
        }
        private string _title;

        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            //get { return _description ?? ""; }
            //set { _description = value?.Trim() ?? ""; }
            get => _description ?? "";
            set => _description = value?.Trim() ?? "";

        }
        private string _description;

        /// <summary>Gets or sets the run length in minutes.</summary>
        [Range(0, Int32.MaxValue, ErrorMessage ="Run length must be >= 0")]
        [Display(Name = "run Length")]
        public int RunLength { get; set; }

        /// <summary>Gets or sets the release year.</summary>
        /// <value>Default is 1900.</value>
        [Range(1900, 2100)]
        [Display(Name = "Release Year")]
        public int ReleaseYear { get; set; } = 1900;

        /// <summary>Gets or sets the MPAA rating.</summary>
        [Required(AllowEmptyStrings = false)]
        public string Rating
        {
            get { return _rating ?? ""; }
            set { _rating = value?.Trim() ?? ""; }
        }
        private string _rating;

        /// <summary>Determines if the movie is a classic.</summary>
        public bool IsClassic { get; set; }

        /// <summary>Determines if the movie is black and white.</summary>
        //public bool IsBlackAndWhite () { return _releaseYear < 1939; }
        // public bool IsBlackAndWhite => ReleaseYear < YearColorWasIntroduced;
        //{
        //    //get { return ReleaseYear < YearColorWasIntroduced; }
        //    get => ReleaseYear < YearColorWasIntroduced;
        //}

        //Public fields are allowed when they are constants
        public const int YearColorWasIntroduced = 1939;

        /// <summary>Clones the existing movie.</summary>
        /// <returns>A copy of the movie.</returns>
        public Movie Clone ()
        {
            var movie = new Movie();
            CopyTo(movie);

            return movie;
        }

        /// <summary>Copy the movie to another instance.</summary>
        /// <param name="movie">Movie to copy into.</param>
        public void CopyTo ( Movie movie )
        {
            movie.Id = Id;
            movie.Title = Title;
            movie.Description = Description;
            movie.RunLength = RunLength;
            movie.ReleaseYear = ReleaseYear;
            movie.Rating = Rating;
            movie.IsClassic = IsClassic;
        }

        /// <summary>Validates a movie.</summary>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>true if valid or false otherwise.</returns>

        /// <inheritdoc />
        public override string ToString () => Title;

        [Obsolete("Depreciated in v1. Use NewMethod instead")]
        public void OldMethod ()
        {

        }
        [System.Diagnostics.Conditional("DEBUG")]
        public void Dump ()
        {

        }
        //{
        //    return Title;
        //}

        //public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        //{
        //    var errors = new List<ValidationResult>();
        //    //if (Title.Length == 0)
        //    //    errors.Add(new ValidationResult("Title is required", new[] {nameof(Title)} ));

        //    //if (Rating.Length == 0)
        //    //    errors.Add(new ValidationResult("Rating is required", new[] { nameof(Rating) }));

        //    //if (RunLength <= 0)
        //    //    errors.Add(new ValidationResult("RunLength is required", new[] { nameof(RunLength) }));

        //    //if (ReleaseYear < 1900)
        //    //    errors.Add(new ValidationResult("Release Year must be >= 1900", new[] { nameof(ReleaseYear) }));

        //    return errors;
        //}
      
    }
}