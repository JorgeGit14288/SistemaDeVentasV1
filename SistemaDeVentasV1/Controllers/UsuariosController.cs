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
        public UsuariosController()
        {
            if(ctx.AspNetRoles.Count()==0)
            {
                AspNetRoles rol1 = new AspNetRoles();
                rol1.Id = "1";
                rol1.Name = "Administrador";
                AspNetRoles rol2 = new AspNetRoles();
                rol2.Id = "2";
                rol2.Name = "Ventas";
                AspNetRoles rol3 = new AspNetRoles();
                rol3.Id = "3";
                rol3.Name = "Bodega";
                AspNetRoles rol4 = new AspNetRoles();
                rol4.Id = "4";
                rol4.Name = "Reportes";

                //agregamos los roles
                ctx.AspNetRoles.Add(rol1);
                ctx.AspNetRoles.Add(rol2);
                ctx.AspNetRoles.Add(rol3);
                ctx.AspNetRoles.Add(rol4);
                ctx.SaveChanges();
            }
        }
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
            ViewBag.Roles = ctx.AspNetRoles.ToList();
            return View(ctx.AspNetUsers.SingleOrDefault((r => r.Id == id)));
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection,AspNetUsers user)
        {
            ViewBag.Roles = ctx.AspNetRoles.ToList();
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
                actual.Activo = user.Activo;
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

        public ActionResult AgregarRol(string id)
        {
            ViewBag.Roles = ctx.AspNetRoles.ToList();
            return View(ctx.AspNetUsers.Find(id));
        }
        [HttpPost]
        public ActionResult AgregarRol(string idUser, string idRol)
        {
            AspNetUsers user = ctx.AspNetUsers.Find(idUser);
            AspNetRoles rol = ctx.AspNetRoles.Find(idRol);
           if(user.AspNetRoles.FirstOrDefault(r=> r.Id == rol.Id)==null)
            {
                user.AspNetRoles.Add(rol);
                ctx.SaveChanges();
                
                return RedirectToAction("Edit", "Usuarios", new { id = idUser });

            }

            ViewBag.Error = "El rol ya existe en el usuario actual";
            return RedirectToAction("Edit", "Usuarios", new { id = idUser });
        }
        [HttpPost]
        public ActionResult EliminarRol(string idUser, string idRol)
        {
            AspNetUsers user = ctx.AspNetUsers.Find(idUser);
            AspNetRoles rol = ctx.AspNetRoles.Find(idRol);
            if (user.AspNetRoles.FirstOrDefault(r => r.Id == rol.Id) == null)
            {
                ViewBag.Error = "No se pudo eliminar el rol del usuario";
                return RedirectToAction("Edit","Usuarios",new { id = idUser });

            }
            user.AspNetRoles.Remove(rol);
            ctx.SaveChanges();
            return RedirectToAction("Edit", "Usuarios", new { id = idUser });

        }

    }
}
