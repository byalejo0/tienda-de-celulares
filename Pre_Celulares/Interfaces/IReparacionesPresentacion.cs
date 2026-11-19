using lib_Celulares.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Interfaces
{
    public interface IReparacionesPresentacion
    {
        Reparaciones Insertar(Reparaciones entidad);
        Reparaciones Actualizar(Reparaciones entidad);
        List<Reparaciones> Consultar();
        List<Reparaciones> Buscar(Reparaciones entidad);
        Reparaciones Borrar(Reparaciones entidad);
    }
}