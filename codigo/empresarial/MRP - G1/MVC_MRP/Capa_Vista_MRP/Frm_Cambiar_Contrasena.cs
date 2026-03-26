using System;
using System.Windows.Forms;
using Capa_Controlador_Seguridad;

namespace Capa_Vista_MRP
{
    public partial class Frm_Cambiar_Contrasena : Form
    {

        private Cls_controlador_cambio_contrasena controlador = new Cls_controlador_cambio_contrasena();
        private int iIdUsuario;
        public Frm_Cambiar_Contrasena(int iIdUsuarioActual)
        {       
            InitializeComponent();
            iIdUsuario = iIdUsuarioActual;

            Txt_contrasena_actual.UseSystemPasswordChar = true;
            Txt_nueva_contrasena.UseSystemPasswordChar = true;
            Txt_confirmar_contrasena.UseSystemPasswordChar = true;
        }

        private void Btn_Cambiar_Click(object sender, EventArgs e)
        {
            string sActual = Txt_contrasena_actual.Text.Trim();
            string sNueva = Txt_nueva_contrasena.Text.Trim();
            string sConfirmar = Txt_confirmar_contrasena.Text.Trim();

            // Validar campos vacíos
            if (string.IsNullOrEmpty(sActual))
            {
                MessageBox.Show("Debe ingresar la contraseña actual.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(sNueva) || string.IsNullOrEmpty(sConfirmar))
            {
                MessageBox.Show("Debe ingresar y confirmar la nueva contraseña.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar coincidencia de nuevas contraseñas
            if (sNueva != sConfirmar)
            {
                MessageBox.Show("La nueva contraseña y su confirmación no coinciden.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar contraseña actual
            if (!controlador.fun_validar_contrasena(iIdUsuario, sActual))
            {
                MessageBox.Show("La contraseña actual es incorrecta.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Intentar actualizar
            bool bExito = controlador.fun_actualizar_Contrasena(iIdUsuario, sNueva);
            if (bExito)
            {
                MessageBox.Show("Contraseña cambiada correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos
                Txt_contrasena_actual.Clear();
                Txt_nueva_contrasena.Clear();
                Txt_confirmar_contrasena.Clear();

            }
            else
            {
                MessageBox.Show("Ocurrió un error al cambiar la contraseña.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Chk_Mostrar_CheckedChanged(object sender, EventArgs e)
        {
            bool bMostrar = Chk_Mostrar.Checked;
            Txt_contrasena_actual.UseSystemPasswordChar = !bMostrar;
            Txt_nueva_contrasena.UseSystemPasswordChar = !bMostrar;
            Txt_confirmar_contrasena.UseSystemPasswordChar = !bMostrar;
        }
    }
}
