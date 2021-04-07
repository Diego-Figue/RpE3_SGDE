using appE3_SGDE.Datoss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appE3_SGDE.Vistaa
{
    public partial class frmBuscarSocio : Form
    {
        public frmBuscarSocio()
        {
            InitializeComponent();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            clSocio objSocio = new clSocio();
            objSocio.documento = txtFiltrarSocio.Text;
            DataTable tblDatos = new DataTable();
            tblDatos = objSocio.mtdBuscar();
            dgvFiltrarDocumento.DataSource = tblDatos;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltrarSocio.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
