namespace MovieLibary
{    
    /// <summary>Represents a movie.</summary>
    public class Movie
    {
        
        public Movie ()  : this("", "")
        {
                    
        }
        public Movie ( string title) : this(title, "")
        {           
        }

        public Movie ( string title, string description ) : base()
        {
            Title = title;
            Description = description;
        }

        public int Id { get; private set; }
        
        /// <summary>Gets or Sets Title </summary>
        public string Title
        {
            get 
            { 
                return _title ?? "";
            }
            set { _title = value?.Trim() ?? ""; }
        }       
        private string _title;

        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim() ?? ""; }
        }
        private string _description;
        
        public int RunLength { get; set; }

        public int ReleaseYear { get; set; } = 1900;

        public string Rating
        {
            get { return _rating ?? ""; }
            set { _rating = value?.Trim() ?? ""; }
        }
        private string _rating;

        public bool IsClassic { get; set; }

        public bool IsBlackAndWhite
        {
            get { return ReleaseYear < YearColorWasIntroduced; }
        }

        public const int YearColorWasIntroduced = 1939;

        /// <summary>Clones the existing movie.</summary>
        /// <returns>A copy of the movie.</returns>
        
        public bool Validate (out string errorMessage)
        {
            if (Title.Length == 0)
            {
                errorMessage = "Title is Required";
                return false;
            };
            if (Rating.Length == 0)
            {
                errorMessage = "Rating is Required";
                return false;
            };
            if (RunLength <= 0)
            {
                errorMessage = "Run Length must be > 0";
                return false;
            };
            if (ReleaseYear < 1900)
            {
                errorMessage = "Release Year must be >= 1900";
                return false;
            };

            errorMessage = null;
            return true;
        }
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
            movie.Title = Title;
            movie.Description = Description;
            movie.RunLength = RunLength;
            movie.ReleaseYear = ReleaseYear;
            movie.Rating = Rating;
            movie.IsClassic = IsClassic;
        }
        public override string ToString ()
        {
            var str = base.ToString (); 
            return Title;
        }
    }
}