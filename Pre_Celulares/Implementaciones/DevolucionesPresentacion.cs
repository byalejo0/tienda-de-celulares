using lib_Celulares.Entidades;
using Pre_Celulares.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Implementaciones
{
    public class DevolucionesPresentacion : IDevolucionesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public DevolucionesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }
        public Devoluciones Actualizar(Devoluciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Devoluciones>(
                "Devoluciones/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Devoluciones Borrar(Devoluciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Devoluciones>(
                "Devoluciones/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Devoluciones> Buscar(Devoluciones entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Devoluciones>>(
                "Devoluciones/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Devoluciones> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Devoluciones>>(
                "Devoluciones/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Devoluciones Insertar(Devoluciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Devoluciones>(
                "Devoluciones/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Devoluciones entidad)
        {
            return string.IsNullOrEmpty(entidad.Motivo) ||
                entidad.ValorDevuelto <= 0 ||
                entidad.FechaDevolucion == null ||
                entidad.FechaDevolucion == DateTime.MinValue ||
                entidad.FechaDevolucion > DateTime.Now; 
        }

    }
}
