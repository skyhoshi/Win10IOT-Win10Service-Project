//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.ServiceProcess;
//using System.Text;
//using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Install;
using System.Reflection;
using System.ServiceProcess;
using System.Text;

namespace Remote_Computer_Control_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            //ServiceBase.Run(ServicesToRun);
            var Service1 = new Service1();
            Service1.ServiceName = ServiceDetails.GetConfigurationValue(key: "ServiceName");


            //This allows you to (un)install the application by prompt with Arguments via the commandline.
            //Enviroment.UserInteractive is the test of Head(ed/less) mode. (in other words Service [Headless] or not a service [Headed]) 
            if (Environment.UserInteractive)
            {
                string parameter = string.Concat(args);
                switch (parameter)
                {
                    case "--install":
                        ManagedInstallerClass.InstallHelper(new[] { Assembly.GetExecutingAssembly().Location });
                        break;
                    case "--uninstall":
                        ManagedInstallerClass.InstallHelper(new[] { "/u", Assembly.GetExecutingAssembly().Location });
                        break;
                }
                //Here is where you would perform your debug methods and calls out to services componets. 
                //This eliminates the need for console class completely and the need to change the startup class.
                //This Method only works in debug mode on your local machine. and is for testing purposes ONLY.
#if DEBUG
                Service1.Start();
#elif RELEASE //This Mode is intended only to (un)install the application
                //In Production we do not want the application running in this mode.
                ServiceEventManager.RecordEvent("Relase - Developer Crimecast Service: Application Run.", System.Diagnostics.EventLogEntryType.Information);
                ServicesToRun = new ServiceBase[] { Service1 };
                ServiceBase.Run(ServicesToRun);
#endif
            }
            else
            {
#if DEBUG
                /////This must be here for the Staging portion of the application to work correctly. 
                /////When preparing the staging application Uncomment this portion or the service will not start. 
                //Settings.RecordEvent("Debug - Developer Crimecast Service: Application Run.", System.Diagnostics.EventLogEntryType.Information);
                //ServicesToRun = new ServiceBase[] {Service1};
                //ServiceBase.Run(ServicesToRun);
#elif RELEASE // More than one user Service may run within the same process. To add
                // another service to this process, change the following line to
                // create a second service object. For example,
                //
                //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
                //
                ServiceEventManager.RecordEvent("Release - Developer Crimecast Service: Application Run.", System.Diagnostics.EventLogEntryType.Information);
                ServicesToRun = new ServiceBase[] { new Service1(),  };
                ServiceBase.Run(ServicesToRun);
#endif
            }
        }


    }
}

