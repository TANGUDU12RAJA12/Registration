using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace RegistrationLogin.OTP_handling
{
    public  class OTP_handler
    {
        static string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        
            public static string GenerateOTP()  //OTP Generation
        {
                Random rnd = new Random();
                return rnd.Next(100000, 999999).ToString();
            }
        
        public static void SaveOtp(string username, string otp) //Save OTP to DataBase
        {
            
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string query = "INSERT INTO PasswordResetOTP (UserName , OTP ,CreatedAt , IsUsed ) VALUES(@username , @otp ,@CreatedAt,@IsUsed)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@otp", otp);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@IsUsed", 0);

                cmd.ExecuteNonQuery();
            }
        }

        public static bool ValideOTP(string username , string otp) //Validate OTP from DataBase
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string query = @"SELECT COUNT(*) FROM PasswordResetOTP
                  WHERE Username=@username AND OTP=@otp AND IsUsed=0";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@otp", otp);
                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }


        public static void MarkOtpUsed(string username, string otp) //Mark OTP as used in DataBase
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                string query =
                "UPDATE PasswordResetOTP SET IsUsed=1 WHERE Username=@u AND OTP=@o";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@o", otp);

                cmd.ExecuteNonQuery();
            }
        }


     
public static void sendOTPEmail(string toEmail, string otp)
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("tanguduraja143@gmail.com");
            mail.To.Add(toEmail);
            mail.Subject = "Password Reset OTP";
            mail.Body = "Your OTP is: " + otp;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(
                "tanguduraja143@gmail.com",
                "wkhzxoayueoumopx"
            );
            smtp.EnableSsl = true;

            smtp.Send(mail);
            Console.WriteLine("OTP sent successfully ");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to send email ");
            Console.WriteLine(ex.Message);
        }
    }

}
}
