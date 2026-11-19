using lib_Celulares.Entidades;
using Pre_Celulares.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Implementaciones
{
    public class DetallesReparacionesPresentacion : IDetallesReparacionesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public DetallesReparacionesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }
        public DetallesReparaciones Actualizar(DetallesReparaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesReparaciones>(
                "DetallesReparaciones/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public DetallesReparaciones Borrar(DetallesReparaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<DetallesReparaciones>(
                "DetallesReparaciones/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetallesReparaciones> Buscar(DetallesReparaciones entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<DetallesReparaciones>>(
                "DetallesReparaciones/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetallesReparaciones> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<DetallesReparaciones>>(
                "DetallesReparaciones/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public DetallesReparaciones Insertar(DetallesReparaciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesReparaciones>(
                "DetallesReparaciones/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(DetallesReparaciones entidad)
        {
            return string.IsNullOrEmpty(entidad.Diagnostico) ||
                string.IsNullOrEmpty(entidad.ServicioRealizado) ||
                string.IsNullOrEmpty(entidad.ComponenteReemplazado) ||
                entidad.Cantidad < 0 ||
                entidad.Precio <= 0 ||
                entidad.Subtotal <= 0;
        }

    }
}
