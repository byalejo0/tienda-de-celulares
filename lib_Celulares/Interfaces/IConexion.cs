using lib_Celulares.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_Celulares.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Bonos>? Bonos { get; set; }
        DbSet<Celulares>? Celulares { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Componentes>? Componentes { get; set; }
        DbSet<Compras>? Compras { get; set; }
        DbSet<DetallesCompras>? DetallesCompras { get; set; }
        DbSet<DetallesFacturas>? DetallesFacturas { get; set; }
        DbSet<DetallesReparaciones>? DetallesReparaciones { get; set; }
        DbSet<Devoluciones>? Devoluciones { get; set; }
        DbSet<Envios>? Envios { get; set; }
        DbSet<Facturas>? Facturas { get; set; }
        DbSet<Garantias>? Garantias { get; set; }
        DbSet<Marcas>? Marcas { get; set; }
        DbSet<Personas>? Personas { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<Reparaciones>? Reparaciones { get; set; }
        DbSet<Tecnicos>? Tecnicos { get; set; }
        DbSet<Trabajadores>? Trabajadores { get; set; }
        DbSet<Transportadoras>? Transportadoras { get; set; }
        DbSet<Vendedores>? Vendedores { get; set; }
    }
}

