using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjectionTests
{
    public class ServiceLocator
    {
        private List<ServiceDescriptor> registeredServices = new();

        public void Register<T>(T implementation)
        {
            ServiceDescriptor? descriptor = registeredServices
                .FirstOrDefault(s => s.Type == typeof(T));

            if (descriptor != null) throw new ArgumentException($"Type {typeof(T).Name} is already registered");

            registeredServices.Add(new ServiceDescriptor
            {
                Type = typeof(T),
                Implementation = implementation
            });
        }

        public void Register<T>()
        {
            registeredServices.Add(new ServiceDescriptor
            {
                Type = typeof(T)
            });
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        private object GetService(Type type)
        {
            ServiceDescriptor descriptor = registeredServices
                .First(s => s.Type == type);

            if (descriptor.Implementation != null)
            {
                return descriptor.Implementation;
            }

            var constructor = type.GetConstructors()[0];

            var paramsInfo = constructor.GetParameters();

            if (paramsInfo.Length == 0)
            {
                return Activator.CreateInstance(type)!;
            }

            var parameters = paramsInfo
                .Select(p => GetService(p.ParameterType))
                .ToArray();
            return Activator.CreateInstance(type, parameters)!;
        }
    }
}