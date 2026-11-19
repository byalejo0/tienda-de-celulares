using lib_Celulares.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Interfaces
{
    public interface IVendedoresPresentacion
    {
        Vendedores Insertar(Vendedores entidad);
        Vendedores Actualizar(Vendedores entidad);
        List<Vendedores> Consultar();
        List<Vendedores> Buscar(Vendedores entidad);
        Vendedores Borrar(Vendedores entidad);
    }
}