using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Presupuestos.Models;
using Presupuestos.Comun;

namespace Presupuestos.Controllers
{
    public class UsuariosController : Controller
    {
        private dbPresupuestosEntities db = new dbPresupuestosEntities();

        // GET: /Usuarios/
        public ActionResult Index()
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            var tblusuarios = db.TblUsuarios.Include(t => t.TblEmpleado);
            return View(tblusuarios.ToList());
        }

        // GET: /Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUsuario tblusuario = db.TblUsuarios.Find(id);
            if (tblusuario == null)
            {
                return HttpNotFound();
            }
            return View(tblusuario);
        }

        // GET: /Usuarios/Create
        public ActionResult Create()
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            ViewBag.IDEmpleado = new SelectList(db.TblEmpleados, "IDEmpleado", "Nombre");
            return View();
        }

        // POST: /Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDUsuario,Nombre,NombreCuenta,Clave,Active,Tipo,IDEmpleado")] TblUsuario tblusuario)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            if (ModelState.IsValid)
            {
                tblusuario.Clave = Comun.Utilerias.Code(tblusuario.Clave);

                db.TblUsuarios.Add(tblusuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDEmpleado = new SelectList(db.TblEmpleados, "IDEmpleado", "Nombre", tblusuario.IDEmpleado);
            return View(tblusuario);
        }

        // GET: /Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUsuario tblusuario = db.TblUsuarios.Find(id);
            if (tblusuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDEmpleado = new SelectList(db.TblEmpleados, "IDEmpleado", "Nombre", tblusuario.IDEmpleado);
            return View(tblusuario);
        }

        // POST: /Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDUsuario,Nombre,NombreCuenta,Clave,Active,Tipo,IDEmpleado")] TblUsuario tblusuario)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            if (ModelState.IsValid)
            {
                tblusuario.Clave = Comun.Utilerias.Code(tblusuario.Clave);

                db.Entry(tblusuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDEmpleado = new SelectList(db.TblEmpleados, "IDEmpleado", "Nombre", tblusuario.IDEmpleado);
            return View(tblusuario);
        }

        // GET: /Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUsuario tblusuario = db.TblUsuarios.Find(id);
            if (tblusuario == null)
            {
                return HttpNotFound();
            }
            return View(tblusuario);
        }

        // POST: /Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            TblUsuario tblusuario = db.TblUsuarios.Find(id);
            db.TblUsuarios.Remove(tblusuario);
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
