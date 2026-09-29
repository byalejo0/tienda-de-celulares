using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;


namespace lib_Celulares.Entidades
{
    public class Clientes
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public string? TipoCliente { get; set; }
        public string? PaisResidencia { get; set; }
        public string? Correo { get; set; }

        [ForeignKey("PersonaId")] public Personas? _Persona { get; set; }
        public List<Facturas>? Facturas { get; set; }
        public List<Garantias>? Garantias { get; set; }
        public List<Envios>? Envios { get; set; }
        public List<Devoluciones>? Devoluciones { get; set; }
        public List<Reparaciones>? Reparaciones { get; set; }
    }
}
