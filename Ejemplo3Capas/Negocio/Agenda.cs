using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Logica;
using System.Windows.Forms;

namespace Negocio
{
    public class Agenda
    {
        public static DataSet consultarTodos()
        {
            DataSet ds = null;
            Conexion con = new Conexion();

            try
            {
                ds = con.consultar(Constantes.pro_traer_persona);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, " + ex);
            }
            return ds;
        }


        public static bool insertarRegistro(String nombres, String apellidos, String telefono, String estado)
        {
            bool resultado = false;
            Conexion con = new Conexion();

            try
            {
                String[] parametros = new String[4];
                parametros[0] = nombres;
                parametros[1] = apellidos;
                parametros[2] = telefono;
                parametros[3] = estado;

                resultado = con.ejecutar(Constantes.pro_crear_persona, parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, " + ex);
            }
            return resultado;
        }

        public static bool modificarRegistro(String nombres, String apellidos, String telefono, String estado, int id)
        {
            bool resultado = false;
            Conexion con = new Conexion();

            try
            {
                String[] parametros = new String[5];
                parametros[0] = id.ToString();
                parametros[1] = nombres;
                parametros[2] = apellidos;
                parametros[3] = telefono;
                parametros[4] = estado;

                resultado = con.ejecutar(Constantes.pro_modificar_persona, parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, " + ex);
            }
            return resultado;
        }

        public static bool borrarpersonaId(int id)
        {
            bool resultado = false;
            Conexion con = new Conexion();

            try
            {
                String[] parametros = new String[1];
                parametros[0] = id.ToString();

                resultado = con.ejecutar(Constantes.pro_borrar_id, parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, " + ex);
            }
            return resultado;
        }


    }
}
