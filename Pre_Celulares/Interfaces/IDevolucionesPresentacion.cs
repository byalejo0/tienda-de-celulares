using lib_Celulares.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Interfaces
{
    public interface IDevolucionesPresentacion
    {
        Devoluciones Insertar(Devoluciones entidad);
        Devoluciones Actualizar(Devoluciones entidad);
        List<Devoluciones> Consultar();
        List<Devoluciones> Buscar(Devoluciones entidad);
        Devoluciones Borrar(Devoluciones entidad);
    }
}

