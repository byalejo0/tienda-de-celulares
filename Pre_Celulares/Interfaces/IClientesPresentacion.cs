using lib_Celulares.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Interfaces
{
    public interface IClientesPresentacion
    {
        Clientes Insertar(Clientes entidad);
        Clientes Actualizar(Clientes entidad);
        List<Clientes> Consultar();
        List<Clientes> Buscar(Clientes entidad);
        Clientes Borrar(Clientes entidad);
    }
}

