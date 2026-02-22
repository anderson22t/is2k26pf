using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador;

namespace Capa_Vista_Antecedentes
{
    public partial class Frm_Antecedentes : Form
    {
        public Frm_Antecedentes()
        {
            InitializeComponent();
        }

        private void CargarCiudadanos()
        {
            CiudadanoControlador controlador = new CiudadanoControlador();

            Cbo_Ciudadano.DataSource = controlador.ObtenerCiudadanos();
            Cbo_Ciudadano.DisplayMember = "NombreCompleto";
            Cbo_Ciudadano.ValueMember = "IdCiudadano";

            Cbo_Ciudadano.SelectedIndex = -1;
        }

        private void Frm_Antecedentes_Load(object sender, EventArgs e)
        {
            CargarCiudadanos();

        }

        private void Cbo_Ciudadano_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_Ciudadano.SelectedItem is Capa_Modelo_Antecedentes.Ciudadano ciudadano)
            {
                int idCiudadano = ciudadano.IdCiudadano;
                Console.WriteLine("ID seleccionado: " + idCiudadano);
            }
        }
    }
}
