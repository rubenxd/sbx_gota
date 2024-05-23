using sbx_gota.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sbx_gota.MODEL
{
    public class cls_reportes
    {
        //instancias
        cls_datos cls_datos = new cls_datos();

        //Variables
        DataTable v_dt;
        string v_query = "";
        public string v_buscar { get; set; }

        //getter and setter
        public int IdCuentaCobro { get; set; }
        public string MontoPrestamo { get; set; }
        public string ValorInteres { get; set; }
        public string NumeroCuotas { get; set; }
        public string VlrCuota { get; set; }
        public string ValorAbono { get; set; }
        public string ValorRecuperado { get; set; }
        public string Ganancia { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }

        //Metodos
        public DataTable mtd_consultar_reporte()
        {
            v_query = " EXECUTE sp_consultar_resultados '" + v_buscar + "' ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }
    }
}
