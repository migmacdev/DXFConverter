namespace Convierte_a_DXF
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.b_convertir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.r_yxz = new System.Windows.Forms.RadioButton();
            this.r_xyz = new System.Windows.Forms.RadioButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_convertir
            // 
            this.b_convertir.Location = new System.Drawing.Point(22, 163);
            this.b_convertir.Name = "b_convertir";
            this.b_convertir.Size = new System.Drawing.Size(140, 23);
            this.b_convertir.TabIndex = 1;
            this.b_convertir.Text = "Seleccionar y Convertir";
            this.b_convertir.UseVisualStyleBackColor = true;
            this.b_convertir.Click += new System.EventHandler(this.b_convertir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.r_yxz);
            this.groupBox1.Controls.Add(this.r_xyz);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(22, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 92);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Orden";
            // 
            // r_yxz
            // 
            this.r_yxz.AutoSize = true;
            this.r_yxz.Location = new System.Drawing.Point(7, 44);
            this.r_yxz.Name = "r_yxz";
            this.r_yxz.Size = new System.Drawing.Size(58, 17);
            this.r_yxz.TabIndex = 1;
            this.r_yxz.Text = "Y, X, Z";
            this.r_yxz.UseVisualStyleBackColor = true;
            // 
            // r_xyz
            // 
            this.r_xyz.AutoSize = true;
            this.r_xyz.Checked = true;
            this.r_xyz.Location = new System.Drawing.Point(7, 20);
            this.r_xyz.Name = "r_xyz";
            this.r_xyz.Size = new System.Drawing.Size(58, 17);
            this.r_xyz.TabIndex = 0;
            this.r_xyz.TabStop = true;
            this.r_xyz.Text = "X, Y, Z";
            this.r_xyz.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(189, 213);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.b_convertir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convertir a DXF";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_convertir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton r_yxz;
        private System.Windows.Forms.RadioButton r_xyz;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

