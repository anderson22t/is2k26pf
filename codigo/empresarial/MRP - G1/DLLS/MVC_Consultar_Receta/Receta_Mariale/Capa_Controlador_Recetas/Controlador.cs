using System;
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

        public DataTable cargarBOMGrid(int idProducto)
        {
            return sen.obtenerBOMGrid(idProducto);
        }

        public DataTable cargarEstados()
        {
            return sen.obtenerEstados();
        }

        // guardar cesar santizo 0901-22-5215
        public void guardarBOM(string descripcion, string version, DateTime fecha, int estado, int producto)
        {
            sen.insertarBOM(descripcion, version, fecha, estado, producto);
        }

        // editar cesar santizo 0901-22-5215
        public void editarBOM(int idBOM, string descripcion, string version, DateTime fecha, int estado)
        {
            sen.editarBOM(idBOM, descripcion, version, fecha, estado);
        }
    }
}