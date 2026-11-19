using lib_Celulares.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Interfaces
{
    public interface IComponentesPresentacion
    {
        Componentes Insertar(Componentes entidad);
        Componentes Actualizar(Componentes entidad);
        List<Componentes> Consultar();
        List<Componentes> Buscar(Componentes entidad);
        Componentes Borrar(Componentes entidad);
    }
}

