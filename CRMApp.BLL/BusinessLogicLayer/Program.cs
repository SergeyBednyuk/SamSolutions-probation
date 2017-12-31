using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BusinessLogicLayer.Services;

namespace BusinessLogicLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (UserDbDllServices services = new UserDbDllServices())
            //{
            //    foreach (var item in services.GetAllOrders())
            //    {
            //        Console.WriteLine("{0} {1}", item.Name, item.Description);
            //    }
            //}

            //using (UserDbDllServices services = new UserDbDllServices())
            //{
            //    services.AddOrders(new OrderDto() { ClientId = 1, UserId = 1, DateTime = DateTime.Now, Description = "TEST", Name = "TEST" });
            //}
            //Thread.Sleep(1000);

            using (UserDbDllServices services = new UserDbDllServices())
            {
                var item = services.GetAllOrderAsync();

            }



            //using (var services = new UnitOfWork.UnityOfWorkClient("BasicHttpBinding_IUnityOfWork"))
            //{
            //    foreach (var itemAllClient in services.GetAllClients())
            //    {
            //        Console.WriteLine("{0} {1}", itemAllClient.ClientId, itemAllClient.Name);
            //    }
            //    Console.ReadKey();
            //}

            //using (UserDbDllServices services = new UserDbDllServices())
            //{
            //    services.UserDtoAuthorization("444", "444");

            //    Console.WriteLine("{0} {1}", services.GetCurrentUser().Name, services.GetCurrentUser().SurName);

            //    Console.ReadKey();
            //}

            Console.ReadKey();
        }
    }
}
