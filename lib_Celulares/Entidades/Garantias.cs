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

        [ForeignKey("CelularId")] public Celulares? _Celular { get; set; }
        [ForeignKey("ClienteId")] public Clientes? _Cliente { get; set; }
        [ForeignKey("FacturaId")] public Facturas? _Factura { get; set; }
    }
}
