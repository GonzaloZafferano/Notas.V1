using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace NotasDeEscritorio
{
    public partial class FrmCambiarTitulo : Form
    {
        private Tema tema;
        private Nota nota;
        public FrmCambiarTitulo(Nota nota, Tema tema)
        {
            InitializeComponent();
            this.nota = nota;
            this.tema = tema;
        }

        /// <summary>
        /// Carga el tema actual en la aplicacion.
        /// </summary>
        private void CargarTema()
        {
            this.BackColor = tema.ColorDeFondoAplicacion;

            foreach (Control control in this.Controls)
            {
                control.BackColor = tema.ColorDeFondoAplicacion;
                control.ForeColor = tema.ColorDeLetra;

                if (control is Button boton)
                {
                    boton.FlatStyle = FlatStyle.Flat;
                    boton.FlatAppearance.BorderColor = tema.ColorDeBordeDeBoton;
                    boton.FlatAppearance.MouseDownBackColor = tema.ColorMouseDown;
                    boton.FlatAppearance.MouseOverBackColor = tema.ColorMouseOver;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.nota.ModificarTituloNota = this.txtTitulo.Text;
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }  

        private void FrmCambiarTitulo_Load(object sender, EventArgs e)
        {
            this.lblTituloActualDeNota.Text = this.nota.TituloDeNota;
            this.CargarTema();
        }
    }
}
