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
    public class cls_cliente
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
        public string TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string FechaRegistro { get; set; }

        //Metodos
        public DataTable mtd_consultar_cliente()
        {
            v_query = " EXECUTE sp_consultar_cliente  '" + v_buscar + "' ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        public DataTable mtd_consultar_cliente_exacto()
        {
            v_query = " SELECT * FROM tbl_cliente WHERE Id = '"+ v_buscar + "' ";
            v_dt = cls_datos.mtd_consultar(v_query);
            return v_dt;
        }

        private void mtd_asignaParametros()
        {
            Parametros = new SqlParameter[8];

            Parametros[0] = new SqlParameter();
            Parametros[0].ParameterName = "@Id";
            Parametros[0].SqlDbType = SqlDbType.Int;
            Parametros[0].SqlValue = Id;

            Parametros[1] = new SqlParameter();
            Parametros[1].ParameterName = "@TipoIdentificacion";
            Parametros[1].SqlDbType = SqlDbType.VarChar;
            Parametros[1].SqlValue = TipoIdentificacion;

            Parametros[2] = new SqlParameter();
            Parametros[2].ParameterName = "@NumeroIdentificacion";
            Parametros[2].SqlDbType = SqlDbType.VarChar;
            Parametros[2].SqlValue = NumeroIdentificacion;

            Parametros[3] = new SqlParameter();
            Parametros[3].ParameterName = "@Nombres";
            Parametros[3].SqlDbType = SqlDbType.VarChar;
            Parametros[3].SqlValue = Nombres;

            Parametros[4] = new SqlParameter();
            Parametros[4].ParameterName = "@Apellidos";
            Parametros[4].SqlDbType = SqlDbType.VarChar;
            Parametros[4].SqlValue = Apellidos;

            Parametros[5] = new SqlParameter();
            Parametros[5].ParameterName = "@Celular";
            Parametros[5].SqlDbType = SqlDbType.VarChar;
            Parametros[5].SqlValue = Celular;

            Parametros[6] = new SqlParameter();
            Parametros[6].ParameterName = "@Direccion";
            Parametros[6].SqlDbType = SqlDbType.VarChar;
            Parametros[6].SqlValue = Direccion;

            Parametros[7] = new SqlParameter();
            Parametros[7].ParameterName = "@FechaRegistro";
            Parametros[7].SqlDbType = SqlDbType.DateTime;
            Parametros[7].SqlValue = FechaRegistro;

        }
        public Boolean mtd_registrar()
        {
            v_query = " INSERT INTO tbl_cliente (TipoIdentificacion,NumeroIdentificacion,Nombres,Apellidos,Celular,Direccion,FechaRegistro)" +
                      " VALUES (@TipoIdentificacion,@NumeroIdentificacion,@Nombres,@Apellidos,@Celular,@Direccion,@FechaRegistro)";

            mtd_asignaParametros();
            v_ok = cls_datos.mtd_registrar(Parametros, v_query);
            return v_ok;
        }
        public Boolean mtd_Editar()
        {
            v_query = " UPDATE tbl_cliente SET TipoIdentificacion = @TipoIdentificacion,NumeroIdentificacion = @NumeroIdentificacion,Nombres = @Nombres,  " +
                      " Apellidos = @Apellidos,Celular = @Celular,Direccion = @Direccion,FechaRegistro = @FechaRegistro " +
                      " WHERE Id = " + Id;

            mtd_asignaParametros();
            v_ok = cls_datos.mtd_editar(Parametros, v_query);
            return v_ok;
        }
        public Boolean mtd_eliminar()
        {
            v_query = "DELETE FROM tbl_cliente WHERE Id = '" + Id + "'";
            v_ok = cls_datos.mtd_eliminar(v_query);
            return v_ok;
        }
    }
}
