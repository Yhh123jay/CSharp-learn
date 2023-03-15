using System;

namespace delegate_demo02
{
    //声明委托
    public delegate double Calc(double x, double y);
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(Action);
            Console.WriteLine(t);
            Calculator calculator = new Calculator();
            Calc calc1 = new Calc(calculator.Add);
            Calc calc2 = new Calc(calculator.Sub);
            Calc calc3 = new Calc(calculator.Mul);
            Calc calc4 = new Calc(calculator.Div);
            double a = 100;
            double b = 200;
           
            Console.WriteLine(calc1(a, b));
            Console.WriteLine(calc2(a, b));
            Console.WriteLine(calc3(a, b));
            Console.WriteLine(calc4(a, b));
        }
    }

    class Calculator
    {
        public double Add(double a,double b)
        {
            return a + b;
        }
        public double Sub(double a, double b)
        {
            return a - b;
        }
        public double Mul(double a, double b)
        {
            return a * b;
        }
        public double Div(double a, double b)
        {
            return a / b;
        }
    }
}
