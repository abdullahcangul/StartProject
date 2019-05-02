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

            for (int i = 0; i < 3; i++)
            {
                Departmant departmant = new Departmant()
                {
                    name = FakeData.NameData.GetCompanyName(),
                    description = FakeData.TextData.GetAlphabetical(10),

                };
                context.Departmants.Add(departmant);
            }
            for (int i = 0; i < 3; i++)
            {
                Title title = new Title()
                {
                    name = "standart",
                    description = FakeData.TextData.GetAlphabetical(10),

                };
                context.Titles.Add(title);
            }

            context.SaveChanges();
            // Adding admin user..
            Employee admin = new Employee()
            {
                name = "Abullah",
                surname = "Cangul",
                email = "abdullahcangul@gmail.com",
                activateGuid = Guid.NewGuid(),
                isActive = true,
                profileImageFilename = "user_boy.png",
                password = "123456",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now.AddMinutes(5),
                updatedBy = "erdi yalçın",
                createdBy = "erdem siyam",
                Departmant = context.Departmants.ToList()[1],
                Title=context.Titles.ToList()[1]
                
            };

            // Adding standart user..
            Employee standartUser = new Employee()
            {
                name = "Hamza",
                surname = "Taş",
                email = "hamzatas@gmail.com",
                activateGuid = Guid.NewGuid(),
                isActive = true,
                profileImageFilename = "user_boy.png",
                password = "123456",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now.AddMinutes(5),
                updatedBy = "erdem siyam",
                createdBy = "erdem siyam",
                Departmant = context.Departmants.ToList()[2],
                Title = context.Titles.ToList()[2]

            };
            context.Employees.Add(admin);
            context.Employees.Add(standartUser);
            //adding 8 user
            for (int i = 0; i < 8; i++)
            {
                Employee user = new Employee()
                {
                    name = FakeData.NameData.GetFirstName(),
                    surname = FakeData.NameData.GetSurname(),
                    email = FakeData.NetworkData.GetEmail(),
                    profileImageFilename = "user_boy.png",
                    activateGuid = Guid.NewGuid(),
                    isActive = true,
                    password = "123",
                    createdAt = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    updatedAt = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    createdBy = $"user{i}",
                    Departmant = context.Departmants.ToList()[random.Next(1, 3)],
                    Title = context.Titles.ToList()[random.Next(1, 3)]
                    

                };

                context.Employees.Add(user);
            }
            context.SaveChanges();

     
            //adding Customer
            for (int i = 0; i < 3; i++)
            {
               
                Customer customer = new Customer()
                {
                    name = FakeData.NameData.GetFirstName(),
                    email = FakeData.NetworkData.GetEmail(),
                    competnent = "süper",
                    description = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(5, 7)),
                    url=FakeData.NetworkData.GetDomain(),
                    Employee = context.Employees.ToList()[i],

                };
                
            context.Customers.Add(customer);
            }


            Customer customerStandart = new Customer()
            {
                competnent = "hiper",
                description = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(5, 5)),
                url = FakeData.NetworkData.GetDomain(),
                email = FakeData.NetworkData.GetEmail(),
                
                Employee = context.Employees.SingleOrDefault(x=>x.email== "hamzatas@gmail.com"),
            };
            context.Customers.Add(customerStandart);
            context.SaveChanges();


            for (int i = 0; i < 3; i++)
            {
                Project project = new Project()
                {
                    Customer = context.Customers.ToList()[i],
                    Employee = context.Employees.ToList()[i],
                    description = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(5, 7)),
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
