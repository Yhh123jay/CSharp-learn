using System;

namespace DIP_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            //依赖倒置原则
            //单元测试是依赖倒置原则在开发中的应用
            Console.WriteLine("Hello World!");
            Fan fan = new Fan(new PowerSupply());
            Console.WriteLine(fan.Work()); 
        }      
    }
    //电源接口
    public interface IPowerSupply
    {
        int GetPower();
    }
    //电源类
    public class PowerSupply : IPowerSupply
    {
        public int GetPower()
        {
            return 100;
        }
    }

    //风扇类
    public class Fan
    {
        IPowerSupply powerSupply;
        public Fan(IPowerSupply powerSupply)
        {
            this.powerSupply = powerSupply;
        }
        public int Work()
        {
           return powerSupply.GetPower();
        }

    }
}
