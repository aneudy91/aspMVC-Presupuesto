using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Presupuestos.Comun
{
    class mUsuario
    {
        string connString;

        public int IDUsuario { set; get; }
        public int IDEmpresa { set; get; }
        public int IDClienteEmpresa { set; get; }
        public string Nombre { set; get; }
        public string NombreCuenta { set; get; }
        public string Clave { set; get; }

        DataTable dtUserdata;

        public mUsuario(string conn) 
        {
            this.connString = conn;
            this.IDUsuario = 0;

        }


        public mUsuario(string conn, int idEmpresa)
        {
            this.connString = conn;
  
        }

        public mUsuario(string conn, DataTable dtUserdata)
        {
            this.connString = conn;
            this.dtUserdata = dtUserdata;
            this.IDUsuario = Convert.ToInt32(dtUserdata.Rows[0]["idUsuario"].ToString());                      
            this.Nombre =dtUserdata.Rows[0]["Nombre"].ToString();
            this.NombreCuenta = dtUserdata.Rows[0]["NombreCuenta"].ToString();
    
        }

        public mUsuario(string conn, string nombreCuenta, string Clave) 
        {
            this.connString = conn;
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@NombreCuenta", nombreCuenta);
            param[1] = new SqlParameter("@Clave", Clave);
            DataTable dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "spLogIn", param).Tables[0];

            this.IDUsuario = Convert.ToInt32(dt.Rows[0]["IDUsuario"].ToString());
            this.Nombre = dt.Rows[0]["Nombre"].ToString();
            this.NombreCuenta = dt.Rows[0]["NombreCuenta"].ToString();
            this.Clave = dt.Rows[0]["NombreCuenta"].ToString();

        }

        public void loadUsuario(int idUsuario)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDUsuario", idUsuario);

            DataTable dt = SqlHelper.ExecuteDataset(this.connString, CommandType.StoredProcedure, "spBuscarUsuarios", param).Tables[0];
            this.IDUsuario = Convert.ToInt32(dt.Rows[0]["IDUsuario"].ToString());                    
            this.Nombre = dt.Rows[0]["Nombre"].ToString();
            this.NombreCuenta = dt.Rows[0]["NombreCuenta"].ToString();
            this.Clave = dt.Rows[0]["Clave"].ToString();

        }

        public static mUsuario logging(string conn,string nombreCuenta, string Clave) 
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@NombreCuenta", nombreCuenta);
            param[1] = new SqlParameter("@Clave", Clave);
            DataTable dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "spLogIn", param).Tables[0];

            if (dt.Rows.Count > 0) 
            {
                
                mUsuario user = new mUsuario(conn,dt);

                return user;
            }
            else
            {
                return null;
            }

        
        }

        public bool insertUsuario()
        {
            int result;
            try
            {
                SqlParameter[] param = new SqlParameter[7];                
                param[2] = new SqlParameter("@Nombre", this.Nombre);
                param[3] = new SqlParameter("@NombreCuenta", this.NombreCuenta);
                param[4] = new SqlParameter("@Clave", this.Clave);
                param[5] = new SqlParameter("@IDUsuario", this.IDUsuario);
                param[6] = new SqlParameter("@Actualizar", 0);
                result = SqlHelper.ExecuteNonQuery(this.connString, CommandType.StoredProcedure, "spInsertUsuarios", param);
            }
            catch (Exception e)
            {
                result = 0;
            }

            return Convert.ToBoolean(result);

        }

        public bool updateUsuario()
        {
            int result;
            try
            {
                SqlParameter[] param = new SqlParameter[7];             
                param[2] = new SqlParameter("@Nombre", this.Nombre);
                param[3] = new SqlParameter("@NombreCuenta", this.NombreCuenta);
                param[4] = new SqlParameter("@Clave", this.Clave);
                param[5] = new SqlParameter("@IDUsuario", this.IDUsuario);
                param[6] = new SqlParameter("@Actualizar", 1);
                result = SqlHelper.ExecuteNonQuery(this.connString, CommandType.StoredProcedure, "spInsertUsuarios", param);
            }
            catch (Exception e)
            {
                result = 0;
            }

            return Convert.ToBoolean(result);

        }

        public bool getAdminUserValidate() 
        {
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                DataTable dt = SqlHelper.ExecuteDataset(this.connString, CommandType.StoredProcedure, "spBuscarUsuariosAdmin", param).Tables[0];
                DataRow[] rows = dt.Select("IDUsuario = "+this.IDUsuario.ToString());

                if (rows.Length > 0) 
                {
                    return true;
                }
                else { return false; }

            }
            catch (Exception e) 
            {
                
                return false;
            }
        }

        public bool DeleteUser(int idUsuario)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@idUsuario", idUsuario);
                int i = SqlHelper.ExecuteNonQuery(this.connString, CommandType.StoredProcedure, "spDeleteUsuarios", param);

                if (i == 1) 
                {
                    return true;
                }else
                {
                    return false;
                }

            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}
