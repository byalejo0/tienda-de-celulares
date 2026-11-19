using lib_Celulares.Entidades;
using Pre_Celulares.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Implementaciones
{
    public class ComprasPresentacion : IComprasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ComprasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }
        public Compras Actualizar(Compras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Compras>(
                "Compras/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Compras Borrar(Compras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Compras>(
                "Compras/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Compras> Buscar(Compras entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Compras>>(
                "Compras/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Compras> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Compras>>(
                "Compras/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Compras Insertar(Compras entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Compras>(
                "Compras/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Compras entidad)
        {
            return string.IsNullOrEmpty(entidad.Estado) ||
                entidad.Total <= 0 ||
                entidad.FechaCompra == null || 
                entidad.FechaCompra == DateTime.MinValue ||
                entidad.FechaCompra > DateTime.Now;
        }

    }
}
