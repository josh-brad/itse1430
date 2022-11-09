using ContactCreator;
using Microsoft.VisualBasic.Devices;

namespace JoshuaBradshaw.ContactManager.UI
{
    public partial class MainForm : Form
            
    {
        public MainForm ()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing ( FormClosingEventArgs e )
        {
            base.OnFormClosing(e);

            if (Confirm("Are you sure you want to leave?", "Close"))
                return;

            e.Cancel = true;
        }

        protected override void OnFormClosed ( FormClosedEventArgs e )
        {
            base.OnFormClosed(e);
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            UpdateUI();
        }

        #region Event Handlers

        private void OnContactAdd ( object sender, EventArgs e )
        {
            var child = new ContactForm();

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                if (_contacts.Add(child.SelectedContact, out var error) != null)
                {
                    UpdateUI();
                    return;
                };

                DisplayError(error, "Add Failed");
            } while (true);
        }

        private void OnContactDelete ( object sender, EventArgs e )
        {
            var contact = GetSelectedContact();
            if (contact == null)
                return;

            if (!Confirm($"Are you sure you want to delete '{contact.LastName}'?", "Delete"))
                return;

            _contacts.Remove(contact.Id);
            UpdateUI();
        }

        private void OnContactEdit ( object sender, EventArgs e )
        {
            var contact = GetSelectedContact();
            if (contact == null)
                return;

            var child = new ContactForm();
            child.SelectedContact = contact;

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                if (_contacts.Update(contact.Id, child.SelectedContact, out var error))
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
            var movies = _contacts.GetAll();
            _listContacts.Items.Clear();
            var items = movies.OrderBy(x => x.LastName)
                              .ThenBy(x => x.FirstName)
                              .ToArray();

            _listContacts.Items.AddRange(items);
        }

        private Contact GetSelectedContact ()
        {
            return _listContacts.SelectedItem as Contact;
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

        private ContactDatabase _contacts = new ContactDatabase();
        #endregion

    }

}
