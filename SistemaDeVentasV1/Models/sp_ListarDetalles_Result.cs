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
    
    public partial class sp_ListarDetalles_Result
    {
        public int idDetalle { get; set; }
        public int idFactura { get; set; }
        public string idProducto { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }
        public Nullable<decimal> subTotal { get; set; }
    }
}
