using StartProject.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject.Repository.EntityFramework
{
    class MyInitializer: CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            Random random = new Random();
            //Adding  authoritys..

         

            // Adding admin user..
            User admin = new User()
            {
                name = "Abullah",
                surname = "Cangul",
                email = "abdullahcangul@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                isActive = true,
                username = "abdullahcangul",
                profileImageFilename = "user_boy.png",
                password = "123456",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now.AddMinutes(5),
                updatedBy = "erdi yalçın",
                createdBy = "erdem siyam",
                Authorities = context.Authorities.Where(x=>x.name== "admin").ToList()
                
            };

            // Adding standart user..
            User standartUser = new User()
            {
                name = "Hamza",
                surname = "Taş",
                email = "hamzatas@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                isActive = true,
                username = "hamzatas",
                profileImageFilename = "user_boy.png",
                password = "123456",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now.AddMinutes(5),
                updatedBy = "erdem siyam",
                createdBy = "erdem siyam",
                Authorities = context.Authorities.Where(x => x.name == "standart").ToList()

            };
            context.Users.Add(admin);
            context.Users.Add(standartUser);
            //adding 8 user
            for (int i = 0; i < 8; i++)
            {
                User user = new User()
                {
                    name = FakeData.NameData.GetFirstName(),
                    surname = FakeData.NameData.GetSurname(),
                    email = FakeData.NetworkData.GetEmail(),
                    profileImageFilename = "user_boy.png",
                    ActivateGuid = Guid.NewGuid(),
                    isActive = true,
                    username = $"user{i}",
                    password = "123",
                    createdAt = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    updatedAt = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    createdBy = $"user{i}",
                    Authorities = context.Authorities.Take(random.Next(1, 4)).ToList(),
                     
                };

                context.Users.Add(user);
            }
            context.SaveChanges();

            List<Authority> authoritys = new List<Authority>()
            {
                { new Authority(){ name="admin" ,User= context.Users.ToList()[1],} },
                { new Authority(){ name="employe",User= context.Users.ToList()[2] } },
                { new Authority(){ name="musteri" ,User= context.Users.ToList()[3]} },
                { new Authority(){ name="standart",User= context.Users.ToList()[4] } },
            };
            context.Authorities.AddRange(authoritys);
            context.SaveChanges();

            //adding employee
            for (int i = 0; i < 3; i++)
            {
                Employee employee = new Employee()
                {
                    User =context.Users.ToList()[i+4],
                };
                Customer customer = new Customer()
                {
                    competnent = "süper",
                    description = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(5, 10)),
                    url=FakeData.NetworkData.GetDomain(),
                    User = context.Users.ToList()[i],
                };

            context.Employees.Add(employee);
            context.Customers.Add(customer);
            }
            
            Employee employeeAdmin = new Employee()
            {
                User = context.Users.SingleOrDefault(x=>x.email== "abdullahcangul@gmail.com"),
            };
            context.Employees.Add(employeeAdmin);
            Customer customerStandart = new Customer()
            {
                competnent = "hiper",
                description = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(5, 5)),
                url = FakeData.NetworkData.GetDomain(),
                User = context.Users.SingleOrDefault(x=>x.email== "hamzatas@gmail.com"),
            };
            context.Customers.Add(customerStandart);
            context.SaveChanges();


            for (int i = 0; i < 3; i++)
            {
                Project project = new Project()
                {
                    Customer = context.Customers.ToList()[i],
                    Employee = context.Employees.ToList()[i],
                    description = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(5, 10)),
                    name = FakeData.NameData.GetFirstName(),
                };
              
                context.Projects.Add(project);
            }
            context.SaveChanges();

            for (int i = 0; i < 2; i++)
            {
                Content content = new Content()
                {

                    message = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                    isCustomer = true,
                    //Process = context.Processes.ToList()[i],


                };

                context.Contents.Add(content);
            }
            context.SaveChanges();

            for (int i = 0; i < 2; i++)
            {
                Process process = new Process()
                {

                    Employee = context.Employees.ToList()[i+1],
                    Project = context.Projects.ToList()[i+1],
                    Contents=context.Contents.ToList(),
                    priority = "kırmızı",
                    status = "ilerliyor",
                    

                };

                context.Processes.Add(process);
                
            }
            context.SaveChanges();
            
            // base.Seed(context);
        }
    }
}
