using lib_Celulares.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Interfaces
{
    public interface IEnviosPresentacion
    {
        Envios Insertar(Envios entidad);
        Envios Actualizar(Envios entidad);
        List<Envios> Consultar();
        List<Envios> Buscar(Envios entidad);
        Envios Borrar(Envios entidad);
    }
}

