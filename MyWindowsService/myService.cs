using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WcfServ;

namespace MyWindowsService
{
    public partial class myService : ServiceBase
    {
        ServiceHost service1Host = null;
        public myService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (service1Host != null)
            {
                service1Host.Close();
            }

            service1Host = new ServiceHost(typeof(Service1), new Uri("http://localhost:62415/"));
            service1Host.AddDefaultEndpoints();

            service1Host.Open();
            EventLog.WriteEntry("ServiceWCFWindows", "Service WCF démarré", EventLogEntryType.Information);
        }

        protected override void OnStop()
        {
            if (service1Host != null)
            {
                service1Host.Close();
                service1Host = null;
            }
        }
    }
}
