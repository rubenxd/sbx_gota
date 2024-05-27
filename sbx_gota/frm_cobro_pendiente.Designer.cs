namespace sbx_gota
{
    partial class frm_cobro_pendiente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_cobro_pendiente));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_acciones = new System.Windows.Forms.Panel();
            this.cbx_con_mora = new System.Windows.Forms.ComboBox();
            this.cbx_tipo_filtro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Ffin = new System.Windows.Forms.Label();
            this.dtp_fecha_fin = new System.Windows.Forms.DateTimePicker();
            this.dtp_fecha_ini = new System.Windows.Forms.DateTimePicker();
            this.cbx_dia_semana = new System.Windows.Forms.ComboBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.dtg_cobro_pendiente = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.pnl_acciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_cobro_pendiente)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(844, 26);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pagos pendientes";
            // 
            // pnl_acciones
            // 
            this.pnl_acciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_acciones.Controls.Add(this.cbx_con_mora);
            this.pnl_acciones.Controls.Add(this.cbx_tipo_filtro);
            this.pnl_acciones.Controls.Add(this.label2);
            this.pnl_acciones.Controls.Add(this.Ffin);
            this.pnl_acciones.Controls.Add(this.dtp_fecha_fin);
            this.pnl_acciones.Controls.Add(this.dtp_fecha_ini);
            this.pnl_acciones.Controls.Add(this.cbx_dia_semana);
            this.pnl_acciones.Controls.Add(this.btn_buscar);
            this.pnl_acciones.Controls.Add(this.txt_buscar);
            this.pnl_acciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_acciones.Location = new System.Drawing.Point(0, 26);
            this.pnl_acciones.Name = "pnl_acciones";
            this.pnl_acciones.Size = new System.Drawing.Size(844, 39);
            this.pnl_acciones.TabIndex = 11;
            // 
            // cbx_con_mora
            // 
            this.cbx_con_mora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_con_mora.AutoCompleteCustomSource.AddRange(new string[] {
            "Cedula",
            "Cedula Extranjera",
            "Tarjeta de identidad"});
            this.cbx_con_mora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_con_mora.FormattingEnabled = true;
            this.cbx_con_mora.Items.AddRange(new object[] {
            "En mora",
            "Sin mora",
            "Todos"});
            this.cbx_con_mora.Location = new System.Drawing.Point(189, 8);
            this.cbx_con_mora.Name = "cbx_con_mora";
            this.cbx_con_mora.Size = new System.Drawing.Size(108, 21);
            this.cbx_con_mora.TabIndex = 15;
            // 
            // cbx_tipo_filtro
            // 
            this.cbx_tipo_filtro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_tipo_filtro.AutoCompleteCustomSource.AddRange(new string[] {
            "Cedula",
            "Cedula Extranjera",
            "Tarjeta de identidad"});
            this.cbx_tipo_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_tipo_filtro.FormattingEnabled = true;
            this.cbx_tipo_filtro.Items.AddRange(new object[] {
            "Todos",
            "Por fecha"});
            this.cbx_tipo_filtro.Location = new System.Drawing.Point(303, 8);
            this.cbx_tipo_filtro.Name = "cbx_tipo_filtro";
            this.cbx_tipo_filtro.Size = new System.Drawing.Size(108, 21);
            this.cbx_tipo_filtro.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "F.Ini";
            this.label2.Visible = false;
            // 
            // Ffin
            // 
            this.Ffin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Ffin.AutoSize = true;
            this.Ffin.Location = new System.Drawing.Point(417, 12);
            this.Ffin.Name = "Ffin";
            this.Ffin.Size = new System.Drawing.Size(30, 13);
            this.Ffin.TabIndex = 12;
            this.Ffin.Text = "F.Fin";
            // 
            // dtp_fecha_fin
            // 
            this.dtp_fecha_fin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha_fin.Location = new System.Drawing.Point(451, 9);
            this.dtp_fecha_fin.Name = "dtp_fecha_fin";
            this.dtp_fecha_fin.Size = new System.Drawing.Size(129, 20);
            this.dtp_fecha_fin.TabIndex = 11;
            // 
            // dtp_fecha_ini
            // 
            this.dtp_fecha_ini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_fecha_ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha_ini.Location = new System.Drawing.Point(77, 8);
            this.dtp_fecha_ini.Name = "dtp_fecha_ini";
            this.dtp_fecha_ini.Size = new System.Drawing.Size(23, 20);
            this.dtp_fecha_ini.TabIndex = 10;
            this.dtp_fecha_ini.Visible = false;
            // 
            // cbx_dia_semana
            // 
            this.cbx_dia_semana.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_dia_semana.AutoCompleteCustomSource.AddRange(new string[] {
            "Cedula",
            "Cedula Extranjera",
            "Tarjeta de identidad"});
            this.cbx_dia_semana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_dia_semana.FormattingEnabled = true;
            this.cbx_dia_semana.Items.AddRange(new object[] {
            "Todos",
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes",
            "Sabado",
            "Domingo"});
            this.cbx_dia_semana.Location = new System.Drawing.Point(11, 8);
            this.cbx_dia_semana.Name = "cbx_dia_semana";
            this.cbx_dia_semana.Size = new System.Drawing.Size(27, 21);
            this.cbx_dia_semana.TabIndex = 9;
            this.cbx_dia_semana.Visible = false;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_buscar.BackColor = System.Drawing.SystemColors.Control;
            this.btn_buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_buscar.FlatAppearance.BorderSize = 0;
            this.btn_buscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_buscar.Image")));
            this.btn_buscar.Location = new System.Drawing.Point(809, 7);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(22, 22);
            this.btn_buscar.TabIndex = 8;
            this.btn_buscar.UseVisualStyleBackColor = false;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // txt_buscar
            // 
            this.txt_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_buscar.ForeColor = System.Drawing.Color.Gray;
            this.txt_buscar.Location = new System.Drawing.Point(606, 9);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(197, 20);
            this.txt_buscar.TabIndex = 7;
            this.txt_buscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_buscar_KeyUp);
            // 
            // dtg_cobro_pendiente
            // 
            this.dtg_cobro_pendiente.AllowUserToAddRows = false;
            this.dtg_cobro_pendiente.AllowUserToDeleteRows = false;
            this.dtg_cobro_pendiente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_cobro_pendiente.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_cobro_pendiente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_cobro_pendiente.Location = new System.Drawing.Point(0, 65);
            this.dtg_cobro_pendiente.Name = "dtg_cobro_pendiente";
            this.dtg_cobro_pendiente.ReadOnly = true;
            this.dtg_cobro_pendiente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_cobro_pendiente.Size = new System.Drawing.Size(844, 385);
            this.dtg_cobro_pendiente.TabIndex = 12;
            this.dtg_cobro_pendiente.DoubleClick += new System.EventHandler(this.dtg_cobro_pendiente_DoubleClick);
            // 
            // frm_cobro_pendiente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 450);
            this.Controls.Add(this.dtg_cobro_pendiente);
            this.Controls.Add(this.pnl_acciones);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_cobro_pendiente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_cobro_pendiente";
            this.Load += new System.EventHandler(this.frm_cobro_pendiente_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_acciones.ResumeLayout(false);
            this.pnl_acciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_cobro_pendiente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_acciones;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.DataGridView dtg_cobro_pendiente;
        private System.Windows.Forms.ComboBox cbx_dia_semana;
        private System.Windows.Forms.DateTimePicker dtp_fecha_fin;
        private System.Windows.Forms.Label Ffin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_fecha_ini;
        private System.Windows.Forms.ComboBox cbx_tipo_filtro;
        private System.Windows.Forms.ComboBox cbx_con_mora;
    }
}