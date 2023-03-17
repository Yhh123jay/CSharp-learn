using System;

namespace DIP_Interface_isolation_demo02
{
    class Program
    {
        //演示接口隔离原则
        //c#语言：接口的显示实现，只有显示声明一个接口才能调用该接口的方法
        static void Main(string[] args)
        {
            IKiller killer = new WarmKiller();
            killer.Kill();
            var wk = killer as WarmKiller;
            //此时wk不能调用kill方法
            wk.Love();
        }

        interface IGentleman
        {
            void Love();
        }
        interface IKiller
        {
            void Kill();
        }
        class WarmKiller : IGentleman,IKiller
        {
            //实现接口（普通方式）
            public void Love()
            {
                Console.WriteLine("I will love you forever...");
            }
            //显示实现接口
            void IKiller.Kill()
            {
                Console.WriteLine("I will kill the enemy!!!");
            }
        }
    }
}
