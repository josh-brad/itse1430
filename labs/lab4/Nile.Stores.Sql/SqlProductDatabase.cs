using System.Data;
using System.Data.SqlClient;


namespace Nile.Stores.Sql
{
    public class SqlProductDatabase : ProductDatabase
    {
        public SqlProductDatabase( string connectionstring )
        {
            _connectionString = connectionstring;
        }

        protected override Product AddCore ( Product product )
        {
            //Using statement
            using (var conn = OpenConnection())
            {
                //Command op 2 - long way
                var cmd = new SqlCommand();
                cmd.CommandText = "AddProduct";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                //Add para best way
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

                //Execute command
                object result = cmd.ExecuteScalar();
                //movie.Id = (int)result;
                product.Id = Convert.ToInt32(result);
                return product;

            }
        }

        protected override void RemoveCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                //Create command option 3 - generic
                var cmd = conn.CreateCommand();
                cmd.CommandText = "RemoveProduct";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

            }
        }

        protected override IEnumerable<Product> GetAllCore ()
        {
            var ds = new DataSet();

            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetAllProducts", conn);
                var da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            //Data loaded, can work with it now
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                foreach (DataRow row in table.Rows.OfType<DataRow>())
                {
                    yield return new Product() {
                        Name = row.Field<string>("Name"),
                        Description = row.Field<string>("Description"),
                        Id = row.Field<int>("Id"),
                        Price = row.Field<decimal>("Price"),
                        IsDiscontinued = row.Field<bool>("IsDiscontinued"),

                    };
                };
            };

        }

        protected override Product GetCore ( int id )
        {


            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Product() {
                            Id = (int)reader[0],
                            Description = reader.GetString("Description"),
                            Name = reader.GetString("Name"),
                            Price = reader.GetFieldValue<decimal>("Price"),
                            IsDiscontinued = reader.GetFieldValue<bool>("IsDiscontinued"),
                        };
                    };
                };
            }
            return null;
        }

        protected override Product UpdateCore ( Product existing, Product product )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "UpdateProduct";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", existing.Id);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);
                cmd.ExecuteNonQuery();

                return existing;
            }
        }

        protected override Product FindByName ( string name )
        {

            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("FindByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);

                //Read with streamed IO
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Product() {
                            Id = (int)reader[0],
                            Description = reader.GetString("Description"),
                            Name = reader.GetString("Name"),
                            Price = reader.GetFieldValue<decimal>("Price"),
                            IsDiscontinued = reader.GetFieldValue<bool>("IsDiscontinued"),
                        };
                    };
                };
            }
            return null;
        }





        #region Private Members
        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }
        private readonly string _connectionString;
        # endregion

    }
}