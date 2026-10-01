using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class Compras
    {
        public int Id { get; set; }
        public int ProveedorId { get; set; }
        public int TrabajadorId { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Total { get; set; }
        public string? Estado { get; set; }

        [ForeignKey("ProveedorId")] public Proveedores? _Proveedor { get; set; }
        [ForeignKey("TrabajadorId")] public Trabajadores? _Trabajador { get; set; }
        public List<DetallesCompras>? DetallesCompras { get; set; }
    }
}
