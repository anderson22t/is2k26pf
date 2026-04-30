using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Fase;

namespace Capa_Controlador_Fase
{
    public class Cls_Controlador_Fase
    {
        Cls_Sentencias sentencias = new Cls_Sentencias();

        public DataTable fun_DatosProductos()
        {
            return sentencias.fun_ObtenerProductos();
        }

        public DataTable fun_DatosFase(int iCodigoProducto)
        {
            return sentencias.fun_ObtenerFasesProducción(iCodigoProducto);
        }

        public void pro_GuardarFase(int iProducto, string sFase, string sDescripcion, int iHoras)
        {
            sentencias.pro_GuardarDatosFase(iProducto, sFase, sDescripcion, iHoras);
        }

        public void pro_EliminarFase(int iCodigoFase)
        {
            sentencias.pro_EliminarReceta(iCodigoFase);
        }

        public void pro_ActualizarFase(int iCodigoFase, string sFase, string sDescripcion, int iHoras)
        {
            sentencias.pro_Actualizar(iCodigoFase, sFase, sDescripcion, iHoras);
        }

    }
}
