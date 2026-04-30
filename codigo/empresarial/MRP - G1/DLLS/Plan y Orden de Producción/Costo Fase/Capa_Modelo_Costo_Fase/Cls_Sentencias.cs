using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using Capa_Modelo_Seguridad;


namespace Capa_Modelo_Costo_Fase
{
   
    public class Cls_Datos_Fase
    {
        public int iIdFase { get; set; }
        public string sNombreFase { get; set; }
    }

    public class Cls_Datos_Tipo_Costo
    {
        public int iIdTipoCosto { get; set; }
        public string sNombreTipoCosto { get; set; }
    }

    public class Cls_Datos_Costo_Fase
    {
        public int iIdCostoFase { get; set; }
        public int iIdFase { get; set; }
        public int iIdTipoCosto { get; set; }
        public decimal dCosto { get; set; }

        public string sNombreFase { get; set; }
        public string sNombreTipoCosto { get; set; }
    }

   
    public class Cls_Sentencias
    {
        Cls_Conexion conexion = new Cls_Conexion();

       
        public List<Cls_Datos_Fase> fun_ObtenerFases()
        {
            List<Cls_Datos_Fase> lista = new List<Cls_Datos_Fase>();

            using (OdbcConnection con = conexion.conexion())
            {
                string query = @"SELECT 
                                Pk_Id_Fase_Producto AS Codigo,
                                Nombre_Fase_Produccion AS Nombre
                                FROM Tbl_Fases_Produccion";

                OdbcCommand cmd = new OdbcCommand(query, con);

                using (OdbcDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Cls_Datos_Fase()
                        {
                            iIdFase = Convert.ToInt32(reader["Codigo"]),
                            sNombreFase = reader["Nombre"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

       
        public List<Cls_Datos_Tipo_Costo> fun_ObtenerTiposCosto()
        {
            List<Cls_Datos_Tipo_Costo> lista = new List<Cls_Datos_Tipo_Costo>();

            using (OdbcConnection con = conexion.conexion())
            {
                string query = @"SELECT 
                                Pk_Id_Tipo_Costo_Fase AS Codigo,
                                Nombre_Tipo_Costo AS Nombre
                                FROM Tbl_Tipo_Costo_Fase";

                OdbcCommand cmd = new OdbcCommand(query, con);

                using (OdbcDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Cls_Datos_Tipo_Costo()
                        {
                            iIdTipoCosto = Convert.ToInt32(reader["Codigo"]),
                            sNombreTipoCosto = reader["Nombre"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

       
        public void fun_InsertarCostoFase(int idFase, int idTipoCosto, decimal costo)
        {
            using (OdbcConnection con = conexion.conexion())
            {
                string query = @"INSERT INTO Tbl_Costo_Fase 
                        (Fk_Id_Fase_Producto, Fk_Id_Tipo_Costo_Fase, Costo) 
                        VALUES (?, ?, ?)";

                OdbcCommand cmd = new OdbcCommand(query, con);

                // Agregamos los parámetros en orden estricto y con su tipo
                cmd.Parameters.Add("?", OdbcType.Int).Value = idFase;
                cmd.Parameters.Add("?", OdbcType.Int).Value = idTipoCosto;
                cmd.Parameters.Add("?", OdbcType.Decimal).Value = costo;

                cmd.ExecuteNonQuery();
            }
        }

        
        public List<Cls_Datos_Costo_Fase> fun_ObtenerCostoFase()
        {
            List<Cls_Datos_Costo_Fase> lista = new List<Cls_Datos_Costo_Fase>();

            using (OdbcConnection con = conexion.conexion())
            {
                string query = @"
                    SELECT 
                        cf.Pk_Id_Costo_Fase AS Id,
                        cf.Fk_Id_Fase_Producto AS IdFase,
                        cf.Fk_Id_Tipo_Costo_Fase AS IdTipoCosto,
                        f.Nombre_Fase_Produccion AS Fase,
                        tc.Nombre_Tipo_Costo AS TipoCosto,
                        cf.Costo AS Costo
                    FROM Tbl_Costo_Fase cf
                    INNER JOIN Tbl_Fases_Produccion f 
                        ON cf.Fk_Id_Fase_Producto = f.Pk_Id_Fase_Producto
                    INNER JOIN Tbl_Tipo_Costo_Fase tc 
                        ON cf.Fk_Id_Tipo_Costo_Fase = tc.Pk_Id_Tipo_Costo_Fase";

                OdbcCommand cmd = new OdbcCommand(query, con);

                using (OdbcDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Cls_Datos_Costo_Fase()
                        {
                            iIdCostoFase = Convert.ToInt32(reader["Id"]),
                            iIdFase = Convert.ToInt32(reader["IdFase"]),
                            iIdTipoCosto = Convert.ToInt32(reader["IdTipoCosto"]),
                            sNombreFase = reader["Fase"].ToString(),
                            sNombreTipoCosto = reader["TipoCosto"].ToString(),
                            dCosto = Convert.ToDecimal(reader["Costo"])
                        });
                    }
                }
            }

            return lista;
        }
        public void fun_ModificarCostoFase(int id, int idFase, int idTipoCosto, decimal costo)
        {
            using (OdbcConnection con = conexion.conexion())
            {
                string query = @"UPDATE Tbl_Costo_Fase 
                         SET Fk_Id_Fase_Producto = ?, 
                             Fk_Id_Tipo_Costo_Fase = ?, 
                             Costo = ?
                         WHERE Pk_Id_Costo_Fase = ?";

                OdbcCommand cmd = new OdbcCommand(query, con);

                cmd.Parameters.AddWithValue("", idFase);
                cmd.Parameters.AddWithValue("", idTipoCosto);
                cmd.Parameters.AddWithValue("", costo);
                cmd.Parameters.AddWithValue("", id);

                cmd.ExecuteNonQuery();
            }
        }

        public void fun_EliminarCostoFase(int id)
        {
            using (OdbcConnection con = conexion.conexion())
            {
                string query = @"DELETE FROM Tbl_Costo_Fase 
                         WHERE Pk_Id_Costo_Fase = ?";

                OdbcCommand cmd = new OdbcCommand(query, con);
                cmd.Parameters.AddWithValue("", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
