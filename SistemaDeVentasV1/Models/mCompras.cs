using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaDeVentasV1.Models;

namespace SistemaDeVentasV1.Models
{
    public class mCompras
    {
        public List<DetallesCompra> detalles { get; set; }
        public Compras compra { get; set; }
        public Proveedores proveedor { get; set; }

    }
}