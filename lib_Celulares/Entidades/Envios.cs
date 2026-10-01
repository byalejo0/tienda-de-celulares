using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class Envios
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int TransportadoraId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaEnvio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal CostoEnvio { get; set; }

        [ForeignKey("FacturaId")] public Facturas? _Factura { get; set; }
        [ForeignKey("TransportadoraId")] public Transportadoras? _Transportadora { get; set; }
        [ForeignKey("ClienteId")] public Clientes? _Cliente { get; set; }
    }
}
