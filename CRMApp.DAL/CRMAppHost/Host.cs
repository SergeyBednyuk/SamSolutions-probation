using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UserDbServices.Infrastructure;

namespace CRMAppHost
{
    class Host
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(UserDbServices.UnityOfWork)))
            {
                AutoMapperConfig.Initialize();

                host.Open();

                Console.WriteLine("Host started ....");
                Console.ReadKey();

                host.Close();
            }
        }
    }
}
