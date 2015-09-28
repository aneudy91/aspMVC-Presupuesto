using Presupuestos.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presupuestos.Presentacion
{
    public partial class FrmHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                Response.Redirect("~/Presentacion/FrmCerrarSession.aspx");

            if (user.Tipo.Equals(2))
                Response.Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 


        }
    }
}