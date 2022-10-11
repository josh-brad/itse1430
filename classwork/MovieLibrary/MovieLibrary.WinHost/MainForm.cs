namespace MovieLibrary.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var child = new MovieForm();
            if (child.ShowDialog() != DialogResult.OK)
                return;
            //todo save this off
            var movie = child.SelectedMovie;
            //Showing Form Modally
            //child.Show();
        }

        private bool Confirm (string message, string title )
        {
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;              
        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(message, title , MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void deleteToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            if (!Confirm("Are you sure you want to delete the movie?", "Delete"))
                return;

            DisplayError("Not Implmented", "Delete");
        }
    }
}