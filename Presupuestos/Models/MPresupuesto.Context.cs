﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Presupuestos.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbPresupuestosEntities : DbContext
    {
        public dbPresupuestosEntities()
            : base("name=dbPresupuestosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TblEmpresa> TblEmpresas { get; set; }
        public virtual DbSet<TblUsuario> TblUsuarios { get; set; }
        public virtual DbSet<TblCliente> TblClientes { get; set; }
        public virtual DbSet<TblEmpleado> TblEmpleados { get; set; }
        public virtual DbSet<TblConcepto> TblConceptos { get; set; }
        public virtual DbSet<TblProyecto> TblProyectos { get; set; }
        public virtual DbSet<TblProyectosEmpleado> TblProyectosEmpleados { get; set; }
        public virtual DbSet<TblEstatu> TblEstatus { get; set; }
    }
}