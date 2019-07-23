using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer {

    public class Conexion {

         SqlConnection DBConexion () {

            SqlConnection con = new SqlConnection (@"Data Source=ADPRO-0286\SQLEXPRESS;Initial Catalog=inventories;User Id=sa;Password=Sinco123");
            con.Open ();
            return con;
        }

        public DataTable ConsultarSPDT (ConexionDTO obj) {
            DataTable ds = new DataTable ();
            using (SqlConnection context = DBConexion ()) {
                SqlCommand cmd = new SqlCommand (obj.procedimiento.Trim (), context);
                if (obj.parametros != null) {
                    foreach (var item in obj.parametros) {
                        SqlParameter objsp = new SqlParameter ();
                        objsp.ParameterName = item.Key;
                        objsp.Value = item.Value;

                        cmd.Parameters.Add (objsp);
                    }
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 200;
                SqlDataAdapter da = new SqlDataAdapter (cmd);
                try {
                    da.Fill (ds);

                } catch (Exception E) {
                    if (context.State != ConnectionState.Closed) {
                        context.Close ();
                    }
                    throw new ArgumentException (E.Message + E.Source + E.StackTrace + E.TargetSite + E.HelpLink + E.HelpLink);
                }
                context.Close ();
            }
            return ds;
        }
    }
}