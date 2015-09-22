using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace Presupuestos.Datos
{
    public class DatosComun
    {
        public static string constr
        {
            get { return ConfigurationManager.ConnectionStrings["conn"].ConnectionString; }
        }

        public static string Provider
        {
            get { return ConfigurationManager.ConnectionStrings["conn"].ProviderName; }
        }

        public static DbProviderFactory dpf
        {
            get { return DbProviderFactories.GetFactory(Provider); }
        }

        public static int ejecutarNonQuery(string StoreProcedure, List<DbParameter> parametros)
        {
            int id = 0;
            try
            {
                using (DbConnection con = dpf.CreateConnection())
                {
                    con.ConnectionString = constr;
                    using (DbCommand cmd = dpf.CreateCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = StoreProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (DbParameter param in parametros)
                            cmd.Parameters.Add(param);
                        con.Open();
                        id = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e) { throw; }

            return id;
        } // Fin ejecutarNonQuery

        public DataTable BindGrid(string strQuery)
        {
            //  string strQuery = "select CustomerID,City,PostalCode" +
            //     " from customers";
            DataTable dt = new DataTable();
            String strConnString = System.Configuration.ConfigurationManager
                        .ConnectionStrings["conn"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }

        public int ActualizarDetallePeriodo(int IDProyecto,string Concepto,int IDEmpleado, decimal Cap1)
        {
            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = DatosComun.dpf.CreateParameter();
            param.Value = IDProyecto;
            param.ParameterName = "IDProyecto";
            parametros.Add(param);

            DbParameter param1 = DatosComun.dpf.CreateParameter();
            param1.Value = Concepto;
            param1.ParameterName = "Concepto";
            parametros.Add(param1);

            DbParameter param2 = DatosComun.dpf.CreateParameter();
            param2.Value = IDEmpleado;
            param2.ParameterName = "IDEmpleado";
            parametros.Add(param2);

            DbParameter param3 = DatosComun.dpf.CreateParameter();
            param3.Value = Cap1;
            param3.ParameterName = "Cap1";
            parametros.Add(param3);


            return DatosComun.ejecutarNonQuery("spActualizarDetalleProyecto", parametros);
        }

        public int spIAbono(int IDProyecto, DateTime Fecha, decimal Total, string RecibiDe)
        {
            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = DatosComun.dpf.CreateParameter();
            param.Value = IDProyecto;
            param.ParameterName = "IDProyecto";
            parametros.Add(param);

            DbParameter param1 = DatosComun.dpf.CreateParameter();
            param1.Value = Fecha;
            param1.ParameterName = "Fecha";
            parametros.Add(param1);

            DbParameter param2 = DatosComun.dpf.CreateParameter();
            param2.Value = Total;
            param2.ParameterName = "Total";
            parametros.Add(param2);

            DbParameter param3 = DatosComun.dpf.CreateParameter();
            param3.Value = RecibiDe;
            param3.ParameterName = "RecibiDe";
            parametros.Add(param3);


            return DatosComun.ejecutarNonQuery("spIAbono", parametros);
        }

        public int CalculoProyecto(int IDProyecto)
        {
            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = DatosComun.dpf.CreateParameter();
            param.Value = IDProyecto;
            param.ParameterName = "IDProyecto";
            parametros.Add(param);

            return DatosComun.ejecutarNonQuery("spCalculoProyecto", parametros);
        
        }


    }
}