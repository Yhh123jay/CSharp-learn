using System;
using System.Reflection;

namespace DI_Demo01
{
    class Program
    {
        static void Main(string[] args)
        {
            //演示反射机制
            Tank tank = new Tank();
            var t = tank.GetType();
            object o = Activator.CreateInstance(t);
            MethodInfo fireMethod = t.GetMethod("Fire");
            MethodInfo runMethod = t.GetMethod("Run");
            fireMethod.Invoke(o,null);
            runMethod.Invoke(o,null);
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
    class Tank : IVehicle,IWeapon
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
