using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace csharp_generics_5
{
    class Program
    {
        static void Main(string[] args)
        {
            using(IRespository<Employee> employeeRespository = new SqlRespository<Employee>(new EmployeeDb()))
            {
             AddEmployees(employeeRespository);
             AddManagers(employeeRespository);
             CountEmployees(employeeRespository);
             QueryEmployess(employeeRespository);
             DumpPeople(employeeRespository);
             IEnumerable<Person> temp = employeeRespository.FindAll();   
            }
        }
        private static void AddManagers(IWriteOnlyRespository<Manager> employeeRespository)
        {
            employeeRespository.Add(new Manager{Name = "keepwan"});
            employeeRespository.Commit();
        }
        public static void DumpPeople(IReadOnlyRespository<Person> employeeRespository)
        {
            var employees = employeeRespository.FindAll();
            foreach(var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        private static void QueryEmployess(IRespository<Employee> employeeRespository)
        {
            var employee = employeeRespository.FindById(1);
            Console.WriteLine(employee.Name);
        }
        private static void CountEmployees(IRespository<Employee> employeeRespository)
        {
            Console.WriteLine(employeeRespository.FindAll().Count());
        }
        private static void AddEmployees(IRespository<Employee> employeeRespository)
        {
            employeeRespository.Add(new Employee{Name = "keep"});
            employeeRespository.Add(new Employee{Name = "wan"});
            employeeRespository.Commit();
        }
    }
}
