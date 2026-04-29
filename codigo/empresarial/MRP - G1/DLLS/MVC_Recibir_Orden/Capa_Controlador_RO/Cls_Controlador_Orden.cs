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

        // ------ KEVIN NATARENO - 0901-21-635, 28/04/2026 --------
        public DataTable ObtenerOrdenes()
        {
            return modelo.ObtenerOrdenes();
        }
        public DataTable ObtenerEstados()
        {
            return modelo.ObtenerEstados();
        }

        public DataTable FiltrarOrdenes(string idExterno, int idEstado)
        {
            return modelo.FiltrarOrdenes(idExterno, idEstado);
        }
        // ------ KEVIN NATARENO - 0901-21-635, 28/04/2026 --------


    }
}
