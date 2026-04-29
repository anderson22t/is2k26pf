using System;
using System.Data;
using System.Windows.Forms;
using Capa_Controlador_RO;

namespace Capa_Vista_RO
{
    // ------ LETICIA SONTAY - 9959-21-9664, 28/04/2026 --------
    public partial class Frm_Detalle_Orden : Form
    {
        private readonly Cls_Controlador_Orden _controlador = new Cls_Controlador_Orden();
        private int _idOrden;
        private bool _cargando = false;

        public Frm_Detalle_Orden()
        {
            InitializeComponent();
        }

        public Frm_Detalle_Orden(int idOrden)
        {
            InitializeComponent();
            _idOrden = idOrden;
        }

        private void Frm_Detalle_Orden_Load(object sender, EventArgs e)
        {
            CargarComboEstados();
            CargarComboOrdenes();

            // ------ PAULA DANIELA LEONARDO - 0901-22-9580, 28/04/2026 --------
            CargarCombosMateriales();
            // ------ PAULA DANIELA LEONARDO - 0901-22-9580, 28/04/2026 --------

            if (_idOrden > 0)
            {
                Cmb_ID.SelectedValue = _idOrden;
            }
        }

        private void CargarComboEstados()
        {
            DataTable dt = _controlador.ObtenerEstadosOrden();
            Cmb_Estado.DataSource = dt;
            Cmb_Estado.DisplayMember = "NombreEstado";
            Cmb_Estado.ValueMember = "IdEstado";
            Cmb_Estado.SelectedIndex = -1;
        }

        private void CargarComboOrdenes()
        {
            _cargando = true;
            try
            {
                DataTable dt = _controlador.ObtenerOrdenesCombo();
                Cmb_ID.DataSource = dt;
                Cmb_ID.DisplayMember = "Orden";
                Cmb_ID.ValueMember = "IdOrden";
                Cmb_ID.SelectedIndex = -1;
            }
            finally
            {
                _cargando = false;
            }
        }

        private void Cmb_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargando) return;
            if (Cmb_ID.SelectedValue == null || Cmb_ID.SelectedIndex < 0) return;

