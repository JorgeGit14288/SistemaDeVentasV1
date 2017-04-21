using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeVentasV1.Models;

namespace SistemaDeVentasV1.Dao
{
    interface IDetallesDao
    {
        bool Crear(Detalles d);
        bool Actualizar(Detalles d);
        bool Eliminar(int idFactura, int idDetalle);
        Detalles Buscar(int idFactura, int idDetalle);
        List<Detalles> DetallesFactura(int idFactura);
        bool ExisteDetalle(int idFactura, int idDetalle);

    }
}
