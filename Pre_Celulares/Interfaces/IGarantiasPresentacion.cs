using lib_Celulares.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Interfaces
{
    public interface IGarantiasPresentacion
    {
        Garantias Insertar(Garantias entidad);
        Garantias Actualizar(Garantias entidad);
        List<Garantias> Consultar();
        List<Garantias> Buscar(Garantias entidad);
        Garantias Borrar(Garantias entidad);
    }
}

