using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class Tecnicos
    {
        public int Id { get; set; }
        public int TrabajadorId { get; set; }
        public int CelularesReparados { get; set; }
        public string? Especializacion { get; set; }

        [ForeignKey("TrabajadorId")] public Trabajadores? Trabajador { get; set; }
        public List<Bonos>? Bonos { get; set; }
        public List<Reparaciones>? Reparaciones { get; set; }
    }
}
