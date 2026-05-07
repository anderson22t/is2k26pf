using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Prod;

namespace Capa_Vista_Prod
{
    public partial class Frm_Produccion : Form
    {
        Cls_Controlador_Prod controlador = new Cls_Controlador_Prod();
        public Frm_Produccion()
        {
            InitializeComponent();
            this.Load += Frm_Prod_Load;
            ToolTip tip = new ToolTip();
            tip.IsBalloon = true;
            tip.ToolTipTitle = "Búsqueda de Órdenes";
            tip.SetToolTip(Cbo_Orden, "Seleccione o escriba el número de orden para realizar la implosión.");
        }

        private void Frm_Prod_Load(object sender, EventArgs e)
        {
            // Configurar DateTimePickers igual que Kevin
            

            ObtenerOrdenesRecibidas();
           
        }

        private void ObtenerOrdenesRecibidas()
        {
            DataTable dt = controlador.ObtenerOrdenesRecibidas();
            Cbo_Orden.DataSource = dt;
            Cbo_Orden.DisplayMember = "No_Orden";
            Cbo_Orden.ValueMember = "Pk_Id_Orden_Recibida";
            Cbo_Orden.SelectedIndex = -1;
        }
    }
}
