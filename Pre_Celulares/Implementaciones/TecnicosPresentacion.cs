using lib_Celulares.Entidades;
using Pre_Celulares.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Implementaciones
{
    public class TecnicosPresentacion : ITecnicosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public TecnicosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }
        public Tecnicos Actualizar(Tecnicos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Tecnicos>(
                "Tecnicos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Tecnicos Borrar(Tecnicos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Tecnicos>(
                "Tecnicos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Tecnicos> Buscar(Tecnicos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Tecnicos>>(
                "Tecnicos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Tecnicos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Tecnicos>>(
                "Tecnicos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Tecnicos Insertar(Tecnicos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Tecnicos>(
                "Tecnicos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Tecnicos entidad)
        {
            return string.IsNullOrEmpty(entidad.Especializacion) ||
                entidad.CelularesReparados < 0;
        }

    }
}
