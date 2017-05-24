using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaDeVentasV1.Models;

namespace SistemaDeVentasV1.Controllers
{
    public class UsuariosController : Controller
    {
        private FacturacionDbEntities ctx = new FacturacionDbEntities();
        // GET: Usuarios
        public ActionResult Index()
        {
            List<AspNetUsers> lista = new List<AspNetUsers>();
            lista = ctx.AspNetUsers.ToList();
            return View(lista);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            return View(ctx.AspNetUsers.SingleOrDefault((r=> r.Id== id)));
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
          return  RedirectToAction("Register","Account");

        }
        // GET: Usuarios/Edit/5
        public ActionResult Edit(string id)
        {
            return View(ctx.AspNetUsers.SingleOrDefault((r => r.Id == id)));
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection,AspNetUsers user)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    ViewBag.Error = "Los datos a guardar no son validos.";
                    return View(user);

                }

                AspNetUsers actual = new AspNetUsers();
                actual = ctx.AspNetUsers.Find(id);
                actual.nombre = user.nombre;
                actual.direccion = user.direccion;
                actual.LockoutEnabled = user.LockoutEnabled;
                actual.Email = user.Email;
                actual.UserName = user.UserName;
                actual.tel_casa = user.tel_casa;

                ctx.Entry(actual).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
               return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ha ocurrido un error "+ex.ToString();
                return View(user);
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(string id)
        {
            return View(ctx.AspNetUsers.SingleOrDefault((r => r.Id == id)));
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                AspNetUsers user = new AspNetUsers();
                user = ctx.AspNetUsers.Find(id);
                ctx.AspNetUsers.Remove(user);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Error al eliminar " + ex.ToString();
                return View(id);
            }
        }
    }
}
