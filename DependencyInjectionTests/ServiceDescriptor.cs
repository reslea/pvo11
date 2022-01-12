using System;

namespace DependencyInjectionTests
{
    public class ServiceDescriptor
    {
        public Type Type { get; set; }
        public Type ImplementationType { get; set; }

        public object? Implementation { get; set; }
        public Func<object> Resolver { get; set; }
    }
}