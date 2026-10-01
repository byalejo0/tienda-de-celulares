using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class Celulares
    {
        public int Id { get; set; }
        public int MarcaId { get; set; }
        public int ComponenteId { get; set; }
        public bool Disponible { get; set; }
        public int CantidadDisponible { get; set; }
        public string? Color { get; set; }
        public decimal Precio { get; set; }
        public string? Modelo { get; set; }
        public string? Almacenamiento { get; set; }

        [ForeignKey("MarcaId")] public Marcas? _Marca { get; set; }
        [ForeignKey("ComponenteId")] public Componentes? _Componente { get; set; }
        public List<Garantias>? Garantias { get; set; }
        public List<DetallesFacturas>? DetallesFacturas { get; set; }
        public List<Reparaciones>? Reparaciones { get; set; }
        public List<DetallesCompras>? DetallesCompras { get; set; }
    }
}
