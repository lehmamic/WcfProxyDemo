using System;
using System.ServiceModel;
using WcfProxyDemo.Proxy;
using WcfProxyDemo.Service;

namespace WcfProxyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Type serviceType = typeof(DemoService);
            var host = new ServiceHost(serviceType);
            host.Open();

            var service = ProxyFactory.CreateProxy<IDemoService>("WcfProxyDemo.Service.DemoService");

            Console.WriteLine(service.Hello("World"));
        }
    }
}
