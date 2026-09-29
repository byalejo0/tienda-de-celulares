using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_Celulares.Implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Bonos>? Bonos { get; set; }
        public DbSet<Celulares>? Celulares { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Componentes>? Componentes { get; set; }
        public DbSet<Compras>? Compras { get; set; }
        public DbSet<DetallesCompras>? DetallesCompras { get; set; }
        public DbSet<DetallesFacturas>? DetallesFacturas { get; set; }
        public DbSet<DetallesReparaciones>? DetallesReparaciones { get; set; }
        public DbSet<Devoluciones>? Devoluciones { get; set; }
        public DbSet<Envios>? Envios { get; set; }
        public DbSet<Facturas>? Facturas { get; set; }
        public DbSet<Garantias>? Garantias { get; set; }
        public DbSet<Marcas>? Marcas { get; set; }
        public DbSet<Personas>? Personas { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Reparaciones>? Reparaciones { get; set; }
        public DbSet<Tecnicos>? Teecnicos { get; set; }
        public DbSet<Trabajadores>? Trabajadores { get; set; }
        public DbSet<Transportadoras>? Transportadoras { get; set; }
        public DbSet<Vendedores>? Vendedores { get; set; }
    }
}
