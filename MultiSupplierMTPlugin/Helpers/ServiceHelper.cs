using MultiSupplierMTPlugin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MultiSupplierMTPlugin.Helpers
{
    public class ServiceHelper
    {
        private static readonly Dictionary<string, MultiSupplierMTService> services = new Dictionary<string, MultiSupplierMTService>();

        static ServiceHelper()
        {
            IEnumerable<Type> serviceTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(MultiSupplierMTService)
                .IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);

            foreach (Type serviceType in serviceTypes)
            {
                MultiSupplierMTService serviceInstance = (MultiSupplierMTService)Activator.CreateInstance(serviceType);
                services.Add(serviceInstance.UniqueName(), serviceInstance);
            }
        }

        public static MultiSupplierMTService GetService(string uniqueName)
        {
            services.TryGetValue(uniqueName, out MultiSupplierMTService serviceProvider);

            return serviceProvider;
        }

        public static List<MultiSupplierMTService>  GetServiceList()
        {
            return services.Values.ToList();
        }

        public static List<string> GetUniqueNameList()
        {
            return services.Keys.ToList();
        }
    }
}
