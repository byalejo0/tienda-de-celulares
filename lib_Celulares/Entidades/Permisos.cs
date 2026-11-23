using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class Permisos
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public string? Ventana { get; set; }

        [ForeignKey("RolId")] public Roles? _Rol { get; set; }
    }
}
