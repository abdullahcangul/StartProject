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
    [Table("Users")]
    public class User:BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DisplayName("İsim"), Column("first_name"),
    StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string name { get; set; }

        [DisplayName("Soyad"), Column("last_name"),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string surname { get; set; }

        [DisplayName("Kullanıcı Adı"), Column("user_name"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string username { get; set; }

        [DisplayName("E-Posta"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(70, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string email { get; set; }

        [DisplayName("Şifre"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string password { get; set; }

        [StringLength(30), ScaffoldColumn(false)]
        public string profileImageFilename { get; set; }

        [DisplayName("Aktif")]
        public bool isActive { get; set; }


        [Required, ScaffoldColumn(false)]
        public Guid ActivateGuid { get; set; }

    


        public Employee Employee { get; set; }
        public Customer Customer { get; set; }
        public List<Authority> Authorities { get; set; }

    }
}
