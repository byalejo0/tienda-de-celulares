using lib_Celulares.Entidades;
using Pre_Celulares.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Implementaciones
{
    public class MarcasPresentacion : IMarcasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public MarcasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }
        public Marcas Actualizar(Marcas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Marcas>(
                "Marcas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Marcas Borrar(Marcas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Marcas>(
                "Marcas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Marcas> Buscar(Marcas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Marcas>>(
                "Marcas/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Marcas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Marcas>>(
                "Marcas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Marcas Insertar(Marcas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Marcas>(
                "Marcas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Marcas entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Telefono) ||
                string.IsNullOrEmpty(entidad.Correo) ||
                string.IsNullOrEmpty(entidad.Direccion);
        }

    }
}
