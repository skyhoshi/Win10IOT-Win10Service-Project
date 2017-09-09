using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using NAudio.Gui;
using NAudio.Mixer;

namespace Remote_Computer_Control_System
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        public void Start()
        {
#if DEBUG
            Console.WriteLine("Hi this is my service in debug mode");
            Mixer  MyMixer = new Mixer();
            MyMixer.GetState();
            Console.ReadLine();
#endif
        }

        protected override void OnStart(string[] args)
        {
            string parameter = string.Concat(args);
            switch (parameter)
            {
                case "--install":
                    Console.WriteLine("Your Attempting to install. Good luck.");
                    break;
                case "--uninstall":
                    Console.WriteLine($"if you failed to uninstall you'll have to wipe and reload the OS on the computer. haha just kiding. or am i");
                    break;
            }
            Start();
        }

        protected override void OnStop()
        {
        }
    }
}
