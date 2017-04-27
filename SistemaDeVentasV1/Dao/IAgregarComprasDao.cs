using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeVentasV1.Models;

namespace SistemaDeVentasV1.Dao
{
    interface IAgregarComprasDao
    {
        bool Crear(mCompras mc);
        mCompras BuscarCompra(int idCompra);

    }
}
