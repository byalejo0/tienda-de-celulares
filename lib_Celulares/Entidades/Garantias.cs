using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class Garantias
    {
        public int Id { get; set; }
        public int CelularId { get; set; }
        public int ClienteId { get; set; }
        public int FacturaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string? TipoGarantia { get; set; }
        public string? Estado { get; set; }

        [ForeignKey("CelularId")] public Celulares? Celular { get; set; }
        [ForeignKey("ClienteId")] public Clientes? Cliente { get; set; }
        [ForeignKey("FacturaId")] public Facturas? Factura { get; set; }
    }
}
