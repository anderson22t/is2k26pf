using System;
using System.Data;
using System.Windows.Forms;
using Capa_Controlador_RO;

namespace Capa_Vista_RO
{
    public partial class Frm_Detalle_Orden : Form
    {
        private readonly Cls_Controlador_Orden _controlador = new Cls_Controlador_Orden();
        private int _idOrden;
        private bool _cargando = false; // ✅ bandera para evitar disparos falsos del evento

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
            CargarComboEstados();  // ✅ primero los estados
            CargarComboOrdenes();  // luego las órdenes

            if (_idOrden > 0)
            {
                Cmb_ID.SelectedValue = _idOrden;
            }
        }

        // ✅ Carga los estados en Cmb_Estado
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
            _cargando = true; // ✅ bloquea el evento mientras cargamos
            try
            {
                DataTable dt = _controlador.ObtenerOrdenesCombo();
                Cmb_ID.DataSource = dt;
                Cmb_ID.DisplayMember = "Orden";
                Cmb_ID.ValueMember = "IdOrden"; // ✅ coincide con alias de la query
                Cmb_ID.SelectedIndex = -1;
            }
            finally
            {
                _cargando = false;
            }
        }

        // ── Evento SelectedIndexChanged de Cmb_ID ──
        private void Cmb_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ✅ Si estamos cargando datos o no hay selección, salir
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
                return;
            }

            // ✅ Manejar nulls en todas las columnas antes de mostrar
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    if (row[col] == DBNull.Value)
                    {
                        // Si es numérica asigna 0, si es texto asigna vacío
                        if (col.DataType == typeof(decimal) ||
                            col.DataType == typeof(int) ||
                            col.DataType == typeof(double))
                            row[col] = 0;
                        else
                            row[col] = string.Empty;
                    }
                }
            }

            // Agregar columna de número de fila desde C#
            dt.Columns.Add("Numero", typeof(int));
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["Numero"] = i + 1;

            dt.Columns["Numero"].SetOrdinal(0);

            Dgv_Materiales.AutoGenerateColumns = true;//
            Dgv_Materiales.DataSource = dt;

            // Encabezados en español
            Dgv_Materiales.Columns["Numero"].HeaderText = "#";
            Dgv_Materiales.Columns["Id_Material"].HeaderText = "ID Material";       
            Dgv_Materiales.Columns["Nombre_Material"].HeaderText = "Nombre Material";  
            Dgv_Materiales.Columns["UnidadMedida"].HeaderText = "Unidad de Medida";
            Dgv_Materiales.Columns["CantidadSolicitada"].HeaderText = "Cantidad Solicitada";
        }

        private void CargarDatosOrden(int idOrden)
        {
            DataTable dt = _controlador.ObtenerOrdenPorId(idOrden);
            if (dt.Rows.Count == 0) return;

            DataRow row = dt.Rows[0];

            // ✅ Usar los aliases limpios que definimos en la query
            Cmb_Estado.SelectedValue = row["IdEstado"];

            // ✅ Verificar que las fechas no sean nulas antes de asignar
            if (row["FechaRecepcion"] != DBNull.Value)
                Dtp_Recepcion.Value = Convert.ToDateTime(row["FechaRecepcion"]);

            if (row["FechaRequerida"] != DBNull.Value)
                Dtp_Requerida.Value = Convert.ToDateTime(row["FechaRequerida"]);

            Rtxt_Observaciones.Text = row["Observacion"] != DBNull.Value
                                      ? row["Observacion"].ToString()
                                      : string.Empty;
        }

        // Al final de la clase, antes del último }
        private void label2_Click(object sender, EventArgs e) { }

        private void Dgv_Materiales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }

}