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
    public partial class frmSocio : Form
    {
        public frmSocio()
        {
            InitializeComponent();
            mtdCargar();
        }

        List<clSocio> listSocio;
        clSocio objSocio =  new clSocio();
        private void frmEmpresa_Load(object sender, EventArgs e)
        {
            mtdCargar();
        }
        public void mtdCargarDatos()
        {

            objSocio.documento = txtDocumento.Text;
            objSocio.nombre = txtNombre.Text;
            objSocio.apellido = txtApellido.Text;
            objSocio.direccion = txtDireccion.Text;
            objSocio.telefono = txtTelefono.Text;
            objSocio.email = txtEmail.Text;

            if (rbSi.Checked == true)
            {
                objSocio.disponibilidad = "Si";
            }
            else
            {
                objSocio.disponibilidad = "No";
            }
            
        }
        private void mtdCargar()
        {
            listSocio = new List<clSocio>();
            objSocio = new clSocio();
            listSocio = objSocio.mtdConsultaSocio();
            dgvListarSocios.DataSource = listSocio;

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            mtdCargarDatos();

            int filasAfectadas = objSocio.mtdRegistrar();
            if (filasAfectadas > 0)
            {
                MessageBox.Show("Socio Registrado", "SGDE", MessageBoxButtons.OK);

                mtdCargar();

            }
            else
            {
                MessageBox.Show("Error Al Socio", "SGDE", MessageBoxButtons.OK);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            mtdCargarDatos();

            int contador = 0;
            for (int i = 0; i < listSocio.Count; i++)
            {
                if (listSocio[i].documento == txtDocumento.Text && listSocio[i].nombre == txtNombre.Text && listSocio[i].apellido == txtApellido.Text && listSocio[i].direccion == txtDireccion.Text && listSocio[i].telefono == txtTelefono.Text && listSocio[i].email == txtEmail.Text)
                {
                    MessageBox.Show("Socios Actualizados");
                    contador = contador + 1;
                }
            }
            if (contador == 0)
            {
                int filasAfectadas = objSocio.mtdActualizar();
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
        int idSocioBorrar = 0;
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objSocio = new clSocio();
            objSocio.idSocio = idSocioBorrar;

            if (objSocio.mtdEliminar() > 0)
            {
                MessageBox.Show("Socio Eliminado");
                mtdCargar();

            }
            else
            {
                MessageBox.Show("Error, no se pudo eliminar el socio");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarSocio objBuscarSocio = new frmBuscarSocio();
            objBuscarSocio.ShowDialog();
        }
    }
}
