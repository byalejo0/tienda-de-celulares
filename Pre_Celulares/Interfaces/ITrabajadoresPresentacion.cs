using lib_Celulares.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Interfaces
{
    public interface ITrabajadoresPresentacion
    {
        Trabajadores Insertar(Trabajadores entidad);
        Trabajadores Actualizar(Trabajadores entidad);
        List<Trabajadores> Consultar();
        List<Trabajadores> Buscar(Trabajadores entidad);
        Trabajadores Borrar(Trabajadores entidad);
    }
}