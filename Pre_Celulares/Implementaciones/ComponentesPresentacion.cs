using lib_Celulares.Entidades;
using Pre_Celulares.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pre_Celulares.Implementaciones
{
    public class ComponentesPresentacion : IComponentesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ComponentesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }
        public Componentes Actualizar(Componentes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Componentes>(
                "Componentes/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Componentes Borrar(Componentes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Componentes>(
                "Componentes/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Componentes> Buscar(Componentes entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Componentes>>(
                "Componentes/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Componentes> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Componentes>>(
                "Componentes/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Componentes Insertar(Componentes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Componentes>(
                "Componentes/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Componentes entidad)
        {
           return string.IsNullOrEmpty(entidad.Procesador) ||
           string.IsNullOrEmpty(entidad.MemoriaRam) ||
           string.IsNullOrEmpty(entidad.Pantalla) ||
           string.IsNullOrEmpty(entidad.Bateria) ||
           string.IsNullOrEmpty(entidad.Camara) ||
           string.IsNullOrEmpty(entidad.SistemaOperativo);
        }

    }
}
