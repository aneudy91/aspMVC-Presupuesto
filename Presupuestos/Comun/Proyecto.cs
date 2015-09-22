using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Presupuestos.Comun
{
    public class Proyecto
    {
        public int IDProyecto { get ; set ;}
        public int IDCliente { get; set; }
        public string Cliente { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Boolean Activo { get; set; }
        public int IDEstatus { get; set; }
        public string Estatus { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal CostoRestante { get; set; }


        public Proyecto() 
        {
 
        }

        public Proyecto(int IDProyecto)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDProyecto", IDProyecto);

            DataTable dt = SqlHelper.ExecuteDataset(Datos.DatosComun.constr, CommandType.StoredProcedure, "spBuscarProyecto", param).Tables[0];

            this.IDProyecto = Convert.ToInt32(dt.Rows[0]["IDProyecto"].ToString());
            this.IDCliente = Convert.ToInt32(dt.Rows[0]["IDCliente"].ToString());
            this.Cliente = dt.Rows[0]["Cliente"].ToString();
            this.Nombre = dt.Rows[0]["Nombre"].ToString();
            this.Descripcion = dt.Rows[0]["Decripcion"].ToString();
            this.FechaInicio = Convert.ToDateTime( dt.Rows[0]["FechaInicio"].ToString() );
            this.FechaFin = Convert.ToDateTime(dt.Rows[0]["FechaFin"].ToString());
            this.Activo = Convert.ToBoolean(dt.Rows[0]["Activo"].ToString());
            this.IDEstatus = Convert.ToInt32(dt.Rows[0]["IDEstatus"].ToString());
            this.Estatus = dt.Rows[0]["Estatus"].ToString();
            this.CostoTotal = Convert.ToDecimal( dt.Rows[0]["CostoTotal"].ToString());
            this.CostoRestante = Convert.ToDecimal( dt.Rows[0]["CostoRestante"].ToString() );

        }
    }
}