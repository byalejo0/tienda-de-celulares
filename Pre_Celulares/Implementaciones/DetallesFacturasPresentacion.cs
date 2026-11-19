using lib_Celulares.Entidades;
using Pre_Celulares.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Implementaciones
{
    public class DetallesFacturasPresentacion : IDetallesFacturasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public DetallesFacturasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }
        public DetallesFacturas Actualizar(DetallesFacturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesFacturas>(
                "DetallesFacturas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public DetallesFacturas Borrar(DetallesFacturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<DetallesFacturas>(
                "DetallesFacturas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetallesFacturas> Buscar(DetallesFacturas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<DetallesFacturas>>(
                "DetallesFacturas/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetallesFacturas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<DetallesFacturas>>(
                "DetallesFacturas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public DetallesFacturas Insertar(DetallesFacturas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesFacturas>(
                "DetallesFacturas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(DetallesFacturas entidad)
        {
            return entidad.Cantidad <= 0 ||
                   entidad.Subtotal <= 0 ||
                   entidad.Iva <= 0 ||
                   entidad.Total <= 0;
        }

    }
}
