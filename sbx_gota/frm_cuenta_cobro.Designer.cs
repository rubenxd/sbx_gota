namespace sbx_gota
{
    partial class frm_cuenta_cobro
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_cuenta_cobro));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtt_fecha_primer_pago = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_valor_cuota = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_valor_total = new System.Windows.Forms.TextBox();
            this.lbl_id_cuenta_cobro = new System.Windows.Forms.Label();
            this.lbl_id_cliente = new System.Windows.Forms.Label();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_nota = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_dia_fecha_pago = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbx_dia_pago = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbx_modo_pago = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_num_cuotas = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_porcentaje_interes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_vlr_interes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_vlr_prestamo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.txt_cliente = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_consultar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.dtg_cuenta_cobro = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_cuenta_cobro)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(800, 26);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuenta cobro";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dtt_fecha_primer_pago);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txt_valor_cuota);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txt_valor_total);
            this.panel2.Controls.Add(this.lbl_id_cuenta_cobro);
            this.panel2.Controls.Add(this.lbl_id_cliente);
            this.panel2.Controls.Add(this.btn_guardar);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txt_nota);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txt_dia_fecha_pago);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cbx_dia_pago);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cbx_modo_pago);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txt_num_cuotas);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txt_porcentaje_interes);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txt_vlr_interes);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txt_vlr_prestamo);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btn_buscar);
            this.panel2.Controls.Add(this.txt_cliente);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 226);
            this.panel2.TabIndex = 2;
            // 
            // dtt_fecha_primer_pago
            // 
            this.dtt_fecha_primer_pago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtt_fecha_primer_pago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtt_fecha_primer_pago.Location = new System.Drawing.Point(549, 120);
            this.dtt_fecha_primer_pago.Name = "dtt_fecha_primer_pago";
            this.dtt_fecha_primer_pago.Size = new System.Drawing.Size(219, 20);
            this.dtt_fecha_primer_pago.TabIndex = 87;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(432, 122);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 15);
            this.label13.TabIndex = 86;
            this.label13.Text = "Fecha primer pago";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(486, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 15);
            this.label12.TabIndex = 85;
            this.label12.Text = "Vlr  cuota";
            // 
            // txt_valor_cuota
            // 
            this.txt_valor_cuota.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_valor_cuota.Enabled = false;
            this.txt_valor_cuota.Location = new System.Drawing.Point(549, 14);
            this.txt_valor_cuota.MaxLength = 200;
            this.txt_valor_cuota.Name = "txt_valor_cuota";
            this.txt_valor_cuota.Size = new System.Drawing.Size(219, 20);
            this.txt_valor_cuota.TabIndex = 84;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(114, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 15);
            this.label11.TabIndex = 83;
            this.label11.Text = "Vlr  total";
            // 
            // txt_valor_total
            // 
            this.txt_valor_total.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_valor_total.Enabled = false;
            this.txt_valor_total.Location = new System.Drawing.Point(170, 118);
            this.txt_valor_total.MaxLength = 200;
            this.txt_valor_total.Name = "txt_valor_total";
            this.txt_valor_total.Size = new System.Drawing.Size(219, 20);
            this.txt_valor_total.TabIndex = 82;
            // 
            // lbl_id_cuenta_cobro
            // 
            this.lbl_id_cuenta_cobro.AutoSize = true;
            this.lbl_id_cuenta_cobro.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_id_cuenta_cobro.Location = new System.Drawing.Point(11, 43);
            this.lbl_id_cuenta_cobro.Name = "lbl_id_cuenta_cobro";
            this.lbl_id_cuenta_cobro.Size = new System.Drawing.Size(14, 15);
            this.lbl_id_cuenta_cobro.TabIndex = 81;
            this.lbl_id_cuenta_cobro.Text = "0";
            // 
            // lbl_id_cliente
            // 
            this.lbl_id_cliente.AutoSize = true;
            this.lbl_id_cliente.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_id_cliente.Location = new System.Drawing.Point(11, 14);
            this.lbl_id_cliente.Name = "lbl_id_cliente";
            this.lbl_id_cliente.Size = new System.Drawing.Size(14, 15);
            this.lbl_id_cliente.TabIndex = 80;
            this.lbl_id_cliente.Text = "0";
            // 
            // btn_guardar
            // 
            this.btn_guardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_guardar.FlatAppearance.BorderSize = 0;
            this.btn_guardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_guardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_guardar.ForeColor = System.Drawing.Color.White;
            this.btn_guardar.Location = new System.Drawing.Point(170, 180);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(126, 31);
            this.btn_guardar.TabIndex = 79;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = false;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(510, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 15);
            this.label10.TabIndex = 78;
            this.label10.Text = "Nota";
            // 
            // txt_nota
            // 
            this.txt_nota.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_nota.Location = new System.Drawing.Point(549, 146);
            this.txt_nota.MaxLength = 200;
            this.txt_nota.Name = "txt_nota";
            this.txt_nota.Size = new System.Drawing.Size(219, 20);
            this.txt_nota.TabIndex = 77;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(446, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 15);
            this.label9.TabIndex = 76;
            this.label9.Text = "Dias fecha pago";
            // 
            // txt_dia_fecha_pago
            // 
            this.txt_dia_fecha_pago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_dia_fecha_pago.Location = new System.Drawing.Point(549, 94);
            this.txt_dia_fecha_pago.MaxLength = 200;
            this.txt_dia_fecha_pago.Name = "txt_dia_fecha_pago";
            this.txt_dia_fecha_pago.Size = new System.Drawing.Size(219, 20);
            this.txt_dia_fecha_pago.TabIndex = 75;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(486, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 74;
            this.label8.Text = "Dia pago";
            // 
            // cbx_dia_pago
            // 
            this.cbx_dia_pago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbx_dia_pago.AutoCompleteCustomSource.AddRange(new string[] {
            "Cedula",
            "Cedula Extranjera",
            "Tarjeta de identidad"});
            this.cbx_dia_pago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_dia_pago.FormattingEnabled = true;
            this.cbx_dia_pago.Items.AddRange(new object[] {
            "NA",
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes",
            "Sabado",
            "Domingo"});
            this.cbx_dia_pago.Location = new System.Drawing.Point(549, 67);
            this.cbx_dia_pago.Name = "cbx_dia_pago";
            this.cbx_dia_pago.Size = new System.Drawing.Size(219, 21);
            this.cbx_dia_pago.TabIndex = 73;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(475, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 15);
            this.label7.TabIndex = 72;
            this.label7.Text = "Modo pago";
            // 
            // cbx_modo_pago
            // 
            this.cbx_modo_pago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbx_modo_pago.AutoCompleteCustomSource.AddRange(new string[] {
            "Cedula",
            "Cedula Extranjera",
            "Tarjeta de identidad"});
            this.cbx_modo_pago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_modo_pago.FormattingEnabled = true;
            this.cbx_modo_pago.Items.AddRange(new object[] {
            "Diario",
            "Semanal",
            "Quincenal",
            "Mensual",
            "Semestral",
            "Anual"});
            this.cbx_modo_pago.Location = new System.Drawing.Point(549, 40);
            this.cbx_modo_pago.Name = "cbx_modo_pago";
            this.cbx_modo_pago.Size = new System.Drawing.Size(219, 21);
            this.cbx_modo_pago.TabIndex = 71;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(85, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 70;
            this.label6.Text = "Num cuotas*";
            // 
            // txt_num_cuotas
            // 
            this.txt_num_cuotas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_num_cuotas.Location = new System.Drawing.Point(170, 144);
            this.txt_num_cuotas.MaxLength = 200;
            this.txt_num_cuotas.Name = "txt_num_cuotas";
            this.txt_num_cuotas.Size = new System.Drawing.Size(219, 20);
            this.txt_num_cuotas.TabIndex = 69;
            this.txt_num_cuotas.TextChanged += new System.EventHandler(this.txt_num_cuotas_TextChanged);
            this.txt_num_cuotas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_num_cuotas_KeyUp);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(97, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 68;
            this.label5.Text = "%  interes*";
            // 
            // txt_porcentaje_interes
            // 
            this.txt_porcentaje_interes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_porcentaje_interes.Location = new System.Drawing.Point(170, 92);
            this.txt_porcentaje_interes.MaxLength = 200;
            this.txt_porcentaje_interes.Name = "txt_porcentaje_interes";
            this.txt_porcentaje_interes.Size = new System.Drawing.Size(219, 20);
            this.txt_porcentaje_interes.TabIndex = 67;
            this.txt_porcentaje_interes.TextChanged += new System.EventHandler(this.txt_porcentaje_interes_TextChanged);
            this.txt_porcentaje_interes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_porcentaje_interes_KeyUp);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(94, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 66;
            this.label4.Text = "Vlr  interes*";
            // 
            // txt_vlr_interes
            // 
            this.txt_vlr_interes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_vlr_interes.Location = new System.Drawing.Point(170, 66);
            this.txt_vlr_interes.MaxLength = 200;
            this.txt_vlr_interes.Name = "txt_vlr_interes";
            this.txt_vlr_interes.Size = new System.Drawing.Size(219, 20);
            this.txt_vlr_interes.TabIndex = 65;
            this.txt_vlr_interes.TextChanged += new System.EventHandler(this.txt_vlr_interes_TextChanged);
            this.txt_vlr_interes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_vlr_interes_KeyUp);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(79, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 64;
            this.label3.Text = "Vlr prestamo *";
            // 
            // txt_vlr_prestamo
            // 
            this.txt_vlr_prestamo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_vlr_prestamo.Location = new System.Drawing.Point(170, 40);
            this.txt_vlr_prestamo.MaxLength = 200;
            this.txt_vlr_prestamo.Name = "txt_vlr_prestamo";
            this.txt_vlr_prestamo.Size = new System.Drawing.Size(219, 20);
            this.txt_vlr_prestamo.TabIndex = 63;
            this.txt_vlr_prestamo.TextChanged += new System.EventHandler(this.txt_vlr_prestamo_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(110, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 62;
            this.label2.Text = "Cliente *";
            // 
            // btn_buscar
            // 
            this.btn_buscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_buscar.BackColor = System.Drawing.SystemColors.Control;
            this.btn_buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_buscar.FlatAppearance.BorderSize = 0;
            this.btn_buscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_buscar.Image")));
            this.btn_buscar.Location = new System.Drawing.Point(407, 11);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(22, 22);
            this.btn_buscar.TabIndex = 61;
            this.btn_buscar.UseVisualStyleBackColor = false;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // txt_cliente
            // 
            this.txt_cliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_cliente.Enabled = false;
            this.txt_cliente.Location = new System.Drawing.Point(170, 14);
            this.txt_cliente.MaxLength = 200;
            this.txt_cliente.Name = "txt_cliente";
            this.txt_cliente.Size = new System.Drawing.Size(219, 20);
            this.txt_cliente.TabIndex = 60;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btn_editar);
            this.panel4.Controls.Add(this.btn_consultar);
            this.panel4.Controls.Add(this.btn_eliminar);
            this.panel4.Controls.Add(this.txt_buscar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 252);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 39);
            this.panel4.TabIndex = 70;
            // 
            // btn_editar
            // 
            this.btn_editar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_editar.BackColor = System.Drawing.SystemColors.Control;
            this.btn_editar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_editar.FlatAppearance.BorderSize = 0;
            this.btn_editar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editar.Image = ((System.Drawing.Image)(resources.GetObject("btn_editar.Image")));
            this.btn_editar.Location = new System.Drawing.Point(8, 9);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(20, 20);
            this.btn_editar.TabIndex = 2;
            this.btn_editar.UseVisualStyleBackColor = false;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_consultar
            // 
            this.btn_consultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_consultar.BackColor = System.Drawing.SystemColors.Control;
            this.btn_consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_consultar.FlatAppearance.BorderSize = 0;
            this.btn_consultar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_consultar.Image = ((System.Drawing.Image)(resources.GetObject("btn_consultar.Image")));
            this.btn_consultar.Location = new System.Drawing.Point(764, 7);
            this.btn_consultar.Name = "btn_consultar";
            this.btn_consultar.Size = new System.Drawing.Size(22, 22);
            this.btn_consultar.TabIndex = 6;
            this.btn_consultar.UseVisualStyleBackColor = false;
            this.btn_consultar.Click += new System.EventHandler(this.btn_consultar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_eliminar.BackColor = System.Drawing.SystemColors.Control;
            this.btn_eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_eliminar.FlatAppearance.BorderSize = 0;
            this.btn_eliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Image")));
            this.btn_eliminar.Location = new System.Drawing.Point(38, 9);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(20, 20);
            this.btn_eliminar.TabIndex = 3;
            this.btn_eliminar.UseVisualStyleBackColor = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // txt_buscar
            // 
            this.txt_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_buscar.ForeColor = System.Drawing.Color.Gray;
            this.txt_buscar.Location = new System.Drawing.Point(561, 9);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(197, 20);
            this.txt_buscar.TabIndex = 5;
            this.txt_buscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_buscar_KeyUp);
            // 
            // dtg_cuenta_cobro
            // 
            this.dtg_cuenta_cobro.AllowUserToAddRows = false;
            this.dtg_cuenta_cobro.AllowUserToDeleteRows = false;
            this.dtg_cuenta_cobro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_cuenta_cobro.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_cuenta_cobro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_cuenta_cobro.Location = new System.Drawing.Point(0, 291);
            this.dtg_cuenta_cobro.Name = "dtg_cuenta_cobro";
            this.dtg_cuenta_cobro.ReadOnly = true;
            this.dtg_cuenta_cobro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_cuenta_cobro.Size = new System.Drawing.Size(800, 374);
            this.dtg_cuenta_cobro.TabIndex = 71;
            // 
            // frm_cuenta_cobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 665);
            this.Controls.Add(this.dtg_cuenta_cobro);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_cuenta_cobro";
            this.Text = "frm_cuenta_cobro";
            this.Load += new System.EventHandler(this.frm_cuenta_cobro_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_cuenta_cobro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_cliente;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_vlr_prestamo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_vlr_interes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_porcentaje_interes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_num_cuotas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbx_modo_pago;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbx_dia_pago;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_dia_fecha_pago;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_nota;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lbl_id_cliente;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_consultar;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.DataGridView dtg_cuenta_cobro;
        private System.Windows.Forms.Label lbl_id_cuenta_cobro;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_valor_total;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_valor_cuota;
        private System.Windows.Forms.DateTimePicker dtt_fecha_primer_pago;
        private System.Windows.Forms.Label label13;
    }
}