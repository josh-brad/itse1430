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

        public Contact SelectedContact { get; set; }
    }
}
