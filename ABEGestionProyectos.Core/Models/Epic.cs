using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABEGestionProyectos.Core.Models
{
   public class Epic
    {
        public int EpicID { get; set; }

        [Required(ErrorMessage = "*Campo Obligatorio"), StringLength(150)]
        public string Name { get; set; }

        //[Required]
        public int ProjectID { get; set; }


        //Propiedades de Navegación

        public virtual Project Project { get; set; }
        public virtual ICollection<UserHistory> UserHistories { get; set; }
    }

}
