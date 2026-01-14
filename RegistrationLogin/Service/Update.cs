using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
  
namespace RegistrationLogin.Service
{
    public class Update
    {
        public static void UpdatePassword(string userName , string password)
        {
            string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Users SET userPassWord = @password WHERE userName = @userName", con))
                {
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
    }
}
