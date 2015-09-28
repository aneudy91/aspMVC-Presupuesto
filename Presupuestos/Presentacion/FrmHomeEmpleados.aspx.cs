using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using Presupuestos.Comun;
using Presupuestos.Datos;

namespace Presupuestos.Presentacion
{
    public partial class FrmHomeEmpleados : System.Web.UI.Page
    {
        mUsuario user;

        DatosComun dc = new DatosComun();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Session["User"] as mUsuario;

            if (user == null)
                Response.Redirect("~/Presentacion/FrmCerrarSession.aspx");


            if (user.Tipo != 2)
                Response.Redirect("~/Presentacion/FrmHome.aspx");

            if (!IsPostBack)
            {
                DataTable dt = dc.BindGrid(" exec spBuscarTotalPagadoEmpleado "+user.mEmp.IDEmpleado.ToString());
                LTotalPagado.Text =" RD$ "+  dt.Rows[0]["Total"].ToString();


                gvBind(user.mEmp.IDEmpleado);
            }
        }


        private void gvBind(int IDEmpleado)
        {
            gvProyectos.DataSource = dc.BindGrid("exec spBuscarEmpleadoProyecto " + IDEmpleado.ToString());
            gvProyectos.DataBind();
        }
    }
}