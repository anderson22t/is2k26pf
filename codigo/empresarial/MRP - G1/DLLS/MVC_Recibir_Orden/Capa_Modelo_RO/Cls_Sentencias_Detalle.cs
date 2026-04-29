using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Seguridad;

namespace Capa_Modelo_RO
{
    public class Cls_Sentencias_Detalle
    {
        private readonly Cls_Conexion conexion = new Cls_Conexion();
        public DataTable ObtenerDetalleOrden(int idOrden)
        {
            DataTable dt = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            {
                string query = @"
            SELECT 
                d.Pk_Id_Detalle,
                m.Codigo_Material                       AS Material,
                m.Nombre_Material                       AS Descripcion,
                u.Abreviatura_Unidad_Medida             AS [Unidad Medida],
                d.Cantidad_Solicitada                   AS [Cantidad Solicitada]
            FROM Tbl_Orden_Recibida_Detalle d
            INNER JOIN Tbl_Materiales m 
                ON d.Fk_Id_Material = m.Pk_Id_Materiales
            INNER JOIN Tbl_Unidad_Medida u
                ON m.Fk_Id_Unidad_Medida = u.Pk_Id_Unidad_Medida
            WHERE d.Fk_Id_Orden_Recibida = ?";

                OdbcCommand cmd = new OdbcCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idOrden);

                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }


        public DataTable ObtenerOrdenesCombo()
        {
            DataTable dt = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            {
                string query = @"
            SELECT 
                o.Pk_Id_Orden_Recibida,
                o.Id_Externo_Logistica AS Orden
            FROM Tbl_Orden_Recibida o
            ORDER BY o.Id_Externo_Logistica";

                OdbcDataAdapter da = new OdbcDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
