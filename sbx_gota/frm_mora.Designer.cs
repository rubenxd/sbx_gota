namespace sbx_gota
{
    partial class frm_mora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_mora));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_id_mora = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_nota = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_vlr_pagar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_saldo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_pagos_mora = new System.Windows.Forms.TextBox();
            this.btn_pago_total = new System.Windows.Forms.Button();
            this.txt_id_cuenta_cobro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_nombres = new System.Windows.Forms.TextBox();
            this.txt_mora = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.dtg_pagos_mora = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_pagos_mora)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_id_mora);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txt_nota);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt_vlr_pagar);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_saldo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_pagos_mora);
            this.panel1.Controls.Add(this.btn_pago_total);
            this.panel1.Controls.Add(this.txt_id_cuenta_cobro);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_nombres);
            this.panel1.Controls.Add(this.txt_mora);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 233);
            this.panel1.TabIndex = 121;
            // 
            // lbl_id_mora
            // 
            this.lbl_id_mora.AutoSize = true;
            this.lbl_id_mora.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_id_mora.Location = new System.Drawing.Point(12, 9);
            this.lbl_id_mora.Name = "lbl_id_mora";
            this.lbl_id_mora.Size = new System.Drawing.Size(14, 15);
            this.lbl_id_mora.TabIndex = 129;
            this.lbl_id_mora.Text = "0";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(266, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 15);
            this.label10.TabIndex = 128;
            this.label10.Text = "Nota";
            // 
            // txt_nota
            // 
            this.txt_nota.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_nota.Location = new System.Drawing.Point(305, 168);
            this.txt_nota.MaxLength = 200;
            this.txt_nota.Name = "txt_nota";
            this.txt_nota.Size = new System.Drawing.Size(219, 20);
            this.txt_nota.TabIndex = 127;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(220, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 126;
            this.label6.Text = "Valor a pagar";
            // 
            // txt_vlr_pagar
            // 
            this.txt_vlr_pagar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_vlr_pagar.Location = new System.Drawing.Point(305, 142);
            this.txt_vlr_pagar.MaxLength = 200;
            this.txt_vlr_pagar.Name = "txt_vlr_pagar";
            this.txt_vlr_pagar.Size = new System.Drawing.Size(219, 20);
            this.txt_vlr_pagar.TabIndex = 125;
            this.txt_vlr_pagar.TextChanged += new System.EventHandler(this.txt_vlr_pagar_TextChanged);
            this.txt_vlr_pagar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_vlr_pagar_KeyUp);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(262, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 124;
            this.label5.Text = "Debe";
            // 
            // txt_saldo
            // 
            this.txt_saldo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_saldo.Enabled = false;
            this.txt_saldo.Location = new System.Drawing.Point(305, 116);
            this.txt_saldo.MaxLength = 200;
            this.txt_saldo.Name = "txt_saldo";
            this.txt_saldo.Size = new System.Drawing.Size(219, 20);
            this.txt_saldo.TabIndex = 123;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(186, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 15);
            this.label4.TabIndex = 122;
            this.label4.Text = "Total pagos a mora";
            // 
            // txt_pagos_mora
            // 
            this.txt_pagos_mora.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_pagos_mora.Enabled = false;
            this.txt_pagos_mora.Location = new System.Drawing.Point(305, 90);
            this.txt_pagos_mora.MaxLength = 200;
            this.txt_pagos_mora.Name = "txt_pagos_mora";
            this.txt_pagos_mora.Size = new System.Drawing.Size(219, 20);
            this.txt_pagos_mora.TabIndex = 121;
            // 
            // btn_pago_total
            // 
            this.btn_pago_total.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_pago_total.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_pago_total.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_pago_total.FlatAppearance.BorderSize = 0;
            this.btn_pago_total.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_pago_total.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btn_pago_total.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pago_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_pago_total.ForeColor = System.Drawing.Color.White;
            this.btn_pago_total.Location = new System.Drawing.Point(305, 194);
            this.btn_pago_total.Name = "btn_pago_total";
            this.btn_pago_total.Size = new System.Drawing.Size(126, 31);
            this.btn_pago_total.TabIndex = 120;
            this.btn_pago_total.Text = "Agregar pago";
            this.btn_pago_total.UseVisualStyleBackColor = false;
            this.btn_pago_total.Click += new System.EventHandler(this.btn_pago_total_Click);
            // 
            // txt_id_cuenta_cobro
            // 
            this.txt_id_cuenta_cobro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_id_cuenta_cobro.Enabled = false;
            this.txt_id_cuenta_cobro.Location = new System.Drawing.Point(305, 12);
            this.txt_id_cuenta_cobro.MaxLength = 200;
            this.txt_id_cuenta_cobro.Name = "txt_id_cuenta_cobro";
            this.txt_id_cuenta_cobro.Size = new System.Drawing.Size(219, 20);
            this.txt_id_cuenta_cobro.TabIndex = 118;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(208, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 15);
            this.label3.TabIndex = 119;
            this.label3.Text = "Id cuenta cobro";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 117;
            this.label2.Text = "Total Mora";
            // 
            // txt_nombres
            // 
            this.txt_nombres.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_nombres.Enabled = false;
            this.txt_nombres.Location = new System.Drawing.Point(305, 38);
            this.txt_nombres.MaxLength = 200;
            this.txt_nombres.Name = "txt_nombres";
            this.txt_nombres.Size = new System.Drawing.Size(219, 20);
            this.txt_nombres.TabIndex = 114;
            // 
            // txt_mora
            // 
            this.txt_mora.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_mora.Enabled = false;
            this.txt_mora.Location = new System.Drawing.Point(305, 64);
            this.txt_mora.MaxLength = 200;
            this.txt_mora.Name = "txt_mora";
            this.txt_mora.Size = new System.Drawing.Size(219, 20);
            this.txt_mora.TabIndex = 116;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(247, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 15);
            this.label14.TabIndex = 115;
            this.label14.Text = "Nombre";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btn_buscar);
            this.panel4.Controls.Add(this.btn_eliminar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 233);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 38);
            this.panel4.TabIndex = 122;
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
            this.btn_buscar.Location = new System.Drawing.Point(764, 6);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(22, 22);
            this.btn_buscar.TabIndex = 6;
            this.btn_buscar.UseVisualStyleBackColor = false;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
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
            this.btn_eliminar.Location = new System.Drawing.Point(7, 8);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(20, 20);
            this.btn_eliminar.TabIndex = 3;
            this.btn_eliminar.UseVisualStyleBackColor = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // dtg_pagos_mora
            // 
            this.dtg_pagos_mora.AllowUserToAddRows = false;
            this.dtg_pagos_mora.AllowUserToDeleteRows = false;
            this.dtg_pagos_mora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_pagos_mora.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtg_pagos_mora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_pagos_mora.Location = new System.Drawing.Point(0, 271);
            this.dtg_pagos_mora.Name = "dtg_pagos_mora";
            this.dtg_pagos_mora.ReadOnly = true;
            this.dtg_pagos_mora.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_pagos_mora.Size = new System.Drawing.Size(800, 265);
            this.dtg_pagos_mora.TabIndex = 123;
            // 
            // frm_mora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 536);
            this.Controls.Add(this.dtg_pagos_mora);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frm_mora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_mora";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_mora_FormClosed);
            this.Load += new System.EventHandler(this.frm_mora_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_pagos_mora)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_id_mora;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_nota;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_vlr_pagar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_pago_total;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.DataGridView dtg_pagos_mora;
        public System.Windows.Forms.TextBox txt_saldo;
        public System.Windows.Forms.TextBox txt_pagos_mora;
        public System.Windows.Forms.TextBox txt_id_cuenta_cobro;
        public System.Windows.Forms.TextBox txt_nombres;
        public System.Windows.Forms.TextBox txt_mora;
    }
}