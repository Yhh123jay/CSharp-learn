using System;

namespace Event_defineEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;
            customer.OnOrder("gongbaojiding","large");
            customer.PayTheBill();
            Console.ReadLine();
        }
    }
    public class OrderEventArgs:EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }
    //声明一个委托类型的事件
    public delegate void OrderEventHandler(Customer customer,OrderEventArgs e);
    //事件拥有者
    public class Customer
    {
        
        //声明事件,简略
        public event OrderEventHandler Order;

        //委托类型的字段
        //private OrderEventHandler OrderEventHandler;
        ////声明事件,完整
        //public event OrderEventHandler Order
        //{
        //    add
        //    {
        //        this.OrderEventHandler += value;
        //    }
        //    remove
        //    {
        //        this.OrderEventHandler -= value;
        //    }
        //}
        public double Bill { get; set; }
        public void PayTheBill()
        {
            Console.WriteLine("I will pay ${0}.", this.Bill);
        }
        //触发事件
        public void OnOrder(string dishName,string size)
        {
            Console.ReadLine();
            if(this.Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = dishName;
                e.Size = size;
                this.Order.Invoke(this,e);
            }
        }
    }
    //事件响应者
    public class Waiter
    {
        //事件处理器
        public void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine("I will serve you the dish - {0}", e.DishName);
            double price = 10;
            switch (e.Size)
            {
                case "small":
                    price = price * 0.5;
                    break;
                case "large":
                    price = price * 1.5;
                    break;
                default:
                    break;                  
            }
            customer.Bill += price;
        }
    }
}
