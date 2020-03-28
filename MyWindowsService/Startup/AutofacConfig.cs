using Autofac;
using Autofac.Extras.Quartz;
using System.Collections.Specialized;
using System.Configuration;

namespace MyWindowsService.Startup
{
    public class AutofacConfig
    {
        private static IContainer Container;

        public void ConfigureDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new QuartzAutofacFactoryModule
            {
                ConfigurationProvider = context =>
                    (NameValueCollection)ConfigurationManager.GetSection("quartz")
            });

            builder.RegisterModule(new QuartzAutofacJobsModule(GetType().Assembly));
            builder.RegisterType<Bootstraper>();
            Container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
