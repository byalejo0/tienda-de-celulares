using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class Facturas
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int TrabajadorId { get; set; }
        public int? ReparacionId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("ClienteId")] public Clientes? Cliente { get; set; }
        [ForeignKey("TrabajadorId")] public Trabajadores? Trabajador { get; set; }
        [ForeignKey("ReparacionId")] public Reparaciones? Reparacion { get; set; }
        public Envios? Envio { get; set; }
        public List<DetallesFacturas>? DetallesFacturas { get; set; }
        public List<Garantias>? Garantias { get; set; }
        public List<Devoluciones>? Devoluciones { get; set; }
    }
}
