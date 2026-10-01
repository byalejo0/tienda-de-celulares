using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class Trabajadores
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public string? Experiencia { get; set; }
        public decimal Salario { get; set; }
        public string? Turno { get; set; }

        [ForeignKey("PersonaId")] public Personas? _Persona { get; set; }
        public List<Vendedores>? Vendedores { get; set; }
        public List<Tecnicos>? Tecnicos { get; set; }
        public List<Facturas>? Facturas { get; set; }
        public List<Compras>? Compras { get; set; }
    }
}
