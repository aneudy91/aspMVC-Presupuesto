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
    public class EmpleadoProyectoController : Controller
    {
        private dbPresupuestosEntities db = new dbPresupuestosEntities();

        // GET: /EmpleadoProyecto/
        public ActionResult Index()
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            var tblproyectosempleados = db.TblProyectosEmpleados.Include(t => t.TblEmpleado).Include(t => t.TblProyecto);
            return View(tblproyectosempleados.ToList());
        }

        // GET: /EmpleadoProyecto/Details/5
        public ActionResult Details(int? id)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProyectosEmpleado tblproyectosempleado = db.TblProyectosEmpleados.Find(id);
            if (tblproyectosempleado == null)
            {
                return HttpNotFound();
            }
            return View(tblproyectosempleado);
        }

        // GET: /EmpleadoProyecto/Create
        public ActionResult Create()
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            ViewBag.IDEmpleado = new SelectList(db.TblEmpleados, "IDEmpleado", "Nombre");
            ViewBag.IDProyecto = new SelectList(db.TblProyectos, "IDProyecto", "Nombre");
            return View();
        }

        // POST: /EmpleadoProyecto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDProyectoEmpleado,IDProyecto,IDEmpleado")] TblProyectosEmpleado tblproyectosempleado)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (ModelState.IsValid)
            {
                db.TblProyectosEmpleados.Add(tblproyectosempleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDEmpleado = new SelectList(db.TblEmpleados, "IDEmpleado", "Nombre", tblproyectosempleado.IDEmpleado);
            ViewBag.IDProyecto = new SelectList(db.TblProyectos, "IDProyecto", "Nombre", tblproyectosempleado.IDProyecto);
            return View(tblproyectosempleado);
        }

        // GET: /EmpleadoProyecto/Edit/5
        public ActionResult Edit(int? id)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProyectosEmpleado tblproyectosempleado = db.TblProyectosEmpleados.Find(id);
            if (tblproyectosempleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDEmpleado = new SelectList(db.TblEmpleados, "IDEmpleado", "Nombre", tblproyectosempleado.IDEmpleado);
            ViewBag.IDProyecto = new SelectList(db.TblProyectos, "IDProyecto", "Nombre", tblproyectosempleado.IDProyecto);
            return View(tblproyectosempleado);
        }

        // POST: /EmpleadoProyecto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDProyectoEmpleado,IDProyecto,IDEmpleado")] TblProyectosEmpleado tblproyectosempleado)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (ModelState.IsValid)
            {
                db.Entry(tblproyectosempleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDEmpleado = new SelectList(db.TblEmpleados, "IDEmpleado", "Nombre", tblproyectosempleado.IDEmpleado);
            ViewBag.IDProyecto = new SelectList(db.TblProyectos, "IDProyecto", "Nombre", tblproyectosempleado.IDProyecto);
            return View(tblproyectosempleado);
        }

        // GET: /EmpleadoProyecto/Delete/5
        public ActionResult Delete(int? id)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProyectosEmpleado tblproyectosempleado = db.TblProyectosEmpleados.Find(id);
            if (tblproyectosempleado == null)
            {
                return HttpNotFound();
            }
            return View(tblproyectosempleado);
        }

        // POST: /EmpleadoProyecto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            TblProyectosEmpleado tblproyectosempleado = db.TblProyectosEmpleados.Find(id);
            db.TblProyectosEmpleados.Remove(tblproyectosempleado);
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
