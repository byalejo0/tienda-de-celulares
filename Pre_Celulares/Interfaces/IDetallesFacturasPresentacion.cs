using lib_Celulares.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Interfaces
{
    public interface IDetallesFacturasPresentacion
    {
        DetallesFacturas Insertar(DetallesFacturas entidad);
        DetallesFacturas Actualizar(DetallesFacturas entidad);
        List<DetallesFacturas> Consultar();
        List<DetallesFacturas> Buscar(DetallesFacturas entidad);
        DetallesFacturas Borrar(DetallesFacturas entidad);
    }
}

