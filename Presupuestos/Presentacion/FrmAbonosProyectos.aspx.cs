using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Presupuestos.Comun;
using Presupuestos.Datos;

namespace Presupuestos.Presentacion
{
    public partial class FrmAbonosProyectos : System.Web.UI.Page
    {
        DatosComun dc = new DatosComun();
        Proyecto p;
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                Response.Redirect("~/Presentacion/FrmCerrarSession.aspx");

            if (user.Tipo.Equals(2))
                Response.Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            if (!IsPostBack)
            {
                DDLProyectos.DataSource = dc.BindGrid("EXEC spBuscarProyectos 1");
                DDLProyectos.DataValueField = "IDProyecto";
                DDLProyectos.DataTextField = "Nombre";
                DDLProyectos.DataBind();

                BuscarInfoProyecto(Convert.ToInt32(DDLProyectos.SelectedValue));
            }
        }



        public void BuscarInfoProyecto(int IDProyecto)
        {
            p = new Proyecto(IDProyecto);

            txt_Descripcion.Text = p.Descripcion;

            LCosto.Text = "Costo Total: <b>" + p.CostoTotal.ToString() + "</b>  Costo Restante: <b>" + p.CostoRestante.ToString()+"</b>";

            GvAbonos.DataSource = dc.BindGrid("exec spBuscarAbonos "+IDProyecto.ToString());
            GvAbonos.DataBind();
        
        }

        protected void BtGuardar_Click(object sender, EventArgs e)
        {
            dc.spIAbono(Convert.ToInt32(DDLProyectos.SelectedValue),Convert.ToDateTime( txt_FechaAbono.Text), Convert.ToDecimal(txt_cantidadAbono.Text),txt_RecibiDe.Text);
        }
    }
}