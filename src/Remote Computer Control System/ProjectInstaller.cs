using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace Remote_Computer_Control_System
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
        private System.ServiceProcess.ServiceInstaller serviceInstaller1;

        private string ServiceUsername => Remote_Computer_Control_System.ServiceDetails.GetConfigurationValue(key: "ServiceUsername");
        private string ServicePassword
        {
            get
            {
                var d = Remote_Computer_Control_System.ServiceDetails.GetConfigurationValue(key: "ServicePassword");
                var e = Remote_Computer_Control_System.ServiceDetails.GetConfigurationValue(key: "ServicePasswordSalt");
                return SkyhoshiEncryption.Crypto.DecryptStringAES(d, e);
            }
        }

        public ProjectInstaller()
        {
            InitializeComponent();
            this.serviceInstaller1.ServiceName = Remote_Computer_Control_System.ServiceDetails.GetConfigurationValue(key: "ServiceSystemName");
            this.serviceInstaller1.DisplayName = Remote_Computer_Control_System.ServiceDetails.GetConfigurationValue(key: "ServiceName");
            this.serviceInstaller1.Description = Remote_Computer_Control_System.ServiceDetails.GetConfigurationValue(key: "ServiceDescription");
            this.serviceProcessInstaller1.Username = ServiceUsername;
            this.serviceProcessInstaller1.Password = ServicePassword;
        }
        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalService;

            // 
            // serviceInstaller1
            // 
            this.serviceInstaller1.DelayedAutoStart = true;
            this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
                this.serviceProcessInstaller1,
                this.serviceInstaller1});

        }

        #endregion
    }
}
