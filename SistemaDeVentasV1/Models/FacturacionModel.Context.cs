﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaDeVentasV1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FacturacionDbEntities : DbContext
    {
        public FacturacionDbEntities()
            : base("name=FacturacionDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Detalles> Detalles { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<DetallesCompra> DetallesCompra { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
    
        public virtual int sp_ActualizarCliente(string nit, string nombre, string direccion, string telefono)
        {
            var nitParameter = nit != null ?
                new ObjectParameter("nit", nit) :
                new ObjectParameter("nit", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("direccion", direccion) :
                new ObjectParameter("direccion", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ActualizarCliente", nitParameter, nombreParameter, direccionParameter, telefonoParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_ActualizarDetalle(Nullable<int> idDetalle, Nullable<int> idFactura, string idProducto, Nullable<decimal> precio, Nullable<decimal> subTotal, Nullable<decimal> cantidad)
        {
            var idDetalleParameter = idDetalle.HasValue ?
                new ObjectParameter("idDetalle", idDetalle) :
                new ObjectParameter("idDetalle", typeof(int));
    
            var idFacturaParameter = idFactura.HasValue ?
                new ObjectParameter("idFactura", idFactura) :
                new ObjectParameter("idFactura", typeof(int));
    
            var idProductoParameter = idProducto != null ?
                new ObjectParameter("idProducto", idProducto) :
                new ObjectParameter("idProducto", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(decimal));
    
            var subTotalParameter = subTotal.HasValue ?
                new ObjectParameter("subTotal", subTotal) :
                new ObjectParameter("subTotal", typeof(decimal));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("cantidad", cantidad) :
                new ObjectParameter("cantidad", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_ActualizarDetalle", idDetalleParameter, idFacturaParameter, idProductoParameter, precioParameter, subTotalParameter, cantidadParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_ActualizarFactura(Nullable<int> idFactura, Nullable<decimal> total)
        {
            var idFacturaParameter = idFactura.HasValue ?
                new ObjectParameter("idFactura", idFactura) :
                new ObjectParameter("idFactura", typeof(int));
    
            var totalParameter = total.HasValue ?
                new ObjectParameter("total", total) :
                new ObjectParameter("total", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_ActualizarFactura", idFacturaParameter, totalParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> sp_ActualizarProducto(string idProducto, string nombre, Nullable<decimal> precio, Nullable<decimal> existencia, string observaciones, byte[] imagen)
        {
            var idProductoParameter = idProducto != null ?
                new ObjectParameter("idProducto", idProducto) :
                new ObjectParameter("idProducto", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(decimal));
    
            var existenciaParameter = existencia.HasValue ?
                new ObjectParameter("existencia", existencia) :
                new ObjectParameter("existencia", typeof(decimal));
    
            var observacionesParameter = observaciones != null ?
                new ObjectParameter("observaciones", observaciones) :
                new ObjectParameter("observaciones", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("imagen", imagen) :
                new ObjectParameter("imagen", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("sp_ActualizarProducto", idProductoParameter, nombreParameter, precioParameter, existenciaParameter, observacionesParameter, imagenParameter);
        }
    
        public virtual int sp_ActualizarUsuario(string email, string pass, string nombre)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ActualizarUsuario", emailParameter, passParameter, nombreParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual ObjectResult<sp_BuscarClienteNit_Result> sp_BuscarClienteNit(string nit)
        {
            var nitParameter = nit != null ?
                new ObjectParameter("nit", nit) :
                new ObjectParameter("nit", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_BuscarClienteNit_Result>("sp_BuscarClienteNit", nitParameter);
        }
    
        public virtual ObjectResult<sp_BuscarClienteNombre_Result> sp_BuscarClienteNombre(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_BuscarClienteNombre_Result>("sp_BuscarClienteNombre", nombreParameter);
        }
    
        public virtual ObjectResult<sp_BuscarFacturaId_Result> sp_BuscarFacturaId(Nullable<int> idFactura)
        {
            var idFacturaParameter = idFactura.HasValue ?
                new ObjectParameter("idFactura", idFactura) :
                new ObjectParameter("idFactura", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_BuscarFacturaId_Result>("sp_BuscarFacturaId", idFacturaParameter);
        }
    
        public virtual ObjectResult<sp_BuscarFacturanit_Result> sp_BuscarFacturanit(string nitCliente)
        {
            var nitClienteParameter = nitCliente != null ?
                new ObjectParameter("nitCliente", nitCliente) :
                new ObjectParameter("nitCliente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_BuscarFacturanit_Result>("sp_BuscarFacturanit", nitClienteParameter);
        }
    
        public virtual ObjectResult<sp_BuscarProductoId_Result> sp_BuscarProductoId(string idProducto)
        {
            var idProductoParameter = idProducto != null ?
                new ObjectParameter("idProducto", idProducto) :
                new ObjectParameter("idProducto", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_BuscarProductoId_Result>("sp_BuscarProductoId", idProductoParameter);
        }
    
        public virtual ObjectResult<sp_BuscarUsuario_Result> sp_BuscarUsuario(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_BuscarUsuario_Result>("sp_BuscarUsuario", emailParameter);
        }
    
        public virtual int sp_CrearCliente(string nit, string nombre, string direccion, string telefono)
        {
            var nitParameter = nit != null ?
                new ObjectParameter("nit", nit) :
                new ObjectParameter("nit", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("direccion", direccion) :
                new ObjectParameter("direccion", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CrearCliente", nitParameter, nombreParameter, direccionParameter, telefonoParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_CrearDetalle(Nullable<int> idDetalle, Nullable<int> idFactura, string idProducto, Nullable<decimal> precio, Nullable<decimal> subTotal, Nullable<decimal> cantidad)
        {
            var idDetalleParameter = idDetalle.HasValue ?
                new ObjectParameter("idDetalle", idDetalle) :
                new ObjectParameter("idDetalle", typeof(int));
    
            var idFacturaParameter = idFactura.HasValue ?
                new ObjectParameter("idFactura", idFactura) :
                new ObjectParameter("idFactura", typeof(int));
    
            var idProductoParameter = idProducto != null ?
                new ObjectParameter("idProducto", idProducto) :
                new ObjectParameter("idProducto", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(decimal));
    
            var subTotalParameter = subTotal.HasValue ?
                new ObjectParameter("subTotal", subTotal) :
                new ObjectParameter("subTotal", typeof(decimal));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("cantidad", cantidad) :
                new ObjectParameter("cantidad", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_CrearDetalle", idDetalleParameter, idFacturaParameter, idProductoParameter, precioParameter, subTotalParameter, cantidadParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_CrearFactura(Nullable<int> idFactura, string nitCliente, Nullable<System.DateTime> fecha, Nullable<decimal> total, string usuario)
        {
            var idFacturaParameter = idFactura.HasValue ?
                new ObjectParameter("idFactura", idFactura) :
                new ObjectParameter("idFactura", typeof(int));
    
            var nitClienteParameter = nitCliente != null ?
                new ObjectParameter("nitCliente", nitCliente) :
                new ObjectParameter("nitCliente", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            var totalParameter = total.HasValue ?
                new ObjectParameter("total", total) :
                new ObjectParameter("total", typeof(decimal));
    
            var usuarioParameter = usuario != null ?
                new ObjectParameter("usuario", usuario) :
                new ObjectParameter("usuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_CrearFactura", idFacturaParameter, nitClienteParameter, fechaParameter, totalParameter, usuarioParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> sp_CrearProducto(string idProducto, string nombre, Nullable<decimal> precio, Nullable<decimal> existencia, string observaciones, byte[] imagen)
        {
            var idProductoParameter = idProducto != null ?
                new ObjectParameter("idProducto", idProducto) :
                new ObjectParameter("idProducto", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(decimal));
    
            var existenciaParameter = existencia.HasValue ?
                new ObjectParameter("existencia", existencia) :
                new ObjectParameter("existencia", typeof(decimal));
    
            var observacionesParameter = observaciones != null ?
                new ObjectParameter("observaciones", observaciones) :
                new ObjectParameter("observaciones", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("imagen", imagen) :
                new ObjectParameter("imagen", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("sp_CrearProducto", idProductoParameter, nombreParameter, precioParameter, existenciaParameter, observacionesParameter, imagenParameter);
        }
    
        public virtual int sp_CrearUsuario(string email, string pass, string nombre)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CrearUsuario", emailParameter, passParameter, nombreParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual ObjectResult<sp_DetalleFacturaId_Result> sp_DetalleFacturaId(Nullable<int> idFactura)
        {
            var idFacturaParameter = idFactura.HasValue ?
                new ObjectParameter("idFactura", idFactura) :
                new ObjectParameter("idFactura", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_DetalleFacturaId_Result>("sp_DetalleFacturaId", idFacturaParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_EliminarCliente(string nit)
        {
            var nitParameter = nit != null ?
                new ObjectParameter("nit", nit) :
                new ObjectParameter("nit", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EliminarCliente", nitParameter);
        }
    
        public virtual int sp_EliminarDetalles(Nullable<int> idDetalle, Nullable<int> idFactura)
        {
            var idDetalleParameter = idDetalle.HasValue ?
                new ObjectParameter("idDetalle", idDetalle) :
                new ObjectParameter("idDetalle", typeof(int));
    
            var idFacturaParameter = idFactura.HasValue ?
                new ObjectParameter("idFactura", idFactura) :
                new ObjectParameter("idFactura", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EliminarDetalles", idDetalleParameter, idFacturaParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_EliminarFactura(Nullable<int> idFactura)
        {
            var idFacturaParameter = idFactura.HasValue ?
                new ObjectParameter("idFactura", idFactura) :
                new ObjectParameter("idFactura", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_EliminarFactura", idFacturaParameter);
        }
    
        public virtual int sp_EliminarProducto(string idProducto)
        {
            var idProductoParameter = idProducto != null ?
                new ObjectParameter("idProducto", idProducto) :
                new ObjectParameter("idProducto", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EliminarProducto", idProductoParameter);
        }
    
        public virtual int sp_EliminarUsuario(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EliminarUsuario", emailParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_ListarClientes_Result> sp_ListarClientes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ListarClientes_Result>("sp_ListarClientes");
        }
    
        public virtual ObjectResult<sp_ListarDetalles_Result> sp_ListarDetalles()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ListarDetalles_Result>("sp_ListarDetalles");
        }
    
        public virtual ObjectResult<Nullable<int>> sp_ListarDetallesId(Nullable<int> idDetalle, Nullable<int> idFactura)
        {
            var idDetalleParameter = idDetalle.HasValue ?
                new ObjectParameter("idDetalle", idDetalle) :
                new ObjectParameter("idDetalle", typeof(int));
    
            var idFacturaParameter = idFactura.HasValue ?
                new ObjectParameter("idFactura", idFactura) :
                new ObjectParameter("idFactura", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_ListarDetallesId", idDetalleParameter, idFacturaParameter);
        }
    
        public virtual ObjectResult<sp_ListarProductos_Result> sp_ListarProductos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ListarProductos_Result>("sp_ListarProductos");
        }
    
        public virtual ObjectResult<sp_ListarUsuarios_Result> sp_ListarUsuarios()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ListarUsuarios_Result>("sp_ListarUsuarios");
        }
    
        public virtual int sp_LoginUsuario(string email, string pass)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_LoginUsuario", emailParameter, passParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_ObtenerIdFactura()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_ObtenerIdFactura");
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
