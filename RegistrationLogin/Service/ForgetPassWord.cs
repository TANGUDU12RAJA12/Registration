using RegistrationLogin.OTP_handling;
using RegistrationLogin.EmailService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrationLogin.Security;

namespace RegistrationLogin.Service
{
    public class ForgetPassWord
    {
        public static async Task PasswordResetOfUser()
        {
            // Console.WriteLine("Enter the UserName:\n");
            // string userName = Console.ReadLine();

            //// string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

            // string email = UserEmailService.GetEmail(userName);
            // if(email == null)
            // {
            //     Console.WriteLine("UserName not found");
            //     return;
            // }

            Console.WriteLine("Enter the UserName:\n");
            string userName = Console.ReadLine();

            string email = UserEmailService.GetEmail(userName);
            if (email == null)
            {
                Console.WriteLine("UserName not found");
                return;
            }


            ////string otp =  OTP_handler.GenerateOTP();

            //// OTP_handler.SaveOtp(userName ,otp);

            //// OTP_handler.sendOTPEmail(email, otp);
            //// Console.WriteLine("OTP has been sent to your registered email address.\n");

            //// Console.WriteLine("Enter the OTP sent to your email:\n");
            //// string enteredOtp = Console.ReadLine();



            // if(!OTP_handler.ValideOTP( userName, enteredOtp))
            // {
            //     Console.WriteLine("Invalid OTP. Password reset failed.\n");
            //     return;
            // }

            bool sent = await OTPApiService.GenerateOTP(email);
            if (!sent)
            {
                Console.WriteLine("Failed to send OTP");
                return;
            }
            Console.WriteLine("OTP has been sent to your registered email.\n");

            Console.WriteLine("Enter the OTP:\n");
            string enteredOtp = Console.ReadLine();


            bool isValid = await OTPApiService.ValidateOTP(email, enteredOtp);

            if (!isValid)
            {
                Console.WriteLine("Invalid OTP. Password reset failed.\n");
                return;
            }

            // Console.WriteLine("Enter a New Password:") ;
            // string newPassword =Hashing.HashPassword( Console.ReadLine());
            // Update.UpdatePassword(userName, newPassword);
            // OTP_handler.MarkOtpUsed(userName, otp);
            // Console.WriteLine("Password Reset Successfully");

            Console.WriteLine("Enter New Password:");
            string newPassword = Hashing.HashPassword(Console.ReadLine());

            Update.UpdatePassword(userName, newPassword);

            Console.WriteLine("Password Reset Successfully ✅");

        }
    }
}
