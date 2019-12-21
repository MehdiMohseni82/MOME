using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MOME.DotNetDIExtensions
{
    public static class RegisterAllAssignableTypes
    {
        public static void RegisterAllAssignableType<T>(this IServiceCollection services, string assemblyName)
        {
            var assembly = AppDomain.CurrentDomain.Load(assemblyName);
            var types = assembly.GetTypes().Where(p => typeof(T).IsAssignableFrom(p)).ToArray();

            var addTransientMethod = typeof(ServiceCollectionServiceExtensions).GetMethods().FirstOrDefault(m =>
                m.Name == "AddTransient" &&
                m.IsGenericMethod == true &&
                m.GetGenericArguments().Count() == 2);

            foreach (var type in types)
            {
                if (type.IsInterface)
                    continue;

                var fooOfBarMethod = addTransientMethod.MakeGenericMethod(new[] { typeof(T), type });
                fooOfBarMethod.Invoke(services, new[] { services });
            }
        }

        public static Interface ResolveByName<Interface>(this IServiceProvider serviceProvider, string typeName)
        {
            var allRegisteredTypes = serviceProvider.GetRequiredService<IEnumerable<Interface>>();
            var resolvedService = allRegisteredTypes.FirstOrDefault(p => p.GetType().FullName.Contains(typeName));

            if (resolvedService != null)
            {
                return resolvedService;
            }
            else
            {
                throw new TypeNotFound($"{typeName} type not found.");
            }
        }
    }
}
