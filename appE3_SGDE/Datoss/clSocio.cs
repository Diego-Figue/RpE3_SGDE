using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appE3_SGDE.Datoss
{
    class clSocio
    {
        public int idSocio { get; set; }
        public string documento { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string disponibilidad { get; set; }
        public List<clSocio> mtdConsultaSocio()
        {

            string consulta = "select * from socio";
            clConexion objConexion = new clConexion();
            DataTable tblDatos = new DataTable();
            tblDatos = objConexion.mtdDesconectado(consulta);
            List<clSocio> listSocio = new List<clSocio>();
            for (int i = 0; i < tblDatos.Rows.Count; i++)
            {
                clSocio objSocio = new clSocio();
                objSocio.idSocio = int.Parse(tblDatos.Rows[i]["idSocio"].ToString());
                objSocio.documento = tblDatos.Rows[i]["documento"].ToString();
                objSocio.nombre = tblDatos.Rows[i]["nombre"].ToString();
                objSocio.apellido = tblDatos.Rows[i]["apellido"].ToString();
                objSocio.direccion = tblDatos.Rows[i]["direccion"].ToString();
                objSocio.telefono = tblDatos.Rows[i]["telefono"].ToString();
                objSocio.email = tblDatos.Rows[i]["email"].ToString();
                objSocio.disponibilidad = tblDatos.Rows[i]["disponibilidad"].ToString();

                listSocio.Add(objSocio);

            }

            return listSocio;
        }
        public int mtdRegistrar()
        {

            string consulta = "insert into socio(documento,nombre,apellido,direccion,telefono,email,disponibilidad) " +
                "values ('" + documento + "','" + nombre + "','" + apellido + "','" + direccion + "','"+ telefono + "','"+ email +"','"+ disponibilidad +"')";

            clConexion objConexion = new clConexion();
            int Datos = objConexion.mtdConectado(consulta);
            return Datos;

        }
        public int mtdActualizar()
        {
            string consulta = "update socio set (documento='" + documento +"',nombre='" + nombre + "',apellido= '" + apellido +
                "', direccion='" + direccion + "', email='" + disponibilidad + "')";

            clConexion objConexion = new clConexion();
            int filasAfectadas = objConexion.mtdConectado(consulta);
            return filasAfectadas;
        }
        public int mtdEliminar()
        {

            string consulta = "delete from socio where idSocio = " + idSocio;
            clConexion objConexion = new clConexion();
            int eliminar = objConexion.mtdConectado(consulta);
            return eliminar;

        }
        public DataTable mtdBuscar()
        {
            string consulta = "select * from socio where documento='" + documento + "'";
            clConexion objConexion = new clConexion();
            DataTable tblDatos = new DataTable();
            tblDatos = objConexion.mtdDesconectado(consulta);
            return tblDatos;
        }
    }
}
