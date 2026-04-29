using System.Data;
using Capa_Modelo_Recetas;

namespace Capa_Controlador_Recetas
{
    public class Controlador
    {
        Sentencias sen = new Sentencias();

        public DataTable cargarProductos()
        {
            return sen.obtenerProductosTerminados();
        }

        public DataTable cargarBOM(int idProducto)
        {
            return sen.obtenerBOM(idProducto);
        }

        public DataTable cargarDetalleBOM(int idProducto)
        {
            return sen.obtenerDetalleBOM(idProducto);
        }

        public DataTable cargarEstados()
        {
            return sen.obtenerEstados();
        }
    }
}