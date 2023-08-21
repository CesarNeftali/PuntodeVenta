namespace Proyecto
{
    partial class Inactivos
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
            this.txtID2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreArticulo2 = new System.Windows.Forms.TextBox();
            this.txtIDProveedor2 = new System.Windows.Forms.TextBox();
            this.txtDescripcion2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvInactivos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCantidad2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInactivos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtID2
            // 
            this.txtID2.Enabled = false;
            this.txtID2.Location = new System.Drawing.Point(85, 9);
            this.txtID2.Name = "txtID2";
            this.txtID2.ReadOnly = true;
            this.txtID2.Size = new System.Drawing.Size(100, 20);
            this.txtID2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre de Articulo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID Proveedor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID Articulo";
            // 
            // txtNombreArticulo2
            // 
            this.txtNombreArticulo2.Location = new System.Drawing.Point(133, 72);
            this.txtNombreArticulo2.Name = "txtNombreArticulo2";
            this.txtNombreArticulo2.Size = new System.Drawing.Size(100, 20);
            this.txtNombreArticulo2.TabIndex = 6;
            this.txtNombreArticulo2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreArticulo2_KeyPress);
            // 
            // txtIDProveedor2
            // 
            this.txtIDProveedor2.Enabled = false;
            this.txtIDProveedor2.Location = new System.Drawing.Point(100, 40);
            this.txtIDProveedor2.Name = "txtIDProveedor2";
            this.txtIDProveedor2.ReadOnly = true;
            this.txtIDProveedor2.Size = new System.Drawing.Size(100, 20);
            this.txtIDProveedor2.TabIndex = 7;
            // 
            // txtDescripcion2
            // 
            this.txtDescripcion2.Enabled = false;
            this.txtDescripcion2.Location = new System.Drawing.Point(276, 9);
            this.txtDescripcion2.Multiline = true;
            this.txtDescripcion2.Name = "txtDescripcion2";
            this.txtDescripcion2.ReadOnly = true;
            this.txtDescripcion2.Size = new System.Drawing.Size(302, 54);
            this.txtDescripcion2.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(196, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Descripcion";
            // 
            // dgvInactivos
            // 
            this.dgvInactivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInactivos.Location = new System.Drawing.Point(-3, 98);
            this.dgvInactivos.Name = "dgvInactivos";
            this.dgvInactivos.Size = new System.Drawing.Size(617, 150);
            this.dgvInactivos.TabIndex = 10;
            this.dgvInactivos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInactivos_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(523, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Activar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCantidad2
            // 
            this.txtCantidad2.Location = new System.Drawing.Point(306, 72);
            this.txtCantidad2.Name = "txtCantidad2";
            this.txtCantidad2.Size = new System.Drawing.Size(42, 20);
            this.txtCantidad2.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(243, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Cantidad";
            // 
            // Inactivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(610, 291);
            this.Controls.Add(this.txtCantidad2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvInactivos);
            this.Controls.Add(this.txtDescripcion2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIDProveedor2);
            this.Controls.Add(this.txtNombreArticulo2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtID2);
            this.Name = "Inactivos";
            this.Text = "Inactivos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Inactivos_FormClosed);
            this.Load += new System.EventHandler(this.Inactivos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInactivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreArticulo2;
        private System.Windows.Forms.TextBox txtIDProveedor2;
        private System.Windows.Forms.TextBox txtDescripcion2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvInactivos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCantidad2;
        private System.Windows.Forms.Label label6;
    }
}