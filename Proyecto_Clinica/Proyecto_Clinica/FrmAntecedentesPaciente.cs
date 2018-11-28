using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using Proyecto_Clinica.Clases;

namespace Proyecto_Clinica
{
    public partial class FrmAntecedentesPaciente : Form
    {
        public FrmAntecedentesPaciente()
        {
            InitializeComponent();
        }
        private void limpiar()
        {
            txtidentidad.Text = "";
            txtalimentos.Text = "";
            txtmedicamentos.Text = "";
            txtotros.Text = "";
            txtcronicos.Text = "";
            txtcirugias.Text = "";
            txtnombre.Text = "";
            txtidentidad.Focus();
            btnGuardar.Visible = true;
            btnActualizar.Visible = false;
        }

        private void txtguardar_Click(object sender, EventArgs e)
        {
            if (txtidentidad.Text == "")
            {
                MessageBox.Show("Hay espacios en blanco en el formulario", "Control de Pacientes", MessageBoxButtons.OK);
            }
            else
            {
                Clase_AntecedentePaciente nuevo = new Clase_AntecedentePaciente();
                nuevo.Identidad = txtidentidad.Text;
                nuevo.AlergiasAlimentos = txtalimentos.Text;
                nuevo.AlergiaMedicinas = txtmedicamentos.Text;
                nuevo.OtrasAlergias = txtotros.Text;
                nuevo.EnfermedadCronica = txtcronicos.Text;
                nuevo.TtatamientosMedicos = txtcirugias.Text;

                if (Clase_AntecedentePaciente.InsertarAntecedente(nuevo))
                {
                    MessageBox.Show(nuevo.m);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error durante la operación", "Control de pacientes");
                    limpiar();
                }


            }
        }

        private void txtactualizar_Click(object sender, EventArgs e)
        {
            if (txtidentidad.Text == "")
            {
                MessageBox.Show("Debe de ingresar la identidad del paciente", "Control de Pacientes", MessageBoxButtons.OK);
            }
            else
            {
                Clase_AntecedentePaciente nuevo = new Clase_AntecedentePaciente();
                nuevo.Identidad = txtidentidad.Text;
                nuevo.AlergiasAlimentos = txtalimentos.Text;
                nuevo.AlergiaMedicinas = txtmedicamentos.Text;
                nuevo.OtrasAlergias = txtotros.Text;
                nuevo.EnfermedadCronica = txtcronicos.Text;
                nuevo.TtatamientosMedicos = txtcirugias.Text;

                if (Clase_AntecedentePaciente.ActualizarAntecedente(nuevo))
                {
                    MessageBox.Show(nuevo.m);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error durante la operación", "Control de pacientes");
                    limpiar();
                }
            }
        }

        private void txtidentidad_Leave(object sender, EventArgs e)
        {
            Clase_AntecedentePaciente nuevo = Clase_AntecedentePaciente.BuscarAntecedente(txtidentidad.Text);
            // Llenamos los campos con los datos obtenidos

            txtalimentos.Text = nuevo.AlergiasAlimentos;
            txtmedicamentos.Text = nuevo.AlergiaMedicinas;
            txtotros.Text = nuevo.OtrasAlergias;
            txtcronicos.Text = nuevo.EnfermedadCronica;
            txtcirugias.Text = nuevo.TtatamientosMedicos;

            if (txtalimentos.Text != "" || txtmedicamentos.Text != "" || txtcirugias.Text != "" || txtcronicos.Text != "")
            {
                btnActualizar.Visible = true;
                btnGuardar.Visible = false;
            }
            else
            {
                btnActualizar.Visible = false;
                btnGuardar.Visible = true;
            }
        }

        private void txtsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAntecedentesPaciente_Load(object sender, EventArgs e)
        {
            txtidentidad.Text = FrmPacientes.identidad;
            txtnombre.Text = FrmPacientes.nombre;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtidentidad_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
