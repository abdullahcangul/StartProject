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
    public class BaseEntity
    {


        [ ScaffoldColumn(false)]
        public DateTime? createdAt { get; set; }
        [ScaffoldColumn(false), StringLength(50)]
        public string createdBy { get; set; }
        [ ScaffoldColumn(false)]
        public DateTime? updatedAt { get; set; }
        [StringLength(50), ScaffoldColumn(false) ]
        public string updatedBy { get; set; }

        

    }
}
