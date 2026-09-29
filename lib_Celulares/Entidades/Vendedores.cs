using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class Vendedores
    {
        public int Id { get; set; }
        public int TrabajadorId { get; set; }
        public int CelularesVendidos { get; set; }
        public string? MarcaEncargada { get; set; }

        [ForeignKey("TrabajadorId")] public Trabajadores? Trabajador { get; set; }
    }
}
