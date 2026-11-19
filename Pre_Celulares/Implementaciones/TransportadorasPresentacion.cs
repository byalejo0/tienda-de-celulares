using lib_Celulares.Entidades;
using Pre_Celulares.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Implementaciones
{
    public class TransportadorasPresentacion : ITransportadorasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public TransportadorasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }
        public Transportadoras Actualizar(Transportadoras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Transportadoras>(
                "Transportadoras/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Transportadoras Borrar(Transportadoras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Transportadoras>(
                "Transportadoras/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Transportadoras> Buscar(Transportadoras entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Transportadoras>>(
                "Transportadoras/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Transportadoras> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Transportadoras>>(
                "Transportadoras/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Transportadoras Insertar(Transportadoras entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Transportadoras>(
                "Transportadoras/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Transportadoras entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Correo) ||
                string.IsNullOrEmpty(entidad.Telefono);
        }

    }
}
