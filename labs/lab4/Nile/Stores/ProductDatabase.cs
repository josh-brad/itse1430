/*
 * ITSE 1430
 */
namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <inheritdoc />
        public Product Add ( Product product )
        {
            //Check arguments
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            //Validate product
            ObjectValidator.Validate(product);
            var existing = FindByName(product.Name);
           
            if (existing != null)
                throw new InvalidOperationException("Movie title must be unique.");

            //Emulate database by storing copy
            return AddCore(product);
        }

        /// <inheritdoc />
        public Product Get ( int id )
        {
            //Check arguments
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            return GetCore(id);
        }

        /// <inheritdoc />
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }

        /// <inheritdoc />
        public void Remove ( int id )
        {
            // Check arguments
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            RemoveCore(id);
        }

        /// <inheritdoc />
        public Product Update ( Product product )
        {
            // Check arguments
            if (product == null)
               throw new ArgumentNullException(nameof(product));

            // Validate product
            ObjectValidator.Validate(product);

            //Get existing product
            //New
            var existingName = FindByName(product.Name);
            var existing = GetCore(product.Id);
            if( existingName != null && product.Id != existingName.Id)
                throw new InvalidOperationException("Product name must be unique.");
          
                return UpdateCore(existing, product);
            

        }

        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );

        //New
        protected abstract Product FindByName ( string Name );
        
        #endregion
    }
}