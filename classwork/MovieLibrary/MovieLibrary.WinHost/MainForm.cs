using MovieLibary;

namespace MovieLibrary.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var child = new MovieForm();
            if (child.ShowDialog() != DialogResult.OK)
                return;
            //todo save this off
            _movie = child.SelectedMovie;
            //Showing Form Modally
            //child.Show();
            UpDateUi();
        }
        private Movie _movie;

        private bool Confirm ( string message, string title )
        {
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            if (!Confirm($"Are you sure you want to delete '{movie.Title}'?", "Delete"))
                return;

            _movie = null;
            UpDateUi();
        }

        protected override void OnFormClosing( FormClosingEventArgs e )
        {
            base.OnFormClosing(e);

            if (Confirm("Are you sure you want to leave?", "Close"))
                return;

            //Stop the event
            e.Cancel = true;
        }
        protected override void OnFormClosed ( FormClosedEventArgs e )
        {
            base.OnFormClosed ( e );
        }

        private void UpDateUi ()
        {
           _listMovies.Items.Clear();
            if (_movie != null)
            {
                _listMovies.Items.Add(_movie);
            }
        }
        private Movie GetSelectedMovie ()
        {
            return _movie;
        }

        private void _miMovieEdit_Click ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;
            var child = new MovieForm();
            child.SelectedMovie = movie;
            
            if (child.ShowDialog() != DialogResult.OK)
                return;

            _movie = child.SelectedMovie;

            UpDateUi();
        }
    }
}