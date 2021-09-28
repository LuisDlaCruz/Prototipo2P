using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador;



namespace CapaVista
{
    public partial class frmMantenimientoPerfil : Form
    {
        Controlador conAplicacion = new Controlador();
        public frmMantenimientoPerfil()
        {
            InitializeComponent();
        }

        

        public void funLimpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox3.Text = "";

        }



 
        private void frmMantenimientoPerfil_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet5.proveedores' Puede moverla o quitarla según sea necesario.
            this.proveedoresTableAdapter.Fill(this.dataSet5.proveedores);
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'dataSet3.perfil' Puede moverla o quitarla según sea necesario.
                this.proveedoresTableAdapter.Fill(this.dataSet5.proveedores);
            }
            catch (Exception Error)
            {
                Console.WriteLine("404", Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //public void funValidarPerfil()
        //{

        //    if (txtId.Text.Trim() != "" && txtPerfil.Text.Trim() != "")
        //    {
        //        MessageBox.Show("Insercion realizada");


        //    }
        //    else
        //    {

        //        MessageBox.Show("Error debe de ingresar todos los valores solicitados ");

        //    }
        //}

        private void btnIngresar_Click(object sender, EventArgs e)
        {



            conAplicacion.insertarPerfil(textBox1.Text, textBox2.Text, textBox5.Text, textBox4.Text, textBox6.Text, textBox3.Text);
            MessageBox.Show("Insercion realizada");
            funLimpiar();


            MessageBox.Show("Error debe de ingresar todos los valores solicitados ");



            actualizarTablaDeporte();

        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
           
            
               
                conAplicacion.modificarPerfil(textBox1.Text, textBox2.Text, textBox5.Text, textBox4.Text, textBox6.Text, textBox3.Text);
                MessageBox.Show("Insercion realizada");
                funLimpiar();
            
            actualizarTablaDeporte();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            conAplicacion.eliminarPerfil(textBox1.Text);
            MessageBox.Show("Eliminacion realizada");
            funLimpiar();
            actualizarTablaDeporte();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            funLimpiar();
        }


        public void actualizarTablaDeporte()
        {
            try
            {
                this.proveedoresTableAdapter.Fill(this.dataSet5.proveedores);
                //CapaVista.deporteTableAdapter.Fill(vista.vwDeportes.deporte);
            }
            catch (Exception Error)
            {
                Console.WriteLine("404 ", Error);
            }

        }

       

        private void perfilTabla_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            textBox1.Text = perfilTabla.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = perfilTabla.CurrentRow.Cells[1].Value.ToString();
            textBox5.Text = perfilTabla.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = perfilTabla.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = perfilTabla.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = perfilTabla.CurrentRow.Cells[4].Value.ToString();


        }
    }




}
