using Capa_Modelo_Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Citas
{
    public class Cls_Sentencias
    {
        private Cls_Conexion conexion = new Cls_Conexion();

        public bool Insertar(Cls_Modelo_Citas cita)
        {
            OdbcConnection conn = null;

            try
            {
                conn = conexion.conexion();

                string sql = @"INSERT INTO Tbl_Cita
                               (Cmp_Fecha_Cita,
                                Fk_Id_Tipo_Cita,
                                Fk_Id_Horarios,
                                Fk_Id_Sede,
                                Fk_Id_Estado_Cita,
                                Fk_Id_Boleta)
                               VALUES (?, ?, ?, ?, ?, ?)";

                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    // ⚠ ODBC usa el ORDEN
                    cmd.Parameters.AddWithValue("", cita.FechaCita);
                    cmd.Parameters.AddWithValue("", cita.IdTipoCita);
                    cmd.Parameters.AddWithValue("", cita.IdHorario);
                    cmd.Parameters.AddWithValue("", cita.IdSede);
                    cmd.Parameters.AddWithValue("", cita.IdEstadoCita);
                    cmd.Parameters.AddWithValue("", cita.IdBoleta);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            finally
            {
                if (conn != null)
                    conexion.desconexion(conn);
            }
        }

        public DataTable ObtenerTiposCita()
        {
            DataTable tabla = new DataTable();
            OdbcConnection conn = null;

            try
            {
                conn = conexion.conexion();

                string sql = "SELECT Pk_Id_Tipo_Cita, Cmp_Nombre_Tipo_Cita FROM Tbl_Tipo_Cita";

                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                {
                    da.Fill(tabla);
                }
            }
            finally
            {
                if (conn != null)
                    conexion.desconexion(conn);
            }

            return tabla;
        }
    }
}
