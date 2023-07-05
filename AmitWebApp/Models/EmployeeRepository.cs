using AmitWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Models
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly List<Employee> employees;
        private readonly EmployeeDbContext context;
        public EmployeeRepository()
        {
            employees = new List<Employee>()
         {
           new Employee(){Id=1001,Name="Gaurav Narula", Email="gaurav@sircltech.com", Department=Dept.IT},
           new Employee(){Id=1002,Name="Vinod Kumar", Email="vkn@sircltech.com", Department=Dept.Development},
           new Employee(){Id=1003,Name="Raju Singh", Email="rishi@sircltech.com", Department=Dept.Payroll },
           new Employee(){Id=1004,Name="Neelam", Email="neelam@sircltech.com", Department=Dept.Web_Designing},
           new Employee(){Id=1005,Name="Vaibhav", Email="pandey@sircltech.com", Department= Dept.HR},
          };
        }
        public async Task<IEnumerable<SelectListItem>> statelist()
        {
            var data = context.states.Select(S => new { Name = S.StateName, id = S.StateId });
            var res = await data.Select(x => new SelectListItem { Text = x.Name, Value = x.id.ToString() }).ToListAsync();
            return res;
        }
        public Employee AddEmployee(Employee employee)
        {
            
            employee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(employee);
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployee()
        {
            return employees;
        }
        public Employee GetEmployee(int Id)
        {
            return employees.FirstOrDefault(eid => eid.Id == Id);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SelectListItem>> District(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SelectListItem>> Cities(int id)
        {
            throw new NotImplementedException();
        }
    }
}
