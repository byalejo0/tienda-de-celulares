using lib_Celulares.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Interfaces
{
    public interface IBonosPresentacion
    {
        Bonos Insertar(Bonos entidad);
        Bonos Actualizar(Bonos entidad);
        List<Bonos> Consultar();
        List<Bonos> Buscar(Bonos entidad);
        Bonos Borrar(Bonos entidad);
    }
}

