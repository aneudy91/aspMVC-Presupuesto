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
    public class ConceptosController : Controller
    {
        private dbPresupuestosEntities db = new dbPresupuestosEntities();

        // GET: /Conceptos/
        public ActionResult Index()
        {
            var user = Session["User"] as mUsuario;

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            if (user == null)
                return Redirect("~/Default");


            return View(db.TblConceptos.ToList());
        }

        // GET: /Conceptos/Details/5
        public ActionResult Details(string id)
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
            TblConcepto tblconcepto = db.TblConceptos.Find(id);
            if (tblconcepto == null)
            {
                return HttpNotFound();
            }
            return View(tblconcepto);
        }

        // GET: /Conceptos/Create
        public ActionResult Create()
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 


            return View();
        }

        // POST: /Conceptos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDConcepto,Descripcion,OrdenInsert,Tipo")] TblConcepto tblconcepto)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 


            if (ModelState.IsValid)
            {
                db.TblConceptos.Add(tblconcepto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblconcepto);
        }

        // GET: /Conceptos/Edit/5
        public ActionResult Edit(string id)
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
            TblConcepto tblconcepto = db.TblConceptos.Find(id);
            if (tblconcepto == null)
            {
                return HttpNotFound();
            }
            return View(tblconcepto);
        }

        // POST: /Conceptos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDConcepto,Descripcion,OrdenInsert,Tipo")] TblConcepto tblconcepto)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 


            if (ModelState.IsValid)
            {
                db.Entry(tblconcepto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblconcepto);
        }

        // GET: /Conceptos/Delete/5
        public ActionResult Delete(string id)
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
            TblConcepto tblconcepto = db.TblConceptos.Find(id);
            if (tblconcepto == null)
            {
                return HttpNotFound();
            }
            return View(tblconcepto);
        }

        // POST: /Conceptos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            TblConcepto tblconcepto = db.TblConceptos.Find(id);
            db.TblConceptos.Remove(tblconcepto);
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
