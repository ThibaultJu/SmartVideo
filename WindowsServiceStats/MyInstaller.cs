using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace WindowsServiceStats
{
    [RunInstaller(true)]
    public partial class MyInstaller : System.Configuration.Install.Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller processInstaller;

        public MyInstaller() : base()
        {

            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

            // Service will run under system account
            processInstaller.Account = ServiceAccount.LocalSystem;

            // Service will have Start Type of Manual
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            serviceInstaller.ServiceName = "MyWindowsStatService";

            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);

        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
            EventLog.WriteEntry("SMServiceInstaller", "Installation de mon service", EventLogEntryType.Information);
        }

        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            base.Uninstall(savedState);
            EventLog.WriteEntry("SMServiceInstaller", "Désinstallation de mon service", EventLogEntryType.Information);
        }
    }
}
