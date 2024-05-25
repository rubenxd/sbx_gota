using sbx_gota.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
            if (Boton != "btn_ajustes")
            {
                btn_ajustes.BackColor = Color.Gray;
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
        DataTable v_dt;
        private void frm_inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            v_dt = new DataTable();
            //consultar ruta a guardar
            cls_parametros cls_Parametros = new cls_parametros();
            v_dt = cls_Parametros.mtd_consultar_parametros();
            string ruta = "";
            foreach (DataRow item in v_dt.Rows)
            {
                if (item["Nombre"].ToString() == "RutaBackup")
                {
                    //ruta = item["Valor"].ToString();
                }
            }
            string NombreCopiaSeguridad = DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Day.ToString() + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + " SBX_GOTA.bak";
            string ComandoConsulta = "BACKUP DATABASE [SBX_GOTA] TO  DISK = N'" + ruta + "" + NombreCopiaSeguridad + "' WITH NOFORMAT, NOINIT,  NAME = N'SBX_GOTA-Completa Base de datos Copia de seguridad', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
            sbx_gota.DB.cls_conexion cls_Conexion = new DB.cls_conexion();
            if (cls_Conexion.Cadenacn.State == ConnectionState.Open)
            {
                cls_Conexion.Cadenacn.Close();
            }
            SqlCommand cmd = new SqlCommand(ComandoConsulta, cls_Conexion.Cadenacn);
            try
            {
                cls_Conexion.Cadenacn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se genero copia de seguidad Correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Ruta de la carpeta origen y destino
                string origen = @"";
                string destino = @"";
                DataTable dt;
                dt = new DataTable();
                cls_Parametros = new cls_parametros();
                dt = cls_Parametros.mtd_consultar_parametros();
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Nombre"].ToString() == "RutaBackup")
                    {
                        origen = dr["Valor"].ToString();
                    }
                    else if (dr["Nombre"].ToString() == "RutaDestino")
                    {
                        destino = dr["Valor"].ToString();
                    }
                }
                // Lista de archivos a mover
                string[] archivos = Directory.GetFiles(origen);
                foreach (string archivo in archivos)
                {
                    // Obtener el nombre del archivo
                    string nombreArchivo = Path.GetFileName(archivo);
                    // Construir la ruta de destino
                    string rutaDestino = Path.Combine(destino, nombreArchivo);
                    try
                    {
                        // mover el archivo
                        File.Move(archivo, rutaDestino);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"Error al mover {nombreArchivo}: {ex.Message}");
                    }
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar generar copia de seguidad: " + ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        private void btn_ajustes_Click(object sender, EventArgs e)
        {
            formul.Dispose();
            frm_ajustes frm_Ajustes = new frm_ajustes();
            ColoresBotones("btn_ajustes");
            AbrirFormularioEnPanel(frm_Ajustes);
            btn_ajustes.BackColor = Color.DarkSeaGreen;
        }
    }
}
