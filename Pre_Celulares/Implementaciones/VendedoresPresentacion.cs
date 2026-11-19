using lib_Celulares.Entidades;
using Pre_Celulares.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Implementaciones
{
    public class VendedoresPresentacion : IVendedoresPresentacion
    {
        private IComunicaciones IComunicaciones;

        public VendedoresPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }
        public Vendedores Actualizar(Vendedores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Vendedores>(
                "Vendedores/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Vendedores Borrar(Vendedores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Vendedores>(
                "Vendedores/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Vendedores> Buscar(Vendedores entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Vendedores>>(
                "Vendedores/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Vendedores> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Vendedores>>(
                "Vendedores/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Vendedores Insertar(Vendedores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Vendedores>(
                "Vendedores/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Vendedores entidad)
        {
            return string.IsNullOrEmpty(entidad.MarcaEncargada) ||
                entidad.CelularesVendidos < 0;
        }

    }
}
