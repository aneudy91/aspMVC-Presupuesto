﻿using System;
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
    public class PuestosController : Controller
    {
        private dbPresupuestosEntities db = new dbPresupuestosEntities();

        // GET: /Puestos/
        public ActionResult Index()
        {
            return View(db.TblPuestos.ToList());
        }

        // GET: /Puestos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblPuesto tblpuesto = db.TblPuestos.Find(id);
            if (tblpuesto == null)
            {
                return HttpNotFound();
            }
            return View(tblpuesto);
        }

        // GET: /Puestos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Puestos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDPuesto,Descripcion")] TblPuesto tblpuesto)
        {
            if (ModelState.IsValid)
            {
                db.TblPuestos.Add(tblpuesto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblpuesto);
        }

        // GET: /Puestos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblPuesto tblpuesto = db.TblPuestos.Find(id);
            if (tblpuesto == null)
            {
                return HttpNotFound();
            }
            return View(tblpuesto);
        }

        // POST: /Puestos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDPuesto,Descripcion")] TblPuesto tblpuesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblpuesto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblpuesto);
        }

        // GET: /Puestos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblPuesto tblpuesto = db.TblPuestos.Find(id);
            if (tblpuesto == null)
            {
                return HttpNotFound();
            }
            return View(tblpuesto);
        }

        // POST: /Puestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblPuesto tblpuesto = db.TblPuestos.Find(id);
            db.TblPuestos.Remove(tblpuesto);
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
