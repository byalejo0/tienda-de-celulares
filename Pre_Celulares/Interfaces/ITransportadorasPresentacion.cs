using lib_Celulares.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Interfaces
{
    public interface ITransportadorasPresentacion
    {
        Transportadoras Insertar(Transportadoras entidad);
        Transportadoras Actualizar(Transportadoras entidad);
        List<Transportadoras> Consultar();
        List<Transportadoras> Buscar(Transportadoras entidad);
        Transportadoras Borrar(Transportadoras entidad);
    }
}

