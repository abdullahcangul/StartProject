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
    [Table("Authorities")]
    public class Authority:BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [DisplayName("İsim"), 
  StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string name { get; set; }

        public int userId { get; set; }
        public User User { get; set; }
    }
}
