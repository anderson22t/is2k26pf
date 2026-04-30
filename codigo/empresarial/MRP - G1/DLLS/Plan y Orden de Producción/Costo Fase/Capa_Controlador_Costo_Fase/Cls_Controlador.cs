using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Costo_Fase;

namespace Capa_Controlador_Costo_Fase
{
   public class Cls_Controlador
    {
        Cls_Sentencias sentencias = new Cls_Sentencias();

        
        public List<Cls_Datos_Fase> ObtenerFases()
        {
            return sentencias.fun_ObtenerFases();
        }

        
        public List<Cls_Datos_Tipo_Costo> ObtenerTiposCosto()
        {
            return sentencias.fun_ObtenerTiposCosto();
        }

       
        public void InsertarCostoFase(int idFase, int idTipoCosto, decimal costo)
        {
            sentencias.fun_InsertarCostoFase(idFase, idTipoCosto, costo);
        }

       
        public List<Cls_Datos_Costo_Fase> ObtenerCostoFase()
        {
            return sentencias.fun_ObtenerCostoFase();
        }
       
        public void ModificarCostoFase(int id, int idFase, int idTipoCosto, decimal costo)
        {
            sentencias.fun_ModificarCostoFase(id, idFase, idTipoCosto, costo);
        }

        public void EliminarCostoFase(int id)
        {
            sentencias.fun_EliminarCostoFase(id);
        }


    }
}
