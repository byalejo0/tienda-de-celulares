using System;
using System.Collections.Generic;
using System.Text;

namespace lib_Celulares.Entidades
{
        public class Personas
        {
            public int Id { get; set; }
            public string? Cedula { get; set; }
            public string? Nombre { get; set; }
            public int Edad { get; set; }
            public string? Direccion { get; set; }

            public List<Clientes>? Clientes { get; set; }
            public List<Trabajadores>? Trabajadores { get; set; }
        }
    
}
