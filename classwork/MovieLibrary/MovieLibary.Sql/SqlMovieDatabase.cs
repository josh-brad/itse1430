using System.Data;
using System.Data.SqlClient;

namespace MovieLibary.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        public SqlMovieDatabase(string connectionstring )
        {
            _connectionString = connectionstring;
        }
        protected override Movie AddCore ( Movie movie )
        {
            //Using statement
            using(var conn = OpenConnection())
            {
                throw new NotImplementedException();
            }
            #region try-finally equivalent 
            //SqlConnection conn = null;
            //try
            //{
            //    conn = OpenConnection();

            //    throw new NotImplementedException();
            //} finally 
            //{ 
            //    conn?.Close();
            //    conn?.Dispose();  
            //}
            #endregion
        }
        protected override Movie FindByTitle ( string title )
        {

            using (var conn = OpenConnection())
            {
                throw new NotImplementedException();
            }
        }
        protected override IEnumerable<Movie> GetAllCore ()
        {
            var ds = new DataSet();

            using (var conn = OpenConnection())
            {
                //Create command 1
                var cmd = new SqlCommand("GetMovies", conn);

                //Need data adapter for Dataset
                var da = new SqlDataAdapter(cmd);

                //Buffered IO              
                da.Fill(ds);

            }
            //Data loaded, can work with it now
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table == null)
            {
                foreach(DataRow row in table.Rows.OfType<DataRow>())
                {
                    yield return new Movie() {
                        Id = (int)row[0],                   
                        Title = row["Name"] as string,
                        Description = row.IsNull(2) ? "": row.Field<string>(2),
                        Rating = row.Field<string>("Rating"),
                        RunLength = row.Field<int>("RunLength"),
                        ReleaseYear = row.Field<int>("ReleaseYear"),
                        IsClassic = row.Field<bool>("IsClassic"),

                    };
                };
            };
        }
        protected override Movie GetCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                throw new NotImplementedException();
            }
        }
        protected override void RemoveCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                throw new NotImplementedException();
            }
        }
        protected override void UpdateCore ( int id, Movie movie )
        {
            using (var conn = OpenConnection())
            {
                throw new NotImplementedException();
            }
        }

        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection (_connectionString);
            conn.Open ();

            return conn;
        }
        private readonly string _connectionString;
    }
}