using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class frmMIDSeguridad : Form
    {
        public frmMIDSeguridad()
        {
            InitializeComponent();
            CenterToScreen();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            //nombreform form3 = new nombreform();
            //form3.MdiParent = this.MdiParent;

            //form3.Show();

        }

        private void btnAplicacion_Click(object sender, EventArgs e)
        {
            frmMantenimientoAplicacion form3 = new frmMantenimientoAplicacion();
            form3.MdiParent = this.MdiParent;

            form3.Show();
        }

        private void btnModulos_Click(object sender, EventArgs e)
        {

        }

        private void btnPerfiles_Click(object sender, EventArgs e)
        {
            frmMantenimientoPerfil form3 = new frmMantenimientoPerfil();
            form3.MdiParent = this.MdiParent;

            form3.Show();
        }

       


       

        private void btnBitacora_Click(object sender, EventArgs e)
        {

        }

        
    }
}
