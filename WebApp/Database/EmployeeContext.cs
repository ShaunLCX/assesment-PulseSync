using System.Collections.Generic;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using Microsoft.Data.SqlClient; 

namespace WebApp.Database
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) :
            base(options)
        {
        }


        public DbSet<EmployeeInfo> EmployeeInfo { get; set; }
        public DbSet<Employee> Employee { get; set; }

        public List<EmployeeInfo> GetEmployeeInfo(string sortOrder)
        {
            var employeeInfo = this.Set<EmployeeInfo>()
                           .FromSqlRaw("EXEC SP_EmployeeInfo @sort_order={0}", sortOrder)
                           .AsEnumerable()
                           .Select(e => new EmployeeInfo
                           {
                               Name = e.Name,
                               Designation = e.Designation,
                               Age = e.Age
                           })
                           .ToList();

            return employeeInfo;
        }  

    }
}
