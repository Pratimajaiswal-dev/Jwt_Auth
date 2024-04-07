using Jwt_Auth.Context;
using Jwt_Auth.Interfaces;
using Jwt_Auth.Models;

namespace Jwt_Auth.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly JwtContext _jwtContext;
        public EmployeeService(JwtContext jwtContext)
        {
            _jwtContext = jwtContext;
        }

        public Employee AddEmployee(Employee employee)
        {
            var emp = _jwtContext.Employees.Add(employee);
            _jwtContext.SaveChanges();
            return emp.Entity;
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                var emp = _jwtContext.Employees.SingleOrDefault(s => s.Id==id);
                if (emp == null)
                    throw new Exception("User not found");
                else
                {
                    _jwtContext.Employees.Remove(emp);
                    _jwtContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        
        }

        public Employee GetEmployee(int id)
        {
            var emp = _jwtContext.Employees.SingleOrDefault(s => s.Id == id);
            return emp;
        }

        public List<Employee> GetEmployeeDetails()
        {
            var employees=_jwtContext.Employees.ToList();
            return employees;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var updated =_jwtContext.Employees.Update(employee);
            _jwtContext.SaveChanges();
            return updated.Entity; 
        }
    }
}
