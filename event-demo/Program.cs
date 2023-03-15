using System;
using System.Timers;

namespace event_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //一星事件实例
            //事件的拥有者
            Timer timer = new Timer();
            timer.Interval = 1000;
            //事件的响应者
            Boy boy = new Boy();
            //事件
            //事件订阅+=
            //不要加括号！！！！Action()
            timer.Elapsed += boy.Action;
            
            timer.Start();
            Console.ReadLine();
        }

       
    }

    class Boy
    {
        public void Action(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("jump");
        }
    }
}
