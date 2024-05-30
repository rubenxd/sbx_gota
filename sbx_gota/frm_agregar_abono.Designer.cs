namespace sbx_gota
{
    partial class frm_agregar_abono
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_agregar_abono));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_cuentaCobro = new System.Windows.Forms.TextBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_nombres = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_id_cuenta_cobro = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_valor_cuota = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_valor_total = new System.Windows.Forms.TextBox();
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_identificacion = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_refinanciar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_pago_total = new System.Windows.Forms.Label();
            this.btn_pago_total = new System.Windows.Forms.Button();
            this.dtg_plan_pagos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_plan_pagos)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_cuentaCobro
            // 
            this.txt_cuentaCobro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_cuentaCobro.Enabled = false;
            this.txt_cuentaCobro.Location = new System.Drawing.Point(344, 12);
            this.txt_cuentaCobro.MaxLength = 200;
            this.txt_cuentaCobro.Name = "txt_cuentaCobro";
            this.txt_cuentaCobro.Size = new System.Drawing.Size(219, 20);
            this.txt_cuentaCobro.TabIndex = 63;
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
            this.btn_buscar.Location = new System.Drawing.Point(581, 9);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(22, 22);
            this.btn_buscar.TabIndex = 64;
            this.btn_buscar.UseVisualStyleBackColor = false;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(249, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 65;
            this.label2.Text = "Cuenta cobro *";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txt_nombres);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txt_id_cuenta_cobro);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txt_valor_cuota);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txt_valor_total);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txt_nota);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txt_dia_fecha_pago);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbx_dia_pago);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbx_modo_pago);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_num_cuotas);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_porcentaje_interes);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_vlr_interes);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_vlr_prestamo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_identificacion);
            this.groupBox1.Location = new System.Drawing.Point(12, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(849, 229);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info Cuenta cobro";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(128, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 15);
            this.label14.TabIndex = 111;
            this.label14.Text = "Nombre";
            // 
            // txt_nombres
            // 
            this.txt_nombres.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_nombres.Enabled = false;
            this.txt_nombres.Location = new System.Drawing.Point(186, 72);
            this.txt_nombres.MaxLength = 200;
            this.txt_nombres.Name = "txt_nombres";
            this.txt_nombres.Size = new System.Drawing.Size(219, 20);
            this.txt_nombres.TabIndex = 110;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(89, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 15);
            this.label13.TabIndex = 109;
            this.label13.Text = "Id cuenta cobro";
            // 
            // txt_id_cuenta_cobro
            // 
            this.txt_id_cuenta_cobro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_id_cuenta_cobro.Enabled = false;
            this.txt_id_cuenta_cobro.Location = new System.Drawing.Point(186, 20);
            this.txt_id_cuenta_cobro.MaxLength = 200;
            this.txt_id_cuenta_cobro.Name = "txt_id_cuenta_cobro";
            this.txt_id_cuenta_cobro.Size = new System.Drawing.Size(219, 20);
            this.txt_id_cuenta_cobro.TabIndex = 108;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(123, 203);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 15);
            this.label12.TabIndex = 107;
            this.label12.Text = "Vlr  cuota";
            this.label12.Visible = false;
            // 
            // txt_valor_cuota
            // 
            this.txt_valor_cuota.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_valor_cuota.Enabled = false;
            this.txt_valor_cuota.Location = new System.Drawing.Point(186, 200);
            this.txt_valor_cuota.MaxLength = 200;
            this.txt_valor_cuota.Name = "txt_valor_cuota";
            this.txt_valor_cuota.Size = new System.Drawing.Size(219, 20);
            this.txt_valor_cuota.TabIndex = 106;
            this.txt_valor_cuota.Visible = false;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(130, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 15);
            this.label11.TabIndex = 105;
            this.label11.Text = "Vlr  total";
            // 
            // txt_valor_total
            // 
            this.txt_valor_total.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_valor_total.Enabled = false;
            this.txt_valor_total.Location = new System.Drawing.Point(186, 148);
            this.txt_valor_total.MaxLength = 200;
            this.txt_valor_total.Name = "txt_valor_total";
            this.txt_valor_total.Size = new System.Drawing.Size(219, 20);
            this.txt_valor_total.TabIndex = 104;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(502, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 15);
            this.label10.TabIndex = 103;
            this.label10.Text = "Nota";
            // 
            // txt_nota
            // 
            this.txt_nota.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_nota.Enabled = false;
            this.txt_nota.Location = new System.Drawing.Point(541, 123);
            this.txt_nota.MaxLength = 200;
            this.txt_nota.Name = "txt_nota";
            this.txt_nota.Size = new System.Drawing.Size(219, 20);
            this.txt_nota.TabIndex = 102;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(438, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 15);
            this.label9.TabIndex = 101;
            this.label9.Text = "Dias fecha pago";
            // 
            // txt_dia_fecha_pago
            // 
            this.txt_dia_fecha_pago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_dia_fecha_pago.Enabled = false;
            this.txt_dia_fecha_pago.Location = new System.Drawing.Point(541, 97);
            this.txt_dia_fecha_pago.MaxLength = 200;
            this.txt_dia_fecha_pago.Name = "txt_dia_fecha_pago";
            this.txt_dia_fecha_pago.Size = new System.Drawing.Size(219, 20);
            this.txt_dia_fecha_pago.TabIndex = 100;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(478, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 99;
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
            this.cbx_dia_pago.Enabled = false;
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
            this.cbx_dia_pago.Location = new System.Drawing.Point(541, 43);
            this.cbx_dia_pago.Name = "cbx_dia_pago";
            this.cbx_dia_pago.Size = new System.Drawing.Size(219, 21);
            this.cbx_dia_pago.TabIndex = 98;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(467, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 15);
            this.label7.TabIndex = 97;
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
            this.cbx_modo_pago.Enabled = false;
            this.cbx_modo_pago.FormattingEnabled = true;
            this.cbx_modo_pago.Items.AddRange(new object[] {
            "NA",
            "Diario",
            "Semanal",
            "Quincenal",
            "Mensual",
            "Semestral",
            "Anual"});
            this.cbx_modo_pago.Location = new System.Drawing.Point(541, 70);
            this.cbx_modo_pago.Name = "cbx_modo_pago";
            this.cbx_modo_pago.Size = new System.Drawing.Size(219, 21);
            this.cbx_modo_pago.TabIndex = 96;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(106, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 15);
            this.label6.TabIndex = 95;
            this.label6.Text = "Num cuotas";
            // 
            // txt_num_cuotas
            // 
            this.txt_num_cuotas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_num_cuotas.Enabled = false;
            this.txt_num_cuotas.Location = new System.Drawing.Point(186, 174);
            this.txt_num_cuotas.MaxLength = 200;
            this.txt_num_cuotas.Name = "txt_num_cuotas";
            this.txt_num_cuotas.Size = new System.Drawing.Size(219, 20);
            this.txt_num_cuotas.TabIndex = 94;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(473, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 15);
            this.label5.TabIndex = 93;
            this.label5.Text = "%  interes";
            // 
            // txt_porcentaje_interes
            // 
            this.txt_porcentaje_interes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_porcentaje_interes.Enabled = false;
            this.txt_porcentaje_interes.Location = new System.Drawing.Point(541, 17);
            this.txt_porcentaje_interes.MaxLength = 200;
            this.txt_porcentaje_interes.Name = "txt_porcentaje_interes";
            this.txt_porcentaje_interes.Size = new System.Drawing.Size(219, 20);
            this.txt_porcentaje_interes.TabIndex = 92;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(115, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 91;
            this.label4.Text = "Vlr  interes";
            // 
            // txt_vlr_interes
            // 
            this.txt_vlr_interes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_vlr_interes.Enabled = false;
            this.txt_vlr_interes.Location = new System.Drawing.Point(186, 122);
            this.txt_vlr_interes.MaxLength = 200;
            this.txt_vlr_interes.Name = "txt_vlr_interes";
            this.txt_vlr_interes.Size = new System.Drawing.Size(219, 20);
            this.txt_vlr_interes.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(103, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 89;
            this.label3.Text = "Vlr prestamo";
            // 
            // txt_vlr_prestamo
            // 
            this.txt_vlr_prestamo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_vlr_prestamo.Enabled = false;
            this.txt_vlr_prestamo.Location = new System.Drawing.Point(186, 96);
            this.txt_vlr_prestamo.MaxLength = 200;
            this.txt_vlr_prestamo.Name = "txt_vlr_prestamo";
            this.txt_vlr_prestamo.Size = new System.Drawing.Size(219, 20);
            this.txt_vlr_prestamo.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 87;
            this.label1.Text = "Identificacion";
            // 
            // txt_identificacion
            // 
            this.txt_identificacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_identificacion.Enabled = false;
            this.txt_identificacion.Location = new System.Drawing.Point(186, 46);
            this.txt_identificacion.MaxLength = 200;
            this.txt_identificacion.Name = "txt_identificacion";
            this.txt_identificacion.Size = new System.Drawing.Size(219, 20);
            this.txt_identificacion.TabIndex = 86;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_refinanciar);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.btn_pago_total);
            this.groupBox2.Controls.Add(this.dtg_plan_pagos);
            this.groupBox2.Location = new System.Drawing.Point(12, 281);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(849, 308);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Plan de pagos";
            // 
            // btn_refinanciar
            // 
            this.btn_refinanciar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_refinanciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_refinanciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_refinanciar.FlatAppearance.BorderSize = 0;
            this.btn_refinanciar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_refinanciar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btn_refinanciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_refinanciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_refinanciar.ForeColor = System.Drawing.Color.White;
            this.btn_refinanciar.Location = new System.Drawing.Point(717, 267);
            this.btn_refinanciar.Name = "btn_refinanciar";
            this.btn_refinanciar.Size = new System.Drawing.Size(126, 31);
            this.btn_refinanciar.TabIndex = 82;
            this.btn_refinanciar.Text = "Refinanciar";
            this.btn_refinanciar.UseVisualStyleBackColor = false;
            this.btn_refinanciar.Click += new System.EventHandler(this.btn_refinanciar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.lbl_pago_total);
            this.panel1.Location = new System.Drawing.Point(138, 267);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 32);
            this.panel1.TabIndex = 81;
            // 
            // lbl_pago_total
            // 
            this.lbl_pago_total.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_pago_total.AutoSize = true;
            this.lbl_pago_total.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pago_total.ForeColor = System.Drawing.SystemColors.Window;
            this.lbl_pago_total.Location = new System.Drawing.Point(4, 9);
            this.lbl_pago_total.Name = "lbl_pago_total";
            this.lbl_pago_total.Size = new System.Drawing.Size(14, 15);
            this.lbl_pago_total.TabIndex = 110;
            this.lbl_pago_total.Text = "0";
            // 
            // btn_pago_total
            // 
            this.btn_pago_total.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_pago_total.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_pago_total.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_pago_total.Enabled = false;
            this.btn_pago_total.FlatAppearance.BorderSize = 0;
            this.btn_pago_total.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_pago_total.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btn_pago_total.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pago_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_pago_total.ForeColor = System.Drawing.Color.White;
            this.btn_pago_total.Location = new System.Drawing.Point(6, 267);
            this.btn_pago_total.Name = "btn_pago_total";
            this.btn_pago_total.Size = new System.Drawing.Size(126, 31);
            this.btn_pago_total.TabIndex = 80;
            this.btn_pago_total.Text = "Pago total";
            this.btn_pago_total.UseVisualStyleBackColor = false;
            this.btn_pago_total.Click += new System.EventHandler(this.btn_pago_total_Click);
            // 
            // dtg_plan_pagos
            // 
            this.dtg_plan_pagos.AllowUserToAddRows = false;
            this.dtg_plan_pagos.AllowUserToDeleteRows = false;
            this.dtg_plan_pagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_plan_pagos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_plan_pagos.Location = new System.Drawing.Point(6, 19);
            this.dtg_plan_pagos.Name = "dtg_plan_pagos";
            this.dtg_plan_pagos.ReadOnly = true;
            this.dtg_plan_pagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_plan_pagos.Size = new System.Drawing.Size(837, 242);
            this.dtg_plan_pagos.TabIndex = 0;
            this.dtg_plan_pagos.DoubleClick += new System.EventHandler(this.dtg_plan_pagos_DoubleClick);
            // 
            // frm_agregar_abono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 598);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.txt_cuentaCobro);
            this.MaximizeBox = false;
            this.Name = "frm_agregar_abono";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_agregar_abono";
            this.Load += new System.EventHandler(this.frm_agregar_abono_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_plan_pagos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txt_id_cuenta_cobro;
        public System.Windows.Forms.TextBox txt_valor_cuota;
        public System.Windows.Forms.TextBox txt_valor_total;
        public System.Windows.Forms.TextBox txt_nota;
        public System.Windows.Forms.TextBox txt_dia_fecha_pago;
        public System.Windows.Forms.ComboBox cbx_dia_pago;
        public System.Windows.Forms.ComboBox cbx_modo_pago;
        public System.Windows.Forms.TextBox txt_num_cuotas;
        public System.Windows.Forms.TextBox txt_porcentaje_interes;
        public System.Windows.Forms.TextBox txt_vlr_interes;
        public System.Windows.Forms.TextBox txt_vlr_prestamo;
        public System.Windows.Forms.TextBox txt_identificacion;
        public System.Windows.Forms.DataGridView dtg_plan_pagos;
        public System.Windows.Forms.TextBox txt_nombres;
        public System.Windows.Forms.Button btn_pago_total;
        public System.Windows.Forms.Label lbl_pago_total;
        public System.Windows.Forms.TextBox txt_cuentaCobro;
        public System.Windows.Forms.Button btn_buscar;
        public System.Windows.Forms.Button btn_refinanciar;
    }
}