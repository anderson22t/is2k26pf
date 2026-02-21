using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista_Migracion
{
    public partial class Frm_MDI_Migracion : Form
    {

        public Frm_MDI_Migracion()
        {
            InitializeComponent();

            this.IsMdiContainer = true; // <- activa MDI container
            this.Load += Frm_MDI_Migracion_Load;
        }
       

        private void Frm_MDI_Migracion_Load(object sender, EventArgs e)
        {
            // Mostrar usuario conectado en StatusStrip si existe el control
            try
            {
                toolStripStatusLabel.Text = $"Estado: Conectado | Usuario: {Capa_Controlador_Seguridad.Cls_Usuario_Conectado.sNombreUsuario}";
            }
            catch
            {
                // Si no existe toolStripStatusLabel en este formulario, ignorar.
            }

        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_Login_Migracion ventanaPrincipal = new Frm_Login_Migracion();
            ventanaPrincipal.ShowDialog();
            this.Close();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Cambiar_Contrasenea ventana = new Frm_Cambiar_Contrasenea(Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario);
            ventana.Show();
        }

        private void mantenimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        // Ruben Lopez 19/02/1016
        private void emisionPasaporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capa_Vista_Pasaporte.Frm_pasaporte pasaporte = new Capa_Vista_Pasaporte.Frm_pasaporte();
            pasaporte.MdiParent = this;
            pasaporte.Show();

        }

        //Arón Esquit 21/2/2026
        private void estadoCitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Estado_Cita estado = new Frm_Estado_Cita();
            estado.MdiParent = this;
            estado.Show();
        }
    }
}
