using lib_Celulares.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Interfaces
{
    public interface IMarcasPresentacion
    {
        Marcas Insertar(Marcas entidad);
        Marcas Actualizar(Marcas entidad);
        List<Marcas> Consultar();
        List<Marcas> Buscar(Marcas entidad);
        Marcas Borrar(Marcas entidad);
    }
}
