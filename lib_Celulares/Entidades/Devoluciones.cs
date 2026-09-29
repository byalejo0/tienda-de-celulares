using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class Devoluciones
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public string? Motivo { get; set; }
        public decimal ValorDevuelto { get; set; }

        [ForeignKey("FacturaId")] public Facturas? Factura { get; set; }
        [ForeignKey("ClienteId")] public Clientes? Cliente { get; set; }
    }
}
