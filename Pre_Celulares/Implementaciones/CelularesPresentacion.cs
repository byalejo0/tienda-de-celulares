using lib_Celulares.Entidades;
using Pre_Celulares.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pre_Celulares.Implementaciones
{
    public class CelularesPresentacion : ICelularesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public CelularesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }
        public Celulares Actualizar(Celulares entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Celulares>(
                "Celulares/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Celulares Borrar(Celulares entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Celulares>(
                "Celulares/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Celulares> Buscar(Celulares entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Celulares>>(
                "Celulares/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Celulares> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Celulares>>(
                "Celulares/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Celulares Insertar(Celulares entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Celulares>(
                "Celulares/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Celulares entidad)
        {
            return string.IsNullOrEmpty(entidad.Color) ||
                string.IsNullOrEmpty(entidad.Modelo) ||
                string.IsNullOrEmpty(entidad.Almacenamiento) ||
                entidad.CantidadDisponible < 0 ||
                entidad.Precio <= 0;
        }

    }
}
