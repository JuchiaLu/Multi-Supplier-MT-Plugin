using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MultiSupplierMTPlugin.Service
{
    public class MtServiceHolder
    {
        private static readonly Dictionary<string, MultiSupplierMTServiceInterface> services = new Dictionary<string, MultiSupplierMTServiceInterface>();

        static MtServiceHolder() 
        {
            IEnumerable<Type> serviceTypes = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(type => typeof(MultiSupplierMTServiceInterface).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);

            foreach (Type serviceType in serviceTypes)
            {
                MultiSupplierMTServiceInterface serviceInstance = (MultiSupplierMTServiceInterface)Activator.CreateInstance(serviceType);
                services.Add(serviceInstance.UniqueName(), serviceInstance);
            }
        }

        public static MultiSupplierMTServiceInterface GetService(string uniqueName)
        {
            MultiSupplierMTServiceInterface serviceProvider;
            
            services.TryGetValue(uniqueName, out serviceProvider);

            return serviceProvider;
        }

        public static List<string> GetUniqueNameList() 
        {
            return services.Keys.ToList();
        }
    }
}
