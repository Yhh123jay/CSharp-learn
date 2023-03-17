using System;
using System.Collections;

namespace DIP_Interface_isolation
{
    class Program
    {
        //演示接口隔离
        static void Main(string[] args)
        {
            int[] nums1 = { 1, 2, 4, 5, 6 };
            var nums2 = new ReadOnlyCollection(nums1);
            ArrayList nums3 = new ArrayList { 1,2,4,5,6} ;
            Console.WriteLine(Sum(nums1));
            Console.WriteLine(Sum(nums2));
            Console.WriteLine(Sum(nums3));
            
        }
        //使用ICollection接口可以修改数组中的元素，我们并不需要这一功能，所以自定义一个只读的Collection类，实现IEnumerable接口
        //static int Sum(ICollection nums)
        static int Sum(IEnumerable nums)
        {
            int sum = 0;
            foreach(var n in nums)
            {
                sum += (int)n;
            }
            return sum;
        }
    }
    //创建一个ReadOnlyCollection类，使用内部类实现IEnumerator接口,自定义只读迭代器
    //Array和ArrayList继承自ICollection接口和IEnumerable接口
    class ReadOnlyCollection : IEnumerable
    {
        private int[] _array;
        //构造器
        public ReadOnlyCollection(int[] array)
        {
            this._array = array;
        }
        //返回迭代器
        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        //自定义Enumerator迭代器
        public class Enumerator : IEnumerator
        {
            private ReadOnlyCollection _collection; 
            private int _head = -1;
            public Enumerator(ReadOnlyCollection collection)
            {
                this._collection = collection;
                _head = -1;
            }
            public object Current
            {
                get
                {
                    object current = _collection._array[_head];
                    return current;
                }
            }

            public bool MoveNext()
            {
                if(++_head < _collection._array.Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                _head = -1;
            }
        }
    }
}
