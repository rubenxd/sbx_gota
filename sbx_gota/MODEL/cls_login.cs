using sbx_gota.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sbx_gota.MODEL
{
    public class cls_login
    {
        //instancias
        cls_conexion cls_cn = new cls_conexion();
        cls_datos cls_datos = new cls_datos();

        //Variables
        DataTable v_dt;
        string v_query = "";

        //getter and setter
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int IdRol { get; set; }

        //Metodos
        public DataTable mtd_consultar_estado()
        {
            v_query = " EXECUTE sp_verificar_login  '" + Usuario + "','" + Contrasena + "' ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }
    }
}
