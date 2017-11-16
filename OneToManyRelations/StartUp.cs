using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace OneToManyRelations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new MyDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var department = new Department{Name = "Prazni Kartuni"};
            department.Employees.Add(new Employee{Name = "Gancho"});
            db.Departments.Add(department);
            db.SaveChanges();
        }
    }
}
