using System;
using System.Collections.Generic;
namespace csharp_generics_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeesByName = new SortedList<string,List<Employee>>();
            employeesByName.Add("万文峰",new List<Employee>{new Employee(),new Employee(),new Employee()});
            employeesByName.Add("龚岚", new List<Employee>{new Employee(),new Employee()});
            foreach(var item in employeesByName)
            {
                Console.WriteLine("这是统计的键值{0}:{1}",item.Key,item.Value.Count);
            }
        }
    }
}
