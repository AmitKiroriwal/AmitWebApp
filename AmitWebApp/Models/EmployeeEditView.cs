using MyWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace AmitWebApp.Models
{
    public class EmployeeEditView
    {
        public string Name { get; set; }


      
        public string Email { get; set; }

        public Dept? Department { get; set; }
    }
}
