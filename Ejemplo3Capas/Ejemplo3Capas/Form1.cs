using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Ejemplo3Capas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                DTGDatos.DataSource = Agenda.consultarTodos().Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepcion..." + ex);
            }
            
        }

        public void limpiar()
        {
            TxtApellidos.Text = "";
            TxtNombres.Text = "";
            TxtTelefono.Text = "";
            LblId.Text = "0";
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtNombres.Text != "" && TxtApellidos.Text != "" && TxtTelefono.Text != "" && CbxEstado.Text != "")
                {
                    bool resultado = Agenda.insertarRegistro(TxtNombres.Text, TxtApellidos.Text, TxtTelefono.Text, CbxEstado.Text);
                    if (resultado)
                    {
                        MessageBox.Show("Se registro con exito");
                        DTGDatos.DataSource = Agenda.consultarTodos().Tables[0];
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo registrar");
                    }
                }
                else
                {
                    MessageBox.Show("Debe llenar todos los campos");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Excepcion... " + ex);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtNombres.Text != "" && TxtApellidos.Text != "" && TxtTelefono.Text != "" && CbxEstado.Text != "" && LblId.Text != "0")
                {
                    bool resultado = Agenda.modificarRegistro(TxtNombres.Text, TxtApellidos.Text, TxtTelefono.Text, CbxEstado.Text, Convert.ToInt32(LblId.Text));
                    if (resultado)
                    {
                        MessageBox.Show("Se Modifico con exito");
                        DTGDatos.DataSource = Agenda.consultarTodos().Tables[0];
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Modificar");
                    }
                }
                else {
                    MessageBox.Show("Debe llenar todos los campos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepcion... " + ex);
            }
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblId.Text != "0")
                {
                    bool resultado = Agenda.borrarpersonaId(Convert.ToInt32(LblId.Text));
                    if (resultado)
                    {
                        MessageBox.Show("Se Borro con exito");
                        DTGDatos.DataSource = Agenda.consultarTodos().Tables[0];
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo borrar");
                    }
                }
                else
                {
                    MessageBox.Show("Debe llenar todos los campos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepcion... " + ex);
            }
        }

        private void DTGDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void DTGDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DTGDatos.SelectedRows.Count != -1)
            {
                LblId.Text = DTGDatos.CurrentRow.Cells[0].Value.ToString();
                TxtNombres.Text = DTGDatos.CurrentRow.Cells[1].Value.ToString();
                TxtApellidos.Text = DTGDatos.CurrentRow.Cells[2].Value.ToString();
                TxtTelefono.Text = DTGDatos.CurrentRow.Cells[3].Value.ToString();
                CbxEstado.Text = DTGDatos.CurrentRow.Cells[4].Value.ToString();
            }
        }
    }
}
