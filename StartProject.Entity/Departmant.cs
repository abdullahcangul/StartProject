using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject.Entity
{
    public class Departmant
    {
        public Departmant()
        {
            Employee = new List<Employee>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [DisplayName("DepartmanAdı"), Column("name"),
            StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string name { get; set; }
        [DisplayName("Açıklama"), Column("description"),
          StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string description { get; set; }

        public  List<Employee> Employee { get; set; }
    }
}
