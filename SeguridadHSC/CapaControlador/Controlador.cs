using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaModelo;

namespace CapaControlador
{
    public class Controlador
    {
        Sentencias sn = new Sentencias();

        //frmLogin
        public int InicarSesion(string documento_compraenca, string codigo_producto, int validar)
        {
            validar = sn.funIniciarSesion(documento_compraenca, codigo_producto, validar);

            return validar;
        }

        //frmMantenimientoAplicacion
        public void insertarAplicacion(string documento_compraenca, string codigo_producto, float cantidad_compradet, float costo_compradet, string codigo_bodega)
        {
            sn.funInsertar(documento_compraenca, codigo_producto, cantidad_compradet,  costo_compradet,  codigo_bodega);
        }

        public void modificarAplicacion(string documento_compraenca, string codigo_producto, float cantidad_compradet, float costo_compradet, string codigo_bodega)
        {
            sn.funModificar(documento_compraenca, codigo_producto, cantidad_compradet, costo_compradet, codigo_bodega);


        }

        public (string, string, float, float,string) buscarAplicacion(string documento_compraenca, string codigo_producto, float cantidad_compradet, float costo_compradet, string codigo_bodega)
        {
            sn.funBuscar(documento_compraenca, codigo_producto, cantidad_compradet, costo_compradet, codigo_bodega);
            return (documento_compraenca, codigo_producto, cantidad_compradet, costo_compradet, codigo_bodega);
        }

        public void eliminarAplicacion(string documento_compraenca)
        {
            sn.funEliminar(documento_compraenca);
        }

        //frmPerfiles
        public DataTable PerfilllenarTbl(string tabla2)
        {
            OdbcDataAdapter dt = sn.PerfilllenarTbl(tabla2);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }


        public DataTable PerfilllenarTblPersonal(string tabla2, string condicion)
        {
            OdbcDataAdapter dt = sn.PerfilllenarTblPersonal(tabla2, condicion);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }


        public DataTable PerfilllenarNombre(string tabla, string condicion)
        {
            OdbcDataAdapter dt = sn.PerfilllenarNombre(tabla, condicion);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }


        public void Perfilagregar(string tabla3, string valor1, string valor2)
        {
            sn.Perfilagregar(tabla3, valor1, valor2);
        }

        public void Perfileliminar(string tabla3, string valor1, string valor2)
        {
            sn.Perfileliminar(tabla3, valor1, valor2);
        }

        public void perfilPerfileliminartodo(string tabla3, string valor1)
        {
            sn.Perfileliminartodo(tabla3, valor1);
        }

        public void perfilPerfilagregartodo(string tabla3, string valor1, string valor2, string tabla2)
        {
            sn.Perfilagregartodo(tabla3, valor1, valor2, tabla2);
        }

        



        //frmRecuperarContraseña
        //frmRContraseña
     


        //Mantenimiento Perfil


        public void insertarPerfil(string codigo_proveedor, string nombre_proveedor, string  direccion_proveedor, string telefono_proveedor,string nit_proveedor, string estatus_proveedor)
        {
            sn.funInsertar( codigo_proveedor,  nombre_proveedor,   direccion_proveedor,  telefono_proveedor,  nit_proveedor,  estatus_proveedor);
        }

        public void modificarPerfil(string codigo_proveedor, string nombre_proveedor, string direccion_proveedor, string telefono_proveedor, string nit_proveedor, string estatus_proveedor)
        {
            sn.funModificar(codigo_proveedor, nombre_proveedor, direccion_proveedor, telefono_proveedor, nit_proveedor, estatus_proveedor);


        }

        public (string, string, string, string, string) buscarPerfil(string codigo_proveedor, string nombre_proveedor, string direccion_proveedor, string telefono_proveedor, string nit_proveedor, string estatus_proveedor)
        {
            sn.funBuscar(codigo_proveedor, nombre_proveedor, direccion_proveedor, telefono_proveedor, nit_proveedor, estatus_proveedor);
            return ( nombre_proveedor, direccion_proveedor, telefono_proveedor, nit_proveedor, estatus_proveedor);
        }

        public void eliminarPerfil(string codigo_proveedor)
        {
            sn.funEliminarPerfil(codigo_proveedor);
        }

       
    }
}
