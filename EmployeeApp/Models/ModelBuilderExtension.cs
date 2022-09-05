using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   Id = 1,
                   NameofProducts = "Mary",
                   Department = Dept.IT,
                   Description = "mary222@gmail.com"
               },
               new Employee
               {
                   Id = 2,
                   NameofProducts = "John",
                   Department = Dept.HR,
                   Description = "john222@gmail.com"
               }

               );
        }
    }
}
