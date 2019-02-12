using System.Collections.Generic;

namespace Wantsome.WebApp01.Models
{
    public class EmployeeManager : IEmployeeManager
    {
        static readonly List<Employee> List = new List<Employee>();

        static int _count = 0;

        public void Save(Employee employee)
        {
            employee.Id = _count++.ToString();
            List.Add(employee);
        }

        public Employee Get(string id)
        {
            foreach (var employee in List)
                if (employee.Id == id)
                    return employee;

            return null;
        }

        public IList<Employee> GetAll()
        {
            return List;
        }
    }
}