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
    public class cls_parametros
    {
        //instancias
        cls_datos cls_datos = new cls_datos();

        //Variables
        DataTable v_dt;
        string v_query = "";
        SqlParameter[] Parametros;
        bool v_ok;
        public string v_buscar { get; set; }

        //getter and setter
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public string descripcion { get; set; }

        //Metodos
        public DataTable mtd_consultar_parametros()
        {
            v_query = " EXECUTE sp_consultar_parametros ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        public DataTable mtd_consultar_abonos_exacto()
        {
            v_query = " SELECT * FROM tbl_parametro WHERE Id = '" + v_buscar + "' ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        private void mtd_asignaParametros()
        {
            Parametros = new SqlParameter[3];

            Parametros[0] = new SqlParameter();
            Parametros[0].ParameterName = "@Nombre";
            Parametros[0].SqlDbType = SqlDbType.VarChar;
            Parametros[0].SqlValue = Nombre;

            Parametros[1] = new SqlParameter();
            Parametros[1].ParameterName = "@Valor";
            Parametros[1].SqlDbType = SqlDbType.VarChar;
            Parametros[1].SqlValue = Valor;

            Parametros[2] = new SqlParameter();
            Parametros[2].ParameterName = "@descripcion";
            Parametros[2].SqlDbType = SqlDbType.VarChar;
            Parametros[2].SqlValue = descripcion;

        }
        public Boolean mtd_registrar()
        {
            v_query = " INSERT INTO tbl_parametro (Nombre,Valor,descripcion)" +
                      " VALUES (@Nombre,@Valor,@descripcion)";

            mtd_asignaParametros();
            v_ok = cls_datos.mtd_registrar(Parametros, v_query);
            return v_ok;
        }
        public Boolean mtd_Editar()
        {
            v_query = " UPDATE tbl_parametro SET Nombre = @Nombre,Valor = @Valor,descripcion = @descripcion " +
                      " WHERE Id = " + Id;

            mtd_asignaParametros();
            v_ok = cls_datos.mtd_editar(Parametros, v_query);
            return v_ok;
        }
        public Boolean mtd_eliminar_cuentaCobro()
        {
            v_query = "DELETE FROM tbl_parametro WHERE Id = '" + Id + "'";
            v_ok = cls_datos.mtd_eliminar(v_query);
            return v_ok;
        }
    }
}
