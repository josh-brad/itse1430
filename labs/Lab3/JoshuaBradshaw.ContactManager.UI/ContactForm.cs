using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ContactCreator;

using Microsoft.VisualBasic.Devices;

namespace JoshuaBradshaw.ContactManager.UI
{
    public partial class ContactForm : Form
    {
        public ContactForm ()
        {
            InitializeComponent();
        }


        public Contact SelectedMovie { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (SelectedMovie != null)
            {
                _textFirstName.Text = SelectedMovie.FirstName;
                _textLastName.Text = SelectedMovie.LastName;
                _textEmail.Text = SelectedMovie.Email;
                _checkIsFavorite.Checked = SelectedMovie.IsFavorite;
                _textNotes.Text = SelectedMovie.Notes;
            };
            if (!ValidateChildren())
                return;
        }

        private void OnSave ( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            var btn = sender as Button;

            var contact = new Contact();
            contact.LastName = _textLastName.Text;
            contact.FirstName = _textFirstName.Text;
            contact.Email = _textEmail.Text;
            contact.Notes = _textNotes.Text;
            contact.IsFavorite = _checkIsFavorite.Checked;

            //if (!new ObjectValidator().IsValid(contact, out var error))
            //{
            //    DisplayError(error, "Save");
            //    return;
            //};

            SelectedMovie = contact;
            DialogResult = DialogResult.OK;
            Close();
        }

        private int GetInt32 ( TextBox control )
        {
            if (Int32.TryParse(control.Text, out int value))
                return value;
            return -1;
        }
        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnValidateTitle ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Title is Required");
                e.Cancel = true;
            } else
            {
                _errors.SetError(control, "");
            }
        }
        private void OnValidateRating ( object sender, CancelEventArgs e )
        {
            var control = sender as ComboBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Rating is Required");
                e.Cancel = true;
            } else
            {
                _errors.SetError(control, "");
            }
        }

        private void OnValidateReleaseYear ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            var value = GetInt32(control);
            if (value < 1900)
            {
                _errors.SetError(control, "Release Year must be at least 1900");
                e.Cancel = true;
            } else
            {
                _errors.SetError(control, "");
            }
        }

        private void OnValidateRunLength ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            var value = GetInt32(control);

            if (value < 0)
            {
                _errors.SetError(control, "Run Length must be >= 0");
                e.Cancel = true;
            } else
            {
                _errors.SetError(control, "");
            }
        }
    }
}

