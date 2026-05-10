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
    public class Cls_Sentencias_Materiales
    {
        private readonly Cls_Conexion conexion = new Cls_Conexion();
        public DataTable ObtenerMaterialesConsumidos(int idOrden)
        {
            DataTable dt = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            {
                string query = @"
            SELECT 
                m.Pk_Id_Materiales              AS Id_Material,
                m.Nombre_Material               AS Material,
                u.Abreviatura_Unidad_Medida     AS Unidad,
                emd.Cantidad_Total              AS Cantidad_Necesaria,
                emd.Cantidad_Real_Con_Merma     AS Cantidad_Con_Merma,
                i.Costo_Unitario                AS Costo_Unitario,
                (emd.Cantidad_Real_Con_Merma * i.Costo_Unitario) AS Subtotal
            FROM Tbl_Orden_Produccion op
            INNER JOIN Tbl_Plan_Produccion pp 
                ON op.Fk_Id_Plan_Produccion = pp.Pk_Id_Plan_Produccion
            INNER JOIN Tbl_Explosion_Materiales em 
                ON pp.Fk_Id_Orden_Recibida = em.Fk_Id_Orden_Recibida
            INNER JOIN Tbl_Explosion_Materiales_Detalle emd 
                ON em.Pk_Id_Explosion = emd.Fk_Id_Explosion
            INNER JOIN Tbl_Materiales m 
                ON emd.Fk_Id_Material = m.Pk_Id_Materiales
            INNER JOIN Tbl_Unidad_Medida u
                ON m.Fk_Id_Unidad_Medida = u.Pk_Id_Unidad_Medida
            INNER JOIN Tbl_Inventario i
                ON emd.Fk_Id_Material = i.Fk_Id_Material
            WHERE op.Pk_Id_Orden_Produccion = ?";

                OdbcCommand cmd = new OdbcCommand(query, conn);
                cmd.Parameters.AddWithValue("?", idOrden);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
