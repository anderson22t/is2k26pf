using Capa_Controlador_Citas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista_Citas
{
    public partial class Frm_Citas : Form
    {
        Cls_Controlador_Citas controlador = new Cls_Controlador_Citas();
        public Frm_Citas()
        {
            
            InitializeComponent();
            CargarCombos();
        }
        private void CargarCombos()
        {
            DataTable dtTipos = controlador.ObtenerTiposCita();

            Cbo_Tipo_Cita.DataSource = dtTipos;
            Cbo_Tipo_Cita.DisplayMember = "Cmp_Nombre_Tipo_Cita";
            Cbo_Tipo_Cita.ValueMember = "Pk_Id_Tipo_Cita";
            Cbo_Tipo_Cita.SelectedIndex = -1; // Nada seleccionado
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cls_Controlador_Citas controller = new Cls_Controlador_Citas();

            bool resultado = controller.AgendarCita(
                Dtp_Fecha_Cita.Value.Date,
                Convert.ToInt32(Cbo_Tipo_Cita.SelectedValue),
                Convert.ToInt32(Cbo_Horario.SelectedValue),
                Convert.ToInt32(Cbo_Sede.SelectedValue),
                int.Parse(Txt_No_Boleta.Text),
                out string mensaje
            );

            MessageBox.Show(mensaje);
        }
    }
}