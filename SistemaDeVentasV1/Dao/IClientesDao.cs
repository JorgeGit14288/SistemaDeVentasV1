using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeVentasV1.Models;

namespace SistemaDeVentasV1.Dao
{
    interface IClientesDao
    {
        bool Crear(Clientes c);
        bool Actualizar(Clientes a);
        bool Eliminar(string nit);
        Clientes BuscarNit(string nit);
        Clientes BuscarNombre(String nombre);
        List<Clientes> Listar();
        bool ExisteCliente(string nit);
    }
}
