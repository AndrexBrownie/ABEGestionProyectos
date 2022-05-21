using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABEGestionProyectos.Core.Models
{
    public class UserHistory
    {
        public int UserHistoryID { get; set; }

        [Required(ErrorMessage = "*Campo Obligatorio"), StringLength(150)]
        public string Title { get; set; }

        [Required(ErrorMessage = "*Campo Obligatorio"), StringLength(150)]
        public string IAsA { get; set; }

        [Required(ErrorMessage = "*Campo Obligatorio"), StringLength(150)]
        public string INeed { get; set; }

        [Required(ErrorMessage = "*Campo Obligatorio"), StringLength(150)]
        public string SoThat { get; set; }

        [Required(ErrorMessage = "*Campo Obligatorio"), StringLength(150)]
        public string Estimate { get; set; }

        [Required(ErrorMessage = "*Campo Obligatorio"), StringLength(150)]
        public string Priority { get; set; }

        [Required]
        public int EpicID { get; set; }

        [Required]
        public int SprintID { get; set; }


        //Propiedades de Navegación
        public virtual Epic Epic { get; set; }

        public virtual Sprint Sprint { get; set; }

        public virtual ICollection<Chore> Chores { get; set; }

    }
}
