using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class DetallesReparaciones
    {
        public int Id { get; set; }
        public int ReparacionId { get; set; }
        public string? Diagnostico { get; set; }
        public string? ServicioRealizado { get; set; }
        public string? ComponenteReemplazado { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }

        [ForeignKey("ReparacionId")] public Reparaciones? _Reparacion { get; set; }
    }
}
