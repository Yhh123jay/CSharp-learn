using System;

namespace Abstract_demo01
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = new Car();
            car.Run();
        }
    }

    abstract class Vehicle
    {
        public void Stop()
        {
            Console.WriteLine("stop");
        }
        abstract public void Run();
    }

    class Car : Vehicle
    {
       
        public override void Run()
        {
            Console.WriteLine("Car is Running!");
        }

    }
    class Trunk : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Trunk is Running!");
        }
    }
}
