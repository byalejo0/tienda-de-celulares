using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class DetallesFacturas
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int CelularId { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("FacturaId")] public Facturas? Factura { get; set; }
        [ForeignKey("CelularId")] public Celulares? Celular { get; set; }
    }
}
