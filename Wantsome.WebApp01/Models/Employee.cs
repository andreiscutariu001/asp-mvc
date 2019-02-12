using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Wantsome.WebApp01.Models
{
    public class Employee
    {
        public string Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email address")]
        public string Email { get; set; }

        [DisplayName("Details")]
        public string Details { get; set; }
    }

    public interface IEmployeeManager
    {
        void Save(Employee employee);

        Employee Get(string id);

        IList<Employee> GetAll();
    }

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