using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            FrmPacientes nuevo = new FrmPacientes();
            nuevo.ShowDialog();
        }
    }
}
