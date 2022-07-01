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
    public partial class FrmPassword : Form
    {
        Tema tema;
        public FrmPassword()
        {
            InitializeComponent();
            this.tema = FrmNotas.temaAplicacion;
        }

        private void FrmPassword_Load(object sender, EventArgs e)
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

        private void btnQuitarPassword_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["Password"] = string.Empty;
            Properties.Settings.Default.Save();

            MessageBox.Show("Contraseña removida con exito!", "Aviso: Contraseña removida.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            this.Close();
        }

        private void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(this.txtIngresarPassword.Text) &&
                !string.IsNullOrWhiteSpace(this.txtConfirmarPassword.Text))
            {
                if(this.txtIngresarPassword.Text == this.txtConfirmarPassword.Text)
                {
                    Properties.Settings.Default["Password"] = this.txtConfirmarPassword.Text;
                    Properties.Settings.Default.Save();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden.", "Aviso: Contraseña invalida.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una contraseña.", "Aviso: Ingrese contraseña.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
