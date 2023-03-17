using System;
using Microsoft.Extensions.DependencyInjection;

namespace DI_依赖注入容器
{
    class Program
    {
        static void Main(string[] args)
        {
            //演示依赖注入
            //首先添加依赖注入nuget包
            //创建容器
            var sc = new ServiceCollection();
            sc.AddScoped(typeof(ITank), typeof(Tank));
            sc.AddScoped(typeof(IVehicle), typeof(Car));
            sc.AddScoped(typeof(IVehicle), typeof(Tank));
            sc.AddScoped<Driver>();
            //创建服务提供者
            var sp = sc.BuildServiceProvider();
            //==================================
            //在容器中注入了Tank，任何可以看得到容器的地方都可以调用
            //而且，由于IVehicle在容器中已经注入,在创建Driver对象时，容器会自动帮我们创建Car
            //后注入的先调用
            var driver = sp.GetService<Driver>();
            driver.Drive();
        }
    }

    class Driver
    {
        //使用接口隔离，使Driver只能调用车辆的方法
        private IVehicle vehicle;
        public Driver(IVehicle vehicle)
        {
            this.vehicle = vehicle;
        }
        public void Drive()
        {
            vehicle.Run();
        }
    }
    interface IVehicle
    {
        void Run();
    }
    interface IWeapon
    {
        void Fire();
    }
    interface ITank:IVehicle,IWeapon
    {

    }

    class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("ka");
        }
    }
    class Trunk : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("ka ka");
        }
    }
    
    class Tank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("boom");
        }

        public void Run()
        {
            Console.WriteLine("ka ka ka");
        }
    }
}
