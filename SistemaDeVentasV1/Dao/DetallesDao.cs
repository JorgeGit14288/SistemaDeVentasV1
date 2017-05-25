using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaDeVentasV1.Models;

namespace SistemaDeVentasV1.Dao
{
    public class DetallesDao : IDetallesDao
    {
        FacturacionDbEntities ctx = new FacturacionDbEntities();
        public bool Actualizar(Detalles d)
        {
            throw new NotImplementedException();
        }

        public Detalles Buscar(int idFactura, int idDetalle)
        {
            throw new NotImplementedException();
        }

        public bool Crear(Detalles d)
        {
            try
            {
                ctx.Detalles.Add(d);
                ctx.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public List<Detalles> DetallesFactura(int idFactura)
        {
            List<Detalles> lista = new List<Detalles>();
            try
            {
                var query = (from d in ctx.Detalles where d.idFactura == idFactura select d);
                return lista = query.ToList();
                
            }
            catch
            {
                return lista;

            }

          
        }

        public bool Eliminar(int idFactura, int idDetalle)
        {
            throw new NotImplementedException();
        }

        public bool ExisteDetalle(int idFactura, int idDetalle)
        {
            throw new NotImplementedException();
        }
    }
}