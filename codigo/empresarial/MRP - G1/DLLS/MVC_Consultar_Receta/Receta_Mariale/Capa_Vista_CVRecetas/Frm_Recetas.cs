using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Capa_Controlador_Recetas;
using Capa_Vista_Fases;

namespace Capa_Vista_CVRecetas
{
    public partial class Frm_Recetas : Form
    {
        Controlador con = new Controlador();

        public Frm_Recetas()
        {
            InitializeComponent();
            cargarCombos();
        }

        // 🔹 Cargar combos
        public void cargarCombos()
        {
            // Productos terminados
            Cbo_producto.DataSource = con.cargarProductos();
            Cbo_producto.DisplayMember = "Nombre_Material";
            Cbo_producto.ValueMember = "Pk_Id_Materiales";
            Cbo_producto.SelectedIndex = -1;

            // Estados
            Cbo_estado.DataSource = con.cargarEstados();
            Cbo_estado.DisplayMember = "Nombre_Estado_BOM";
            Cbo_estado.ValueMember = "Pk_Id_Estado_BOM";
            Cbo_estado.SelectedIndex = -1;
        }

        
        private void btn_produccion_Click_1(object sender, EventArgs e)
        {
            Frm_Fases_Produccion m = new Frm_Fases_Produccion();
            m.Show();
        }

        private void btn_consultar_Click_1(object sender, EventArgs e)
        {
            if (Cbo_producto.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            int idProducto;
            if (!int.TryParse(Cbo_producto.SelectedValue.ToString(), out idProducto))
                return;

            // 🔹 1. CABECERA BOM
            DataTable dtBOM = con.cargarBOM(idProducto);

            if (dtBOM.Rows.Count == 0)
            {
                MessageBox.Show("Este producto no tiene BOM registrada");

                // limpiar campos
                Txt_descripcion.Clear();
                Txt_versionBOM.Clear();
                dtp_fecha.Value = DateTime.Now;
                Cbo_estado.SelectedIndex = -1;
                dgv_detalle.DataSource = null;

                return;
            }

            // 🔹 llenar cabecera
            Txt_descripcion.Text = dtBOM.Rows[0]["Descripcion_BOM"].ToString();
            Txt_versionBOM.Text = dtBOM.Rows[0]["Version_BOM"].ToString();
            dtp_fecha.Value = Convert.ToDateTime(dtBOM.Rows[0]["Fecha_Creacion_BOM"]);
            Cbo_estado.SelectedValue = dtBOM.Rows[0]["Fk_Id_Estado_BOM"];

            // 🔹 2. DETALLE
            DataTable dtDetalle = con.cargarDetalleBOM(idProducto);
            dgv_detalle.DataSource = dtDetalle;
        }

        private void dgv_detalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
