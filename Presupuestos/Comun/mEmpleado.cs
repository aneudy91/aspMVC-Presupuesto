using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Presupuestos.Comun
{
    public class mEmpleado
    {

        Datos.DatosComun dc = new Datos.DatosComun();

        string connString;

        public int IDEmpleado {get;set;}
	    public string Nombre {get;set;}
	    public string Paterno {get;set;}
	    public string Materno {get;set;}
        public int IDPuesto { get; set; }

        public string Puesto { get; set; }

        DataTable dt;

        public mEmpleado(){
    
        }

        public mEmpleado(int IDEmpleado)
        {
            dt = dc.BindGrid("exec spBuscarEmpleado "+ IDEmpleado.ToString());


            this.IDEmpleado = Convert.ToInt32(dt.Rows[0]["IDEmpleado"].ToString());
            this.Nombre = dt.Rows[0]["Nombre"].ToString();
            this.Paterno = dt.Rows[0]["Paterno"].ToString();
            this.Materno = dt.Rows[0]["Materno"].ToString();
            this.IDPuesto = Convert.ToInt32(dt.Rows[0]["IDPuesto"].ToString());
            this.Puesto = dt.Rows[0]["Puesto"].ToString();
        }


    }
}