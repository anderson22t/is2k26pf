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
        private Cls_Sentencias_Detalle detalle = new Cls_Sentencias_Detalle();

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

        // ------ LETICIA SONTAY - 9959-21-9664, 28/04/2026 --------
        public DataTable ObtenerOrdenesCombo()
        {
            return detalle.ObtenerOrdenesCombo();
        }

        public DataTable ObtenerDetalleOrden(int idOrden)
        {
            return detalle.ObtenerDetalleOrden(idOrden);
        }

        public DataTable ObtenerOrdenPorId(int idOrden)
        {
            return detalle.ObtenerOrdenPorId(idOrden);
        }

        public DataTable ObtenerEstadosOrden()
        {
            return detalle.ObtenerEstadosOrden();
        }
        // ------ LETICIA SONTAY - 9959-21-9664, 28/04/2026 --------



        // ------ PAULA DANIELA LEONARDO - 0901-22-9580, 28/04/2026 --------
        public DataTable ObtenerMateriales()
        {
            return detalle.ObtenerMateriales();
        }

        public DataTable ObtenerMaterialPorId(int idMaterial)
        {
            return detalle.ObtenerMaterialPorId(idMaterial);
        }

        public DataTable ObtenerMaterialPorCodigo(string codigoMaterial)
        {
            return detalle.ObtenerMaterialPorCodigo(codigoMaterial);
        }

        public DataTable ObtenerMaterialPorNombre(string nombreMaterial)
        {
            return detalle.ObtenerMaterialPorNombre(nombreMaterial);
        }
        // ------ PAULA DANIELA LEONARDO - 0901-22-9580, 28/04/2026 --------

    }
}
