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
    
    public partial class sp_ListarProductos_Result
    {
        public string idProducto { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public decimal existencia { get; set; }
        public string observacion { get; set; }
        public byte[] imagen { get; set; }
    }
}
