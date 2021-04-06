using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace appE3_SGDE.Datoss
{
    class clProducto
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public string descripcion { get; set; }
        public string fotoProducto { get; set; }
        


        public List<clProducto> mtdConsultaProducto()
        {
            string consulta = "select * from producto";
            clConexion objConexion = new clConexion();
            DataTable tblDatos = new DataTable();
            tblDatos = objConexion.mtdDesconectado(consulta);
            List<clProducto> listProducto = new List<clProducto>();
            for (int i = 0; i < tblDatos.Rows.Count; i++)
            {
                clProducto objProducto = new clProducto();
                objProducto.idProducto = int.Parse(tblDatos.Rows[i]["idProducto"].ToString());
                objProducto.nombreProducto = tblDatos.Rows[i]["nombreProducto"].ToString();
                objProducto.descripcion = tblDatos.Rows[i]["descripcion"].ToString();
                objProducto.fotoProducto = tblDatos.Rows[i]["fotoProducto"].ToString();


                listProducto.Add(objProducto);
            }
            return listProducto;
        }

        public DataTable mtdVisualizar()
        {
            string consulta = "select * from producto";
            clConexion objConexion = new clConexion();
            DataTable tblDatos = new DataTable();
            tblDatos = objConexion.mtdDesconectado(consulta);
            return tblDatos;
        }

        public int mtdRegistrar()
        {
            string consulta = "insert into producto (nombreProducto, descripcion, fotoProducto)" + "values ('" + nombreProducto + "','" + descripcion + "','"+fotoProducto+"')";
            clConexion objConexion = new clConexion();
            int Datos = objConexion.mtdConectado(consulta);
            return Datos;
        }

        public int mtdActualizar()
        {
            string consulta = "update producto set nombreProducto='" + nombreProducto + "',descripcion= '" + descripcion +"',fotoProducto='"+fotoProducto+ "'where nombreProducto='" + nombreProducto + "'";
            clConexion objConexion = new clConexion();
            int filasAfectadas = objConexion.mtdConectado(consulta);
            return filasAfectadas;
        }

        public int mtdEliminar()
        {
            string consulta = "delete from producto where idProducto = " + idProducto;
            clConexion objConexion = new clConexion();
            int eliminar = objConexion.mtdConectado(consulta);
            return eliminar;
        }




    }
}
