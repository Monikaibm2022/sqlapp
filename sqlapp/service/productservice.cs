using sqlapp.Model;
using System.Data.SqlClient;

namespace sqlapp.service
{
    public class productservice
    {
        private static string db_source = "sqlserver1210.database.windows.net";
        private static string db_databasename = "mysqldatabase";
        private static string db_adminuser = "monika";
        private static string db_adminpassword = "Welcome@123";

        private  SqlConnection getconnection()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = db_source;
            builder.InitialCatalog = db_databasename;
            builder.UserID = db_adminuser;
            builder.Password = db_adminpassword;
            return new SqlConnection(builder.ConnectionString);

        }
        public List<product> product()
        { 
            SqlConnection con= getconnection();
            List<product> product_lst = new List<product>();
           string statement = "select ProductID,ProductName,Quantity from Products";
            con.Open();
            SqlCommand cmd=new SqlCommand(statement, con);
            using (SqlDataReader reader =cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    product product = new product()
                    {
                        productid = reader.GetInt32(0),
                        productname = reader.GetString(1),
                        quentity = reader.GetInt32(2)
                    };
                    product_lst.Add(product);

                }
            }
            con.Close();
            return product_lst;
             
        }
    }
}
