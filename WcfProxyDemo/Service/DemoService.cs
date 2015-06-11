using System.ServiceModel;

namespace WcfProxyDemo.Service
{
    [ServiceContract]
    public interface IDemoService
    {
        [OperationContract]
        string Hello(string name);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, IncludeExceptionDetailInFaults = true)]
    public class DemoService : IDemoService
    {
        public string Hello(string name)
        {
            return "Hello " + name;
        }
    }
}
