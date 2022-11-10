namespace MovieLibary
{
    public interface IMovieDatabase
    {
        Movie Add ( Movie movie );
        Movie Get ( int id );
        IEnumerable<Movie> GetAll ();
        void Remove ( int id );
        void Update ( int id, Movie movie);
    }
}