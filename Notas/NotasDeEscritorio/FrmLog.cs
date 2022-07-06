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
    public partial class FrmLog : Form
    {
        private Tema tema;
        private string password;

        public FrmLog()
        {
            InitializeComponent();

            this.password = Properties.Settings.Default.Password;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.password = Properties.Settings.Default.Password;

            if (!string.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
                if(this.txtPassword.Text == this.password)
                {
                    this.Hide();

                    this.Loguear();
                }
                else
                {
                    MessageBox.Show("La contraseña es invalida.", "Aviso: Contraseña invalida.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese la contraseña.", "Aviso: Ingrese contraseña ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Loguea al usuario a la aplicacion (si la aplicacion no tiene contraseña), caso contrario solicita la contraseña.
        /// </summary>
        private void Loguear()
        {
            FrmNotas notas = new FrmNotas(this.tema);

            if (notas.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                this.CargarTema();
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// Carga el tema en el formulario;
        /// </summary>
        private void CargarTema()
        {
            string temaAplicacion = Properties.Settings.Default.TemaAplicacion;

            _ = Enum.TryParse(temaAplicacion, out Tema.Temas temaGuardado);
            this.tema = new Tema(temaGuardado);

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

        private void FrmLog_Load(object sender, EventArgs e)
        {
            this.Hide();

            this.CargarTema();

            if (string.IsNullOrEmpty(this.password))
            {
                this.Loguear();
            }
            else
            {
                this.Show();
            }
        }
    }
}
