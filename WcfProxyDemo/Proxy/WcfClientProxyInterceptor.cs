using System.Reflection;
using System.Runtime.ExceptionServices;
using System.ServiceModel;
using Castle.DynamicProxy;

namespace WcfProxyDemo.Proxy
{
    public class WcfClientProxyInterceptor<T> : IInterceptor where T : class
    {
        private readonly ChannelFactory<T> factory;

        public WcfClientProxyInterceptor(string endpointConfigurationName)
        {
            this.factory = new ChannelFactory<T>(endpointConfigurationName);
        }

        #region Implementation of IInterceptor
        public void Intercept(IInvocation invocation)
        {
            var channel = (ICommunicationObject)this.factory.CreateChannel();
            try
            {
                if (channel != null)
                {
                    invocation.ReturnValue = invocation.Method.Invoke(channel, invocation.Arguments);
                    channel.Close();
                }
            }
            catch (TargetInvocationException exception)
            {
                if (channel != null)
                {
                    channel.Abort();
                }

                ExceptionDispatchInfo.Capture(exception.InnerException).Throw();
            }
            catch
            {
                if (channel != null)
                {
                    channel.Abort();
                }

                throw;
            }
        }
        #endregion
    }
}