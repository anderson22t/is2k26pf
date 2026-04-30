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
            Btn_ingresar.Enabled = true;
            EstadoControles(false);
        }

        // ------ DANI - 0901-22-9136, 29/04/2026 --------

        // Método para bloquear o desbloquear componentes
        private void EstadoControles(bool habilitar)
        {
            panel2.Enabled = habilitar;
            panel3.Enabled = habilitar;

            Btn_modificar.Enabled = habilitar;
            Btn_eliminar.Enabled = habilitar;
            Btn_consultar.Enabled = habilitar;
            Btn_refrescar.Enabled = habilitar;
            Btn_imprimir.Enabled = habilitar;
            Btn_inicio.Enabled = habilitar;
            Btn_anterior.Enabled = habilitar;
            Btn_sig.Enabled = habilitar;
            Btn_fin.Enabled = habilitar;
            Btn_ayuda.Enabled = habilitar;

            Btn_guardar.Enabled = habilitar;
            Btn_cancelar.Enabled = habilitar;

            Btn_ingresar.Enabled = !habilitar;

            Btn_salir.Enabled = true;
        }

        private void LimpiarCampos()
        {
            Cmb_ID.SelectedIndex = -1;
            Rtxt_Observaciones.Clear();
            Nud_Cantidad.Value = 0;
        }
        // ------ DANI - 0901-22-9136, 29/04/2026 --------


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
            InicializarColumnasMateriales();
            CargarCombosMateriales();
            // ------ PAULA DANIELA LEONARDO - 0901-22-9580, 28/04/2026 --------

            if (_idOrden > 0)
            {
                Cmb_ID.SelectedValue = _idOrden;
            }
        }

        // ------ DANI - 0901-22-9136, 29/04/2026 --------
        private void CargarComboEstados()
        {
            DataTable dt = _controlador.ObtenerEstadosOrden();
            Cmb_Estado.DataSource = dt;
            Cmb_Estado.DisplayMember = "NombreEstado";
            Cmb_Estado.ValueMember = "IdEstado";
            Cmb_Estado.SelectedIndex = -1;
        }

        // ------ DANI - 0901-22-9136, 29/04/2026 --------

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

        private void InicializarColumnasMateriales()
        {
            Dgv_Materiales.AutoGenerateColumns = false;
            Dgv_Materiales.Columns.Clear();

            Dgv_Materiales.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Codigo_Material",
                HeaderText = "ID Material",
                Width = 100
            });

            Dgv_Materiales.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Nombre_Material",
                HeaderText = "Nombre Material",
                Width = 200
            });

            Dgv_Materiales.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "UnidadMedida",
                HeaderText = "Unidad de Medida",
                Width = 120
            });

            Dgv_Materiales.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Cantidad",
                HeaderText = "Cantidad",
                Width = 80
            });
        }

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
                if (fila.Cells["Codigo_Material"] != null &&
                    fila.Cells["Codigo_Material"].Value != null &&
                    fila.Cells["Codigo_Material"].Value.ToString() == Cmb_IDMat.Text)
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


        // ------ DANI - 0901-22-9136, 29/04/2026 --------

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            EstadoControles(true);
            Cmb_ID.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {

            DialogResult resp = MessageBox.Show("¿Desea cancelar la operación?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                EstadoControles(false);
            }
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cmb_Estado.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un estado.");
                    return;
                }

                string idLogistica = Cmb_ID.Text;
                int estado = Convert.ToInt32(Cmb_Estado.SelectedValue);
                DateTime fechaReq = Dtp_Requerida.Value;
                string obs = Rtxt_Observaciones.Text;

                DataTable dtDetalle = new DataTable();
                dtDetalle.Columns.Add("Fk_Id_Material", typeof(int));
                dtDetalle.Columns.Add("Cantidad_Solicitada", typeof(decimal));

                foreach (DataGridViewRow fila in Dgv_Materiales.Rows)
                {
                    if (fila.Cells["Codigo_Material"].Value != null)
                    {
                        DataRow dr = dtDetalle.NewRow();

                        int idMaterial = _controlador.ObtenerIdPorCodigo(fila.Cells["Codigo_Material"].Value.ToString());

                        dr["Fk_Id_Material"] = idMaterial;
                        dr["Cantidad_Solicitada"] = Convert.ToDecimal(fila.Cells["Cantidad"].Value);
                        dtDetalle.Rows.Add(dr);
                    }
                }

                if (dtDetalle.Rows.Count == 0)
                {
                    MessageBox.Show("Debe agregar al menos un material al detalle.");
                    return;
                }

                bool exito = _controlador.GuardarOrdenCompleta(idLogistica, estado, fechaReq, obs, dtDetalle);

                if (exito)
                {
                    MessageBox.Show("Orden guardada exitosamente en la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EstadoControles(false);
                    LimpiarCampos();
                    Dgv_Materiales.Rows.Clear();
                }
                else
                {
                    MessageBox.Show("Error al intentar guardar la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            EstadoControles(true);

            Cmb_ID.Enabled = false;
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (Cmb_ID.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una orden para eliminar.");
                return;
            }

            DialogResult confirm = MessageBox.Show("¿Seguro que desea eliminar esta orden y sus detalles?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                int idOrden = Convert.ToInt32(Cmb_ID.SelectedValue);
                if (_controlador.BorrarOrden(idOrden))
                {
                    MessageBox.Show("Registro eliminado correctamente.");
                    CargarComboOrdenes(); 
                    LimpiarCampos();
                    EstadoControles(false);
                }
            }
        }

        private void Btn_refrescar_Click(object sender, EventArgs e)
        {
            CargarComboOrdenes();
            CargarComboEstados();
            CargarCombosMateriales();
            MessageBox.Show("Catálogos actualizados.");
        }
        // ------ DANI - 0901-22-9136, 29/04/2026 --------

    }
}
