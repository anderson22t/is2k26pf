using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_RO;

namespace Capa_Controlador_RO
{
    public class Cls_Controlador_Orden
    {
        private Cls_Sentencias modelo = new Cls_Sentencias();

        public DataTable ObtenerOrdenes()
        {
            return modelo.ObtenerOrdenes();
        }
    }
}
