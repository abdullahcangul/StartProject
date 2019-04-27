using StartProject.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace StartProject.Repository.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("StartProjectDb")
        {
            //this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new MyInitializer());
        }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Process> Processes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Departmant> Departmants { get; set; }
        public virtual DbSet<CustomerEmployee> CustomerEmployees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerEmployees)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.CustomerID);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Projects)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.CustomerID);

            modelBuilder.Entity<Departmant>()
                .HasMany(e => e.Employee)
                .WithOptional(e => e.Departmant)
                .HasForeignKey(e => e.DepartmantID);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.EmployeeID);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Processes)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.EmployeeID);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Projects)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.EmployeeID);

            modelBuilder.Entity<Process>()
                .HasMany(e => e.Contents)
                .WithOptional(e => e.Process)
                .HasForeignKey(e => e.ProcessID);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Processes)
                .WithOptional(e => e.Project)
                .HasForeignKey(e => e.ProjectID);

            modelBuilder.Entity<Title>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.Title)
                .HasForeignKey(e => e.TitleID);
        }
    }
    }
