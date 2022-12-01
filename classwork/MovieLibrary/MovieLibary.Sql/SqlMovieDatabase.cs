using System.Data;
using System.Data.SqlClient;

namespace MovieLibary.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        public SqlMovieDatabase ( string connectionstring )
        {
            _connectionString = connectionstring;
        }
        protected override Movie AddCore ( Movie movie )
        {
            //Using statement
            using (var conn = OpenConnection())
            {
                //Command op 2 - long way
                var cmd = new SqlCommand();
                cmd.CommandText = "AddMovie";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                //Add para best way
                cmd.Parameters.AddWithValue("@name", movie.Title);

                //Add para long way
                var paramRating = new SqlParameter("@rating", movie.Rating);
                cmd.Parameters.Add(paramRating);

                //Add parameters option 3 generic
                var paramDescription = cmd.CreateParameter();
                paramDescription.ParameterName = "@description";
                paramDescription.Value = movie.Description;
                paramDescription.DbType = DbType.String;
                cmd.Parameters.Add(paramDescription);

                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                //Execute command
                object result = cmd.ExecuteScalar();
                //movie.Id = (int)result;
                movie.Id = Convert.ToInt32(result);
                return movie;

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
                var cmd = new SqlCommand("FindByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", title);

                //Read with streamed IO
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Movie() {
                            Id = (int)reader[0],
                            Title = reader["Name"] as string,
                            Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            Rating = reader.GetString("Rating"),
                            RunLength = reader.GetInt32("RunLength"),
                            ReleaseYear = reader.GetFieldValue<int>("ReleaseYear"),
                            IsClassic = reader.GetFieldValue<bool>("IsClassic"),
                        };
                    };
                };
            }
            return null;
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
                foreach (DataRow row in table.Rows.OfType<DataRow>())
                {
                    yield return new Movie() {
                        Id = (int)row[0],
                        Title = row["Name"] as string,
                        Description = row.IsNull(2) ? "" : row.Field<string>(2),
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
                var cmd = new SqlCommand("GetMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                //Read with streamed IO
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Movie() {
                            Id = (int)reader[0],
                            Title = reader["Name"] as string,
                            Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            Rating = reader.GetString("Rating"),
                            RunLength = reader.GetInt32("RunLength"),
                            ReleaseYear = reader.GetFieldValue<int>("ReleaseYear"),
                            IsClassic = reader.GetFieldValue<bool>("IsClassic"),
                        };
                    };
                };
            }
            return null;
        }
    
        protected override void RemoveCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                //Create command option 3 - generic
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DeleteMovie";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

            }
        }
        protected override void UpdateCore ( int id, Movie movie )
        {
            using (var conn = OpenConnection())
            {
                //Command op 2 - long way
                var cmd = new SqlCommand();
                cmd.CommandText = "UpdateMovie";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                //Add para best way
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", movie.Title);
                cmd.Parameters.AddWithValue("@rating", movie.Rating);
                cmd.Parameters.AddWithValue("@description", movie.Description);


                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                cmd.ExecuteNonQuery();

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