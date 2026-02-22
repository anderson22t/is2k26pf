using System;
using System.Data;
using System.Data.Odbc;
using Capa_Modelo_Seguridad;  // Paula Daniela Leonardo Paredes 0901-22-9580

namespace Capa_Modelo_Banrural // Paula Daniela Leonardo Paredes 0901-22-9580
{
    public class Cls_Sentencias
    {
        // Instancia de la conexión de seguridad
        Cls_Conexion conexion = new Cls_Conexion();

        // ===============================
        // MÉTODO PARA INSERTAR
        // ===============================
        public void Insertar(string consulta)
        {
            OdbcConnection conn = conexion.conexion();
            OdbcCommand cmd = new OdbcCommand(consulta, conn);
            cmd.ExecuteNonQuery();
            conexion.desconexion(conn);
        }

        // ===============================
        // MÉTODO PARA CONSULTAR (SELECT)
        // ===============================
        public DataTable Consultar(string consulta)
        {
            OdbcConnection conn = conexion.conexion();
            OdbcDataAdapter adaptador = new OdbcDataAdapter(consulta, conn);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            conexion.desconexion(conn);
            return tabla;
        }

        // ===============================
        // MÉTODO PARA ACTUALIZAR
        // ===============================
        public void Actualizar(string consulta)
        {
            OdbcConnection conn = conexion.conexion();
            OdbcCommand cmd = new OdbcCommand(consulta, conn);
            cmd.ExecuteNonQuery();
            conexion.desconexion(conn);
        }

        // ===============================
        // MÉTODO PARA ELIMINAR
        // ===============================
        public void Eliminar(string consulta)
        {
            OdbcConnection conn = conexion.conexion();
            OdbcCommand cmd = new OdbcCommand(consulta, conn);
            cmd.ExecuteNonQuery();
            conexion.desconexion(conn);
        }
    }
}
