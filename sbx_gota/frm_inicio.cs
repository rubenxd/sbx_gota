using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sbx_gota
{
    public partial class frm_inicio : Form
    {
        Form formul = new Form();

        public frm_inicio()
        {
            InitializeComponent();
        }

        private void btn_cliente_Click(object sender, EventArgs e)
        {
            formul.Dispose();
            frm_cliente frm_Cliente = new frm_cliente();
            ColoresBotones("btn_cliente");
            AbrirFormularioEnPanel(frm_Cliente);
            btn_cliente.BackColor = Color.DarkSeaGreen;
        }

        public void AbrirFormularioEnPanel(object FormularioHijo)
        {
            if (this.pnl_centro.Controls.Count > 0)
                this.pnl_centro.Controls.RemoveAt(0);
            //Form formul;  
            formul = FormularioHijo as Form;
            formul.TopLevel = false;
            formul.Dock = DockStyle.Fill;
            this.pnl_centro.Controls.Add(formul);
            this.pnl_centro.Tag = formul;
            formul.Show();
        }
        private void ColoresBotones(string Boton)
        {
            if (Boton != "btn_cuenta_cobro")
            {
                btn_cuenta_cobro.BackColor = Color.Gray;
            }
            if (Boton != "btn_cliente")
            {
                btn_cliente.BackColor = Color.Gray;
            }
            if (Boton != "btn_abonos")
            {
                btn_abonos.BackColor = Color.Gray;
            }
            if (Boton != "btn_reporte")
            {
                btn_reporte.BackColor = Color.Gray;
            }
            if (Boton != "btn_colaborador")
            {
                btn_colaborador.BackColor = Color.Gray;
            }
            if (Boton != "btn_pendiente_pago")
            {
                btn_pendiente_pago.BackColor = Color.Gray;
            } 
        }

        private void btn_cuenta_cobro_Click(object sender, EventArgs e)
        {
            formul.Dispose();
            frm_cuenta_cobro frm_Cuenta_Cobro = new frm_cuenta_cobro();
            ColoresBotones("btn_cuenta_cobro");
            AbrirFormularioEnPanel(frm_Cuenta_Cobro);
            btn_cuenta_cobro.BackColor = Color.DarkSeaGreen;
        }

        private void btn_reporte_Click(object sender, EventArgs e)
        {
            formul.Dispose();
            frm_reporte frm_Reporte = new frm_reporte();
            ColoresBotones("btn_reporte");
            AbrirFormularioEnPanel(frm_Reporte);
            btn_reporte.BackColor = Color.DarkSeaGreen;
        }

        private void btn_abonos_Click(object sender, EventArgs e)
        {
            formul.Dispose();
            frm_abonos frm_Abonos = new frm_abonos();
            ColoresBotones("btn_abonos");
            AbrirFormularioEnPanel(frm_Abonos);
            btn_abonos.BackColor = Color.DarkSeaGreen;
        }

        private void frm_inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea salir?", "", MessageBoxButtons.OKCancel);
            //if (dialogResult == DialogResult.OK)
            //{
            //    //Iniciar Formulario de login
            //    frm_login frm_Login = new frm_login();
            //    frm_Login.Show();
            //    this.Hide();
            //}

            //Iniciar Formulario de login
                frm_login frm_Login = new frm_login();
                frm_Login.Show();
                this.Hide();
        }

        private void btn_colaborador_Click(object sender, EventArgs e)
        {
            formul.Dispose();
            frm_colaborador frm_Colaborador = new frm_colaborador();
            ColoresBotones("btn_colaborador");
            AbrirFormularioEnPanel(frm_Colaborador);
            btn_colaborador.BackColor = Color.DarkSeaGreen;
        }

        private void btn_pendiente_pago_Click(object sender, EventArgs e)
        {
            formul.Dispose();
            frm_cobro_pendiente frm_Cobro_Pendiente = new frm_cobro_pendiente();
            ColoresBotones("btn_pendiente_pago");
            AbrirFormularioEnPanel(frm_Cobro_Pendiente);
            btn_pendiente_pago.BackColor = Color.DarkSeaGreen;
        }
    }
}
