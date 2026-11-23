using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class Roles
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string? Nombre { get; set; }

        [ForeignKey("UsuarioId")] public Usuarios? _Usuario {get; set; }
    }
}
