using RegistrationLogin.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationLogin.Service
{
    public class Login
    {
        public static void UserLogin() 
        { 
            Console.WriteLine("\nLogin Page");
            try
            {
                Console.WriteLine("Enter user Name:");
                string Name = Console.ReadLine();
                
                string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    string query = @"SELECT Count(*)FROM Users Where userName = @Name;";
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        
                        cmd.Parameters.AddWithValue("@Name", Name);
                        int CheckUser = (int)cmd.ExecuteScalar();
                        if (CheckUser == 0)
                        {
                            Console.WriteLine("\n Invalide User");
                            Console.WriteLine("Register First:");

                            con.Close();
                            Registration.Register();
                            return;
                        }

                       
                        Console.WriteLine("Enter user Password");
                        string PassWord = Hashing.HashPassword( Console.ReadLine());

                        Console.WriteLine("Enter Your Email");
                        string email = Console.ReadLine();

                        string LoginQuery = "SELECT Count(*)FROM Users Where userName = @userName AND userPassWord = @PassWord AND Email= @email;";
                        SqlCommand cmd1 = new SqlCommand(LoginQuery, con);
                        cmd1.Parameters.AddWithValue("@userName", Name);
                        cmd1.Parameters.AddWithValue("@PassWord", PassWord);
                        cmd1.Parameters.AddWithValue("@email", email);
                        int count = (int)cmd1.ExecuteScalar();
                        if (count > 0)
                        {
                            Console.WriteLine("\nLogin SuccessFully Done...");
                        }
                        else
                        {
                            Console.WriteLine("Invalide UserNmae And PassWord..");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {   
                Console.WriteLine("Thank You...");
            }
            
        }
        
    }
}
