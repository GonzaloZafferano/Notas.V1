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

        public FrmCambiarTitulo(Nota nota)
        {
            InitializeComponent();

            this.nota = nota;
            this.tema = FrmNotas.temaAplicacion;
        }

        private void FrmCambiarTitulo_Load(object sender, EventArgs e)
        {
            this.lblTituloActualDeNota.Text = this.nota.TituloDeNota;
            this.CargarTema();
        }

        /// <summary>
        /// Carga el tema actual en la aplicacion.
        /// </summary>
        private void CargarTema()
        {
            this.BackColor = tema.ColorDeFondoAplicacion;

            foreach (Control control in this.Controls)
            {
                control.BackColor = this.tema.ColorDeFondoAplicacion;
                control.ForeColor = this.tema.ColorDeLetra;

                if (control is Button boton)
                {
                    boton.FlatStyle = FlatStyle.Flat;
                    boton.FlatAppearance.BorderColor = this.tema.ColorDeBordeDeBoton;
                    boton.FlatAppearance.MouseDownBackColor = this.tema.ColorMouseDown;
                    boton.FlatAppearance.MouseOverBackColor = this.tema.ColorMouseOver;
                }
            }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
