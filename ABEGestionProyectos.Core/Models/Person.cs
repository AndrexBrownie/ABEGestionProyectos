using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABEGestionProyectos.Core.Models
{
    public class Person
    {
        public int PersonID { get; set; }

        [Required(ErrorMessage = "*Campo Obligatorio"), StringLength(150)]
        public string Name { get; set; }

        [Required]
        public int RoleID { get; set; }

        //Propiedades de Navegación

        public virtual ICollection<Chore> Chores { get; set; }
        public virtual Role Role { get; set; }
    }
}
