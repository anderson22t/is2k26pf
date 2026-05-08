using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Seguridad;

namespace Capa_Modelo_Prod
{
    public class Cls_Sentencias_Prod
    {
        private readonly Cls_Conexion conexion = new Cls_Conexion();

        public DataTable ObtenerOrdenesRecibidas()
        {
            DataTable dt = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            {
                string query = @"
            SELECT 
                o.Pk_Id_Orden_Recibida,
                CONCAT(o.Id_Externo_Logistica, ' | ', 
                       DATE_FORMAT(o.Fecha_Requerida, '%Y-%m-%d')) AS Descripcion
            FROM Tbl_Orden_Recibida o
            INNER JOIN Tbl_Estado_Orden_Recibida e
                ON o.Fk_Id_Estado_Orden_Recibida = e.Pk_Id_Estado_Orden_Recibida
            ORDER BY o.Fecha_Recepcion DESC";

                OdbcDataAdapter da = new OdbcDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }


        public DataTable ObtenerInfoOrdenRecibida(int idOrden)
        {
            DataTable dt = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            {
                string query = @"
            SELECT 
                o.Id_Externo_Logistica          AS No_Orden,
                e.Nombre_Estado_Orden_Recibida  AS Estado,
                DATE_FORMAT(o.Fecha_Recepcion, '%Y-%m-%d')  AS Fecha_Recepcion,
                DATE_FORMAT(o.Fecha_Requerida, '%Y-%m-%d')  AS Fecha_Requerida,
                o.Observacion
            FROM Tbl_Orden_Recibida o
            INNER JOIN Tbl_Estado_Orden_Recibida e
                ON o.Fk_Id_Estado_Orden_Recibida = e.Pk_Id_Estado_Orden_Recibida
            WHERE o.Pk_Id_Orden_Recibida = ?";

                OdbcDataAdapter da = new OdbcDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("?", idOrden);
                da.Fill(dt);
            }
            return dt;
        }

        // Productos a fabricar (detalle de la orden recibida)
        public DataTable ObtenerProductosOrdenRecibida(int idOrden)
        {
            DataTable dt = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            {
                string query = @"
            SELECT 
                m.Codigo_Material                   AS Codigo,
                m.Nombre_Material                   AS Producto,
                d.Cantidad_Solicitada               AS Cantidad,
                um.Abreviatura_Unidad_Medida        AS Unidad,
                m.Lead_Time_Produccion_Dias         AS Lead_Time_Dias
            FROM Tbl_Orden_Recibida_Detalle d
            INNER JOIN Tbl_Materiales m 
                ON d.Fk_Id_Material = m.Pk_Id_Materiales
            INNER JOIN Tbl_Unidad_Medida um 
                ON m.Fk_Id_Unidad_Medida = um.Pk_Id_Unidad_Medida
            WHERE d.Fk_Id_Orden_Recibida = ?";

                OdbcDataAdapter da = new OdbcDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("?", idOrden);
                da.Fill(dt);
            }
            return dt;
        }



    }
}
