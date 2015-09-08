using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Text;

using System.IO;

using System.Globalization;

/*
 * 
 *
 *using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

 
 */

namespace Presupuestos.Comun
{
    public class Utilerias
    {

        public Boolean ValidarFechas(DateTime FI, DateTime FF)
        {
            Boolean res = true;
            /*
             * if (DateDesde.SelectedDate < Calendar1.TodaysDate)
            {
                DateDesde.SelectedDate = Calendar1.TodaysDate;
                DateHasta.SelectedDate = Calendar1.TodaysDate;
                res = false;
            }
            else
             */
            if (FI > FF)
            {
                res = false;
            }
            else res = true;

            return res;
        }

        public static string Code(string strCodifica)
        {
            string Str1 = null;
            string Str2 = null;
            string Str3 = null;
            int nCon = 0;
            int nPos = 0;

            Str1 = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz 1234567890><,.-;:_|!#$%&/()*{}+[]=";
            Str2 = "EfDedFlj-J.L]oRM%nmONQP=pqr/X)x}!#UT(ut8<0>9,V[Wv*wS+$s&{igHGhI|;K:k_zY1 Zy742536BAcabC";
            // Str3 = Strings.Space(strCodifica.Length);
            String spaces = new String(' ', strCodifica.Length);
            Str3 = spaces;
            // Str3 = strCodifica.PadRight(strCodifica.Length,' ');
            for (nCon = 0; nCon <= strCodifica.Length - 1; nCon += 1)
            {
                // strCodifica = ("abc123").PadLeft(3, '0');// will be "abc123"
                //nPos = Strings.InStr(Str1, strCodifica[nCon]);
                nPos = Str1.IndexOf(strCodifica[nCon]) + 1;
                Str3 = Str3 + Convert.ToString(Str2[nPos - 1]);
            }
            return Str3.Trim();
        }

        public static void MyMsgBox(string msg, System.Web.UI.Page p)
        {
            //En esta ocasión agregaremos un literal que a su vez agregaremos un div que nos servira de Dialog
            //O si prefieren pueden crear el div directamente en el HTML
            Literal li = new Literal();
            StringBuilder sbMensaje = new StringBuilder();
            //Creamos el Div
            sbMensaje.Append("<div id='dialog' title='ADG - AUTORIZACIONES'>");
            //Le indicamos el mensaje a mostrar
            sbMensaje.Append(msg);
            //cerramos el div
            sbMensaje.Append("</div>");
            //Aperturamos la escritura de Javascript
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.Append("$(document).ready(function () {");
            //Destrimos cualquier rastro de dialogo abierto
            sbMensaje.Append("$('#dialog').dialog('destroy');");
            //le indicamos que muestre el dialogo en modo Modal
            sbMensaje.Append(" $('#dialog').dialog({ modal: true });");
            //Si quieres que muestre un boton para cerrar el mensaje seria esta linea que dejare en comentario
            //sbMensaje.Append(" $('#dialog').dialog({ modal: true, buttons: { 'Ok': function() { $(this).dialog('close'); } } });");
            sbMensaje.Append("});");
            sbMensaje.Append("</script>");
            //Agremamos el texto del stringbuilder al literal
            li.Text = sbMensaje.ToString();
            //Agregamos el literal a la pagina
            p.Controls.Add(li);
        }

        public static int Ck_Tiene_Selected(CheckBoxList ck) 
        {
            int j = 0;
            for (int i = 0; i < ck.Items.Count; i++)
            {
                if (ck.Items[i].Selected)
                {
                    j++;
                }
            }
            return j;
        }

        public static void DownLoadFile(string fileName, string Extencion, System.Web.UI.Page p)
        {     

            string path = "~/Documentos/";
            
          //  fileName = fileName + "." + Extencion;

            if (File.Exists(p.Server.MapPath(path + fileName)))
            {
                p.Response.Clear();
                p.Response.ContentType = "application/" + Extencion;
                p.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                p.Response.WriteFile(path + fileName);
                p.Response.End();
            }
            else
            {
                p.Response.Write("<script LANGUAGE='JavaScript' >alert('Documento Inexistente!')</script>");
            }
        }

        public static int MoverDDL(DropDownList ddl, string value) 
        {
            int j = 0;
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Value == value)
                {
                    
                    j++;
                }
            }
            return j;       
        }
    }
}