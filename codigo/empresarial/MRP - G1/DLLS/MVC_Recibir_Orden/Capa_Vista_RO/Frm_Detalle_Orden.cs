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

        
        private void label2_Click(object sender, EventArgs e) { }

        private void Dgv_Materiales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
    // ------ LETICIA SONTAY - 9959-21-9664, 28/04/2026 --------

}