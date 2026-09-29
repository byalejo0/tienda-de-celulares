using System;
using System.Collections.Generic;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class Componentes
    {
        public int Id { get; set; }
        public string? Procesador { get; set; }
        public string? MemoriaRam { get; set; }
        public string? Pantalla { get; set; }
        public string? Bateria { get; set; }
        public string? Camara { get; set; }
        public string? SistemaOperativo { get; set; }

        public List<Celulares>? Celulares { get; set; }
    }
}
