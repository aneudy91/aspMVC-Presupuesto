using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Presupuestos.Models
{
    public class ConfigController : Controller
    {
        private dbPresupuestosEntities db = new dbPresupuestosEntities();

        // GET: /Config/
        public ActionResult Index()
        {
            return View(db.tblListaConfigs.ToList());
        }

        // GET: /Config/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblListaConfig tbllistaconfig = db.tblListaConfigs.Find(id);
            if (tbllistaconfig == null)
            {
                return HttpNotFound();
            }
            return View(tbllistaconfig);
        }

        // GET: /Config/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Config/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Nombre,Valor,Descripcion")] tblListaConfig tbllistaconfig)
        {
            if (ModelState.IsValid)
            {
                db.tblListaConfigs.Add(tbllistaconfig);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbllistaconfig);
        }

        // GET: /Config/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblListaConfig tbllistaconfig = db.tblListaConfigs.Find(id);
            if (tbllistaconfig == null)
            {
                return HttpNotFound();
            }
            return View(tbllistaconfig);
        }

        // POST: /Config/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Nombre,Valor,Descripcion")] tblListaConfig tbllistaconfig)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbllistaconfig).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbllistaconfig);
        }

        // GET: /Config/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblListaConfig tbllistaconfig = db.tblListaConfigs.Find(id);
            if (tbllistaconfig == null)
            {
                return HttpNotFound();
            }
            return View(tbllistaconfig);
        }

        // POST: /Config/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblListaConfig tbllistaconfig = db.tblListaConfigs.Find(id);
            db.tblListaConfigs.Remove(tbllistaconfig);
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
