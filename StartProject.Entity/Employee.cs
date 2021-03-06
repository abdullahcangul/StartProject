﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject.Entity
{
    [Table("Employees")]
    public class Employee:BaseEntity
    {
        public Employee()
        {
            Customers = new List<Customer>();
            Projects = new List<Project>();
            Processes = new List<Process>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DisplayName("İsim"), Column("first_name"),
    StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string name { get; set; }

        [DisplayName("Soyad"), Column("last_name"),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string surname { get; set; }



        [DisplayName("E-Posta"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(70, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string email { get; set; }

        [DisplayName("Şifre"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string password { get; set; }

        [ ScaffoldColumn(false)]
        public string profileImageFilename { get; set; }


        [ ScaffoldColumn(false)]
        public bool isActive { get; set; }

        [ ScaffoldColumn(false)]
        public string FileName { get; set; }
        [ ScaffoldColumn(false)]
        public string fileBase64String { get; set; }

        [ ScaffoldColumn(false)]
        public Guid activateGuid { get; set; }

        
        public int? DepartmantID { get; set; }
        
        public int? TitleID { get; set; }

        public  Departmant Departmant { get; set; }
        public  Title Title { get; set; }
        public  List<Customer> Customers { get; set; }
        public  List<Project> Projects { get; set; }
        public  List<Process> Processes { get; set; }
    }
}
