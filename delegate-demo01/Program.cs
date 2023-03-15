using System;

namespace delegate_demo01
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            //使用action委托指向这个方法
            Action action = new Action(calculator.Report);
            action.Invoke();
            action();
            //使用function委托（泛型委托）
            Func<int, int, int> func1 = new Func<int, int, int>(calculator.Add);
            Func<int, int, int> func2 = new Func<int, int, int>(calculator.Sub);
            int z = func1.Invoke(3, 2);
            Console.WriteLine(z);
        }
    }

    class Calculator
    {
        public void Report()
        {
            Console.WriteLine("我有三个方法");
        }

        public int Add(int a,int b)
        {
            return a + b;
        }

        public int Sub(int a, int b)
        {
            return a - b;
        }
    }
}
