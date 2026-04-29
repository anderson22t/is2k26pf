using System;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Recetas
{
    public class Sentencias
    {
        Conexion cn = new Conexion();

        // 🔹 1. Productos terminados
        public DataTable obtenerProductosTerminados()
        {
            DataTable tabla = new DataTable();

            using (OdbcConnection conn = cn.AbrirConexion())
            {
                string sql = @"
                SELECT m.Pk_Id_Materiales, m.Nombre_Material
                FROM Tbl_Materiales m
                JOIN Tbl_Categoria_Material c ON m.Fk_Id_Categoria = c.Pk_Id_Categoria_Material
                JOIN Tbl_Tipo_Material t ON c.Fk_Tipo_Material = t.Pk_Id_Tipo_Material
                WHERE t.Nombre_Tipo_Material = 'Producto Terminado';";

                OdbcDataAdapter da = new OdbcDataAdapter(sql, conn);
                da.Fill(tabla);
            }

            return tabla;
        }

        // 🔹 2. Cabecera BOM
        public DataTable obtenerBOM(int idProducto)
        {
            DataTable tabla = new DataTable();

            using (OdbcConnection conn = cn.AbrirConexion())
            {
                string sql = @"
                SELECT 
                    b.Pk_Id_BOM,
                    b.Descripcion_BOM,
                    b.Version_BOM,
                    b.Fecha_Creacion_BOM,
                    b.Fk_Id_Estado_BOM
                FROM Tbl_BOM b
                WHERE b.Fk_Id_Material = ?;";

                OdbcCommand cmd = new OdbcCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", idProducto);

                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }

        // 🔹 3. Detalle BOM
        public DataTable obtenerDetalleBOM(int idProducto)
        {
            DataTable tabla = new DataTable();

            using (OdbcConnection conn = cn.AbrirConexion())
            {
                string sql = @"
                SELECT 
                    d.Fk_Id_Materiales,
                    m.Nombre_Material,
                    d.Cantidad_Requerida_BOM_Detalle,
                    u.Nombre_Unidad_Medida,
                    d.Porcentaje_Merma_BOM_Detalle
                FROM Tbl_BOM b
                JOIN Tbl_BOM_Detalle d ON b.Pk_Id_BOM = d.Fk_Id_BOM
                JOIN Tbl_Materiales m ON d.Fk_Id_Materiales = m.Pk_Id_Materiales
                JOIN Tbl_Unidad_Medida u ON d.Fk_Id_Unidad_Medida = u.Pk_Id_Unidad_Medida
                WHERE b.Fk_Id_Material = ?;";

                OdbcCommand cmd = new OdbcCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", idProducto);

                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }

        // 🔹 4. Estados
        public DataTable obtenerEstados()
        {
            DataTable tabla = new DataTable();

            using (OdbcConnection conn = cn.AbrirConexion())
            {
                string sql = "SELECT * FROM Tbl_Estado_BOM";

                OdbcDataAdapter da = new OdbcDataAdapter(sql, conn);
                da.Fill(tabla);
            }

            return tabla;
        }
    }
}