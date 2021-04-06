using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appE3_SGDE.Vistaa;
using appE3_SGDE.Datoss;

namespace appE3_SGDE.Datoss
{
    class clMapa
    {
        public int idMapa { get; set; }
        public string descripcion { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }

        public List<clMapa> mtdListarMapa()
        {
            string consulta = "select* from mapa";

            clConexion objConexion = new clConexion();
            DataTable tblMapa = new DataTable();
            objConexion.mtdDesconectado(consulta);
            tblMapa = objConexion.mtdDesconectado(consulta);

            List<clMapa> listarMapa = new List<clMapa>();
            for (int i = 0; i < tblMapa.Rows.Count; i++)
            {
                clMapa objPasarMapa = new clMapa();
                objPasarMapa.idMapa = int.Parse(tblMapa.Rows[i]["idMapa"].ToString());
                objPasarMapa.descripcion = tblMapa.Rows[i]["descripcion"].ToString();
                objPasarMapa.latitud = double.Parse(tblMapa.Rows[i]["latitud"].ToString());
                objPasarMapa.longitud = double.Parse(tblMapa.Rows[i]["longitud"].ToString());

                listarMapa.Add(objPasarMapa);
            }

            return listarMapa;
        }
        public int mtdRegistrarMapa()
        {

            string consulta = "insert into mapa(descripcion,latitud,longitud) " +
                "values ('" + descripcion + "','" + latitud + "','" + longitud + "')";

            clConexion objConexion = new clConexion();
            int Datos = objConexion.mtdConectado(consulta);
            return Datos;
        }
    
        public int mtdEliminar()
        {

            string consulta = "delete from mapa where idMapa = " + idMapa;
            clConexion objConexion = new clConexion();
            int eliminar = objConexion.mtdConectado(consulta);
            return eliminar;

        }
    }
}
