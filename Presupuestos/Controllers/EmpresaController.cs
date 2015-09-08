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
    public class EmpresaController : Controller
    {
        private dbPresupuestosEntities db = new dbPresupuestosEntities();

        // GET: /Empresa/
        public ActionResult Index()
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            return View(db.TblEmpresas.ToList());
        }

        // GET: /Empresa/Details/5
        public ActionResult Details(int? id)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEmpresa tblempresa = db.TblEmpresas.Find(id);
            if (tblempresa == null)
            {
                return HttpNotFound();
            }
            return View(tblempresa);
        }

        // GET: /Empresa/Create
        public ActionResult Create()
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            return View();
        }

        // POST: /Empresa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDEmpresa,NombreComercial,RazonSocial,RFC,DomicilioFiscal_calle,DomicilioFiscal_noExterior,DomicilioFiscal_colonia,DomicilioFiscal_localidad,DomicilioFiscal_municipio,DomicilioFiscal_estado,DomicilioFiscal_pais,DomicilioFiscal_codigoPostal")] TblEmpresa tblempresa)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (ModelState.IsValid)
            {
                db.TblEmpresas.Add(tblempresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblempresa);
        }

        // GET: /Empresa/Edit/5
        public ActionResult Edit(int? id)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEmpresa tblempresa = db.TblEmpresas.Find(id);
            if (tblempresa == null)
            {
                return HttpNotFound();
            }
            return View(tblempresa);
        }

        // POST: /Empresa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDEmpresa,NombreComercial,RazonSocial,RFC,DomicilioFiscal_calle,DomicilioFiscal_noExterior,DomicilioFiscal_colonia,DomicilioFiscal_localidad,DomicilioFiscal_municipio,DomicilioFiscal_estado,DomicilioFiscal_pais,DomicilioFiscal_codigoPostal")] TblEmpresa tblempresa)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (ModelState.IsValid)
            {
                db.Entry(tblempresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblempresa);
        }

        // GET: /Empresa/Delete/5
        public ActionResult Delete(int? id)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEmpresa tblempresa = db.TblEmpresas.Find(id);
            if (tblempresa == null)
            {
                return HttpNotFound();
            }
            return View(tblempresa);
        }

        // POST: /Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            TblEmpresa tblempresa = db.TblEmpresas.Find(id);
            db.TblEmpresas.Remove(tblempresa);
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
