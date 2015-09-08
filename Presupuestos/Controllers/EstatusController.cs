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
    public class EstatusController : Controller
    {
        private dbPresupuestosEntities db = new dbPresupuestosEntities();

        // GET: /Estatus/
        public ActionResult Index()
        {
            return View(db.TblEstatus.ToList());
        }

        // GET: /Estatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEstatu tblestatu = db.TblEstatus.Find(id);
            if (tblestatu == null)
            {
                return HttpNotFound();
            }
            return View(tblestatu);
        }

        // GET: /Estatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Estatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDEstatus,Descripcion")] TblEstatu tblestatu)
        {
            if (ModelState.IsValid)
            {
                db.TblEstatus.Add(tblestatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblestatu);
        }

        // GET: /Estatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEstatu tblestatu = db.TblEstatus.Find(id);
            if (tblestatu == null)
            {
                return HttpNotFound();
            }
            return View(tblestatu);
        }

        // POST: /Estatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDEstatus,Descripcion")] TblEstatu tblestatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblestatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblestatu);
        }

        // GET: /Estatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEstatu tblestatu = db.TblEstatus.Find(id);
            if (tblestatu == null)
            {
                return HttpNotFound();
            }
            return View(tblestatu);
        }

        // POST: /Estatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblEstatu tblestatu = db.TblEstatus.Find(id);
            db.TblEstatus.Remove(tblestatu);
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
