using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaDeVentasV1.Models;
using SistemaDeVentasV1.Dao;

namespace SistemaDeVentasV1.Controllers
{
    public class FacturarController : Controller
    {
        // objetos de acceso a datoa
        IFacturarDao daoFacturar = new FacturarDao();
        IFacturasDao daoFacturas = new FacturasDao();
        IClientesDao daoClientes = new ClientesDao();
        IProductosDao daoProductos = new ProductosDao();


        // GET: Facturar
        public ActionResult Facturar()
        {
            //ViewBag.Mensaje = "Todos los campos son requeridos";
            //obtenermos el id de factura 
            int idFactura = daoFacturas.GetIdFactura();
            if(idFactura==0)
            {
                idFactura = 1;
            }
            Session["idFactura"] = idFactura;

            //ViewBag.idProducto = new SelectList(daoProductos.Listar(), "nombre", "precio","existencia");
            // le devolvemos la lista de clientes
            ViewBag.Clientes = daoClientes.Listar();
            // para devolver la lista de productos
            ViewBag.Productos =daoProductos.Listar();
            return View(new Facturar());
        }
        [HttpPost]
        public ActionResult Facturar(FormCollection form, Facturar model)
        {
            try
            {
                //obtenemos los objetos de sesiones
                Clientes c = new Clientes();
                c = (Clientes)Session["Cliente"];
                List<Detalles> detalles = (List<Detalles>)Session["Detalles"];
                decimal totalFactura = Convert.ToDecimal(Session["totalFactura"]);              
                Facturas f = new Facturas();
                if (Session["Factura"]== null || Session["Factura"].ToString()=="")
                {

                }
                else
                {
                    f = (Facturas)Session["Factura"];
                }
                f.nitCliente = c.nit;
                f.nombre = c.nombre;
                f.direccion = c.direccion;
                f.fecha = DateTime.Now;
                f.total = totalFactura;
                f.usuario = Session["Usuario"].ToString();
                int tempIdFactura = daoFacturas.GetIdFactura();
                f.idFactura = tempIdFactura;
                foreach (var d in detalles)
                {
                    d.idFactura = tempIdFactura;
                }              
                Facturar datosFactura = new Facturar()
                {
                    factura = f,
                    detalles = detalles,
                    cliente = c
                };
                ViewBag.Clientes = daoClientes.Listar();
                // para devolver la lista de productos
                ViewBag.Productos = daoProductos.Listar();

                if (daoFacturar.CrearVenta(datosFactura))
                {
                    ViewBag.Mensaje = "Se ha Creado la Factura";
                    Session["Factura"] = "";
                    Session["Cliente"] = "";
                    int idFactura = daoFacturas.GetIdFactura();
                    Session["idFactura"] = idFactura;
                    Session["Detalles"] = "";
                    Session["idDetalle"] = "0";
                    Session["totalFactura"] = "0";
                    return View();
                }
                else
                {
                    ViewBag.Error = "Error, No se realizo la transaccion";
                    return View();
                }
            }
            catch
            {
                ViewBag.Error = "Error, No hay conexion con la base de datos";
                // para devolver la lista de productos
                ViewBag.Clientes = daoClientes.Listar();
                ViewBag.Productos = daoProductos.Listar();
                return View();
            }
        }
        [HttpPost]
        public ActionResult BorrarFactura(FormCollection form)
        {
            try
            {
                Session["Factura"] = "";
                Session["Cliente"] = "";
                int idFactura = daoFacturas.GetIdFactura();
                Session["idFactura"] = idFactura;
                Session["Detalles"] = "";
                Session["idDetalle"] = "0";
                Session["Usuario"] = "";
                Session["totalFactura"] = "0";

                // para devolver la lista de productos
                ViewBag.Clientes = daoClientes.Listar();
                ViewBag.Productos = daoProductos.Listar();
                ViewBag.Mensaje = "Ahora puede crear una nueva factura";
                return View("Facturar");
            }
            catch
            {
                return RedirectToAction ("Facturar");
            }
        }
        [HttpPost]
        public ActionResult BuscarCliente(FormCollection form)
        {
            try
            {
                //Session["Cliente"] = "";
                string nit = form["nitCliente"];
                Clientes cliente = new Clientes();
                cliente = daoClientes.BuscarNit(nit);

                if(cliente ==null)
                {
                    Session["Cliente"] = "";
                    cliente = new Clientes()
                    {
                        nit = nit
                    };
                    Session["Cliente"] = cliente;
                    // para devolver la lista de productos
                    ViewBag.Clientes = daoClientes.Listar();
                    ViewBag.Productos = daoProductos.Listar();
                    ViewBag.ErrorCliente = "No existe un cliente registrado con este nit";
                    return View("Facturar");
                }
                else
                {
                    ViewBag.ErrorCliente = "Se ha encontrado el cliente";
                    // para devolver la lista de productos
                    ViewBag.Clientes = daoClientes.Listar();
                    ViewBag.Productos = daoProductos.Listar();
                    Session["Cliente"] = cliente;

                    Facturas f = new Facturas()
                    {
                        nitCliente = cliente.nit,
                        nombre = cliente.nombre,
                        direccion = cliente.direccion,

                        fecha = DateTime.Now.Date
                    };
                    f.idFactura = Convert.ToInt32(Session["idFactura"]);
                    if (f.idFactura == 0)
                    {
                        f.idFactura = daoFacturas.GetIdFactura();
                        f.fecha = DateTime.Now.Date;
                        Session["idFactura"] = f.idFactura;
                    }
                    f.usuario = Session["Usuario"].ToString();
                    Session["Factura"] = f;




                    return View("Facturar");
                }
              
            }
            catch
            {
                ViewBag.Error = "No se ha podido conectar con el servidor";
                // para devolver la lista de productos
                ViewBag.Clientes = daoClientes.Listar();
                ViewBag.Productos = daoProductos.Listar();
                return View("Facturar");
            }
        }
        [HttpPost]
        public ActionResult CargarCliente(FormCollection form)
        {
            try
            {
                Clientes c = new Clientes()
                {
                    nit = form["nitCliente"],
                    nombre = form["nombre"],
                    direccion = form["direccion"]
                };
                if (c.nit=="c/f" || c.nit=="C/F")
                {
                    //significa que el cliente no se debe de crear
                }
                else
                {
                    if (daoClientes.BuscarNit(c.nit)==null)
                    {
                        // no cambia el valor del cliente porque este no existe
                       
                    }
                    else
                    {
                        c = daoClientes.BuscarNit(c.nit);

                    }
                }
                Session["Cliente"] = "";
                Session["Cliente"] = c;
                Facturas f = new Facturas()
                {
                    nitCliente = c.nit,
                    nombre = c.nombre,
                    direccion = c.direccion,
                                     
                    fecha = DateTime.Now.Date
                };
                f.idFactura = Convert.ToInt32(Session["idFactura"]);
                if(f.idFactura==0)
                {
                    f.idFactura = daoFacturas.GetIdFactura();
                    f.fecha = DateTime.Now.Date;
                    Session["idFactura"] = f.idFactura;
                }
                f.usuario = Session["Usuario"].ToString();
                Session["Factura"] = f;
                ViewBag.Mensaje = "Se ha Cargado el cliente a la factura";
                ViewBag.ErrorCliente = "Cliente Cargado";
                ViewBag.Clientes = daoClientes.Listar();
                // para devolver la lista de productos
                ViewBag.Productos = daoProductos.Listar();
                return View("Facturar");
            }
            catch
            {
                ViewBag.Error = "Error, No se ha podido conectar con el servidor";
                ViewBag.ErrorCliente = "No se ha podido cargar el cliente";
                ViewBag.Clientes = daoClientes.Listar();
                // para devolver la lista de productos
                ViewBag.Productos = daoProductos.Listar();
                return View("Facturar");
            }
        }
        [HttpPost]
        public ActionResult CargarProducto(FormCollection form)
        {
            try
            {
                // buscamos el producto
                string idProducto = form["idProducto"];
                decimal cantidad = Convert.ToDecimal (form["cantidad"]);
                decimal descuento = Convert.ToDecimal(form["descuento"]);
                Productos p = new Productos() ;
                p = daoProductos.BuscarId(idProducto);
                ViewBag.Clientes = daoClientes.Listar();
                // para devolver la lista de productos
                ViewBag.Productos = daoProductos.Listar();

                if (String.IsNullOrEmpty(p.idProducto))
                {
                    ViewBag.ErrorProducto = "No existe  el producto o la existencia es menor a la cantidad solicitada";
                    ViewBag.Productos = daoProductos.Listar();
                    return View("Facturar");
                }
                else
                {
                    // evaluamos si la existencia es menor a la cantidad solicitada
                    if (p.existencia < cantidad)
                    {
                        ViewBag.ErrorProducto = "Error, La cantidad solicitada es menor a la existencia,";
                        ViewBag.Productos = daoProductos.Listar();
                        return View("Facturar");

                    }
                    else
                    {
                        // verificamos si existe algun detalle
                        List<Detalles> detalles = new List<Detalles>();

                        if (Session["Detalles"].ToString() == "")
                        {

                            // si no hay detalles no se hace nada, puesto que se creo el objeto arriba


                        }
                        else
                        {
                            
                            // si existe detalle, lo pasamos a la variable local detalles
                            detalles = (List<Detalles>)Session["Detalles"];
                            
                        }
                        // creamos un objeto temporal para saber si existe el detalle

                        Detalles temp = new Detalles();
                        temp = detalles.Find(r => r.idProducto == p.idProducto);
                        if (temp == null)
                        {
                            // creamos un nuevo detalle, obtenemos el id de la factura
                            int idFactura = Int32.Parse(Session["idFactura"].ToString());
                            // iniciamos el contador para llenar la lista de detalles
                            int idDetalle = Int32.Parse(Session["idDetalle"].ToString()) + 1;

                            Detalles d = new Detalles()
                            {
                                idFactura = idFactura,
                                idDetalle = idDetalle,
                                idProducto = p.idProducto,
                                precio = p.precio,
                                cantidad = cantidad,
                                Productos = p
                            };
                            if (descuento>0)
                            {
                                decimal desc = (descuento / 100);
                                decimal descontado= d.precio * desc;
                                decimal prec = d.precio - descontado;
                                d.subTotal = prec * d.cantidad;
                                 
                            }
                            else
                            {
                                d.subTotal = d.cantidad * d.precio;
                            }
                            //d.Productos.nombre = p.nombre;
                            d.descuento = descuento;
                          //  d.descuento = desc;
                            detalles.Add(d);
                    
                                   
                            decimal totalFactura = Convert.ToDecimal(Session["totalFactura"]);
                            totalFactura = totalFactura + Convert.ToDecimal(d.subTotal);
                            Session["totalFactura"] = totalFactura;
                            //volvemos a parsear el al objeto sessio
                            Session["idDetalle"] = idDetalle;
                            Session["Detalles"] = detalles;
                            // para devolver la lista de productos
                        }
                        else
                        {
                            // el producto ya esta registrado en el detalle asi que solo actualizamos los datos

                            // el producto ya existe en el detalle, entonces lo aumentamos
                            detalles.Remove(temp);
                            temp.cantidad = temp.cantidad + cantidad;
                            temp.subTotal = temp.cantidad * temp.precio;
                            detalles.Add(temp);
                            //recalculamos el total otra vez
                            decimal totalFactura = 0;
                            foreach (var i in detalles)
                            {
                                totalFactura = totalFactura + Convert.ToDecimal(i.subTotal);
                            }
                            Session["totalFactura"] = totalFactura;
                            Session["Detalles"] = detalles;
                            ViewBag.ErrorProducto = "se Modifico " + cantidad + " " + p.nombre + " precio Q" + p.precio + "sub Total  Q" + temp.subTotal;
                        }
                        ViewBag.Productos = daoProductos.Listar();
                        return View("Facturar");
                    }
                }
            }
            catch
            {
                ViewBag.Clientes = daoClientes.Listar();
                // para devolver la lista de productos
                ViewBag.Productos = daoProductos.Listar();
                ViewBag.Error= "No hay conexion con la base de datos";
                ViewBag.ErrorProducto = "No se pudo agregar el producto";
                return View("Facturar");
            }
        }
        public ActionResult EliminarDetalle(FormCollection form, int id)
        {
            try
            {

                ViewBag.Clientes = daoClientes.Listar();
                // para devolver la lista de productos
                ViewBag.Productos = daoProductos.Listar();
                //Obtenemos el objeto de session de detalles
                List<Detalles> detalles = new List<Detalles>();
                detalles = (List<Detalles>)Session["Detalles"];
                //obtenemos el detalle a eliminar de la lista
                Detalles d = new Detalles();
                //busca el detalle en la lista, segun el id
                d = detalles.Find(r => r.idDetalle == id);
                // elimina el detalle de la lista
                detalles.Remove(d);
                // en esta parate reordenamos los objetos, para que no queden ids de detalle saltados
                //creamos una nueva lista de detalles a quien pasaremos los objetos restantes despues de haber eliminado el detalle

                List<Detalles> nuevaLista = new List<Detalles>();
                //con un bucle recorremos la lista actual y pasamos a la lista nueva, modificando los ids, de detalle
                int idDetalle = 1;
                decimal totalFactura = 0;
               foreach(var e in detalles)
                {
                    //Creamos un nuevo de talle para pasarle los objetos
                    Detalles dn = new Detalles();
                    dn = e;
                    dn.idDetalle = idDetalle;
                    idDetalle++;
                    totalFactura = totalFactura + Convert.ToDecimal(dn.subTotal);
                    nuevaLista.Add(dn);

                    //con este metodo terminamos de pasar la lista antigua a la lista nueva;
                }
                // instanceamos las variables de session con los nuevos datos
                Session["Detalles"] = nuevaLista;
                idDetalle = nuevaLista.Count();
                Session["idDetalle"] = idDetalle;
                Session["totalFactura"] = totalFactura;
                //devolvemos los datos


                ViewBag.ErrorProducto = "Se elimino =" + d.Productos.nombre ;
                // para devolver la lista de productos
                ViewBag.Productos = daoProductos.Listar();
                return View("Facturar");
            }
            catch
            {
                ViewBag.Error = "No se pudo eliminar el producto del detalle";
                ViewBag.Clientes = daoClientes.Listar();
                // para devolver la lista de productos
                ViewBag.Productos = daoProductos.Listar();
                return View("Facturar");

            }
     
        }
        public ActionResult EditarDetalle(FormCollection form, int id)
        {
            try
            {
                ViewBag.Clientes = daoClientes.Listar();
                // para devolver la lista de productos
                ViewBag.Productos = daoProductos.Listar();
                //Obtenemos el objeto de session de detalles
                List<Detalles> detalles = new List<Detalles>();
                detalles = (List<Detalles>)Session["Detalles"];
                //obtenemos el detalle a eliminar de la lista
                Detalles d = new Detalles();
                //busca el detalle en la lista, segun el id
                d = detalles.Find(r => r.idDetalle == id);
                //obteniendo el producto devolvemos la cantidad y el ID para poder ser Modificados
                ViewBag.modIdProducto = d.idProducto;
                ViewBag.modCantidad = d.cantidad;
                ViewBag.modIdDetalle = d.idDetalle;
                ViewBag.modDescuento = d.descuento;
                ViewBag.ErrorProducto = "Se elimino =" + d.Productos.nombre;
                // para devolver la lista de productos
                ViewBag.Productos = daoProductos.Listar();
                return View("Facturar");
            }
            catch
            {
                ViewBag.Error = "No se logro editar el producto =" + id;
                ViewBag.Clientes = daoClientes.Listar();
                // para devolver la lista de productos
                ViewBag.Productos = daoProductos.Listar();
                return View("Facturar");
            }

        }
        [HttpPost]
        public ActionResult EditarDetalle(FormCollection form)
        {
            try
            {

                ViewBag.Clientes = daoClientes.Listar();
                // para devolver la lista de productos
                ViewBag.Productos = daoProductos.Listar();

                int idProducto = Convert.ToInt32(form["idProducto"]);
                decimal cantidad = Convert.ToDecimal(form["cantidad"]);
                decimal descuento = Convert.ToDecimal(form["descuento"]);
                int id = Convert.ToInt32(form["idDetalle"]);

                //Obtenemos el objeto de session de detalles
                List<Detalles> detalles = new List<Detalles>();
                detalles = (List<Detalles>)Session["Detalles"];
                //obtenemos el detalle a eliminar de la lista
                Detalles d = new Detalles();
                //busca el detalle en la lista, segun el id
                d = detalles.Find(r => r.idDetalle == id);

                if (d.cantidad == cantidad)
                {
                    //las cantidad ingresada es la misma, entonces no hacemos algo solo retornamos la vista
                    ViewBag.ErrorProducto = "La cantidad ingresada es la misa, no se modifico el producto";
                    // para devolver la lista de productos
                    ViewBag.Productos = daoProductos.Listar();
                    return View("Facturar");

                }
                else
                {
                    //eliminamos el objeto de la lista
                    detalles.Remove(d);
                    //obteniendo el producto devolvemos la cantidad y el ID para poder ser Modificados
                    d.descuento = descuento;
                    decimal tempDesc = descuento / 100;
                    decimal tempPrecio = d.precio * tempDesc;
                    d.cantidad = cantidad;
                    d.subTotal = cantidad * tempPrecio;
                    detalles.Add(d);

                    //calculamos el nuevo total de la factura
                    decimal totalFactura = 0;
                    foreach (var e in detalles)
                    {
                        totalFactura = totalFactura + Convert.ToDecimal(e.subTotal);
                    }
                    Session["totalFactura"] = totalFactura;
                    //modificamos el detalle en la lista
                    ViewBag.ErrorProducto = "Se modifico el producto =" + d.Productos.nombre + " cantidad= " + d.cantidad;
                    // para devolver la lista de productos
                    ViewBag.Productos = daoProductos.Listar();
                    return View("Facturar");
                }
            }
            catch
            {
                ViewBag.Error = "No se logro editar el producto ";
                ViewBag.Clientes = daoClientes.Listar();
                // para devolver la lista de productos
                ViewBag.Productos = daoProductos.Listar();
                return View("Facturar");
            }

        }
        public ActionResult CancelarEdicion(FormCollection form)
        {
           return RedirectToAction("Facturar");
        }
    }
}