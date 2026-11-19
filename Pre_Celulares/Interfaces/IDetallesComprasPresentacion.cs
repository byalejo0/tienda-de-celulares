using lib_Celulares.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Interfaces
{
    public interface IDetallesComprasPresentacion
    {
        DetallesCompras Insertar(DetallesCompras entidad);
        DetallesCompras Actualizar(DetallesCompras entidad);
        List<DetallesCompras> Consultar();
        List<DetallesCompras> Buscar(DetallesCompras entidad);
        DetallesCompras Borrar(DetallesCompras entidad);
    }
}

