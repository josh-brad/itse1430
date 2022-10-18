using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieLibary;

namespace MovieLibrary.WinHost
{
    public partial class MovieForm : Form
    {
        public MovieForm ()
        {
            InitializeComponent();
        }
        
        public Movie SelectedMovie { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            //DO Any init before ui is rendered
            if( SelectedMovie != null)
            {
                //Load UI
                _txtTitle.Text = SelectedMovie.Title;
                _txtDescription.Text = SelectedMovie.Description;
                _cbRating.Text = SelectedMovie.Rating;

                _chkIsClassic.Checked = SelectedMovie.IsClassic;
                _txtRunLength.Text = SelectedMovie.RunLength.ToString();
                _txtReleaseYear.Text = SelectedMovie.ReleaseYear.ToString();
            };
        }

        private void OnSave ( object sender, EventArgs e )
        {
            //TDOt add validation
            var movie = new Movie();
            movie.Title = _txtTitle.Text;
            movie.Description = _txtDescription.Text;
            movie.Rating = _cbRating.Text;

            movie.IsClassic = _chkIsClassic.Checked;
            movie.ReleaseYear = GetInt32(_txtReleaseYear);
            movie.RunLength = GetInt32(_txtRunLength);

            if (!movie.Validate(out var error))
            {
                DisplayError(error, "Save");
                return;
            };

            //Get Rid of form bt setting form's dialog Rasult to a reasonable vlaue call close
            SelectedMovie = movie;
            DialogResult = DialogResult.OK;
            Close();
        }

        private int GetInt32 (TextBox control )
        {
            if (Int32.TryParse(control.Text, out int value))
                return value;
            return -1;
        }
        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
