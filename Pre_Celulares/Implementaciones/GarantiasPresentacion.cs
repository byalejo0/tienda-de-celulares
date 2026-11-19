using lib_Celulares.Entidades;
using Pre_Celulares.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Implementaciones
{
    public class GarantiasPresentacion : IGarantiasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public GarantiasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }
        public Garantias Actualizar(Garantias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Garantias>(
                "Garantias/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Garantias Borrar(Garantias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Garantias>(
                "Garantias/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Garantias> Buscar(Garantias entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Garantias>>(
                "Garantias/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Garantias> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Garantias>>(
                "Garantias/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Garantias Insertar(Garantias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Garantias>(
                "Garantias/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Garantias entidad)
        {
            return string.IsNullOrEmpty(entidad.TipoGarantia) ||
                   string.IsNullOrEmpty(entidad.Estado) ||
                    entidad.FechaInicio == null ||
                    entidad.FechaInicio == DateTime.MinValue ||

                    entidad.FechaVencimiento == null ||
                    entidad.FechaVencimiento == DateTime.MinValue;
        }

    }
}
