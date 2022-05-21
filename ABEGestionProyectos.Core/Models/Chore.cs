using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABEGestionProyectos.Core.Models
{
    public class Chore
    {
        
        public int ChoreID { get; set; }

        [Required(ErrorMessage = "*Campo Obligatorio"), StringLength(150)]
        public string Name { get; set; }

        [Required(ErrorMessage = "*Campo Obligatorio")] 
        public int Points { get; set; }

        [Required(ErrorMessage = "*Campo Obligatorio"), StringLength(150)]
        public string State { get; set; }

        [Required]
        public int PersonID { get; set; }

        [Required]
        public int UserHistoryID { get; set; }


        //Propieades de Navegación
        public virtual UserHistory UserHistory { get; set; }
        public virtual Person Person { get; set; }
    }
}
