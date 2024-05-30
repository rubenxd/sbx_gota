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
    public class cls_pagos_pendientes
    {
        //instancias
        cls_datos cls_datos = new cls_datos();

        //Variables
        DataTable v_dt;
        string v_query = "";
        public string v_buscar { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public string estado { get; set; }

        //getter and setter
        public string NumeroIdentificacion { get; set; }
        public string Cliente { get; set; }
        public string Celular { get; set; }
        public string IdCuentaCobro { get; set; }
        public string NumeroCuota { get; set; }
        public string VlrCuota { get; set; }
        public string FechaCuota { get; set; }
        public string Estado { get; set; }

        //Metodos
        public DataTable mtd_consultar_pagos_pendientes()
        {
            v_query = " EXECUTE sp_consultar_pagos_pendientes  '" + v_buscar + "', '" + FechaIni.ToString("yyyyMMdd") + "', '" + FechaFin.ToString("yyyyMMdd") + "' ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        public DataTable mtd_consultar_pagos_pendientes2()
        {
            if (estado == "Todos")
            {
                estado = "";
            }
            v_query = " EXECUTE sp_consultar_pagos_pendientes_2  '" + v_buscar + "', '" + FechaFin.ToString("yyyyMMdd") + "', '"+ estado + "' ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        public DataTable mtd_consultar_pagos_pendientes3()
        {
            if (estado == "Todos")
            {
                estado = "";
            }
            v_query = " EXECUTE sp_consultar_pagos_pendientes_3  '" + v_buscar + "', '"+ estado + "' ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }
    }
}
