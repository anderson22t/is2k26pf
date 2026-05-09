
namespace Capa_Vista_Plan
{
    partial class Frm_Encabezado_Plan
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
            this.Lbl_listado_plan = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.Lbl_id = new System.Windows.Forms.Label();
            this.Cmb_Id_plan = new System.Windows.Forms.ComboBox();
            this.Lbl_Estado = new System.Windows.Forms.Label();
            this.Cmb_Estado_plan = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Dtp_Desde_plan = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.Dtp_Hasta_plan = new System.Windows.Forms.DateTimePicker();
            this.Btn_crear_plan = new System.Windows.Forms.Button();
            this.Dg_BOM = new System.Windows.Forms.DataGridView();
            this.Btn_Limpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dg_BOM)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_listado_plan
            // 
            this.Lbl_listado_plan.AutoSize = true;
            this.Lbl_listado_plan.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_listado_plan.Location = new System.Drawing.Point(12, 9);
            this.Lbl_listado_plan.Name = "Lbl_listado_plan";
            this.Lbl_listado_plan.Size = new System.Drawing.Size(453, 29);
            this.Lbl_listado_plan.TabIndex = 25;
            this.Lbl_listado_plan.Text = "Listado de Planes y Ordenes Creados";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(17, 41);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1257, 10);
            this.flowLayoutPanel2.TabIndex = 26;
            // 
            // Lbl_id
            // 
            this.Lbl_id.AutoSize = true;
            this.Lbl_id.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_id.Location = new System.Drawing.Point(13, 74);
            this.Lbl_id.Name = "Lbl_id";
            this.Lbl_id.Size = new System.Drawing.Size(100, 23);
            this.Lbl_id.TabIndex = 32;
            this.Lbl_id.Text = "Buscar Id";
            // 
            // Cmb_Id_plan
            // 
            this.Cmb_Id_plan.FormattingEnabled = true;
            this.Cmb_Id_plan.Location = new System.Drawing.Point(144, 76);
            this.Cmb_Id_plan.Name = "Cmb_Id_plan";
            this.Cmb_Id_plan.Size = new System.Drawing.Size(134, 21);
            this.Cmb_Id_plan.TabIndex = 33;
            // 
            // Lbl_Estado
            // 
            this.Lbl_Estado.AutoSize = true;
            this.Lbl_Estado.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Estado.Location = new System.Drawing.Point(320, 74);
            this.Lbl_Estado.Name = "Lbl_Estado";
            this.Lbl_Estado.Size = new System.Drawing.Size(81, 23);
            this.Lbl_Estado.TabIndex = 34;
            this.Lbl_Estado.Text = "Estado:";
            // 
            // Cmb_Estado_plan
            // 
            this.Cmb_Estado_plan.FormattingEnabled = true;
            this.Cmb_Estado_plan.Location = new System.Drawing.Point(420, 76);
            this.Cmb_Estado_plan.Name = "Cmb_Estado_plan";
            this.Cmb_Estado_plan.Size = new System.Drawing.Size(134, 21);
            this.Cmb_Estado_plan.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(592, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 23);
            this.label3.TabIndex = 36;
            this.label3.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(665, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 23);
            this.label4.TabIndex = 37;
            this.label4.Text = "Desde: ";
            // 
            // Dtp_Desde_plan
            // 
            this.Dtp_Desde_plan.Location = new System.Drawing.Point(752, 79);
            this.Dtp_Desde_plan.Name = "Dtp_Desde_plan";
            this.Dtp_Desde_plan.Size = new System.Drawing.Size(200, 20);
            this.Dtp_Desde_plan.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(987, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 23);
            this.label5.TabIndex = 39;
            this.label5.Text = "Hasta:";
            // 
            // Dtp_Hasta_plan
            // 
            this.Dtp_Hasta_plan.Location = new System.Drawing.Point(1063, 82);
            this.Dtp_Hasta_plan.Name = "Dtp_Hasta_plan";
            this.Dtp_Hasta_plan.Size = new System.Drawing.Size(200, 20);
            this.Dtp_Hasta_plan.TabIndex = 40;
            // 
            // Btn_crear_plan
            // 
            this.Btn_crear_plan.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_crear_plan.Location = new System.Drawing.Point(1277, 78);
            this.Btn_crear_plan.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_crear_plan.Name = "Btn_crear_plan";
            this.Btn_crear_plan.Size = new System.Drawing.Size(140, 24);
            this.Btn_crear_plan.TabIndex = 41;
            this.Btn_crear_plan.Text = "Crear Nuevo Plan";
            this.Btn_crear_plan.UseVisualStyleBackColor = true;
            // 
            // Dg_BOM
            // 
            this.Dg_BOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dg_BOM.Location = new System.Drawing.Point(17, 166);
            this.Dg_BOM.Name = "Dg_BOM";
            this.Dg_BOM.RowHeadersWidth = 51;
            this.Dg_BOM.Size = new System.Drawing.Size(1262, 439);
            this.Dg_BOM.TabIndex = 43;
            // 
            // Btn_Limpiar
            // 
            this.Btn_Limpiar.Location = new System.Drawing.Point(1328, 294);
            this.Btn_Limpiar.Name = "Btn_Limpiar";
            this.Btn_Limpiar.Size = new System.Drawing.Size(75, 59);
            this.Btn_Limpiar.TabIndex = 44;
            this.Btn_Limpiar.Text = "Limpiar";
            this.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Limpiar.UseVisualStyleBackColor = true;
            // 
            // Frm_Encabezado_Plan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 650);
            this.Controls.Add(this.Btn_Limpiar);
            this.Controls.Add(this.Dg_BOM);
            this.Controls.Add(this.Btn_crear_plan);
            this.Controls.Add(this.Dtp_Hasta_plan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Dtp_Desde_plan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Cmb_Estado_plan);
            this.Controls.Add(this.Lbl_Estado);
            this.Controls.Add(this.Cmb_Id_plan);
            this.Controls.Add(this.Lbl_id);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.Lbl_listado_plan);
            this.Name = "Frm_Encabezado_Plan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encabezado_Plan";
            ((System.ComponentModel.ISupportInitialize)(this.Dg_BOM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_listado_plan;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label Lbl_id;
        private System.Windows.Forms.ComboBox Cmb_Id_plan;
        private System.Windows.Forms.Label Lbl_Estado;
        private System.Windows.Forms.ComboBox Cmb_Estado_plan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker Dtp_Desde_plan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker Dtp_Hasta_plan;
        private System.Windows.Forms.Button Btn_crear_plan;
        private System.Windows.Forms.DataGridView Dg_BOM;
        private System.Windows.Forms.Button Btn_Limpiar;
    }
}