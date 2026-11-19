using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class Auditorias
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public String? Descripcion { get; set; }
        public DateTime? Fecha { get; set; }

        [ForeignKey("UsuarioId")] public Usuarios? _Usuario { get; set; }
    }
}
