using RegistrationLogin.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace RegistrationLogin.Service
{
    public class Registration
    {
        public static void Register()
        {
            Console.WriteLine("Registration Page:");
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter User Name:");
                    string userName = Console.ReadLine();

                    

                    string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

                    using (SqlConnection con = new SqlConnection(ConnectionString))
                    {
                        con.Open();

                        string query = @"SELECT Count(*)FROM Users Where userName = @Name;";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {

                            cmd.Parameters.AddWithValue("@Name", userName);
                            int CheckUser = (int)cmd.ExecuteScalar();
                            if (CheckUser > 0)
                            {
                                Console.WriteLine("\n User AlReady Exists");
                                Console.WriteLine("Plase re-nter the userId and Password");
                                continue;

                            }
                        }
                            Console.WriteLine("Enter PassWord:");
                            string userPassword = Hashing.HashPassword(Console.ReadLine()); //HASHING

                            Console.WriteLine("Enter Your Email");
                            string email = Console.ReadLine();
                            string Registrationquery = "INSERT INTO Users(userName , userPassWord ,Email) Values(@userName,@userPassWord ,@email)";
                            using (SqlCommand Insertcmd = new SqlCommand(Registrationquery, con))
                            {
                                Insertcmd.Parameters.AddWithValue("@userName", userName);
                                Insertcmd.Parameters.AddWithValue("@userPassWord", userPassword);
                                Insertcmd.Parameters.AddWithValue("@email", email);

                                Insertcmd.ExecuteNonQuery();
                                con.Close();
                                Console.WriteLine("Resistraction SuccessFully Done..");
                                break;
                            }

                        
                    }
                }


                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Console.WriteLine("Thank you..");
                }

            }

        }
    }
}
