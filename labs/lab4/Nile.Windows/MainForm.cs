/*
 * ITSE 1430
 */
namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            _gridProducts.AutoGenerateColumns = false;

            var connString = Program.GetConnectionString("ProductDatabase");
            UpdateList();
        }

        #region Event Handlers
        
        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductAdd( object sender, EventArgs e )
        {
            var child = new ProductDetailForm("Product Details");
            //new
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                //TODO: Handle errors
                try
                {
                    //Save product
                    _database.Add(child.Product);
                    UpdateList();
                    return;
                } catch (Exception ex)
                {
                    DisplayError(ex.Message, "Add Failed");
                }
            } while (true);
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show("No products available.");
                return;
            };

            EditProduct(product);
        }        

        private void OnProductDelete( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
                return;

            DeleteProduct(product);
        }        
                
        private void OnEditRow( object sender, DataGridViewCellEventArgs e )
        {
            var grid = sender as DataGridView;

            //Handle column clicks
            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Product;

            if (item != null)
                EditProduct(item);
        }

        private void OnKeyDownGrid( object sender, KeyEventArgs e )
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var product = GetSelectedProduct();
            if (product != null)
                DeleteProduct(product);
			
			//Don't continue with key
            e.SuppressKeyPress = true;
        }
        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutForm();

            about.ShowDialog();

        }

        #endregion

        #region Private Members
        //New
        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DeleteProduct ( Product product )
        {
            //Confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?",
                                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //TODO: Handle errors
            
            try
            {
                //Delete product
                _database.Remove(product.Id);
            }catch(Exception ex)
            {
                DisplayError(ex.Message, "Delete Failed");
            }
            UpdateList();
        }

        private void EditProduct ( Product product )
        {
            var child = new ProductDetailForm("Product Details");
            child.Product = product;
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;
                //TODO: Handle errors
                try
                {
                    //Save product
                    _database.Update(child.Product);
                    UpdateList();
                } catch (Exception ex)
                {
                    DisplayError(ex.Message, "Update Failed");
                }
            } while (true);

            
            
        }

        private Product GetSelectedProduct ()
        {
            if (_gridProducts.SelectedRows.Count > 0)
                return _gridProducts.SelectedRows[0].DataBoundItem as Product;

            return null;
        }

        private void UpdateList ()
        {
            //TODO: Handle errors

            _bsProducts.DataSource = _database.GetAll();
        }

        private readonly IProductDatabase _database = new SqlProductDatabase(Program.GetConnectionString("AppDatabase"));
        #endregion


    }
}
