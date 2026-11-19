using lib_Celulares.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Interfaces
{
    public interface IComprasPresentacion
    {
        Compras Insertar(Compras entidad);
        Compras Actualizar(Compras entidad);
        List<Compras> Consultar();
        List<Compras> Buscar(Compras entidad);
        Compras Borrar(Compras entidad);
    }
}

