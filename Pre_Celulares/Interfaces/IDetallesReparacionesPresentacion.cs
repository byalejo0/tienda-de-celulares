using lib_Celulares.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Interfaces
{
    public interface IDetallesReparacionesPresentacion
    {
        DetallesReparaciones Insertar(DetallesReparaciones entidad);
        DetallesReparaciones Actualizar(DetallesReparaciones entidad);
        List<DetallesReparaciones> Consultar();
        List<DetallesReparaciones> Buscar(DetallesReparaciones entidad);
        DetallesReparaciones Borrar(DetallesReparaciones entidad);
    }
}

