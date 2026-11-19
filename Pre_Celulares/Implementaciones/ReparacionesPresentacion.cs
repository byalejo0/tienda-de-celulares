using lib_Celulares.Entidades;
using Pre_Celulares.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Implementaciones
{
    public class ReparacionesPresentacion : IReparacionesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ReparacionesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }
        public Reparaciones Actualizar(Reparaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Reparaciones>(
                "Reparaciones/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Reparaciones Borrar(Reparaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Reparaciones>(
                "Reparaciones/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Reparaciones> Buscar(Reparaciones entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Reparaciones>>(
                "Reparaciones/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Reparaciones> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Reparaciones>>(
                "Reparaciones/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Reparaciones Insertar(Reparaciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Reparaciones>(
                "Reparaciones/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Reparaciones entidad)
        {
            return string.IsNullOrEmpty(entidad.Estado) ||
                    entidad.FechaIngreso == null ||
                    entidad.FechaIngreso == DateTime.MinValue ||
                    entidad.FechaIngreso > DateTime.Now||

                     entidad.FechaEntrega == null ||
                     entidad.FechaEntrega == DateTime.MinValue; 
        }

    }
}
