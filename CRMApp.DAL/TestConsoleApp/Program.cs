using System;
using UserDbDTo.DTO;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var _db = new UsersDbContext();

            //foreach (var item in _db.Clients)
            //{
            //    Console.WriteLine(item.ClientId);
            //}

            //var unit = new UnityOfWork();

            //var user = unit.UserDtoAuthorization("222", "222");

            //if (user != null)
            //{
            //    Console.WriteLine("{0} {1}", user.Name, user.SurName);
            //}
            //else
            //{
            //    Console.WriteLine("null");
            //}




            //using (var service = new UnitOfWork.UnityOfWorkClient("BasicHttpBinding_IUnityOfWork"))
            //{
            //    service.AddOrders(new OrderDto() { ClientId = 1, UserId = 1, DateTime = DateTime.Now, Description = "TEST", Name = "TEST" });

            //}

            Console.WriteLine();

            using (var service = new UnitOfWork.UnityOfWorkClient("BasicHttpBinding_IUnityOfWork"))
            {
                var orders = service.GetAllOrderDtos();

                foreach (var o in orders)
                {
                    Console.WriteLine("{0} {1}", o.Description, o.Name);
                }
            }

            Console.ReadKey();
        }
    }
}
