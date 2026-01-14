using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationLogin.EmailService
{
    public class UserEmailService
    {
        static string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
      
        
        
        public static string GetEmail(string username)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                string query = "SELECT Email FROM Users WHERE Username=@u";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@u", username);

                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }

        
    }
}
