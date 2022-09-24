namespace MovieLibary
{
    /// <summary>
    /// Represents a movie.
    /// </summary>
    public class Movie
    {
        public string _title = "";
        public string _description = "";
        public int _runLength = 0; //in minutes
        public int _releaseYear = 1900;
        public string _rating = "";
        public bool _isClassic = false;
    }
}