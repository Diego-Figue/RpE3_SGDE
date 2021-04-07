using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appE3_SGDE.Datoss;
using appE3_SGDE.Vistaa;
using System.IO;

namespace appE3_SGDE.Vistaa
{
    public partial class frmPrecioEmpresa : Form
    {
        public frmPrecioEmpresa()
        {
            InitializeComponent();
        }

        List<clValorAprox> listValorAprox;
        clValorAprox objValorAprox;


        private void frmPrecioEmpresa_Load(object sender, EventArgs e)
        {
            mtdCargar();
            List<clEmpresa> listEmpresa = new List<clEmpresa>();

            clEmpresa objEmpresa = new clEmpresa();
            listEmpresa = objEmpresa.mtdConsultaEmpresa();
            cmbEmpresa.DataSource = listEmpresa;
            cmbEmpresa.DisplayMember = "nombre";
            cmbEmpresa.ValueMember = "idEmpresa";

            List<clProducto> listProducto = new List<clProducto>();

            clProducto objProducto = new clProducto();
            listProducto = objProducto.mtdConsultaProducto();
            cmbProducto.DataSource = listProducto;
            cmbProducto.DisplayMember = "nombreProducto";
            cmbProducto.ValueMember = "idProducto";

        }

        public void mtdCargarDatos()
        {
            objValorAprox.valorAproximado = int.Parse(txtValorAprox.Text);
            objValorAprox.idEmpresa = int.Parse(cmbEmpresa.Text);
            objValorAprox.idProducto = int.Parse(cmbProducto.Text);


        }

        private void mtdCargar()
        {
            listValorAprox = new List<clValorAprox>();
            objValorAprox = new clValorAprox();
            listValorAprox = objValorAprox.mtdConsultaValorAprox();
            dgvValorAprox.DataSource = listValorAprox;
        }

        string extension = "";
        private void btnCargarIma_Click(object sender, EventArgs e)
        {
            openFileProducAprox.Filter = "Image Files(JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF";

            if (openFileProducAprox.ShowDialog() == DialogResult.OK)
            {
                string url = openFileProducAprox.FileName;
                pbImagen.Load(url);
                extension = Path.GetExtension(url);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtValorAprox.Text) && extension != "")
            {
                string ruta = Directory.GetCurrentDirectory() + "\\imagenes\\";
                string nombreImagen = txtValorAprox.Text + extension;
                File.Copy(openFileProducAprox.FileName, ruta + nombreImagen);
            }
            else
            {
                MessageBox.Show("Revise Datos!");
            }

            if (!string.IsNullOrEmpty(txtValorAprox.Text) && extension != "")
            {
                mtdCargarDatos();
                int filasAfectadas = objValorAprox.mtdRegistrar();
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Producto Registrado", "SGDE", MessageBoxButtons.OK);
                    mtdCargar();

                }
            }

            else
            {
                MessageBox.Show("Error al Registrar", "SGDE", MessageBoxButtons.OK);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            mtdCargar();
            int contador = 0;
            for (int i = 0; i < listValorAprox.Count; i++)
            {
                if (listValorAprox[i].valorAproximado == int.Parse(txtValorAprox.Text) && listValorAprox[i].idEmpresa == int.Parse(cmbEmpresa.Text))
                {
                    MessageBox.Show("Dato Registrado");
                }
            }
            if (contador == 0)
            {
                int filasAfectadas = objValorAprox.mtdActualizar();
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Se Actualizo Correctamente");
                    mtdCargar();
                }
                else
                {
                    MessageBox.Show("Error Al Actualizar");
                }
            }           
        }

        int idProductoBorrar = 0;
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objValorAprox = new clValorAprox();
            objValorAprox.idEmpresaProducto = idProductoBorrar;
            if (objValorAprox.mtdEliminar()>0)
            {
                MessageBox.Show("Eliminado");
                mtdCargar();
            }
            else
            {
                MessageBox.Show("Error al Eliminar");
            }
        }

        private void dgvValorAprox_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvValorAprox.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
            {
                dgvValorAprox.CurrentRow.Selected = true;
                idProductoBorrar = int.Parse(dgvValorAprox.Rows[e.RowIndex].Cells["idempresaProducto"].FormattedValue.ToString());
                txtValorAprox.Text = dgvValorAprox.Rows[e.RowIndex].Cells["ValorAproximado"].FormattedValue.ToString();
                cmbEmpresa.Text = dgvValorAprox.Rows[e.RowIndex].Cells["idEmpresa"].FormattedValue.ToString();
                cmbProducto.Text = dgvValorAprox.Rows[e.RowIndex].Cells["idProducto"].FormattedValue.ToString();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
