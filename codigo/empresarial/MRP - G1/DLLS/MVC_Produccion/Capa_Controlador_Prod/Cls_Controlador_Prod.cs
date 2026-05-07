using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Prod;

namespace Capa_Controlador_Prod
{
    public class Cls_Controlador_Prod
    {
        private readonly Cls_Sentencias_Prod sentencias = new Cls_Sentencias_Prod();
        private readonly Cls_Sentencias_Prod sentenciasDetalle = new Cls_Sentencias_Prod();


        public DataTable ObtenerOrdenesRecibidas()
        {
            return sentenciasDetalle.ObtenerOrdenesRecibidas();
        }

        public DataTable ObtenerInfoOrdenRecibida(int idOrden)
        {
            return sentenciasDetalle.ObtenerInfoOrdenRecibida(idOrden);
        }

        public DataTable ObtenerProductosOrdenRecibida(int idOrden)
        {
            return sentenciasDetalle.ObtenerProductosOrdenRecibida(idOrden);
        }
    }
}
