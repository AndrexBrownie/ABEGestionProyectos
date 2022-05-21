using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABEGestionProyectos.Core.Models
{
    public class Role
    {
        public int RoleID { get; set; }

        [Required(ErrorMessage = "*Campo Obligatorio"), StringLength(150)]
        public string Name { get; set; }

        //Proppiedades de Navegación
        public virtual ICollection<Person> People { get; set; }
    }
}
