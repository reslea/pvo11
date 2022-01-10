using System;

namespace DependencyInjectionTests
{
    public class ServiceDescriptor
    {
        public Type Type { get; set; }

        public object? Implementation { get; set; }
    }
}