using System;
using System.Collections.Generic;
using System.Text;

namespace Gestiones.Domain.Entities
{
    public class Usuario
    {

        public int IdUsuario { get; set; }
        public string Email { get; set; }

        public string Passwordhasd { get;set; } 

        public string Rol { get; set; }
    }
}
