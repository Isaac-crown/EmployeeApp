using System.Collections.Generic;
using System.Linq;

namespace EmployeeApp.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private List<Employee> _employeeList;

        public EmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){Id = 1, NameofProducts = "Isaac", Description = "adetunjii@gmail.com", Department = Dept.IT},
                new Employee(){Id = 2, NameofProducts = "Josepg jj", Description = "adetunjii@gmail.com", Department = Dept.HR},
                new Employee(){Id = 3, NameofProducts = "Isaac Kunle", Description = "adetunjii@gmail.com", Department = Dept.Admin}

            };
        }

        public Employee Add(Employee employee)
        {
         employee.Id = _employeeList.Max(e => e.Id) + 1;
           _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == id);
            if(employee != null)
            {
                _employeeList.Remove(employee);
            }

            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(x => x.Id == id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.NameofProducts = employeeChanges.NameofProducts;
                employee.NameofProducts = employeeChanges.NameofProducts;
                employee.Department = employeeChanges.Department;
            }

            return employee;
        }
    }
}
