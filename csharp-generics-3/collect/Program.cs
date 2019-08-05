using System;
using System.Collections.Generic;
namespace Collect
{

    //比对
    public class EmployeeComparer:IEqualityComparer<Employee>,IComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return String.Equals(x.Name,y.Name);
        }
        
        // override object.GetHashCode
        public int GetHashCode(Employee obj)
        {
           return obj.Name.GetHashCode();
        }
        public int Compare(Employee x, Employee y)
        {
            return String.Compare(x.Name,y.Name);
        }
    }
    //集合
    public class DepartmentCollection:SortedDictionary<string,SortedSet<Employee>>
    {
        public DepartmentCollection Add(string departmentName, Employee employee)
        {
            if(!ContainsKey(departmentName))
            {
                Add(departmentName,new SortedSet<Employee>(new EmployeeComparer()));
            }
            this[departmentName].Add(employee);
            return this;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var departments = new DepartmentCollection();
            departments.Add("万文峰",new Employee{Name = "万"})
                .Add("万文峰",new Employee{Name = "文"})
                .Add("万文峰",new Employee{Name = "峰"});
            departments.Add("龚岚",new Employee{Name = "龚"})
                .Add("龚岚",new Employee{Name = "岚"})
                .Add("龚岚",new Employee{Name = "gong"});
            foreach(var d in departments)
            {
                Console.WriteLine(d.Key);
                foreach(var v in d.Value)
                {
                    Console.WriteLine("\t"+v.Name);
                }
            }

        }
    }
}
