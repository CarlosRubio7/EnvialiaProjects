namespace Uptook
{
    partial class MenuPedidos
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
            this.bt_borrar = new System.Windows.Forms.Button();
            this.bt_cancelar = new System.Windows.Forms.Button();
            this.bt_buscar2 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_conectar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_buscar1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bt_guardar_cambios = new System.Windows.Forms.Button();
            this.bt_modificar = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.bt_traspasar_destino = new System.Windows.Forms.Button();
            this.tb_ruta = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bt_generar = new System.Windows.Forms.Button();
            this.bt_traspasar_origen = new System.Windows.Forms.Button();
            this.bt_clear = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bt_exportar = new System.Windows.Forms.Button();
            this.bt_importar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_borrar
            // 
            this.bt_borrar.Location = new System.Drawing.Point(6, 74);
            this.bt_borrar.Name = "bt_borrar";
            this.bt_borrar.Size = new System.Drawing.Size(170, 23);
            this.bt_borrar.TabIndex = 7;
            this.bt_borrar.Text = "Borrar";
            this.bt_borrar.UseVisualStyleBackColor = true;
            this.bt_borrar.Click += new System.EventHandler(this.bt_borrar_Click);
            // 
            // bt_cancelar
            // 
            this.bt_cancelar.Location = new System.Drawing.Point(9, 62);
            this.bt_cancelar.Name = "bt_cancelar";
            this.bt_cancelar.Size = new System.Drawing.Size(170, 23);
            this.bt_cancelar.TabIndex = 2;
            this.bt_cancelar.Text = "Cancelar";
            this.bt_cancelar.UseVisualStyleBackColor = true;
            this.bt_cancelar.Click += new System.EventHandler(this.button1_Click);
            // 
            // bt_buscar2
            // 
            this.bt_buscar2.Location = new System.Drawing.Point(255, 40);
            this.bt_buscar2.Name = "bt_buscar2";
            this.bt_buscar2.Size = new System.Drawing.Size(75, 20);
            this.bt_buscar2.TabIndex = 10;
            this.bt_buscar2.Text = "Buscar";
            this.bt_buscar2.UseVisualStyleBackColor = true;
            this.bt_buscar2.Click += new System.EventHandler(this.bt_buscar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1356, 240);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(306, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Vamos a buscar por?:";
            // 
            // bt_conectar
            // 
            this.bt_conectar.Location = new System.Drawing.Point(7, 21);
            this.bt_conectar.Name = "bt_conectar";
            this.bt_conectar.Size = new System.Drawing.Size(170, 23);
            this.bt_conectar.TabIndex = 1;
            this.bt_conectar.Text = "Conectar";
            this.bt_conectar.UseVisualStyleBackColor = true;
            this.bt_conectar.Click += new System.EventHandler(this.bt_conectar_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.bt_buscar1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 104);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipos de búsqueda";
            // 
            // bt_buscar1
            // 
            this.bt_buscar1.Location = new System.Drawing.Point(333, 64);
            this.bt_buscar1.Name = "bt_buscar1";
            this.bt_buscar1.Size = new System.Drawing.Size(80, 20);
            this.bt_buscar1.TabIndex = 5;
            this.bt_buscar1.Text = "Buscar";
            this.bt_buscar1.UseVisualStyleBackColor = true;
            this.bt_buscar1.Click += new System.EventHandler(this.bt_buscar1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(153, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(174, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.bt_cancelar);
            this.groupBox2.Controls.Add(this.bt_conectar);
            this.groupBox2.Location = new System.Drawing.Point(786, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 104);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conexión";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.bt_guardar_cambios);
            this.groupBox3.Controls.Add(this.bt_modificar);
            this.groupBox3.Controls.Add(this.bt_borrar);
            this.groupBox3.Location = new System.Drawing.Point(977, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(185, 104);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Edición";
            // 
            // bt_guardar_cambios
            // 
            this.bt_guardar_cambios.Location = new System.Drawing.Point(6, 16);
            this.bt_guardar_cambios.Name = "bt_guardar_cambios";
            this.bt_guardar_cambios.Size = new System.Drawing.Size(170, 23);
            this.bt_guardar_cambios.TabIndex = 8;
            this.bt_guardar_cambios.Text = "Guardar cambios";
            this.bt_guardar_cambios.UseVisualStyleBackColor = true;
            this.bt_guardar_cambios.Click += new System.EventHandler(this.bt_guardar_cambios_Click);
            // 
            // bt_modificar
            // 
            this.bt_modificar.Location = new System.Drawing.Point(6, 45);
            this.bt_modificar.Name = "bt_modificar";
            this.bt_modificar.Size = new System.Drawing.Size(170, 23);
            this.bt_modificar.TabIndex = 6;
            this.bt_modificar.Text = "Modificar";
            this.bt_modificar.UseVisualStyleBackColor = true;
            this.bt_modificar.Click += new System.EventHandler(this.bt_modificar_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 445);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1356, 240);
            this.dataGridView2.TabIndex = 24;
            // 
            // bt_traspasar_destino
            // 
            this.bt_traspasar_destino.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_traspasar_destino.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bt_traspasar_destino.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_traspasar_destino.Location = new System.Drawing.Point(691, 364);
            this.bt_traspasar_destino.Name = "bt_traspasar_destino";
            this.bt_traspasar_destino.Size = new System.Drawing.Size(450, 75);
            this.bt_traspasar_destino.TabIndex = 8;
            this.bt_traspasar_destino.Text = ">";
            this.bt_traspasar_destino.UseVisualStyleBackColor = true;
            this.bt_traspasar_destino.Click += new System.EventHandler(this.bt_traspasar_Click);
            // 
            // tb_ruta
            // 
            this.tb_ruta.Location = new System.Drawing.Point(16, 41);
            this.tb_ruta.Name = "tb_ruta";
            this.tb_ruta.Size = new System.Drawing.Size(221, 20);
            this.tb_ruta.TabIndex = 25;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox4.Controls.Add(this.bt_buscar2);
            this.groupBox4.Controls.Add(this.tb_ruta);
            this.groupBox4.Location = new System.Drawing.Point(434, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(346, 104);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Buscar directorio origen";
            // 
            // bt_generar
            // 
            this.bt_generar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_generar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bt_generar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_generar.Location = new System.Drawing.Point(233, 685);
            this.bt_generar.Name = "bt_generar";
            this.bt_generar.Size = new System.Drawing.Size(452, 75);
            this.bt_generar.TabIndex = 26;
            this.bt_generar.Text = "Generar Fichero";
            this.bt_generar.UseVisualStyleBackColor = true;
            this.bt_generar.Click += new System.EventHandler(this.bt_generar_Click);
            // 
            // bt_traspasar_origen
            // 
            this.bt_traspasar_origen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_traspasar_origen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bt_traspasar_origen.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_traspasar_origen.Location = new System.Drawing.Point(233, 364);
            this.bt_traspasar_origen.Name = "bt_traspasar_origen";
            this.bt_traspasar_origen.Size = new System.Drawing.Size(452, 75);
            this.bt_traspasar_origen.TabIndex = 27;
            this.bt_traspasar_origen.Text = "<";
            this.bt_traspasar_origen.UseVisualStyleBackColor = true;
            this.bt_traspasar_origen.Click += new System.EventHandler(this.bt_traspasar_origen_Click);
            // 
            // bt_clear
            // 
            this.bt_clear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_clear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bt_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_clear.Location = new System.Drawing.Point(691, 685);
            this.bt_clear.Name = "bt_clear";
            this.bt_clear.Size = new System.Drawing.Size(450, 75);
            this.bt_clear.TabIndex = 28;
            this.bt_clear.Text = "Limpiar";
            this.bt_clear.UseVisualStyleBackColor = true;
            this.bt_clear.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox5.Controls.Add(this.bt_exportar);
            this.groupBox5.Controls.Add(this.bt_importar);
            this.groupBox5.Location = new System.Drawing.Point(1167, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(185, 104);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Importar/Exportar";
            // 
            // bt_exportar
            // 
            this.bt_exportar.Location = new System.Drawing.Point(6, 63);
            this.bt_exportar.Name = "bt_exportar";
            this.bt_exportar.Size = new System.Drawing.Size(170, 23);
            this.bt_exportar.TabIndex = 10;
            this.bt_exportar.Text = "Exportar";
            this.bt_exportar.UseVisualStyleBackColor = true;
            this.bt_exportar.Click += new System.EventHandler(this.bt_exportar_Click);
            // 
            // bt_importar
            // 
            this.bt_importar.Location = new System.Drawing.Point(6, 23);
            this.bt_importar.Name = "bt_importar";
            this.bt_importar.Size = new System.Drawing.Size(170, 23);
            this.bt_importar.TabIndex = 9;
            this.bt_importar.Text = "Importar";
            this.bt_importar.UseVisualStyleBackColor = true;
            this.bt_importar.Click += new System.EventHandler(this.bt_importar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MenuPedidos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1364, 762);
            this.Controls.Add(this.bt_generar);
            this.Controls.Add(this.bt_clear);
            this.Controls.Add(this.bt_traspasar_origen);
            this.Controls.Add(this.bt_traspasar_destino);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "MenuPedidos";
            this.Text = "Servidor Ftp";
            this.Load += new System.EventHandler(this.MenuPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_borrar;
        private System.Windows.Forms.Button bt_cancelar;
        private System.Windows.Forms.Button bt_buscar2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_conectar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_buscar1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bt_modificar;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button bt_traspasar_destino;
        private System.Windows.Forms.TextBox tb_ruta;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bt_generar;
        private System.Windows.Forms.Button bt_traspasar_origen;
        private System.Windows.Forms.Button bt_clear;
        private System.Windows.Forms.Button bt_guardar_cambios;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button bt_exportar;
        private System.Windows.Forms.Button bt_importar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

