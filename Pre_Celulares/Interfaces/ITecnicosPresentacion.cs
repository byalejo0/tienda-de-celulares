using lib_Celulares.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Interfaces
{
    public interface ITecnicosPresentacion
    {
        Tecnicos Insertar(Tecnicos entidad);
        Tecnicos Actualizar(Tecnicos entidad);
        List<Tecnicos> Consultar();
        List<Tecnicos> Buscar(Tecnicos entidad);
        Tecnicos Borrar(Tecnicos entidad);
    }
}