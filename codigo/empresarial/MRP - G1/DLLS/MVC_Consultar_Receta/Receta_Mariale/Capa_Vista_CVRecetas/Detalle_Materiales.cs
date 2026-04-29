using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Capa_Vista_CVRecetas
{
    public partial class Detalle_Materiales : Form
    {
        string conexion = "DSN=bd_SIG;";

        public Detalle_Materiales()
        {
            InitializeComponent();
            configurarDGV();
            cargarCombos();
        }

        private void cargarCombos()
        {
            cargarProductos();
            cargarMateriales();
            cargarUnidades();
        }

        private void cargarProductos()
        {
            using (OdbcConnection con = new OdbcConnection(conexion))
            {
                con.Open();

                string query = @"
                SELECT m.Pk_Id_Materiales, m.Nombre_Material
                FROM Tbl_Materiales m
                INNER JOIN Tbl_Categoria_Material c 
                    ON m.Fk_Id_Categoria = c.Pk_Id_Categoria_Material
                INNER JOIN Tbl_Tipo_Material t 
                    ON c.Fk_Tipo_Material = t.Pk_Id_Tipo_Material
                WHERE t.Nombre_Tipo_Material = 'Producto Terminado';";

                OdbcDataAdapter da = new OdbcDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Cbo_Producto.DataSource = dt;
                Cbo_Producto.DisplayMember = "Nombre_Material";
                Cbo_Producto.ValueMember = "Pk_Id_Materiales";
                Cbo_Producto.SelectedIndex = -1;
            }
        }

        private void cargarMateriales()
        {
            using (OdbcConnection con = new OdbcConnection(conexion))
            {
                con.Open();

                string query = @"
                SELECT m.Pk_Id_Materiales, m.Nombre_Material
                FROM Tbl_Materiales m
                INNER JOIN Tbl_Categoria_Material c 
                    ON m.Fk_Id_Categoria = c.Pk_Id_Categoria_Material
                INNER JOIN Tbl_Tipo_Material t 
                    ON c.Fk_Tipo_Material = t.Pk_Id_Tipo_Material
                WHERE t.Nombre_Tipo_Material = 'Materia Prima';";

                OdbcDataAdapter da = new OdbcDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Cbo_Material.DataSource = dt;
                Cbo_Material.DisplayMember = "Nombre_Material";
                Cbo_Material.ValueMember = "Pk_Id_Materiales";
                Cbo_Material.SelectedIndex = -1;
            }
        }

        private void cargarUnidades()
        {
            using (OdbcConnection con = new OdbcConnection(conexion))
            {
                con.Open();

                string query = "SELECT Pk_Id_Unidad_Medida, Nombre_Unidad_Medida FROM Tbl_Unidad_Medida;";

                OdbcDataAdapter da = new OdbcDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Cbo_Unidad.DataSource = dt;
                Cbo_Unidad.DisplayMember = "Nombre_Unidad_Medida";
                Cbo_Unidad.ValueMember = "Pk_Id_Unidad_Medida";
                Cbo_Unidad.SelectedIndex = -1;
            }
        }

        private void configurarDGV()
        {
            Dgv_Recetas.Columns.Clear();

            Dgv_Recetas.ColumnCount = 6;

            Dgv_Recetas.Columns[0].Name = "IdProducto";
            Dgv_Recetas.Columns[1].Name = "Producto";
            Dgv_Recetas.Columns[2].Name = "IdMaterial";
            Dgv_Recetas.Columns[3].Name = "Material";
            Dgv_Recetas.Columns[4].Name = "Unidad";
            Dgv_Recetas.Columns[5].Name = "Cantidad";

            Dgv_Recetas.Columns[0].Visible = false;
            Dgv_Recetas.Columns[2].Visible = false;

            Dgv_Recetas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv_Recetas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_Recetas.ReadOnly = true;
            Dgv_Recetas.AllowUserToAddRows = false;
        }

        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            if (Cbo_Producto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            if (Cbo_Material.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un material");
                return;
            }

            if (Cbo_Unidad.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una unidad");
                return;
            }

            if (Nud_Cantidad.Value <= 0)
            {
                MessageBox.Show("Ingrese cantidad válida");
                return;
            }

            Dgv_Recetas.Rows.Add(
                Cbo_Producto.SelectedValue,
                Cbo_Producto.Text,
                Cbo_Material.SelectedValue,
                Cbo_Material.Text,
                Cbo_Unidad.Text,
                Nud_Cantidad.Value
            );
        }
    }
}