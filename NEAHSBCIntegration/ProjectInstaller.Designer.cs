namespace MyWindowsService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MyWindowsServiceInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.MyWindowsService = new System.ServiceProcess.ServiceInstaller();
            // 
            // MyWindowsServiceInstaller
            // 
            this.MyWindowsServiceInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.MyWindowsServiceInstaller.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.MyWindowsService});
            this.MyWindowsServiceInstaller.Password = null;
            this.MyWindowsServiceInstaller.Username = null;
            // 
            // MyWindowsService
            // 
            this.MyWindowsService.Description = "Payment Processing Job";
            this.MyWindowsService.DisplayName = "My Windows Service";
            this.MyWindowsService.ServiceName = "MyWindowsService";
            this.MyWindowsService.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.MyWindowsService.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.MyWindowsService_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.MyWindowsServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller MyWindowsServiceInstaller;
        private System.ServiceProcess.ServiceInstaller MyWindowsService;
    }
}