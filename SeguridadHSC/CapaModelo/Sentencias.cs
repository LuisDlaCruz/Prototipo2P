using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Sentencias
    {


        Conexion cn = new Conexion();
        OdbcCommand Comm;
        //frmLogin
        public int funIniciarSesion(string Usuario, string Contraseña, int validar)
        {
            try
            {
                string con = "";

                string Query = "select * from `componenteseguridad`.`Usuario` where nombre='" + Usuario + "';";

                OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda;
                busqueda = consulta.ExecuteReader();

                if (busqueda.Read())
                {
                    con = busqueda["contraseña"].ToString();
                }

                validar = Contraseña.CompareTo(con);


            }
            catch
            {

            }

            return validar;


        }


        //frmMantenimientoAplicacion
        public void funInsertar(string documento_compraenca, string codigo_producto, float cantidad_compradet, float costo_compradet, string codigo_bodega)
        {

            string cadena = "INSERT INTO" +
            " `dbcompras`.`compras_detalle` VALUES (" + "'" + documento_compraenca + "', '" + codigo_producto + "' , " + cantidad_compradet + ", '" + costo_compradet + "', '" + codigo_bodega + "');";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();


        }


        public void funModificar(string documento_compraenca, string codigo_producto, float cantidad_compradet, float costo_compradet, string codigo_bodega)
        {

            string cadena = "UPDATE dbcompras.compras_detalle set documento_compraenca ='" + documento_compraenca
              + "',codigo_producto ='" + codigo_producto + "',cantidad_compradet = " + cantidad_compradet + ", costo_compradet = '" + costo_compradet + "'  where documento_compraenca= '" + documento_compraenca + "';";


            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();




        }

        public void funEliminar(string documento_compraenca)
        {

            string cadena = "delete from dbcompras.compras_detalle where documento_compraenca ='" + documento_compraenca + "';";


            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

        }




        public (string, float, float,string) funBuscar(string documento_compraenca, string codigo_producto, float cantidad_compradet, float costo_compradet, string codigo_bodega)
        {


            string Query = "select * from `dbcompras`.`compras_detalle` where pkId='" + documento_compraenca + "';";

            OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {

                codigo_producto = busqueda["codigo_producto"].ToString();
                cantidad_compradet = float.Parse(busqueda["cantidad_compradet"].ToString());
                costo_compradet = float.Parse(busqueda["costo_compradet"].ToString());
                codigo_bodega = busqueda["codigo_bodega"].ToString();
            }


            return (codigo_producto, cantidad_compradet, costo_compradet, codigo_bodega);


        }

        //frmPerfiles

        public OdbcDataAdapter PerfilllenarTbl(string tabla2)// metodo  que obtinene el contenido de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT pkid, nombre FROM " + tabla2 + "  ;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
        }

        public OdbcDataAdapter PerfilllenarTblPersonal(string tabla2, string condicion)// metodo  que obtinene el contenido de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT perfil.pkid, perfil.nombre FROM " + tabla2 + "  LEFT JOIN usuarioperfil ON perfil.pkid = usuarioperfil.fkidperfil LEFT JOIN usuario ON usuarioperfil.fkidusuario = usuario.pkid WHERE usuario.pkid = " + condicion + " ORDER BY perfil.pkid;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
        }

        public OdbcDataAdapter PerfilllenarNombre(string tabla, string condicion)// metodo  que obtinene el contenido
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT nombre FROM " + tabla + " WHERE pkid = " + condicion + "  ;";
            OdbcDataAdapter dataName = new OdbcDataAdapter(sql, cn.conexion());
            return dataName;
        }

        public void Perfilagregar(string tabla3, string valor1, string valor2)
        {
            string sql = "INSERT INTO " + tabla3 + " (fkidUsuario, fkidPerfil) Values( '" + valor1 + "', '" + valor2 + "');";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();
        }

        public void Perfileliminar(string tabla3, string valor1, string valor2)
        {
            string sql = "DELETE FROM " + tabla3 + " WHERE fkidUsuario = '" + valor1 + "' AND  fkidperfil='" + valor2 + "';";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();
        }

        public void Perfileliminartodo(string tabla3, string valor1)
        {
            string sql = "DELETE FROM " + tabla3 + " WHERE fkidUsuario = '" + valor1 + "';";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();
        }

        public void Perfilagregartodo(string tabla3, string valor1, string valor2, string tabla2)
        {
            string sql = "INSERT INTO usuarioperfil (fkidUsuario, fkidPerfil) SELECT NULL, pkid FROM perfil;";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();

            string sql2 = "UPDATE usuarioperfil SET " + tabla3 + " = '" + valor1 + "' WHERE fkidUsuario = '';";
            OdbcCommand consulta2 = new OdbcCommand(sql2, cn.conexion());
            consulta2.ExecuteNonQuery();
        }

        //frmAplicaciones
        public OdbcDataAdapter aplicacionllenarTbl(string tabla2)// metodo  que obtinene el contenido de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT pkid, nombre FROM " + tabla2 + "  ;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
        }

        public OdbcDataAdapter aplicacionllenarTblPerfil(string tabla4)// metodo  que obtinene el contenido de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT pkid, nombre FROM " + tabla4 + "  ;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
        }

        public OdbcDataAdapter aplicacionllenarTblPersonal(string tabla2, string condicion)// metodo  que obtinene el contenido de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT aplicacion.pkid, aplicacion.nombre FROM " + tabla2 + "  LEFT JOIN UsuarioAplicacionAsignados ON aplicacion.pkid = UsuarioAplicacionAsignados.fkidaplicacion LEFT JOIN usuario ON UsuarioAplicacionAsignados.fkidusuario = usuario.pkid WHERE usuario.pkid = " + condicion + " ORDER BY aplicacion.pkid;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
        }

        public OdbcDataAdapter aplicacionllenarNombre(string tabla, string condicion)// metodo  que obtinene el contenido
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT nombre FROM " + tabla + " WHERE pkid = " + condicion + "  ;";
            OdbcDataAdapter dataName = new OdbcDataAdapter(sql, cn.conexion());
            return dataName;
        }

        public void aplicacionagregar(string tabla3, string valor1, string valor2)
        {
            string sql = "INSERT INTO " + tabla3 + " (fkidUsuario, fkidaplicacion) Values( '" + valor1 + "', '" + valor2 + "');";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();
        }

        public void aplicacioneliminar(string tabla3, string valor1, string valor2)
        {
            string sql = "DELETE FROM " + tabla3 + " WHERE fkidUsuario = '" + valor1 + "' AND  fkidaplicacion='" + valor2 + "';";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();
        }

        public void aplicacioneliminartodo(string tabla3, string valor1)
        {
            string sql = "DELETE FROM " + tabla3 + " WHERE fkidUsuario = '" + valor1 + "';";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();
        }

        public void aplicacionagregartodo(string tabla3, string valor1, string valor2, string tabla2)
        {
            string sql = "INSERT INTO UsuarioAplicacionAsignados (fkidUsuario, fkidaplicacion) SELECT NULL, pkid FROM aplicacion;";
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();

            string sql2 = "UPDATE UsuarioAplicacionAsignados SET " + tabla3 + " = '" + valor1 + "' WHERE fkidUsuario = '';";
            OdbcCommand consulta2 = new OdbcCommand(sql2, cn.conexion());
            consulta2.ExecuteNonQuery();
        }

        //frmRecuperarContraseña
        public OdbcDataReader funcModificarContraseña(string Consulta)
        {
            try
            {
                Comm = new OdbcCommand(Consulta, cn.conexion());
                OdbcDataReader mostrar = Comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception Error)
            {
                Console.WriteLine("Error en modelo-modificar ", Error);
                return null;
            }
        }
        public void funRecuperar(string Usuario, string Contraseña)
        {
            try
            {
                string cadena = "UPDATE" +
                " `componenteseguridad`.`Usuario` SET contraseña=" + Contraseña + "WHERE nombre=" + Usuario + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
            }
            catch (Exception Error)
            {
                Console.WriteLine("Error en modelo-modificar ", Error);
            }
        }

        public OdbcDataReader llenarcbxUsuario(string sql)
        {
            try
            {
                OdbcCommand datos = new OdbcCommand(sql, cn.conexion());
                OdbcDataReader leer = datos.ExecuteReader();
                return leer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        //mantenimiento Perfil

        public void funInsertar(string codigo_proveedor, string nombre_proveedor, string direccion_proveedor, string telefono_proveedor, string nit_proveedor, string estatus_proveedor)
        {

            string cadena = "INSERT INTO" +
            " `dbcompras`.`proveedores` VALUES (" + "'" + codigo_proveedor + "', '" + nombre_proveedor + "' , '" + direccion_proveedor + "', '" + telefono_proveedor + "', '" + nit_proveedor + "', '" + estatus_proveedor + "');";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();


        }


        public void funModificar(string codigo_proveedor, string nombre_proveedor, string direccion_proveedor, string telefono_proveedor, string nit_proveedor, string estatus_proveedor)
        {

            string cadena = "UPDATE dbcompras.proveedores set codigo_proveedor ='" + codigo_proveedor
              + "',nombre_proveedor ='" + nombre_proveedor + "',direccion_proveedor = " + direccion_proveedor + ",telefono_proveedor = " + telefono_proveedor + ",nit_proveedor = " + nit_proveedor + ",direccion_proveedor = " + direccion_proveedor + ",estatus_proveedor = " + estatus_proveedor + "  where codigo_proveedor= '" + codigo_proveedor + "';";


            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();




        }

        public void funEliminarPerfil(string codigo_proveedor)
        {

            string cadena = "delete from dbcompras.proveedores where pkId ='" + codigo_proveedor + "';";


            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

        }




        public (string, string, string, string, string) funBuscar(string codigo_proveedor, string nombre_proveedor, string direccion_proveedor, string telefono_proveedor, string nit_proveedor, string estatus_proveedor)
        {


            string Query = "select * from `dbcompras`.`proveedores` where pkId='" + codigo_proveedor + "';";

            OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {

                nombre_proveedor = busqueda["nombre_proveedor"].ToString();
                direccion_proveedor = busqueda["direccion_proveedor"].ToString();
                telefono_proveedor = busqueda["telefono_proveedor"].ToString();
                nit_proveedor = busqueda["nit_proveedor"].ToString();
                estatus_proveedor = busqueda["estatus_proveedor"].ToString();

            }


            return (nombre_proveedor, direccion_proveedor, telefono_proveedor, nit_proveedor, estatus_proveedor);
        }


        

    }
}
