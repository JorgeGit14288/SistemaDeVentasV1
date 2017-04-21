using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaDeVentasV1.Models;
using SistemaDeVentasV1.Dao;

namespace SistemaDeVentasV1.Controllers
{
    public class DetallesController : Controller
    {
        private FacturacionDbEntities db = new FacturacionDbEntities();
        private IDetallesDao dao = new DetallesDao();

        // GET: Detalles
        public ActionResult Index()
        {
            var detalles = db.Detalles.Include(d => d.Facturas).Include(d => d.Productos);
            return View(detalles.ToList());
        }

        // GET: Detalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalles detalles = db.Detalles.Find(id);
            if (detalles == null)
            {
                return HttpNotFound();
            }
            return View(detalles);
        }

        // GET: Detalles/Create
        public ActionResult Create()
        {
            ViewBag.idFactura = new SelectList(db.Facturas, "idFactura", "nitCliente");
            ViewBag.idProducto = new SelectList(db.Productos, "idProducto", "nombre");
            return View();
        }

        // POST: Detalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDetalle,idFactura,idProducto,cantidad,precio,subTotal")] Detalles detalles)
        {
            if (ModelState.IsValid)
            {
                // db.Detalles.Add(detalles);
                //db.SaveChanges();
                dao.Crear(detalles);
                return RedirectToAction("Index");
            }

            ViewBag.idFactura = new SelectList(db.Facturas, "idFactura", "nitCliente", detalles.idFactura);
            ViewBag.idProducto = new SelectList(db.Productos, "idProducto", "nombre", detalles.idProducto);
            return View(detalles);
        }

        // GET: Detalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalles detalles = db.Detalles.Find(id);
            if (detalles == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFactura = new SelectList(db.Facturas, "idFactura", "nitCliente", detalles.idFactura);
            ViewBag.idProducto = new SelectList(db.Productos, "idProducto", "nombre", detalles.idProducto);
            return View(detalles);
        }

        // POST: Detalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDetalle,idFactura,idProducto,cantidad,precio,subTotal")] Detalles detalles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFactura = new SelectList(db.Facturas, "idFactura", "nitCliente", detalles.idFactura);
            ViewBag.idProducto = new SelectList(db.Productos, "idProducto", "nombre", detalles.idProducto);
            return View(detalles);
        }

        // GET: Detalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalles detalles = db.Detalles.Find(id);
            if (detalles == null)
            {
                return HttpNotFound();
            }
            return View(detalles);
        }

        // POST: Detalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalles detalles = db.Detalles.Find(id);
            db.Detalles.Remove(detalles);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
