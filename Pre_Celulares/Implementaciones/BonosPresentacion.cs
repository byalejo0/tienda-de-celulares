using lib_Celulares.Entidades;
using Pre_Celulares.Interfaces;
using lib_Celulares.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Implementaciones
{
    public class BonosPresentacion : IBonosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public BonosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }
        public Bonos Actualizar(Bonos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Bonos>(
                "Bonos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Bonos Borrar(Bonos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Bonos>(
                "Bonos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Bonos> Buscar(Bonos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Bonos>>(
                "Bonos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Bonos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Bonos>>(
                "Bonos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Bonos Insertar(Bonos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Bonos>(
                "Bonos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Bonos entidad)
        {
            return entidad.CantidadReparaciones < 0 || 
                   entidad.ValorBono < 0 ;
        }

    }
}
