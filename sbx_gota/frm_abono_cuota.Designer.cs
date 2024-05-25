namespace sbx_gota
{
    partial class frm_abono_cuota
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_valor_cuota = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_fecha_cuota = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nota = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_valor_abono = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_id_cuota = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_numero_cuota = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_guardar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_valor_cuota);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_fecha_cuota);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_nota);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_valor_abono);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_id_cuota);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txt_numero_cuota);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 233);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar Abono";
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
            this.btn_guardar.Location = new System.Drawing.Point(177, 179);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(126, 31);
            this.btn_guardar.TabIndex = 122;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = false;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(98, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 121;
            this.label5.Text = "Valor cuota";
            // 
            // txt_valor_cuota
            // 
            this.txt_valor_cuota.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_valor_cuota.Enabled = false;
            this.txt_valor_cuota.Location = new System.Drawing.Point(177, 97);
            this.txt_valor_cuota.MaxLength = 200;
            this.txt_valor_cuota.Name = "txt_valor_cuota";
            this.txt_valor_cuota.Size = new System.Drawing.Size(219, 20);
            this.txt_valor_cuota.TabIndex = 120;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(91, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 119;
            this.label4.Text = "Fecha cuota";
            // 
            // txt_fecha_cuota
            // 
            this.txt_fecha_cuota.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_fecha_cuota.Enabled = false;
            this.txt_fecha_cuota.Location = new System.Drawing.Point(177, 71);
            this.txt_fecha_cuota.MaxLength = 200;
            this.txt_fecha_cuota.Name = "txt_fecha_cuota";
            this.txt_fecha_cuota.Size = new System.Drawing.Size(219, 20);
            this.txt_fecha_cuota.TabIndex = 118;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(132, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 117;
            this.label3.Text = "Nota";
            // 
            // txt_nota
            // 
            this.txt_nota.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_nota.Location = new System.Drawing.Point(177, 153);
            this.txt_nota.MaxLength = 200;
            this.txt_nota.Name = "txt_nota";
            this.txt_nota.Size = new System.Drawing.Size(219, 20);
            this.txt_nota.TabIndex = 116;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(94, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 115;
            this.label2.Text = "Valor Abono";
            // 
            // txt_valor_abono
            // 
            this.txt_valor_abono.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_valor_abono.Location = new System.Drawing.Point(177, 127);
            this.txt_valor_abono.MaxLength = 200;
            this.txt_valor_abono.Name = "txt_valor_abono";
            this.txt_valor_abono.Size = new System.Drawing.Size(219, 20);
            this.txt_valor_abono.TabIndex = 114;
            this.txt_valor_abono.TextChanged += new System.EventHandler(this.txt_valor_abono_TextChanged);
            this.txt_valor_abono.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_valor_abono_KeyUp);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 113;
            this.label1.Text = "Id cuota";
            // 
            // txt_id_cuota
            // 
            this.txt_id_cuota.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_id_cuota.Enabled = false;
            this.txt_id_cuota.Location = new System.Drawing.Point(177, 19);
            this.txt_id_cuota.MaxLength = 200;
            this.txt_id_cuota.Name = "txt_id_cuota";
            this.txt_id_cuota.Size = new System.Drawing.Size(219, 20);
            this.txt_id_cuota.TabIndex = 112;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(80, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 15);
            this.label13.TabIndex = 111;
            this.label13.Text = "Numero cuota";
            // 
            // txt_numero_cuota
            // 
            this.txt_numero_cuota.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_numero_cuota.Enabled = false;
            this.txt_numero_cuota.Location = new System.Drawing.Point(177, 45);
            this.txt_numero_cuota.MaxLength = 200;
            this.txt_numero_cuota.Name = "txt_numero_cuota";
            this.txt_numero_cuota.Size = new System.Drawing.Size(219, 20);
            this.txt_numero_cuota.TabIndex = 110;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frm_abono_cuota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 255);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(515, 294);
            this.Name = "frm_abono_cuota";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_abono_cuota";
            this.Load += new System.EventHandler(this.frm_abono_cuota_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_numero_cuota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_id_cuota;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_valor_abono;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nota;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_fecha_cuota;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_valor_cuota;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}