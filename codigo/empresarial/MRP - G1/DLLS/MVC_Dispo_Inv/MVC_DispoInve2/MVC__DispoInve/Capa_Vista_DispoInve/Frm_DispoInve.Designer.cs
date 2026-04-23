
namespace Capa_Vista_DispoInve
{
    partial class Frm_DispoInve
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cmbAlmacen = new System.Windows.Forms.ComboBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(495, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Disponibilidad De Inventario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(288, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(669, 148);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(51, 18);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "label5";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(660, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dgvInventario
            // 
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Location = new System.Drawing.Point(70, 202);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.RowHeadersWidth = 51;
            this.dgvInventario.RowTemplate.Height = 24;
            this.dgvInventario.Size = new System.Drawing.Size(655, 150);
            this.dgvInventario.TabIndex = 6;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(120, 102);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(534, 22);
            this.txtBusqueda.TabIndex = 7;
            // 
            // cmbAlmacen
            // 
            this.cmbAlmacen.FormattingEnabled = true;
            this.cmbAlmacen.Location = new System.Drawing.Point(357, 148);
            this.cmbAlmacen.Name = "cmbAlmacen";
            this.cmbAlmacen.Size = new System.Drawing.Size(121, 24);
            this.cmbAlmacen.TabIndex = 10;
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(124, 144);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 24);
            this.cmbTipo.TabIndex = 11;
            // 
            // Frm_DispoInve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.cmbAlmacen);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frm_DispoInve";
            this.Text = "Frm_DispoInve";
            this.Load += new System.EventHandler(this.Frm_DispoInve_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.ComboBox cmbAlmacen;
        private System.Windows.Forms.ComboBox cmbTipo;
    }
}