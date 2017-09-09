using System;
using System.Configuration;
using System.Reflection;
using System.Security;

namespace Remote_Computer_Control_System
{
    public class ServiceDetails
    {
        public static string GetConfigurationValue(string key)
        {
            /*This could cause a problem. if I move the Service Type into another Assembly this would be incorrect or bomb if no additional app.config settings file was available.
              in other words if the config file doesn't contain the appropreate keys, this will throw an error, you could add additional reference checks to see if any other
              referenced dlls contain a config file in the directory.
              Another method is to have certian types of key's stored in certain locations, Passwords and such in asecure location and other settings (user|Application) 
              stored in the Registry or user path. 
              This sets you up to do just that.
              Check out the http://keepass.info source, and consider including it in your applicaitons to store password or encoded information. 
            */
            Assembly service = Assembly.GetAssembly(typeof(Service1));
            Configuration config = ConfigurationManager.OpenExeConfiguration(service.Location);
            if (config.AppSettings.Settings[key] != null)
            {
                return config.AppSettings.Settings[key].Value;
            }
            else
            {
                throw new IndexOutOfRangeException
                    ("Settings collection does not contain the requested key: " + key);
            }
        }

        protected static System.Security.SecureString GetServiceUserPassword()
        {
            // Instantiate the secure string.
            SecureString securePwd = new SecureString();

            //Get Value from App.Config

            //ConsoleKeyInfo key;

            //Console.Write("Enter password: ");
            //do
            //{
            //    key = Console.ReadKey(true);

            //    // Ignore any key out of range.
            //    if (((int)key.Key) >= 65 && ((int)key.Key <= 90))
            //    {
            //        // Append the character to the password.
            //        securePwd.AppendChar(key.KeyChar);
            //        Console.Write("*");
            //    }
            //    // Exit if Enter key is pressed.
            //} while (key.Key != ConsoleKey.Enter);
            //Console.WriteLine();

            //try
            //{
            //    Process.Start("Notepad.exe", "MyUser", securePwd, "MYDOMAIN");
            //}
            //catch (Win32Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    securePwd.Dispose();
            //}
            return securePwd;
        }
    }
}

