namespace Uptook
{
    partial class ImportarBDD
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
            this.tb_ruta = new System.Windows.Forms.TextBox();
            this.bt_buscar = new System.Windows.Forms.Button();
            this.bt_importar = new System.Windows.Forms.Button();
            this.bt_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_ruta
            // 
            this.tb_ruta.Location = new System.Drawing.Point(35, 45);
            this.tb_ruta.Name = "tb_ruta";
            this.tb_ruta.Size = new System.Drawing.Size(416, 20);
            this.tb_ruta.TabIndex = 0;
            // 
            // bt_buscar
            // 
            this.bt_buscar.Location = new System.Drawing.Point(472, 40);
            this.bt_buscar.Name = "bt_buscar";
            this.bt_buscar.Size = new System.Drawing.Size(75, 29);
            this.bt_buscar.TabIndex = 1;
            this.bt_buscar.Text = "Buscar";
            this.bt_buscar.UseVisualStyleBackColor = true;
            this.bt_buscar.Click += new System.EventHandler(this.bt_buscar_Click);
            // 
            // bt_importar
            // 
            this.bt_importar.Location = new System.Drawing.Point(175, 95);
            this.bt_importar.Name = "bt_importar";
            this.bt_importar.Size = new System.Drawing.Size(75, 29);
            this.bt_importar.TabIndex = 2;
            this.bt_importar.Text = "Importar";
            this.bt_importar.UseVisualStyleBackColor = true;
            this.bt_importar.Click += new System.EventHandler(this.bt_importar_Click);
            // 
            // bt_cancelar
            // 
            this.bt_cancelar.Location = new System.Drawing.Point(323, 95);
            this.bt_cancelar.Name = "bt_cancelar";
            this.bt_cancelar.Size = new System.Drawing.Size(75, 29);
            this.bt_cancelar.TabIndex = 3;
            this.bt_cancelar.Text = "Cancelar";
            this.bt_cancelar.UseVisualStyleBackColor = true;
            // 
            // ImportarBDD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 136);
            this.Controls.Add(this.bt_cancelar);
            this.Controls.Add(this.bt_importar);
            this.Controls.Add(this.bt_buscar);
            this.Controls.Add(this.tb_ruta);
            this.MaximizeBox = false;
            this.Name = "ImportarBDD";
            this.Text = "ImportarBDD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_ruta;
        private System.Windows.Forms.Button bt_buscar;
        private System.Windows.Forms.Button bt_importar;
        private System.Windows.Forms.Button bt_cancelar;
    }
}