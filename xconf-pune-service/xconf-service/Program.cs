using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace XConfPune
{
    [ServiceContract]
    interface IXConfServiceHost
    {
        [OperationContract]
        string dummy();
    }

    class XConfServiceHost : IXConfServiceHost
    {
        public string dummy()
        {
            return "Balaji";
        }
    }

    class Program
    {
        private static ServiceHost HostProxy;
        static void Main(string[] args)
        {
            string address = "http://localhost:8001/xconf";
            using (HostProxy = new ServiceHost(typeof(XConfServiceHost), new Uri(address)))
            {
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                HostProxy.Description.Behaviors.Add(smb);
                HostProxy.Open();
                Console.WriteLine("The service is ready at " + address);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();
                HostProxy.Close();           
            }       
        }
    }
}
