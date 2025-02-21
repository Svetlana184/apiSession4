using apiSession4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiSession4.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private RoadOfRussiaContext db;
        public EmployeeController(RoadOfRussiaContext db)
        {
            this.db = db;
        }
        [HttpGet]
        [Route("Employees")]
        public IQueryable GetEmployees()
        {
            var emp = from e in db.Employees
                      select new
                      {
                          e.IdEmployee,
                          e.Surname,
                          e.FirstName,
                          e.SecondName,
                          e.Position,
                          e.PhoneWork,
                          e.Phone,
                          e.Cabinet,
                          e.Email,
                          Department = db.Departments.FirstOrDefault(p => p.IdDepartment == e.IdDepartment)!.DepartmentName,
                          e.IdHelper,
                          e.Other,
                          e.BirthDay,
                          e.IdBoss,
                          e.IsFired,
                          Company = "Дороги России"
                      };
            return emp.AsQueryable();
        }
    }
}
