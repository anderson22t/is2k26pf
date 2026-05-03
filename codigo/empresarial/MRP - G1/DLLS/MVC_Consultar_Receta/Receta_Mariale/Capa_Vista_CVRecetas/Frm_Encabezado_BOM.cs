using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Recetas;

// Hecho por: Maria Morales 0901-22-1226
namespace Capa_Vista_CVRecetas
{
    public partial class Frm_Encabezado_BOM : Form
    {
        Controlador con = new Controlador();

        public Frm_Encabezado_BOM()
        {
            InitializeComponent();
            this.Load += Frm_Encabezado_BOM_Load;
            Dg_BOM.CellContentClick += Dg_BOM_CellContentClick;
        }


        private void cargarGrid()
        {
            DataTable dt = con.obtenerListadoBOM();
            Dg_BOM.DataSource = dt;

            // Ocultar ID si existe
            if (Dg_BOM.Columns.Contains("ID"))
                Dg_BOM.Columns["ID"].Visible = false;

            // Agregar botón UNA sola vez
            if (!Dg_BOM.Columns.Contains("Acciones"))
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Name = "Acciones";
                btn.HeaderText = "Acciones";
                btn.Text = "Ver detalle";
                btn.UseColumnTextForButtonValue = true;

                Dg_BOM.Columns.Add(btn);
            }
        }

        private void Frm_Encabezado_BOM_Load(object sender, EventArgs e)
        {
            cargarGrid(); 
        }


        private void Dg_BOM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && Dg_BOM.Columns[e.ColumnIndex].Name == "Acciones")
            {
                int idBOM = Convert.ToInt32(Dg_BOM.Rows[e.RowIndex].Cells["ID"].Value);

                Frm_Recetas frm = new Frm_Recetas();
                frm.cargarDesdeListado(idBOM);
                frm.ShowDialog();
            }
        }

        private void Btn_crear_Click(object sender, EventArgs e)
        {
          
            Frm_Recetas fr = new Frm_Recetas();

            fr.Show();
        }
    }
}
// Hecho por: Maria Morales 0901-22-1226
