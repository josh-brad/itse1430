namespace JoshuaBradshaw.ContactManager.UI
{
    public partial class Form1 : Form
    {
        public Form1 ()
        {
            InitializeComponent();
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

    }
}