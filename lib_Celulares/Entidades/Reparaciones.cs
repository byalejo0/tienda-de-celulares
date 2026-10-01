using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class Reparaciones
    {
        public int Id { get; set; }
        public int CelularId { get; set; }
        public int TecnicoId { get; set; }
        public int ClienteId { get; set; }
        public int? BonoId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string? Estado { get; set; }

        [ForeignKey("CelularId")] public Celulares? _Celular { get; set; }
        [ForeignKey("TecnicoId")] public Tecnicos? _Tecnico { get; set; }
        [ForeignKey("ClienteId")] public Clientes? _Cliente { get; set; }
        [ForeignKey("BonoId")] public Bonos? _Bono { get; set; }
        public List<DetallesReparaciones>? DetallesReparaciones { get; set; }
        public List<Facturas>? Facturas { get; set; }
    }
}
