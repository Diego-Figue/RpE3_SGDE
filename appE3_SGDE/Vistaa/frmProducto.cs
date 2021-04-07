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
using System.IO;

namespace appE3_SGDE.Vistaa
{
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        List<clProducto> listProducto;
        clProducto objProducto;

        private void frmProducto_Load(object sender, EventArgs e)
        {
            mtdCargar();
            
        }

        public void mtdCargarDatos()
        {
            objProducto.nombreProducto = txtNombre.Text;
            objProducto.descripcion = txtDescripcion.Text;


        }

        private void mtdCargar()
        {
            listProducto = new List<clProducto>();
            objProducto = new clProducto();
            listProducto = objProducto.mtdConsultaProducto();
            dgvProducto.DataSource = listProducto;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text) && extension != "" && !string.IsNullOrEmpty(txtDescripcion.Text))
            {
                string nombreImagen = txtNombre.Text + extension;
                objProducto.fotoProducto = nombreImagen;

                string ruta = Directory.GetCurrentDirectory() + "\\imagenes\\";

                File.Copy(openFileProducto.FileName, ruta + nombreImagen);

            }
            else
            {
                MessageBox.Show("Revise Datos!");
            }

            if (!string.IsNullOrEmpty(txtNombre.Text) && extension != "" && !string.IsNullOrEmpty(txtDescripcion.Text))
            {
                mtdCargarDatos();
                int filasAfectadas = objProducto.mtdRegistrar();
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
            mtdCargarDatos();
            int contador = 0;
            string nombreImagen = txtNombre.Text + extension;
            for (int i = 0; i < listProducto.Count; i++)
            {
                if (listProducto[i].nombreProducto == txtNombre.Text && listProducto[i].descripcion == txtDescripcion.Text && listProducto[i].fotoProducto== nombreImagen
                    )
                {
                    MessageBox.Show("Producto Registrado");
                    contador = contador + 1;
                }

            }
            if (contador == 0)
            {
                int filasAfectadas = objProducto.mtdActualizar();
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
            objProducto = new clProducto();
            objProducto.idProducto = idProductoBorrar;
            if (objProducto.mtdEliminar() > 0)
            {
                MessageBox.Show("Producto Eliminado");
                mtdCargar();
            }
            else
            {
                MessageBox.Show("Error al Eliminar Producto");
            }
        }

        private void dgvProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (dgvProducto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvProducto.CurrentRow.Selected = true;
                idProductoBorrar = int.Parse(dgvProducto.Rows[e.RowIndex].Cells["idProducto"].FormattedValue.ToString());
                txtNombre.Text = dgvProducto.Rows[e.RowIndex].Cells["nombreProducto"].FormattedValue.ToString();
                txtDescripcion.Text = dgvProducto.Rows[e.RowIndex].Cells["descripcion"].FormattedValue.ToString();
                
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmPrecioEmpresa objPrecEmpre = new frmPrecioEmpresa();
            objPrecEmpre.ShowDialog();
        }

        string extension = "";
        private void btnCargarIma_Click(object sender, EventArgs e)
        {
            openFileProducto.Filter = "Image Files(JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF";

            if (openFileProducto.ShowDialog() == DialogResult.OK)
            {
                string url = openFileProducto.FileName;
                pbImagen.Load(url);
                extension = Path.GetExtension(url);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
