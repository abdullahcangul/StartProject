using StartProject.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject.Repository.EntityFramework
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext():base("StartProjectDb")
        {
            Database.SetInitializer(new MyInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Authority> Authorities { get; set; }

    }
}
