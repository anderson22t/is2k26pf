using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using Capa_Modelo_Seguridad;

namespace Capa_Modelo_RO
{
    public class Cls_Consultas_Ordenes
    {
        private Cls_Conexion conexion = new Cls_Conexion();

        //GUARDAR 
        public bool GuardarOrden(string idLog, int estado, DateTime requerida, string obs, DataTable detalle)
        {
            OdbcConnection conn = conexion.AbrirConexion();
            OdbcTransaction transaccion = conn.BeginTransaction();

            try
            {
                OdbcCommand cmdMaestro = new OdbcCommand("{call sp_InsertarOrdenRecibida(?, ?, ?, ?)}", conn);
                cmdMaestro.Transaction = transaccion;
                cmdMaestro.CommandType = CommandType.StoredProcedure;

                cmdMaestro.Parameters.Add("?", OdbcType.VarChar).Value = idLog;
                cmdMaestro.Parameters.Add("?", OdbcType.Int).Value = estado;
                cmdMaestro.Parameters.Add("?", OdbcType.Date).Value = requerida;
                cmdMaestro.Parameters.Add("?", OdbcType.VarChar).Value = obs;

                int idGenerado = Convert.ToInt32(cmdMaestro.ExecuteScalar());

                foreach (DataRow fila in detalle.Rows)
                {
                    OdbcCommand cmdDetalle = new OdbcCommand("INSERT INTO Tbl_Orden_Recibida_Detalle (Fk_Id_Orden_Recibida, Fk_Id_Material, Cantidad_Solicitada) VALUES (?, ?, ?)", conn);
                    cmdDetalle.Transaction = transaccion;

                    cmdDetalle.Parameters.Add("?", OdbcType.Int).Value = idGenerado;
                    cmdDetalle.Parameters.Add("?", OdbcType.Int).Value = fila["Fk_Id_Material"];
                    cmdDetalle.Parameters.Add("?", OdbcType.Decimal).Value = fila["Cantidad_Solicitada"];

                    cmdDetalle.ExecuteNonQuery();
                }

                transaccion.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                Console.WriteLine("Error ODBC (Guardar): " + ex.Message);
                return false;
            }
        }

        // MODIFICAR
        public bool ModificarOrden(int pk, string idLog, int estado, DateTime requerida, string obs)
        {
            OdbcConnection conn = conexion.AbrirConexion();
            try
            {
                OdbcCommand cmd = new OdbcCommand("{call sp_ModificarOrdenRecibida(?, ?, ?, ?, ?)}", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("?", OdbcType.Int).Value = pk;
                cmd.Parameters.Add("?", OdbcType.VarChar).Value = idLog;
                cmd.Parameters.Add("?", OdbcType.Int).Value = estado;
                cmd.Parameters.Add("?", OdbcType.Date).Value = requerida;
                cmd.Parameters.Add("?", OdbcType.VarChar).Value = obs;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ODBC (Modificar): " + ex.Message);
                return false;
            }
        }

        // ELIMINAR
        public bool EliminarOrden(int pk)
        {
            OdbcConnection conn = conexion.AbrirConexion();
            try
            {
                OdbcCommand cmd = new OdbcCommand("{call sp_EliminarOrdenRecibida(?)}", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("?", OdbcType.Int).Value = pk;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ODBC (Eliminar): " + ex.Message);
                return false;
            }
        }

        // ACTUALIZAR GRID 
        public DataTable ObtenerDetalles(int pk)
        {
            DataTable dt = new DataTable();
            OdbcConnection conn = conexion.AbrirConexion();
            try
            {
                OdbcCommand cmd = new OdbcCommand("{call sp_ConsultarDetalleOrden(?)}", conn);
                cmd.Parameters.Add("?", OdbcType.Int).Value = pk;

                OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex) { Console.WriteLine("Error ODBC (Leer): " + ex.Message); }
            return dt;
        }

        // Arón Ricardo Esquit - 0901-22-13036 - 30/04/26
        public bool GuardarDetalleOrden(int idOrden, DataTable detalle)
        {
            OdbcConnection conn = conexion.AbrirConexion();
            OdbcTransaction transaccion = conn.BeginTransaction();

            try
            {
                foreach (DataRow fila in detalle.Rows)
                {
                    OdbcCommand cmdDetalle = new OdbcCommand(
                        "INSERT INTO Tbl_Orden_Recibida_Detalle (Fk_Id_Orden_Recibida, Fk_Id_Material, Cantidad_Solicitada) VALUES (?, ?, ?)",
                        conn
                    );

                    cmdDetalle.Transaction = transaccion;

                    cmdDetalle.Parameters.Add("?", OdbcType.Int).Value = idOrden;
                    cmdDetalle.Parameters.Add("?", OdbcType.Int).Value = fila["Fk_Id_Material"];
                    cmdDetalle.Parameters.Add("?", OdbcType.Decimal).Value = fila["Cantidad_Solicitada"];

                    cmdDetalle.ExecuteNonQuery();
                }

                transaccion.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                Console.WriteLine("Error ODBC (Guardar Detalle): " + ex.Message);
                return false;
            }
        }
    }
}