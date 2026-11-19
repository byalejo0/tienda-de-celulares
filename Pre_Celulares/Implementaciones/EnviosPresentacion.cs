using lib_Celulares.Entidades;
using Pre_Celulares.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Implementaciones
{
    public class EnviosPresentacion : IEnviosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public EnviosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }
        public Envios Actualizar(Envios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Envios>(
                "Envios/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Envios Borrar(Envios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Envios>(
                "Envios/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Envios> Buscar(Envios entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Envios>>(
                "Envios/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Envios> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Envios>>(
                "Envios/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Envios Insertar(Envios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Envios>(
                "Envios/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Envios entidad)
        {
            return entidad.CostoEnvio <= 0 ||
                   entidad.FechaEnvio == null ||
                   entidad.FechaEnvio == DateTime.MinValue ||
                   entidad.FechaEntrega == null ||
                   entidad.FechaEntrega == DateTime.MinValue;
        }

    }
}
