using Castle.DynamicProxy;

namespace WcfProxyDemo.Proxy
{
    public class ProxyFactory
    {
        private static readonly ProxyGenerator Generator = new ProxyGenerator();

        #region Implementation of IAgentProxyFactory

        public static T CreateProxy<T>(string endpointConfigurationName) where T : class
        {
            var interceptor = new WcfClientProxyInterceptor<T>(endpointConfigurationName);

            return Generator.CreateInterfaceProxyWithoutTarget<T>(interceptor);
        }

        #endregion
    }
}