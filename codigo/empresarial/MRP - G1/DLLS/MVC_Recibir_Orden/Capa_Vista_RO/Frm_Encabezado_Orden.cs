using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_RO;

namespace Capa_Vista_RO
{
    public partial class Frm_Encabezado_Orden : Form
    {

        //Cls_Sentencias modelo = new Cls_Sentencias();
        Cls_Controlador_Orden controlador = new  Cls_Controlador_Orden ();
        public Frm_Encabezado_Orden()
        {
            InitializeComponent();
            dgvOrdenes.CellClick += dgvOrdenes_CellClick;
        }
        private void Frm_Encabezado_Orden_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        // 🔹 Evento Load
      

        // 🔹 Cargar datos al grid
        private void CargarGrid()
        {
            dgvOrdenes.DataSource = controlador.ObtenerOrdenes();
            ConfigurarGrid();
            AgregarBotonVer();
        }

        // 🔹 Configuración del DataGrid
        private void ConfigurarGrid()
        {
            if (dgvOrdenes.Columns.Count == 0) return;

            // Ocultar ID interno
            if (dgvOrdenes.Columns.Contains("Pk_Id_Orden_Recibida"))
                dgvOrdenes.Columns["Pk_Id_Orden_Recibida"].Visible = false;

            // Cambiar nombres
            if (dgvOrdenes.Columns.Contains("Orden"))
                dgvOrdenes.Columns["Orden"].HeaderText = "Orden";

            if (dgvOrdenes.Columns.Contains("Fecha_Recepcion"))
                dgvOrdenes.Columns["Fecha_Recepcion"].HeaderText = "Fecha Recepción";

            if (dgvOrdenes.Columns.Contains("Fecha_Requerida"))
                dgvOrdenes.Columns["Fecha_Requerida"].HeaderText = "Fecha Requerida";

            if (dgvOrdenes.Columns.Contains("Estado"))
                dgvOrdenes.Columns["Estado"].HeaderText = "Estado";

            // Estilo
            dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdenes.ReadOnly = true;
            dgvOrdenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenes.MultiSelect = false;
        }

        // 🔹 Agregar botón "Ver"
        private void AgregarBotonVer()
        {
            if (!dgvOrdenes.Columns.Contains("Ver"))
            {
                DataGridViewButtonColumn btnVer = new DataGridViewButtonColumn();
                btnVer.Name = "Ver";
                btnVer.HeaderText = "Acciones";
                btnVer.Text = "Ver";
                btnVer.UseColumnTextForButtonValue = true;

                dgvOrdenes.Columns.Add(btnVer);
            }
        }

        // 🔹 Evento click en el grid
        private void dgvOrdenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvOrdenes.Columns[e.ColumnIndex].Name == "Ver")
            {
                int idOrden = Convert.ToInt32(
                    dgvOrdenes.Rows[e.RowIndex].Cells["Pk_Id_Orden_Recibida"].Value
                );

             
                MessageBox.Show("Abrir detalle de orden ID: " + idOrden);

                // Cuando tengas el form de detalle:
                // FrmDetalleOrden frm = new FrmDetalleOrden(idOrden);
                // frm.ShowDialog();
            }
        }
    }
}
