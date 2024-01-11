using Scrutor;
using System.Reflection;

namespace Demo.TheRetailer.WebApp.Configurations
{
    public static class AppServicesExtensions
    {
        public static void AddAppServices(this IServiceCollection serviceCollection)
        {
            var projectName = Assembly.GetExecutingAssembly().GetName().Name;
            var coreNamespace = $"{projectName}.{nameof(Core)}";

            serviceCollection.Scan(scan => 
                scan.FromCallingAssembly()
                    .AddClasses(x=>x.Where(t=>t.FullName != null && t.FullName.StartsWith(coreNamespace)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Append)
                    .AsImplementedInterfaces()
            );
        }
    }
}
