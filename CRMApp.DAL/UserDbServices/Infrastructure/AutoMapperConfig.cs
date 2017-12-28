using AutoMapper;
using UserDbDll.Models;
using UserDbDTo.DTO;

namespace UserDbServices.Infrastructure
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Client, ClientDto>();
                cfg.CreateMap<LoginAndPassword, LoginAndPasswordDto>();
                cfg.CreateMap<Order, OrderDto>();
                //
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<ClientDto, Client>();
                cfg.CreateMap<LoginAndPasswordDto, LoginAndPassword>();
                cfg.CreateMap<OrderDto, Order>();
            });
        }
    }
}
