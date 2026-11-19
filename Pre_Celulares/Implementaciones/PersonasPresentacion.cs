using lib_Celulares.Entidades;
using Pre_Celulares.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Implementaciones
{
    public class PersonasPresentacion : IPersonasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public PersonasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }
        public Personas Actualizar(Personas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Personas>(
                "Personas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Personas Borrar(Personas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Personas>(
                "Personas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Personas> Buscar(Personas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Personas>>(
                "Personas/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Personas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Personas>>(
                "Personas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Personas Insertar(Personas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Personas>(
                "Personas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Personas entidad)
        {
            return string.IsNullOrEmpty(entidad.Cedula) ||
                string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Direccion) ||
                entidad.Edad <= 0;
        }

    }
}
