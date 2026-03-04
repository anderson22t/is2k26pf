using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Renap;

namespace Capa_Vista_Renap
{
    public partial class Frm_Renap : Form
    {
        public Frm_Renap()
        {
            InitializeComponent();
        }

        string ciu = "Tbl_Ciudadano";
        Cls_Controlador controlador = new Cls_Controlador();


        //Mostrar los datos CAPA VISTA


        public void actualizardatagriew()
        {
            DataTable dt = controlador.llenarTbl(ciu);
            dgv_renap.DataSource = dt;

        }





        private void btn_guardar_Click_1(object sender, EventArgs e)
        {
            // validar DPI
            if (!long.TryParse(txt_dpi.Text.Trim(), out long dpi))
            {
                MessageBox.Show("Ingrese un número de identificación válido.");
                txt_dpi.Focus();
                return;
            }

            // validar sexo
            if (!rdb_femenino.Checked && !rdb_masculino.Checked)
            {
                MessageBox.Show("Seleccione el sexo.");
                return;
            }

            string nombres = txt_nombres.Text.Trim();
            string apellidos = txt_apellidos.Text.Trim();
            string nacionalidad = txt_nacionalidad.Text.Trim();
            string lugarNacimiento = txt_lugarnac.Text.Trim();
            DateTime fechaNacimiento = dtp_fecha.Value;

            // femenino = 0, masculino = 1
            int sexo = rdb_masculino.Checked ? 1 : 0;

            Cls_Controlador controlador = new Cls_Controlador();

            bool guardado = controlador.Guardar(
                                dpi,
                                nombres,
                                apellidos,
                                sexo,
                                nacionalidad,
                                lugarNacimiento,
                                fechaNacimiento
                            );

            if (guardado)
                MessageBox.Show("Registro guardado correctamente.");
            else
                MessageBox.Show("Error al guardar el registro.");
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            actualizardatagriew();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_renap.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro.");
                return;
            }

            int idCiudadano = Convert.ToInt32(
                dgv_renap.CurrentRow.Cells["Pk_Id_Ciudadano"].Value
            );

            DialogResult r = MessageBox.Show(
                "¿Está seguro de eliminar este registro?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (r == DialogResult.No)
                return;

            bool eliminado = controlador.Eliminar(idCiudadano);

            if (eliminado)
            {
                MessageBox.Show("Registro eliminado correctamente.");
                actualizardatagriew();   // refresca el grid
            }
            else
            {
                MessageBox.Show("Error al eliminar el registro.");
            }
        }
    }
}
