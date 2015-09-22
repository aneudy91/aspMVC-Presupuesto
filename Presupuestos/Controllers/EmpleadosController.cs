using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Presupuestos.Models;

namespace Presupuestos.Controllers
{
    public class EmpleadosController : Controller
    {
        private dbPresupuestosEntities db = new dbPresupuestosEntities();

        // GET: /Empleados/
        public ActionResult Index()
        {
            var tblempleados = db.TblEmpleados.Include(t => t.TblPuesto);
            return View(tblempleados.ToList());
        }

        // GET: /Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEmpleado tblempleado = db.TblEmpleados.Find(id);
            if (tblempleado == null)
            {
                return HttpNotFound();
            }
            return View(tblempleado);
        }

        // GET: /Empleados/Create
        public ActionResult Create()
        {
            ViewBag.IDPuesto = new SelectList(db.TblPuestos, "IDPuesto", "Descripcion");
            return View();
        }

        // POST: /Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDEmpleado,Nombre,Paterno,Materno,IDPuesto")] TblEmpleado tblempleado)
        {
            if (ModelState.IsValid)
            {
                db.TblEmpleados.Add(tblempleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPuesto = new SelectList(db.TblPuestos, "IDPuesto", "Descripcion", tblempleado.IDPuesto);
            return View(tblempleado);
        }

        // GET: /Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEmpleado tblempleado = db.TblEmpleados.Find(id);
            if (tblempleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPuesto = new SelectList(db.TblPuestos, "IDPuesto", "Descripcion", tblempleado.IDPuesto);
            return View(tblempleado);
        }

        // POST: /Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDEmpleado,Nombre,Paterno,Materno,IDPuesto")] TblEmpleado tblempleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblempleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPuesto = new SelectList(db.TblPuestos, "IDPuesto", "Descripcion", tblempleado.IDPuesto);
            return View(tblempleado);
        }

        // GET: /Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEmpleado tblempleado = db.TblEmpleados.Find(id);
            if (tblempleado == null)
            {
                return HttpNotFound();
            }
            return View(tblempleado);
        }

        // POST: /Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblEmpleado tblempleado = db.TblEmpleados.Find(id);
            db.TblEmpleados.Remove(tblempleado);
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
