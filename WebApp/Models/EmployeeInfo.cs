using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    [Keyless]
    public class EmployeeInfo
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public int Age { get; set; }
    }
}
