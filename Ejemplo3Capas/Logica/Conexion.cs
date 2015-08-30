using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Logica
{
    public class Conexion
    {
        public SqlConnection obtenerConexion()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Constantes.instancia);
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, " + ex);
            }
            return con;
        }

        public DataSet consultar(String cadena)
        {
            DataSet ds = new DataSet();
            
            try
            {
                  SqlDataAdapter cmd = new SqlDataAdapter(string.Format(cadena), obtenerConexion());
                  cmd.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepcion..." + ex);
            }
            return ds;
        }

        public DataTable consultar(String cadena, String[] para)
        {
            DataTable dt = null;
            String parametro = "";

            try{
                parametro = "'{0}'";
                if (para.Length > 1)
                {
                    for (int i = 0; i < para.Length; i++) {
                        parametro += ", '{" + i + "}'";
                    }
                }
                SqlDataAdapter cmd = new SqlDataAdapter(String.Format(cadena + parametro, para), obtenerConexion());
                cmd.Fill(dt);
            }
            catch (Exception ex) {
                MessageBox.Show("Excepcion..." + ex);
            }
            return dt;
        }

        public Boolean ejecutar(String cadena, String[] para) {
            bool resultado = false;
            String parametro = "";
            try
            {

                parametro = "'{0}'";
                if (para.Length > 1)
                {
                    for (int i = 1; i < para.Length; i++) {
                        parametro += ", '{" + i + "}'";
                    }
                }

                SqlCommand cmd = new SqlCommand(String.Format(cadena + parametro, para), obtenerConexion());
                cmd.ExecuteNonQuery();
                if (cmd != null) {
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepcion..." + ex);
            }
            return resultado;
        }

    }
}
