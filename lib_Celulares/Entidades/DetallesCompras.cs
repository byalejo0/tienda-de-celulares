using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class DetallesCompras
    {
        public int Id { get; set; }
        public int CompraId { get; set; }
        public int CelularId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }

        [ForeignKey("CompraId")] public Compras? _Compra { get; set; }
        [ForeignKey("CelularId")] public Celulares? _Celular { get; set; }
    }
}
