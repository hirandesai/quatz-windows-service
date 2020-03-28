using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace MyWindowsService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        protected override void OnAfterInstall(System.Collections.IDictionary savedState)
        {
            try
            {
                ServiceController controller = new ServiceController("MyWindowsService");
                if (controller != null)
                {
                    if (controller.Status == ServiceControllerStatus.Stopped || controller.Status == ServiceControllerStatus.StopPending)
                    {
                        controller.Start();
                        controller.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 0, 15));
                        controller.Close();
                    }
                }
                base.OnAfterInstall(savedState);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Project Installer-Installation", ex.Message + (ex.InnerException != null ? Environment.NewLine + ex.InnerException.Message : ""));
            }
        }
        protected override void OnBeforeUninstall(System.Collections.IDictionary savedState)
        {
            try
            {
                ServiceController controller = new ServiceController("MyWindowsService");
                if (controller != null)
                {
                    if (controller.Status == ServiceControllerStatus.Running || controller.Status == ServiceControllerStatus.Paused)
                    {
                        controller.Start();
                        controller.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 0, 15));
                        controller.Close();
                    }
                }
                base.OnBeforeUninstall(savedState);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Project Installer-UnInstaller", ex.Message + (ex.InnerException != null ? Environment.NewLine + ex.InnerException.Message : ""));
            }
        }

        private void MyWindowsService_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
