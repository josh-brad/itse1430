using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
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


        public Contact SelectedContact { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (SelectedContact != null)
            {
                _textFirstName.Text = SelectedContact.FirstName;
                _textLastName.Text = SelectedContact.LastName;
                _textEmail.Text = SelectedContact.Email;
                _checkIsFavorite.Checked = SelectedContact.IsFavorite;
                _textNotes.Text = SelectedContact.Notes;
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

            if (!ObjectValidator.IsValid(contact, out var error))
            {
                DisplayError(error, "Save");
                return;
            };

            SelectedContact = contact;
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

        private void OnValidateLastName ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Last Name is required");
                e.Cancel = true;
            } else
            {
                _errors.SetError(control, "");
            }
        }

        private void OnValidateEmail ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (!IsValidEmail(control.Text))
            {
                _errors.SetError(control, "Not a vaild email");
                e.Cancel = true;
            } else
            {
                _errors.SetError(control, "");
            }
        }

        bool IsValidEmail ( string source )
        {
            return MailAddress.TryCreate(source, out var address);
        }
    }
}

