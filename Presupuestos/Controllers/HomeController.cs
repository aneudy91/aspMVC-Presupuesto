using Presupuestos.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presupuestos.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            return View();
        }
	}
}