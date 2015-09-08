using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Presupuestos.Comun;

namespace Presupuestos
{
    public partial class _Default : Page
    {
        mUsuario mu;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["IDUsuario"] != null)
            {                 
                Response.Redirect("~/Presentacion/FrmHome.aspx");               
            }

        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (UserName.Text != "" && Password.Text != "")
            {
                mu = mUsuario.logging(Datos.DatosComun.constr, UserName.Text, Comun.Utilerias.Code(Password.Text));

                LLoginFail.Visible = false;
                Session.RemoveAll();
                if (mu != null)
                {             
                    Session.Add("User", mu);
                    Session.Add("Nombre",mu.Nombre);
                    Response.Redirect("~/Presentacion/FrmHome.aspx");      
                }
                else
                {
                    LLoginFail.Text = "Usuario o Contraseña incorrecto!";
                    LLoginFail.Visible = true;
                }
            }
            else
            {
                LLoginFail.Text = "Complete los campos de nombre usuario y contraseña!";
                LLoginFail.Visible = true;
            }
        }

    }
}