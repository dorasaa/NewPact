using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApi.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string employeeName { get; set; }
        public string email { get; set; }
        public string city { get; set; }
    }
}