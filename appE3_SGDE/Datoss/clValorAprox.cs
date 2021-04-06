using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace appE3_SGDE.Datoss
{
    class clValorAprox
    {
        public int idEmpresaProducto { get; set; }
        public int valorAproximado { get; set; }
        public int idEmpresa { get; set; }
        public int idProducto {get; set;}

        public List<clValorAprox> mtdConsultaValorAprox()
        {
            string consulta = "select * from empresaProducto";
            clConexion objConexion = new clConexion();
            DataTable tblDatos = new DataTable();
            tblDatos = objConexion.mtdDesconectado(consulta);
            List<clValorAprox> listValorAprox = new List<clValorAprox>();
            for (int i = 0; i < tblDatos.Rows.Count; i++)
            {
                clValorAprox objValorAprox = new clValorAprox();
                objValorAprox.idEmpresaProducto = int.Parse(tblDatos.Rows[i]["idEmpresaProducto"].ToString());
                objValorAprox.valorAproximado = int.Parse(tblDatos.Rows[i]["valorAproximado"].ToString());
                objValorAprox.idEmpresa = int.Parse(tblDatos.Rows[i]["idEmpresa"].ToString());
                objValorAprox.idProducto = int.Parse(tblDatos.Rows[i]["idProducto"].ToString());

                listValorAprox.Add(objValorAprox);
            }
            return listValorAprox;
        }
        public void mtdListarEmpresa()
        {
            DataTable tblEmpresa;
            clConexion objConexion = new clConexion();
            string consulta = "select * from empresa";
            tblEmpresa = new DataTable();
            tblEmpresa = objConexion.mtdDesconectado(consulta);
        }
        public void mtdListarProducto()
        {
            DataTable tblProducto;
            clConexion objConexion = new clConexion();
            string consulta = "select * from producto";
            tblProducto = new DataTable();
            tblProducto = objConexion.mtdDesconectado(consulta);
        }

        public DataTable mtdVisualizar()
        {
            string consulta = "select * from empresaProducto";
            clConexion objConexion = new clConexion();
            DataTable tblDatos = new DataTable();
            tblDatos = objConexion.mtdDesconectado(consulta);
            return tblDatos;
        }

        public int mtdRegistrar()
        {
            string consulta = "insert into empresaProducto(valorAproximado, idempresa, idproducto)" + "values('" + valorAproximado + "','" + idEmpresa + "','" + idProducto + "')";
            clConexion objConexion = new clConexion();
            int Datos = objConexion.mtdConectado(consulta);
            return Datos;
        }

        public int mtdActualizar()
        {
            string consulta = "updtae empresaProducto set valorAproximado='"+ valorAproximado+"',idEmpresa='"+idEmpresa+"',idProducto='"+idProducto+"'where valorAproximado='"+valorAproximado+"'";
            clConexion objConexion = new clConexion();
            int filasAfectadas = objConexion.mtdConectado(consulta);
            return filasAfectadas;
        }

        public int mtdEliminar()
        {
            string consulta = "delete from empresaProducto where idEmpresaProducto=" + idProducto;
            clConexion objConexion = new clConexion();
            int eliminar = objConexion.mtdConectado(consulta);
            return eliminar;
        }
    }

}
