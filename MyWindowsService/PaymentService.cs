using MyWindowsService;
using MyWindowsService.Startup;
using System;
using System.Net;
using System.Reflection;
using System.ServiceProcess;

namespace MyWindowsService
{
    public partial class PaymentService : ServiceBase
    {
        private Bootstraper bootstraper;

        public PaymentService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            new AutofacConfig().ConfigureDependencies();
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            bootstraper = AutofacConfig.Resolve<Bootstraper>();
            bootstraper.OnStart();
        }

        protected override void OnStop()
        {
            bootstraper.OnStop();
        }

        protected override void OnPause()
        {
            bootstraper.OnPaused();
        }

        protected override void OnContinue()
        {
            bootstraper.OnPaused();
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;           
        }
    }
}
