using Microsoft.Data.SqlClient;
string connectionString = "Data Source=.;Initial Catalog=TaskModels;Trusted_Connection=true; encrypt option";

using (SqlConnection connection = new SqlConnection(connectionString)) ;

    