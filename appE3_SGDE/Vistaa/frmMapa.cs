﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using appE3_SGDE.Datoss;
using appE3_SGDE.Vistaa;


namespace appE3_SGDE.Vistaa
{
    public partial class frmMapa : Form
    {
        GMarkerGoogle marker;
        GMapOverlay markOverlay;

        int filasSeleccionada = 0;
        double LatInicial = 5.717;
        double LngInicial = -72.917;
        public frmMapa()
        {
            InitializeComponent();
        }
        public void mtdCargarGrind()
        {
            clMapa objMapa = new clMapa();
            List<clMapa> listMapa = new List<clMapa>();
            listMapa = objMapa.mtdListarMapa();
            dgvCooredenadas.DataSource = listMapa;
        }
        private void frmMapa_Load(object sender, EventArgs e)
        {
            mtdCargarGrind();

            this.dgvCooredenadas.Columns["idMapa"].Visible = false;
            this.dgvCooredenadas.Columns["latitud"].Visible = false;
            this.dgvCooredenadas.Columns["longitud"].Visible = false;

            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(LatInicial, LngInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;

            markOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.red_dot);
            markOverlay.Markers.Add(marker);

            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("Ubicación: \n Latitud:{0} \n Longitud:{1}", LatInicial, LngInicial);

            gMapControl1.Overlays.Add(markOverlay);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SeleccionarRegistro(object sender, DataGridViewCellMouseEventArgs e)
        {
            //filasSeleccionada = e.RowIndex;
            //txtDescripcion.Text = dgvCooredenadas.Rows[filasSeleccionada].Cells[0].Value.ToString();
            //txtLatitud.Text = dgvCooredenadas.Rows[filasSeleccionada].Cells[1].Value.ToString();
            //txtLongitud.Text = dgvCooredenadas.Rows[filasSeleccionada].Cells[2].Value.ToString();

            //marker.Position = new PointLatLng(Convert.ToDouble(txtLatitud.Text), Convert.ToDouble(txtLongitud.Text));

            //gMapControl1.Position = marker.Position;

        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;

            txtLatitud.Text = lat.ToString();
            txtLongitud.Text = lng.ToString();

            marker.Position = new PointLatLng(lat, lng);
            marker.ToolTipText = string.Format("Ubicación: \n Latitud:{0} \n Longitud:{1}", lat, lng);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //dt.Rows.Add(txtDescripcion.Text, txtLatitud.Text, txtLongitud.Text);


            clMapa objMapa = new clMapa();
            objMapa.descripcion = txtDescripcion.Text;
            objMapa.latitud = double.Parse(txtLatitud.Text);
            objMapa.longitud = double.Parse(txtLongitud.Text);


            int cantidadRegistros = objMapa.mtdRegistrarMapa();
            if (cantidadRegistros > 0)
            {
                mtdCargarGrind();
                MessageBox.Show("Descripcion Agregada", "SGDE", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Error Al Agregar Descripcion", "SGDE", MessageBoxButtons.OK);
            }

        }
        clMapa objMapa = new clMapa();
        int idMap = 0;
      
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            DialogResult opccion = MessageBox.Show("Desea eliminar este lugar? " + txtDescripcion.Text , "Eliminar Lugar",MessageBoxButtons.YesNo);
            if (opccion== DialogResult.Yes)
            {
                int filasAfectadas = objMapa.mtdEliminar(idMap);
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Lugar Eliminado");
                    mtdCargarGrind();
                }
                else
                {
                    MessageBox.Show("Error, no se pudo eliminar el lugar");
                }
            }
          
        }
       

        private void dgvCooredenadas_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            idMap = int.Parse(dgvCooredenadas.Rows[e.RowIndex].Cells["idMapa"].FormattedValue.ToString());
            filasSeleccionada = e.RowIndex;
            txtDescripcion.Text = dgvCooredenadas.Rows[filasSeleccionada].Cells[1].Value.ToString();
            txtLatitud.Text = dgvCooredenadas.Rows[filasSeleccionada].Cells[2].Value.ToString();
            txtLongitud.Text = dgvCooredenadas.Rows[filasSeleccionada].Cells[3].Value.ToString();

            marker.Position = new PointLatLng(Convert.ToDouble(txtLatitud.Text), Convert.ToDouble(txtLongitud.Text));

            gMapControl1.Position = marker.Position;
        }
    }
}
