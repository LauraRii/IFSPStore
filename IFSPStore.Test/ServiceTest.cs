using IFSPStore.Domain.Base;
using Microsoft.Extensions.DependencyInjection;
using IFSPStore.Service.Service;
using IFSPStore.Domain.Entities;
using IFSPStore.Repository.Context;
using AutoMapper;
using IFSPStore.Service.Validations;
using System.Text.Json;
using Microsoft.Extensions.Logging.Abstractions;
using IFSPStore.Repository.Repository;

namespace IFSPStore.Test
{
    [TestClass]
    public class ServiceTest
    {
        private ServiceCollection services;

        public ServiceProvider ConfigureServices()
        {
            services = new ServiceCollection();
            services.AddDbContext<IFSPStoreContext>();
            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            services.AddScoped<IBaseService<User>, BaseService<User>>();
            services.AddSingleton(new MapperConfiguration(config => {config.CreateMap<User, User>(); }, NullLoggerFactory.Instance).CreateMapper());
            return services.BuildServiceProvider();

        }

        [TestMethod]
        public void TestUserService()
        {
            var serviceProvider = ConfigureServices();
            var _userService = serviceProvider.GetService<IBaseService<User>>();

            var user = new User
            {
                Name = "murilo",
                Login = "murilo123",
                State = "SP",
                Email = "murilo@gmail.com",
                Password = "123ABC!@murilo"
            };
            var result = _userService.Add<User, User, UserValidator>(user);
            Console.WriteLine(JsonSerializer.Serialize(result));

        }
    }
}
