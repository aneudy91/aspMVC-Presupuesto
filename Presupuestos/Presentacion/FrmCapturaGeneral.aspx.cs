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
    public partial class FrmCapturaGeneral : System.Web.UI.Page
    {
        DatosComun dc = new DatosComun();

        protected void Page_Load(object sender, EventArgs e)
        {

            var user = Session["User"] as mUsuario;

            if (user == null)
                Response.Redirect("~/Presentacion/FrmCerrarSession.aspx");

            if (!IsPostBack)
            {
                DDLProyectos.DataSource = dc.BindGrid("EXEC spBuscarProyectos 1");
                DDLProyectos.DataValueField = "IDProyecto";
                DDLProyectos.DataTextField = "Nombre";
                DDLProyectos.DataBind();

                gvBind();
            }

        }

        public void gvBind()
        {
            DataTable dt = dc.BindGrid(" exec spBuscarDetalleProyecto " + DDLProyectos.SelectedValue );
            DataTable dtConceptos = dc.BindGrid("EXEC spBuscarConceptos ");

             GridData.Columns.Clear();

            CommandField cfe = new CommandField();
            cfe.EditText = "Actualizar";
            cfe.CancelText = "Cancelar";
            cfe.UpdateText = "Grabar";
            cfe.ShowEditButton = true;
            GridData.Columns.Add(cfe);

            int j = 0; 
        
            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName == "IDEmpleado" || col.ColumnName == "Nombre")
                {
                    //Declare the bound field and allocate memory for the bound field.
                    BoundField bfield = new BoundField();

                    //Initalize the DataField value.
                    bfield.DataField = col.ColumnName;

                    bfield.ReadOnly = true;                

                    //Initialize the HeaderText field value.
                    bfield.HeaderText = col.ColumnName;
                    
                    //Add the newly created bound field to the GridView.
                    GridData.Columns.Add(bfield);
                } 
                else
                {
                    //Declare the bound field and allocate memory for the bound field.
                    BoundField bfield = new BoundField();

                    // bfield.HeaderStyle.Wrap = false;

                    //Initalize the DataField value.
                    bfield.DataField = col.ColumnName;

                    //Initialize the HeaderText field value.
                    bfield.HeaderText = col.ColumnName + " - " + dtConceptos.Rows[j]["CONCEPTO"];

                    //Add the newly created bound field to the GridView.
                    GridData.Columns.Add(bfield);

                    j++;
                }             
       
            }
            
            GridData.DataSource = dt;
            GridData.DataBind();   
        }

        protected void GridData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GridData.EditIndex = -1;
            gvBind();
        }

        protected void GridData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //GridViewRow row = (GridViewRow)GridData.Rows[e.RowIndex];

            //for (int i = 3; i <= row.Cells.Count - 1; i++)
            //{
            //    // TextBox tb = (TextBox)row.Cells[2].Controls[0];
            //    //  Response.Write(row.Cells[0].Text);
            //    TextBox cap = (TextBox)row.Cells[i].Controls[0];
            //    dc.ActualizaDetallePeriodo(CBTiposNomina.SelectedValue, GridData.Columns[i].HeaderText, row.Cells[1].Text, Convert.ToDecimal(cap.Text), 0, 0);
            //}

            //GridData.EditIndex = -1;
            //gvBind();
        }

        protected void GridData_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            /*
             System.Data.DataRowView drv;
             drv = (System.Data.DataRowView)e.Row.DataItem;
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 if (drv != null)
                 {
                     String catName = drv[1].ToString();
                   //  Response.Write(catName + "/");
                     int catNameLen = catName.Length;
                     if (catNameLen > widestData)
                     {
                         widestData = catNameLen;
                         GridData.Columns[2].ItemStyle.Width = widestData * 30;
                         GridData.Columns[2].ItemStyle.Wrap  = false;
                     }
                 }            
             }
             */
        }

        protected void GridData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridData.EditIndex = e.NewEditIndex;
            gvBind();
        }

        protected void Griddata_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridData.PageIndex = e.NewPageIndex;
            gvBind();
        }

        protected void DDLProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvBind();
        }
            

    }
}