using RegistrationLogin.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationLogin
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ServicePointManager.SecurityProtocol =
            SecurityProtocolType.Tls12;

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.UseNagleAlgorithm = false;



            while (true)
            {
                Console.WriteLine("Enter Your Choice: ");
                Console.WriteLine("\t1.Registration");
                Console.WriteLine("\t2.Login");
                Console.WriteLine("\t3 UpdatePassWord");
                Console.WriteLine("\t4.Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                
                
                switch (choice)
                {
                    case 1:
                        Registration.Register();
                        break;
                    case 2:
                        Login.UserLogin();
                        break;
                    case 3:
                        await ForgetPassWord.PasswordResetOfUser();
                        break;
                    case 4:
                        Console.WriteLine("Thank You For Using Our Application..");
                        return;
                    default:
                        Console.WriteLine("Invalide Choice..");
                        break;
                }
                Console.ReadKey();
            }  
        }
    }
}
