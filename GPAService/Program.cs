using GpaCalculatorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
/*
 * Project: Final Practical WPF
 * Purpose: Demonstrate learning and understanding of WPF
 * Coder: Sonia Friesen, 0813682        
 * Date: April 19th 2021
 */
namespace GpaCalculatorService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost servHost = null;
            try
            {
                // Register the service address
                // servHost = new ServiceHost(typeof(Game), new Uri("net.tcp://localhost:13200/GomokuLibaray/")); 
                // Register the service contract and binding
                //servHost.AddServiceEndpoint(typeof(IGame), new NetTcpBinding(), "GameService");

                //other servHost are now implemented in app.config
                servHost = new ServiceHost(typeof(Gpa));

                // Run the service
                servHost.Open();
                Console.WriteLine("Service started. Please any key to quit.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
                if (servHost != null)
                    servHost.Close();
            }
        }
    }
}
