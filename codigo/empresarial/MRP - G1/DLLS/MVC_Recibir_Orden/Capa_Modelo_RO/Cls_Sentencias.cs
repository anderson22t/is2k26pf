using Capa_Modelo_Seguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace Capa_Modelo_RO
{
    public class Cls_Sentencias
    {
        private readonly Cls_Conexion conexion = new Cls_Conexion();

        public DataTable ObtenerOrdenes()
        {
            DataTable dt = new DataTable();

            using (OdbcConnection conn = conexion.AbrirConexion())
            {
                string query = @"
                    SELECT 
                        o.Pk_Id_Orden_Recibida,
                        o.Id_Externo_Logistica AS Orden,
                        o.Fecha_Recepcion,
                        o.Fecha_Requerida,
                        e.Nombre_Estado AS Estado
                    FROM Tbl_Orden_Recibida o
                    INNER JOIN Tbl_Estado_Orden_Recibida e 
                        ON o.Fk_Id_Estado_Orden_Recibida = e.Pk_Id_Estado_Orden_Recibida";

                OdbcDataAdapter da = new OdbcDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }
    }
}
