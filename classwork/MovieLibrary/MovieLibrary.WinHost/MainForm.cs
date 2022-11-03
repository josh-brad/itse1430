using MovieLibary;

namespace MovieLibrary.WinHost
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm ()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnFormClosing ( FormClosingEventArgs e )
        {
            base.OnFormClosing(e);

            if (Confirm("Are you sure you want to leave?", "Close"))
                return;

            //Stop the event
            e.Cancel = true;
        }

        protected override void OnFormClosed ( FormClosedEventArgs e )
        {
            base.OnFormClosed(e);
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            UpdateUI(true);
        }

        #region Event Handlers

        //Called to handle Movies\Add
        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var child = new MovieForm();

            do
            {
                //Showing form modally
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                if (_movies.Add(child.SelectedMovie, out var error) != null)
                {
                    UpdateUI();
                    return;
                };

                DisplayError(error, "Add Failed");
            } while (true);
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            if (!Confirm($"Are you sure you want to delete '{movie.Title}'?", "Delete"))
                return;

            _movies.Remove(movie.Id);
            UpdateUI();
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var child = new MovieForm();
            child.SelectedMovie = movie;

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                if (_movies.Update(movie.Id, child.SelectedMovie, out var error))
                {
                    UpdateUI();
                    return;
                };

                DisplayError(error, "Update Failed");
            } while (true);
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutForm();

            about.ShowDialog();
        }
        #endregion

        #region Private Members
        private void UpdateUI ()
        {
            UpdateUI(false);
        }
        private void UpdateUI (bool intialLoad)
        {
            //Enumerable.Count(movies) == movies.Count()
            var movies = _movies.GetAll();           
            if(intialLoad && 
                //movies.Count() == 0)
                //movies.FirstOrDefault() == null)
                movies.Any())
            {
                if (Confirm("Do you want to seed some movies?", "Database Empty"))
                {
                    _movies.Seed();
                    movies = _movies.GetAll();
                }
            };
            _listMovies.Items.Clear();
            var items = movies.OrderBy(OrderByTitle)
                              .ThenBy(OrderByReleaseYear)
                              .ToArray();
            //movies = movies.ThenBy();
            _listMovies.Items.AddRange(items);
            
        }

        private int OrderByReleaseYear(Movie movie )
        {
            return movie.ReleaseYear;
        }
        private string OrderByTitle(Movie movie)
        {
            return movie.Title;
        }

        private Movie GetSelectedMovie ()
        {
            //var allTextBoxes = Controls.OfType<TextBox>();
            //IEnumerable<Movie> temp = _listMovies.SelectedItems.OfType<Movie>();
            return _listMovies.SelectedItem as Movie;
        }

        private bool Confirm ( string message, string title )
        {
            DialogResult result = MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private IMovieDatabase _movies = new MovieLibary.Memory.MemoryMovieDatabase();
        #endregion        
    }
}