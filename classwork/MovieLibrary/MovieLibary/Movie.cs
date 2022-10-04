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
            //Init that field initializers cannot do
            
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
            // string get_Title ()
            get 
            { 
                //return String.IsNullOrEmpty(_title) ? "" : _title;
                return _title ?? "";
            }

            // void set_Title ( string value )
            //set { _title = String.IsNullOrEmpty(value) ? "" : value.Trim(); } 
            set { _title = value?.Trim() ?? ""; }
        }       
        private string _title;

        //public string GetTitle ()
        //{
        //    return _title;
        //}

        //public void SetTitle ( string title )
        //{
        //    //this._title = title;
        //    _title = title;
        //}
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim() ?? ""; }
        }
        private string _description;
        
        //public int RunLength
        //{
        //    get { return _runLength; }
        //    set { _runLength = value; }
        //}
        //private int _runLength = 0;

        public int RunLength { get; set; }

        //public int ReleaseYear
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}
        //private int _releaseYear = 1900;
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
            //set { }
        }

        public const int YearColorWasIntroduced = 1939;
       
        //public readonly Movie Empty = new Movie();
        //private Movie EmptyMovie { get; } = new Movie();
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
        public void CopyTo ( /* Movie this */ Movie movie )
        {
            //var areEqual = title == this.title;

            movie.Title = Title;
            movie.Description = Description; //this.description
            movie.RunLength = RunLength;
            movie.ReleaseYear = ReleaseYear;
            movie.Rating = Rating;
            movie.IsClassic = IsClassic;
        }
        public override string ToString ()
        {
            var str = base.ToString ();   // calls base ypt
            return Title;
        }
    }
}