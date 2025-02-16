using apiSession4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiSession4.Controllers
{
    [ApiController]
    [Authorize]
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
                          FIO = e.Surname + " " + e.FirstName + " " + e.SecondName,
                          Email = e.Email,
                          Phone = e.PhoneWork,
                          Position = e.Position,
                          BirthDay = DateTime.Parse(e.BirthDay.ToString()!).ToString("M"),
                      };
            return emp.AsQueryable();
        }
    }
}
