using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABEGestionProyectos.Core.Models
{
   public class Sprint
    {
        public int SprintID { get; set; }

        [Required(ErrorMessage = "*Campo Obligatorio"), StringLength(150)]
        public string Name { get; set; }

        [Required(ErrorMessage = "*Campo Obligatorio")]
        public int Points { get; set; }

        [Required(ErrorMessage = "*Campo Obligatorio"), StringLength(150)]
        public string Estate { get; set; }


        //Propiedades de Navegación
        public virtual ICollection<UserHistory> UserHistories { get; set; }
    }
}
