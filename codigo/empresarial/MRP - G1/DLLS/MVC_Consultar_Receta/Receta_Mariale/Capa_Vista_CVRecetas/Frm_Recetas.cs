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

        //Variables Goblas cesar santizo 0901-22-5215
        int idBOM = 0;
        public Frm_Recetas()
        {
            InitializeComponent();
            cargarCombos();
        }

       
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

            
            idBOM = Convert.ToInt32(dtBOM.Rows[0]["Pk_Id_BOM"]);

            Txt_descripcion.Text = dtBOM.Rows[0]["Descripcion_BOM"].ToString();
            Txt_versionBOM.Text = dtBOM.Rows[0]["Version_BOM"].ToString();
            dtp_fecha.Value = Convert.ToDateTime(dtBOM.Rows[0]["Fecha_Creacion_BOM"]);
            Cbo_estado.SelectedValue = dtBOM.Rows[0]["Fk_Id_Estado_BOM"];

        
            DataTable dtGrid = con.cargarBOMGrid(idProducto);
            dgv_detalle.DataSource = dtGrid;
        }

        //boton de guardar cesar santizo 0901-22-5215
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idProducto = Convert.ToInt32(Cbo_producto.SelectedValue);
                string descripcion = Txt_descripcion.Text;
                string version = Txt_versionBOM.Text;
                DateTime fecha = dtp_fecha.Value;
                int estado = Convert.ToInt32(Cbo_estado.SelectedValue);

                con.guardarBOM(descripcion, version, fecha, estado, idProducto);

                MessageBox.Show("Receta guardada correctamente");
                recargarDatos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }
        //boton editar Cesar santizo 0901-22-5215
        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idBOM == 0)
                {
                    MessageBox.Show("Primero consulte una receta");
                    return;
                }

                string descripcion = Txt_descripcion.Text;
                string version = Txt_versionBOM.Text;
                DateTime fecha = dtp_fecha.Value;
                int estado = Convert.ToInt32(Cbo_estado.SelectedValue);

                con.editarBOM(idBOM, descripcion, version, fecha, estado);

                MessageBox.Show("Receta actualizada correctamente");
                recargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar: " + ex.Message);
            }
        }

        //Recargar los datos Cesar Santizo 0901-22-5215
        public void recargarDatos()
        {
            if (Cbo_producto.SelectedValue == null)
                return;

            int idProducto = Convert.ToInt32(Cbo_producto.SelectedValue);

       
            DataTable dtBOM = con.cargarBOM(idProducto);

            if (dtBOM.Rows.Count > 0)
            {
                idBOM = Convert.ToInt32(dtBOM.Rows[0]["Pk_Id_BOM"]);

                Txt_descripcion.Text = dtBOM.Rows[0]["Descripcion_BOM"].ToString();
                Txt_versionBOM.Text = dtBOM.Rows[0]["Version_BOM"].ToString();
                dtp_fecha.Value = Convert.ToDateTime(dtBOM.Rows[0]["Fecha_Creacion_BOM"]);
                Cbo_estado.SelectedValue = dtBOM.Rows[0]["Fk_Id_Estado_BOM"];
            }

            dgv_detalle.DataSource = con.cargarBOMGrid(idProducto);
        }
        // selecionar dato en la dgv para que se carguen en los cobo box Cesar Santizo 0901-22-5215
        private void dgv_detalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgv_detalle.Rows[e.RowIndex];

                idBOM = Convert.ToInt32(fila.Cells["ID"].Value);

                Txt_descripcion.Text = fila.Cells["Descripcion"].Value.ToString();
                Txt_versionBOM.Text = fila.Cells["Version"].Value.ToString();
                dtp_fecha.Value = Convert.ToDateTime(fila.Cells["Fecha"].Value);

                Cbo_estado.Text = fila.Cells["Estado"].Value.ToString();
            }
        }

        private void btn_ver_detalle_Click(object sender, EventArgs e)
        {
            Detalle_Materiales m = new Detalle_Materiales();
            m.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ver_Recetas m = new Ver_Recetas();
            m.Show();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idBOM == 0)
                {
                    MessageBox.Show("Seleccione una receta para eliminar");
                    return;
                }

                DialogResult resp = MessageBox.Show(
                    "¿Está seguro que desea eliminar esta receta?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resp == DialogResult.Yes)
                {
                    con.eliminarBOM(idBOM);

                    MessageBox.Show("Receta eliminada correctamente");

                    // limpiar campos
                    Txt_descripcion.Clear();
                    Txt_versionBOM.Clear();
                    dtp_fecha.Value = DateTime.Now;
                    Cbo_estado.SelectedIndex = -1;
                    dgv_detalle.DataSource = null;

                    idBOM = 0;

                    recargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }
    }
}
