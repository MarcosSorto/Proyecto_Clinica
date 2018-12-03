using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Proyecto_Clinica.Clases;


namespace Proyecto_Clinica
{
    public partial class FrmEnfermedades : Form
    {
        public FrmEnfermedades()
        {
            InitializeComponent();
        }

        private void FrmEnfermedades_Load(object sender, EventArgs e)
        {
            LimpiarDatos();

        }


        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (txtNombreEnfermedad.Text == "" || txtDescripcion.Text == "")
            {
                MessageBox.Show("Debe de ingresar el nombre y la descripcion de la enfermedad", "Error en ingreso", MessageBoxButtons.OK);

            }
            else
            {
                //Instanciamos de la clase que necesitamos
                Clase_Enfermedades nuevo = new Clase_Enfermedades();
                nuevo.Nombre = txtNombreEnfermedad.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                if (Clase_Enfermedades.InsertarEnfermedad(nuevo))
                {
                    MessageBox.Show(nuevo.msj, "Control de enfermedades");
                    LimpiarDatos();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error duarante la inserción", "Control de enfermedades");
                    LimpiarDatos();
                }
            }
        }

        private void TxtNombreEnfermedad_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Se encaga de limpiar los datos ingresados
        /// </summary>
        public void LimpiarDatos()
        {
            txtDescripcion.Text = "";
            txtNombreEnfermedad.Text = "";
            txtNombreEnfermedad.Focus();
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            btnInhabilitar.Enabled = false;
            txtnuevoNombre.Text = "";
            txtnuevoNombre.Visible = false;
            lblnuevoNombre.Visible = false;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            // Verificamos si hay datos ingresados para guardar.
            if (txtDescripcion.Text == "" || txtNombreEnfermedad.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre y una descripción", "Error en ingreso", MessageBoxButtons.OK);
            }
            else
            {
                // Instanciamos la clase que necesitamos
                Clase_Enfermedades nuevo = new Clase_Enfermedades();
                nuevo.Nombre = txtnuevoNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.NuevoNombre = txtnuevoNombre.Text;

                // Intentamos actualizar los datos.
                if (Clase_Enfermedades.ActualizarEnfermdad(nuevo))
                {
                    MessageBox.Show(nuevo.msj, "Control de enfermedades");
                    LimpiarDatos();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error durante la actualización", "Control de enfermedades");
                    LimpiarDatos();
                }

            }

        }

        private void BtnInhabilitar_Click(object sender, EventArgs e)
        {
            if (txtNombreEnfermedad.Text == "" || txtDescripcion.Text == "")
            {
                MessageBox.Show("Debe seleccionar una enfermedad para inhabilitarla", "Error en ingreso", MessageBoxButtons.OK);
            }
            else
            {
                // Instanciamos de la clase que necesitamos
                Clase_Enfermedades nuevo = new Clase_Enfermedades();
                nuevo.Nombre = txtNombreEnfermedad.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                // Intentamos inhabilitar la enfermedad
                if (Clase_Enfermedades.InhabilitarEnfermedad(nuevo))
                {
                    MessageBox.Show(nuevo.msj, "Control de enfermedades");
                    LimpiarDatos();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error durante la inhabilitación", "Control de enfermedades");
                    LimpiarDatos();
                }
            } 
        }

        private void TxtNombreEnfermedad_Leave(object sender, EventArgs e)
        {
            // instanciamos de la clase enfermedad.
            Clase_Enfermedades nuevo = Clase_Enfermedades.obtenerEnfermeda(txtNombreEnfermedad.Text);

            // Llenamos los datos obtenidos
            txtDescripcion.Text = nuevo.Descripcion;
                if (txtDescripcion.Text !="")
                {
                    txtnuevoNombre.Visible = true;
                    lblnuevoNombre.Visible = true;
                    btnAgregar.Enabled = false;
                    btnEditar.Enabled = true;
                    btnInhabilitar.Enabled = true;
                }
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarEnfermedad nuevo = new FrmBuscarEnfermedad();
            nuevo.ShowDialog();

            txtNombreEnfermedad.Text = FrmBuscarEnfermedad.nombre;
            txtDescripcion.Text = FrmBuscarEnfermedad.descripcion;
            txtNombreEnfermedad.Focus();
        }
    }
}
