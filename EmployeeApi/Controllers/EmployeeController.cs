using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using EmployeeApi.Models;

namespace EmployeeApi.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: Employee
        public JsonResult<Employee> Get()
        {
            var emp = new Employee() { id = 1289, employeeName = "John", email = "john@havenxxx.com", city = "London" };


            return Json<Employee>(emp, new Newtonsoft.Json.JsonSerializerSettings() { });
        }
    }
}