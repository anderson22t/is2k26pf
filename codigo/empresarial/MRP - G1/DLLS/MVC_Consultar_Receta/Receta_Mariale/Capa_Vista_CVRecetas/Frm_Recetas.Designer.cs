
namespace Capa_Vista_CVRecetas
{
    partial class Frm_Recetas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Recetas));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_detalle = new System.Windows.Forms.DataGridView();
            this.btn_ver_detalle = new System.Windows.Forms.Button();
            this.lbl_bom = new System.Windows.Forms.Label();
            this.Txt_versionBOM = new System.Windows.Forms.TextBox();
            this.lbl_descripcion = new System.Windows.Forms.Label();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.Txt_descripcion = new System.Windows.Forms.TextBox();
            this.Cbo_estado = new System.Windows.Forms.ComboBox();
            this.Cbo_producto = new System.Windows.Forms.ComboBox();
            this.lbl_estado = new System.Windows.Forms.Label();
            this.lbl_fecha_creacion = new System.Windows.Forms.Label();
            this.lbl_producto = new System.Windows.Forms.Label();
            this.btn_consultar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_produccion = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_ingresar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_ayuda = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_reporte = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detalle)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_detalle);
            this.groupBox1.Controls.Add(this.btn_ver_detalle);
            this.groupBox1.Controls.Add(this.lbl_bom);
            this.groupBox1.Controls.Add(this.Txt_versionBOM);
            this.groupBox1.Controls.Add(this.lbl_descripcion);
            this.groupBox1.Controls.Add(this.dtp_fecha);
            this.groupBox1.Controls.Add(this.Txt_descripcion);
            this.groupBox1.Controls.Add(this.Cbo_estado);
            this.groupBox1.Controls.Add(this.Cbo_producto);
            this.groupBox1.Controls.Add(this.lbl_estado);
            this.groupBox1.Controls.Add(this.lbl_fecha_creacion);
            this.groupBox1.Controls.Add(this.lbl_producto);
            this.groupBox1.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 193);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(829, 382);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Consulta";
            // 
            // dgv_detalle
            // 
            this.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_detalle.Location = new System.Drawing.Point(5, 190);
            this.dgv_detalle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_detalle.Name = "dgv_detalle";
            this.dgv_detalle.RowHeadersWidth = 51;
            this.dgv_detalle.RowTemplate.Height = 24;
            this.dgv_detalle.Size = new System.Drawing.Size(819, 178);
            this.dgv_detalle.TabIndex = 19;
            this.dgv_detalle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_detalle_CellContentClick);
            this.dgv_detalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_detalle_CellContentClick);
            // 
            // btn_ver_detalle
            // 
            this.btn_ver_detalle.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ver_detalle.Image = ((System.Drawing.Image)(resources.GetObject("btn_ver_detalle.Image")));
            this.btn_ver_detalle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_ver_detalle.Location = new System.Drawing.Point(708, 106);
            this.btn_ver_detalle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ver_detalle.Name = "btn_ver_detalle";
            this.btn_ver_detalle.Size = new System.Drawing.Size(105, 78);
            this.btn_ver_detalle.TabIndex = 18;
            this.btn_ver_detalle.Text = "Ver detalle";
            this.btn_ver_detalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ver_detalle.UseVisualStyleBackColor = true;
            this.btn_ver_detalle.Click += new System.EventHandler(this.btn_ver_detalle_Click);
            // 
            // lbl_bom
            // 
            this.lbl_bom.AutoSize = true;
            this.lbl_bom.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bom.Location = new System.Drawing.Point(463, 75);
            this.lbl_bom.Name = "lbl_bom";
            this.lbl_bom.Size = new System.Drawing.Size(106, 17);
            this.lbl_bom.TabIndex = 9;
            this.lbl_bom.Text = "Version BOM:";
            // 
            // Txt_versionBOM
            // 
            this.Txt_versionBOM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_versionBOM.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_versionBOM.Location = new System.Drawing.Point(592, 73);
            this.Txt_versionBOM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_versionBOM.Name = "Txt_versionBOM";
            this.Txt_versionBOM.Size = new System.Drawing.Size(221, 25);
            this.Txt_versionBOM.TabIndex = 5;
            // 
            // lbl_descripcion
            // 
            this.lbl_descripcion.AutoSize = true;
            this.lbl_descripcion.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_descripcion.Location = new System.Drawing.Point(463, 32);
            this.lbl_descripcion.Name = "lbl_descripcion";
            this.lbl_descripcion.Size = new System.Drawing.Size(98, 17);
            this.lbl_descripcion.TabIndex = 8;
            this.lbl_descripcion.Text = "Descripcion:";
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.CalendarFont = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_fecha.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_fecha.Location = new System.Drawing.Point(149, 114);
            this.dtp_fecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(200, 23);
            this.dtp_fecha.TabIndex = 5;
            // 
            // Txt_descripcion
            // 
            this.Txt_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_descripcion.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_descripcion.Location = new System.Drawing.Point(584, 30);
            this.Txt_descripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_descripcion.Name = "Txt_descripcion";
            this.Txt_descripcion.Size = new System.Drawing.Size(229, 25);
            this.Txt_descripcion.TabIndex = 3;
            // 
            // Cbo_estado
            // 
            this.Cbo_estado.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbo_estado.FormattingEnabled = true;
            this.Cbo_estado.Location = new System.Drawing.Point(129, 73);
            this.Cbo_estado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cbo_estado.Name = "Cbo_estado";
            this.Cbo_estado.Size = new System.Drawing.Size(221, 25);
            this.Cbo_estado.TabIndex = 4;
            // 
            // Cbo_producto
            // 
            this.Cbo_producto.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbo_producto.FormattingEnabled = true;
            this.Cbo_producto.Location = new System.Drawing.Point(99, 30);
            this.Cbo_producto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cbo_producto.Name = "Cbo_producto";
            this.Cbo_producto.Size = new System.Drawing.Size(251, 25);
            this.Cbo_producto.TabIndex = 3;
            // 
            // lbl_estado
            // 
            this.lbl_estado.AutoSize = true;
            this.lbl_estado.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_estado.Location = new System.Drawing.Point(17, 76);
            this.lbl_estado.Name = "lbl_estado";
            this.lbl_estado.Size = new System.Drawing.Size(59, 17);
            this.lbl_estado.TabIndex = 0;
            this.lbl_estado.Text = "Estado:";
            // 
            // lbl_fecha_creacion
            // 
            this.lbl_fecha_creacion.AutoSize = true;
            this.lbl_fecha_creacion.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fecha_creacion.Location = new System.Drawing.Point(16, 117);
            this.lbl_fecha_creacion.Name = "lbl_fecha_creacion";
            this.lbl_fecha_creacion.Size = new System.Drawing.Size(120, 17);
            this.lbl_fecha_creacion.TabIndex = 1;
            this.lbl_fecha_creacion.Text = "Fecha creacion:";
            // 
            // lbl_producto
            // 
            this.lbl_producto.AutoSize = true;
            this.lbl_producto.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_producto.Location = new System.Drawing.Point(17, 33);
            this.lbl_producto.Name = "lbl_producto";
            this.lbl_producto.Size = new System.Drawing.Size(76, 17);
            this.lbl_producto.TabIndex = 0;
            this.lbl_producto.Text = "Producto:";
            // 
            // btn_consultar
            // 
            this.btn_consultar.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_consultar.Image = ((System.Drawing.Image)(resources.GetObject("btn_consultar.Image")));
            this.btn_consultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_consultar.Location = new System.Drawing.Point(483, 17);
            this.btn_consultar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_consultar.Name = "btn_consultar";
            this.btn_consultar.Size = new System.Drawing.Size(87, 64);
            this.btn_consultar.TabIndex = 6;
            this.btn_consultar.Text = "Consultar";
            this.btn_consultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_consultar.UseVisualStyleBackColor = true;
            this.btn_consultar.Click += new System.EventHandler(this.btn_consultar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Crear Receta";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(-3, 96);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(872, 10);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btn_produccion
            // 
            this.btn_produccion.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_produccion.Image = ((System.Drawing.Image)(resources.GetObject("btn_produccion.Image")));
            this.btn_produccion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_produccion.Location = new System.Drawing.Point(740, 112);
            this.btn_produccion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_produccion.Name = "btn_produccion";
            this.btn_produccion.Size = new System.Drawing.Size(108, 78);
            this.btn_produccion.TabIndex = 19;
            this.btn_produccion.Text = "Fases de produccion";
            this.btn_produccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_produccion.UseVisualStyleBackColor = true;
            this.btn_produccion.Click += new System.EventHandler(this.btn_produccion_Click_1);
            // 
            // btn_salir
            // 
            this.btn_salir.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_salir.Location = new System.Drawing.Point(761, 16);
            this.btn_salir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(87, 63);
            this.btn_salir.TabIndex = 10;
            this.btn_salir.Text = "Salir";
            this.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_salir.UseVisualStyleBackColor = true;
            // 
            // btn_ingresar
            // 
            this.btn_ingresar.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ingresar.Image = ((System.Drawing.Image)(resources.GetObject("btn_ingresar.Image")));
            this.btn_ingresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_ingresar.Location = new System.Drawing.Point(12, 17);
            this.btn_ingresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ingresar.Name = "btn_ingresar";
            this.btn_ingresar.Size = new System.Drawing.Size(87, 62);
            this.btn_ingresar.TabIndex = 7;
            this.btn_ingresar.Text = "Ingresar";
            this.btn_ingresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ingresar.UseVisualStyleBackColor = true;
            // 
            // btn_guardar
            // 
            this.btn_guardar.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_guardar.Location = new System.Drawing.Point(197, 18);
            this.btn_guardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(87, 62);
            this.btn_guardar.TabIndex = 16;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_editar
            // 
            this.btn_editar.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editar.Image = ((System.Drawing.Image)(resources.GetObject("btn_editar.Image")));
            this.btn_editar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_editar.Location = new System.Drawing.Point(105, 17);
            this.btn_editar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(87, 62);
            this.btn_editar.TabIndex = 17;
            this.btn_editar.Text = "Editar";
            this.btn_editar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Image")));
            this.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_eliminar.Location = new System.Drawing.Point(389, 17);
            this.btn_eliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(87, 64);
            this.btn_eliminar.TabIndex = 18;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_ayuda
            // 
            this.btn_ayuda.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ayuda.Image = ((System.Drawing.Image)(resources.GetObject("btn_ayuda.Image")));
            this.btn_ayuda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_ayuda.Location = new System.Drawing.Point(668, 15);
            this.btn_ayuda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ayuda.Name = "btn_ayuda";
            this.btn_ayuda.Size = new System.Drawing.Size(87, 64);
            this.btn_ayuda.TabIndex = 11;
            this.btn_ayuda.Text = "Ayuda";
            this.btn_ayuda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ayuda.UseVisualStyleBackColor = true;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_cancelar.Location = new System.Drawing.Point(291, 18);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(87, 64);
            this.btn_cancelar.TabIndex = 19;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            // 
            // btn_reporte
            // 
            this.btn_reporte.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reporte.Image = ((System.Drawing.Image)(resources.GetObject("btn_reporte.Image")));
            this.btn_reporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_reporte.Location = new System.Drawing.Point(575, 16);
            this.btn_reporte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_reporte.Name = "btn_reporte";
            this.btn_reporte.Size = new System.Drawing.Size(87, 64);
            this.btn_reporte.TabIndex = 20;
            this.btn_reporte.Text = "Reporte";
            this.btn_reporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_reporte.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(629, 112);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 78);
            this.button1.TabIndex = 19;
            this.button1.Text = "Ver recetas";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Frm_Recetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 587);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_reporte);
            this.Controls.Add(this.btn_produccion);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_ayuda);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_consultar);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_ingresar);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Frm_Recetas";
            this.Text = "Frm_Recetas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_consultar;
        private System.Windows.Forms.ComboBox Cbo_estado;
        private System.Windows.Forms.ComboBox Cbo_producto;
        private System.Windows.Forms.Label lbl_fecha_creacion;
        private System.Windows.Forms.Label lbl_producto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox Txt_versionBOM;
        private System.Windows.Forms.TextBox Txt_descripcion;
        private System.Windows.Forms.Label lbl_estado;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Button btn_ingresar;
        private System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.Label lbl_bom;
        private System.Windows.Forms.Label lbl_descripcion;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_ayuda;
        private System.Windows.Forms.Button btn_produccion;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_ver_detalle;
        private System.Windows.Forms.Button btn_reporte;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv_detalle;
    }
}