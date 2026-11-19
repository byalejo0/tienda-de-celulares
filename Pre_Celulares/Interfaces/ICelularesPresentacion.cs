using lib_Celulares.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Interfaces
{
    public interface ICelularesPresentacion
    {
        Celulares Insertar(Celulares entidad);
        Celulares Actualizar(Celulares entidad);
        List<Celulares> Consultar();
        List<Celulares> Buscar(Celulares entidad);
        Celulares Borrar(Celulares entidad);
    }
}

