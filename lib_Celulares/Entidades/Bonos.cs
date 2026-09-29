using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class Bonos
    {
        public int Id { get; set; }
        public int TecnicoId { get; set; }
        public int CantidadReparaciones { get; set; }
        public decimal ValorBono { get; set; }

        [ForeignKey("TecnicoId")] public Tecnicos? Tecnico { get; set; }
        public List<Reparaciones>? Reparaciones { get; set; }
    }
}