            int idOrden = Convert.ToInt32(Cmb_ID.SelectedValue);
            CargarMateriales(idOrden);
            CargarDatosOrden(idOrden);
        }

        private void CargarMateriales(int idOrden)
        {
            DataTable dt = _controlador.ObtenerDetalleOrden(idOrden);

            if (dt.Rows.Count == 0)
            {
                Dgv_Materiales.DataSource = null;
                label10.Text = "0.00";
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    if (row[col] == DBNull.Value)
                    {
                        if (col.DataType == typeof(decimal) ||
                            col.DataType == typeof(int) ||
                            col.DataType == typeof(double))
                            row[col] = 0;
                        else
                            row[col] = string.Empty;
                    }
                }
            }

            dt.Columns.Add("Numero", typeof(int));
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["Numero"] = i + 1;

            dt.Columns["Numero"].SetOrdinal(0);

            Dgv_Materiales.AutoGenerateColumns = true;
            Dgv_Materiales.DataSource = dt;

            Dgv_Materiales.Columns["Numero"].HeaderText = "#";
            Dgv_Materiales.Columns["Id_Material"].HeaderText = "ID Material";
            Dgv_Materiales.Columns["Nombre_Material"].HeaderText = "Nombre Material";
            Dgv_Materiales.Columns["UnidadMedida"].HeaderText = "Unidad de Medida";
            Dgv_Materiales.Columns["CantidadSolicitada"].HeaderText = "Cantidad Solicitada";

            Dgv_Materiales.Columns["Nombre_Material"].Width = 200;

            decimal total = 0;
            foreach (DataRow row in dt.Rows)
                total += Convert.ToDecimal(row["CantidadSolicitada"]);

            label10.Text = $"{total:N2}";
        }

        private void CargarDatosOrden(int idOrden)
        {
            DataTable dt = _controlador.ObtenerOrdenPorId(idOrden);
            if (dt.Rows.Count == 0) return;

            DataRow row = dt.Rows[0];

            Cmb_Estado.SelectedValue = row["IdEstado"];

            if (row["FechaRecepcion"] != DBNull.Value)
                Dtp_Recepcion.Value = Convert.ToDateTime(row["FechaRecepcion"]);

            if (row["FechaRequerida"] != DBNull.Value)
                Dtp_Requerida.Value = Convert.ToDateTime(row["FechaRequerida"]);

            Rtxt_Observaciones.Text = row["Observacion"] != DBNull.Value
                                      ? row["Observacion"].ToString()
                                      : string.Empty;
        }
        // ------ LETICIA SONTAY - 9959-21-9664, 28/04/2026 --------


        // ------ PAULA DANIELA LEONARDO - 0901-22-9580, 28/04/2026 --------

        private bool _cargandoMat = false;

        private void CargarCombosMateriales()
        {
            DataTable dt = _controlador.ObtenerMateriales();

            _cargandoMat = true;

            Cmb_IDMat.DataSource = dt.Copy();
            Cmb_IDMat.DisplayMember = "Codigo_Material";
            Cmb_IDMat.ValueMember = "Id_Material";
            Cmb_IDMat.SelectedIndex = -1;

            Cmb_NombreMat.DataSource = dt.Copy();
            Cmb_NombreMat.DisplayMember = "Nombre_Material";
            Cmb_NombreMat.ValueMember = "Id_Material";
            Cmb_NombreMat.SelectedIndex = -1;

            _cargandoMat = false;

            txt_UnidadDeMedida.Text = "";
        }

        private void Cmb_IDMat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargandoMat || Cmb_IDMat.SelectedValue == null) return;

            _cargandoMat = true;

            int idMat = Convert.ToInt32(Cmb_IDMat.SelectedValue);
            DataTable dt = _controlador.ObtenerMaterialPorId(idMat);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                Cmb_NombreMat.SelectedValue = row["Id_Material"];
                txt_UnidadDeMedida.Text = row["UnidadMedida"].ToString();
            }

            _cargandoMat = false;
        }

        private void Cmb_NombreMat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargandoMat || Cmb_NombreMat.SelectedValue == null) return;

            _cargandoMat = true;

            int idMat = Convert.ToInt32(Cmb_NombreMat.SelectedValue);
            DataTable dt = _controlador.ObtenerMaterialPorId(idMat);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                Cmb_IDMat.SelectedValue = row["Id_Material"];
                txt_UnidadDeMedida.Text = row["UnidadMedida"].ToString();
            }

            _cargandoMat = false;
        }

        private void txt_UnidadDeMedida_TextChanged(object sender, EventArgs e)
        {
            // Se carga automáticamente, no requiere lógica adicional
        }

        private void Nud_Cantidad_ValueChanged(object sender, EventArgs e)
        {
            // El usuario elige la cantidad, no requiere lógica adicional
        }

        private void Btn_agregarMat_Click(object sender, EventArgs e)
        {
            if (Cmb_IDMat.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un material.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Nud_Cantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si el material ya fue agregado
            foreach (DataGridViewRow fila in Dgv_Materiales.Rows)
            {
                if (fila.Cells["Id_Material"] != null &&
                    fila.Cells["Id_Material"].Value != null &&
                    Convert.ToInt32(fila.Cells["Id_Material"].Value) == Convert.ToInt32(Cmb_IDMat.SelectedValue))
                {
                    MessageBox.Show("Este material ya fue agregado.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Dgv_Materiales.Rows.Add(
                Cmb_IDMat.Text,
                Cmb_NombreMat.Text,
                txt_UnidadDeMedida.Text,
                Nud_Cantidad.Value
            );

            ActualizarTotal();

            // Limpiar para el siguiente material
            Cmb_IDMat.SelectedIndex = -1;
            Cmb_NombreMat.SelectedIndex = -1;
            txt_UnidadDeMedida.Text = "";
            Nud_Cantidad.Value = 0;
        }

        private void Btn_eliminarMat_Click(object sender, EventArgs e)
        {
            if (Dgv_Materiales.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un material para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Dgv_Materiales.Rows.Remove(Dgv_Materiales.SelectedRows[0]);
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow fila in Dgv_Materiales.Rows)
            {
                if (fila.Cells["Cantidad"].Value != null)
                    total += Convert.ToDecimal(fila.Cells["Cantidad"].Value);
            }
            label10.Text = total.ToString("N2");
        }

        // ------ PAULA DANIELA LEONARDO - 0901-22-9580, 28/04/2026 --------

        private void label2_Click(object sender, EventArgs e) { }

        private void Dgv_Materiales_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void label10_Click(object sender, EventArgs e) { }
    }
}