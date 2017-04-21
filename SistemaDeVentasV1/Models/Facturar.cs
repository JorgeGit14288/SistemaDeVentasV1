using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeVentasV1.Models
{
    public class Facturar
    {
        public Facturas factura { get; set; }
        public List<Detalles> detalles { get; set; }
        public Clientes cliente { get; set; }
    }
}