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

        public DataTable ObtenerOrdenesProduccion()
        {
            DataTable dt = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            {
                string query = @"
            SELECT 
                op.Pk_Id_Orden_Produccion AS IdOrden,
                CONCAT(m.Nombre_Material, ' | ', 
                       DATE_FORMAT(op.Fecha_Inicio_Orden_Produccion, '%Y-%m-%d'), ' - ',
                       DATE_FORMAT(op.Fecha_Fin_Orden_Produccion, '%Y-%m-%d')) AS Descripcion
            FROM Tbl_Orden_Produccion op
            INNER JOIN Tbl_Materiales m ON op.Fk_Id_Material = m.Pk_Id_Materiales
            ORDER BY op.Fecha_Inicio_Orden_Produccion DESC";

                OdbcDataAdapter da = new OdbcDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }


   

        // ############################ METODOS PARA MANO DE OBRA #############################################
        // Mano de obra por orden de producción
        public DataTable ObtenerManoObra(int idOrden)
        {
            DataTable dt = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            {
                string query = @"
            SELECT 
                m.Pk_Id_Mano_Obra                           AS Id,
                CONCAT(e.Cmp_Nombres_Empleado, ' ', e.Cmp_Apellidos_Empleado) AS Empleado,
                m.Hora_Trabajada_Mano_Obra                  AS Horas,
                m.Costo_Hora_Mano_Obra                      AS CostoHora,
                m.Subtotal_Mano_Obra                        AS Subtotal
            FROM Tbl_Mano_Obra m
            INNER JOIN Tbl_Empleado e ON m.Fk_Id_Empleado = e.Pk_Id_Empleado
            WHERE m.Fk_Id_Orden_Produccion = ?";

                OdbcCommand cmd = new OdbcCommand(query, conn);
                cmd.Parameters.AddWithValue("?", idOrden);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public bool GuardarManoObra(int idOrden, int idEmpleado, decimal horas, decimal costoHora)
        {
            using (OdbcConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    decimal subtotal = horas * costoHora;
                    string query = @"
                INSERT INTO Tbl_Mano_Obra 
                    (Fk_Id_Orden_Produccion, Fk_Id_Empleado, Hora_Trabajada_Mano_Obra, Costo_Hora_Mano_Obra, Subtotal_Mano_Obra)
                VALUES (?, ?, ?, ?, ?)";

                    OdbcCommand cmd = new OdbcCommand(query, conn);
                    cmd.Parameters.AddWithValue("?", idOrden);
                    cmd.Parameters.AddWithValue("?", idEmpleado);
                    cmd.Parameters.AddWithValue("?", horas);
                    cmd.Parameters.AddWithValue("?", costoHora);
                    cmd.Parameters.AddWithValue("?", subtotal);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error (GuardarManoObra): " + ex.Message);
                    return false;
                }
            }
        }

        public bool EliminarManoObra(int idManoObra)
        {
            using (OdbcConnection conn = conexion.AbrirConexion())
            {
                try
                {
                    OdbcCommand cmd = new OdbcCommand(
                        "DELETE FROM Tbl_Mano_Obra WHERE Pk_Id_Mano_Obra = ?", conn);
                    cmd.Parameters.AddWithValue("?", idManoObra);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error (EliminarManoObra): " + ex.Message);
                    return false;
                }
            }
        }

        public DataTable ObtenerCostosProduccion(int idOrden)
        {
            DataTable dt = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            {
                string query = @"
            SELECT
                COALESCE((
                    SELECT SUM(emd.Cantidad_Real_Con_Merma * i.Costo_Unitario)
                    FROM Tbl_Orden_Produccion op
                    INNER JOIN Tbl_Plan_Produccion pp 
                        ON op.Fk_Id_Plan_Produccion = pp.Pk_Id_Plan_Produccion
                    INNER JOIN Tbl_Explosion_Materiales em 
                        ON pp.Fk_Id_Orden_Recibida = em.Fk_Id_Orden_Recibida
                    INNER JOIN Tbl_Explosion_Materiales_Detalle emd 
                        ON em.Pk_Id_Explosion = emd.Fk_Id_Explosion
                    INNER JOIN Tbl_Inventario i 
                        ON emd.Fk_Id_Material = i.Fk_Id_Material
                    WHERE op.Pk_Id_Orden_Produccion = ?
                ), 0) AS CostoMateriales,

                COALESCE((
                    SELECT SUM(mo.Hora_Trabajada_Mano_Obra * mo.Costo_Hora_Mano_Obra)
                    FROM Tbl_Mano_Obra mo
                    WHERE mo.Fk_Id_Orden_Produccion = ?
                ), 0) AS CostoManoObra,

                COALESCE((
                    SELECT SUM(ci.Monto_Costo_Indirecto_Produccion)
                    FROM Tbl_Costo_Indirecto_Produccion ci
                    WHERE ci.Fk_Id_Orden_Produccion = ?
                ), 0) AS CostoIndirecto,

                COALESCE((
                    SELECT SUM(me.Cantidad_Merma * i.Costo_Unitario)
                    FROM Tbl_Merma me
                    INNER JOIN Tbl_Inventario i ON me.Fk_Id_Materiales = i.Fk_Id_Material
                    WHERE me.Fk_Id_Orden_Produccion = ?
                ), 0) AS CostoMermas";

                OdbcCommand cmd = new OdbcCommand(query, conn);
                cmd.Parameters.AddWithValue("?", idOrden);
                cmd.Parameters.AddWithValue("?", idOrden);
                cmd.Parameters.AddWithValue("?", idOrden);
                cmd.Parameters.AddWithValue("?", idOrden);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }


        public DataTable ObtenerEmpleados()
        {
            DataTable dt = new DataTable();
            using (OdbcConnection conn = conexion.AbrirConexion())
            {
                string query = @"
            SELECT 
                Pk_Id_Empleado AS IdEmpleado,
                CONCAT(Cmp_Nombres_Empleado, ' ', Cmp_Apellidos_Empleado) AS NombreCompleto
            FROM Tbl_Empleado
            ORDER BY Cmp_Nombres_Empleado";

                OdbcDataAdapter da = new OdbcDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }
        // ############################ METODOS PARA MANO DE OBRA #############################################


    }
}
