using System;
using System.Collections.Generic;
using System.Text;

namespace lib_Celulares.Entidades
{
    public class Proveedores
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }

        public List<Compras>? Compras { get; set; }
    }
}
