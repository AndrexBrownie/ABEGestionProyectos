using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABEGestionProyectos.Core.Models
{
   public class Project
    {
            public int ProjectID { get; set; }

            [Required(ErrorMessage = "*Campo Obligatorio"), StringLength(150)]

           // [Display(Name = "Nombre")]
            public string Name { get; set; }

            [Required(ErrorMessage = "*Campo Obligatorio"), StringLength(150)]
            public string Type { get; set; }

            [Required(ErrorMessage = "*Campo Obligatorio"), StringLength(150)]
            public string Responsible { get; set; }

            [Required(ErrorMessage = "*Campo Obligatorio"), StringLength(150)]
            public string Description { get; set; }

            [Required(ErrorMessage = "*Campo Obligatorio")]
            public DateTime StartDate { get; set; }

        //Propiedades de Navegación
        public virtual ICollection<Epic> Epics { get; set; }

    }
}
