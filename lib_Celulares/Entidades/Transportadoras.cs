using System;
using System.Collections.Generic;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class Transportadoras
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }

        public List<Envios>? Envios { get; set; }
    }
}
