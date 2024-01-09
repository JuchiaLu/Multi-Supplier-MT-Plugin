using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MultiSupplierMTPlugin.Services;

namespace MultiSupplierMTPlugin.Helpers
{
    public class ServiceHolder
    {
        private static readonly Dictionary<string, MTServiceInterface> services = new Dictionary<string, MTServiceInterface>();

        static ServiceHolder()
        {
            IEnumerable<Type> serviceTypes = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(type => typeof(MTServiceInterface).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);

            foreach (Type serviceType in serviceTypes)
            {
                MTServiceInterface serviceInstance = (MTServiceInterface)Activator.CreateInstance(serviceType);
                services.Add(serviceInstance.UniqueName(), serviceInstance);
            }
        }

        public static MTServiceInterface GetService(string uniqueName)
        {
            MTServiceInterface serviceProvider;

            services.TryGetValue(uniqueName, out serviceProvider);

            return serviceProvider;
        }

        public static List<string> GetUniqueNameList()
        {
            return services.Keys.ToList();
        }
    }
}
