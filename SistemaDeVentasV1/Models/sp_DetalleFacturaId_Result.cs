//------------------------------------------------------------------------------
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
    
    public partial class sp_DetalleFacturaId_Result
    {
        public int idFactura { get; set; }
        public string nitCliente { get; set; }
        public System.DateTime fecha { get; set; }
        public int idDetalle { get; set; }
        public string idProducto { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public Nullable<decimal> subTotal { get; set; }
        public Nullable<decimal> total { get; set; }
        public string usuario { get; set; }
    }
}
