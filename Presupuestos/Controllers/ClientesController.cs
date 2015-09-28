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
    public class ClientesController : Controller
    {
        private dbPresupuestosEntities db = new dbPresupuestosEntities();

        // GET: /Clientes/
        public ActionResult Index()
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            return View(db.TblClientes.ToList());
        }

        // GET: /Clientes/Details/5
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
            TblCliente tblcliente = db.TblClientes.Find(id);
            if (tblcliente == null)
            {
                return HttpNotFound();
            }
            return View(tblcliente);
        }

        // GET: /Clientes/Create
        public ActionResult Create()
        {
            var user = Session["User"] as mUsuario;

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            if (user == null)
                return Redirect("~/Default");

            return View();
        }

        // POST: /Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDCliente,NombreComercial,RazonSocial,RFC,Activo")] TblCliente tblcliente)
        {
            var user = Session["User"] as mUsuario;

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            if (user == null)
                return Redirect("~/Default");

            if (ModelState.IsValid)
            {
                db.TblClientes.Add(tblcliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblcliente);
        }

        // GET: /Clientes/Edit/5
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
            TblCliente tblcliente = db.TblClientes.Find(id);
            if (tblcliente == null)
            {
                return HttpNotFound();
            }
            return View(tblcliente);
        }

        // POST: /Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDCliente,NombreComercial,RazonSocial,RFC,Activo")] TblCliente tblcliente)
        {
            var user = Session["User"] as mUsuario;

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            if (user == null)
                return Redirect("~/Default");

            if (ModelState.IsValid)
            {
                db.Entry(tblcliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblcliente);
        }

        // GET: /Clientes/Delete/5
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
            TblCliente tblcliente = db.TblClientes.Find(id);
            if (tblcliente == null)
            {
                return HttpNotFound();
            }
            return View(tblcliente);
        }

        // POST: /Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            TblCliente tblcliente = db.TblClientes.Find(id);
            db.TblClientes.Remove(tblcliente);
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
