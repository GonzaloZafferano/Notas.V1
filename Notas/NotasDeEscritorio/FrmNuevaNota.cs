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
    public partial class FrmNuevaNota : Form
    {
        public event Action<FrmNuevaNota, bool> OnNotaAbierta;
        public event Action OnRefrescarDataGrid;
        private Nota nota;
        private Tema tema;

        public FrmNuevaNota(Nota nota)
        {
            InitializeComponent();

            this.tema = FrmNotas.temaAplicacion;

            if (nota != null)
            {
                this.nota = nota;
                this.CargarColoresFuentesYContenidoAlForm(false);
                this.CargarTamanioYPosicionAlForm();
            }
            else
            {
                this.nota = new Nota(string.Empty);

                this.CargarTema();

                this.GuardarDatos(null);
            }
        }

        public Nota Nota
        {
            get
            {
                return this.nota;
            }
        }

        private void NuevaNota_Load(object sender, EventArgs e)
        {
            this.nota.SeGuardoNotaAbierta = true;
            this.MaximumSize = new Size(720, 570);
            this.MinimumSize = new Size(480, 300);

            if (this.OnNotaAbierta != null)
            {
                this.OnNotaAbierta.Invoke(this, false);
            }

            this.Text = this.nota.TituloDeNota;
            this.rTxtContenidoNota.BorderStyle = BorderStyle.None;
            this.lblCantidadCaracteres.BackColor = Color.Transparent;
            this.lblCantidadCaracteres.Text = this.nota.Texto.Length.ToString();

            Nota.GuardarNotaEnListaDeNotas(this.nota);

            if (this.OnRefrescarDataGrid != null)
            {
                this.OnRefrescarDataGrid.Invoke();
            }
        }

        private void rTxtContenidoNota_TextChanged(object sender, EventArgs e)
        {
            this.nota.Texto = rTxtContenidoNota.Text;
            this.lblCantidadCaracteres.Text = rTxtContenidoNota.Text.Length.ToString();
        }

        /// <summary>
        /// Guarda los datos de estilo recibidos por parametro en la nota. 
        /// Si recibe null, carga los datos actuales en la nota, la almacena en la lista de notas, 
        /// y la guarda en un archivo .json.
        /// </summary>
        /// <param name="opcionesDeFuente"></param>
        private void GuardarDatos(FontDialog opcionesDeFuente)
        {
            if(opcionesDeFuente != null)
            {
                this.nota.Fuente = opcionesDeFuente.Font.Name;
                this.nota.EstiloDeFuente = opcionesDeFuente.Font.Style;
                this.nota.TamanioFuente = opcionesDeFuente.Font.Size;
                this.nota.ColorLetraNota = opcionesDeFuente.Color;
            }
            else
            {
                this.nota.Fuente = this.rTxtContenidoNota.Font.Name;
                this.nota.EstiloDeFuente = this.rTxtContenidoNota.Font.Style;
                this.nota.TamanioFuente = this.rTxtContenidoNota.Font.Size;
                this.nota.ColorLetraNota = this.tema.ColorDeLetra;
                this.nota.ColorFondoNota = this.tema.ColorDeFondoAplicacion;
                this.nota.Texto = this.rTxtContenidoNota.Text;
                this.StartPosition = FormStartPosition.CenterScreen;

                this.ActualizarUbicacionYTamanio();
            }
        }

        /// <summary>
        /// Carga el tema actual en la aplicacion.
        /// </summary>
        private void CargarTema()
        {
            this.ColorParaResaltarControles(this.tema.ColorDeFondoAplicacion, -30, this.CargarColorResaltadoEnFondos);
            this.ColorParaResaltarControles(this.tema.ColorDeLetra, 0, this.CargarColorResaltadoEnLetras);
        }

        /// <summary>
        /// Carga el tamaño y la ubicacion en el form.
        /// </summary>
        private void CargarTamanioYPosicionAlForm()
        {
            this.Width = this.nota.TamanioVentanaNota.HorizontalX;
            this.Height = this.nota.TamanioVentanaNota.VerticalY;
            this.Location = this.nota.PointNota;
        }

        /// <summary>
        /// Actualiza la ubicacion y tamaño del formulario en el objeto Nota.
        /// </summary>
        private void ActualizarUbicacionYTamanio()
        {
            this.nota.PointNota = this.Location;
            this.nota.TamanioVentanaNota.VerticalY = this.Height;
            this.nota.TamanioVentanaNota.HorizontalX = this.Width;
        }

        /// <summary>
        /// Carga el form y controles con los datos de la nota.
        /// </summary>
        /// <param name="requiereResaltar">True si requiere resaltar el fondo de controles y letras, 
        /// False si requiere mantener los colores.</param>
        private void CargarColoresFuentesYContenidoAlForm(bool requiereResaltar)
        {
            this.rTxtContenidoNota.Text = this.nota.Texto;
            this.rTxtContenidoNota.Font = new Font(this.nota.Fuente, this.nota.TamanioFuente, this.nota.EstiloDeFuente);
                           
            this.ColorParaResaltarControles(this.nota.ColorFondoNota, -30, this.CargarColorResaltadoEnFondos);
            
            if(requiereResaltar)
            {
                this.ColorParaResaltarControles(this.nota.ColorFondoNota, 100, this.CargarColorResaltadoEnLetras);
            }
            else
            {
                this.rTxtContenidoNota.ForeColor = this.nota.ColorLetraNota;
                this.lblCantidadCaracteres.ForeColor = this.nota.ColorLetraNota;
                this.barraMenuStrip.ForeColor = this.nota.ColorLetraNota;
            }
        }

        /// <summary>
        /// Modifica un color base, en la medida de color especificada por parametro (-254 a 254), 
        /// y envia el color original y modificado a un delegado para que los utilice.
        /// </summary>
        /// <param name="colorBase">Color base a partir del cual se crearan otros colores.</param>
        /// <param name="medidaDeColor">Medida en la que se modificaran los colores (puede ser negativo o positivo, entre -254 a 254)</param>
        /// <param name="metodoDeAplicacionDeColores">Metodo que aplicara los colores modificados en los controles necesarios.</param>
        private void ColorParaResaltarControles(Color colorBase, int medidaDeColor, Action<Color,Color> metodoDeAplicacionDeColores)
        {
            Predicate<int> esColorValido = medidaDeColor >= 0 ? 
                                           color => color + medidaDeColor <= 254:
                                           color => color + medidaDeColor >= 1;
          
            int alfa = colorBase.A;
            int rojo = colorBase.R;
            int verde = colorBase.G;
            int azul = colorBase.B;

            alfa = esColorValido(alfa) ? alfa + medidaDeColor : alfa;
            rojo = esColorValido(rojo) ? rojo + medidaDeColor : rojo;
            verde = esColorValido(verde) ? verde + medidaDeColor : verde;
            azul = esColorValido(azul) ? azul + medidaDeColor : azul;

            Color colorModificado = Color.FromArgb(alfa, rojo, verde, azul);

            if(metodoDeAplicacionDeColores != null)
            {
                metodoDeAplicacionDeColores.Invoke(colorBase, colorModificado);
            }          
        }

        /// <summary>
        /// Carga los colores recibidos por parametros en los fondos de controles del formulario.
        /// </summary>
        /// <param name="colorOriginal">Color original.</param>
        /// <param name="colorModificado">Color modificado.</param>
        private void CargarColorResaltadoEnFondos(Color colorOriginal, Color colorModificado)
        {
            this.barraMenuStrip.BackColor = colorModificado;
            this.barraStatusStrip.BackColor = colorModificado;
            this.BackColor = colorOriginal;
            this.rTxtContenidoNota.BackColor = colorOriginal;
        }

        /// <summary>
        /// Carga los colores recibidos por parametros en las letras del formulario.
        /// </summary>
        /// <param name="colorOriginal">Color original.</param>
        /// <param name="colorModificado">Color modificado.</param>
        private void CargarColorResaltadoEnLetras(Color colorOriginal, Color colorModificado)
        {
            _ = colorOriginal;

            this.rTxtContenidoNota.ForeColor = colorModificado;
            this.lblCantidadCaracteres.ForeColor = colorModificado;
            this.barraMenuStrip.ForeColor = colorModificado;
            this.nota.ColorLetraNota = colorModificado;
        }

        private void CambiarTítuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCambiarTitulo cambiarTitulo = new FrmCambiarTitulo(this.nota);

            if (cambiarTitulo.ShowDialog() == DialogResult.OK)
            {
                this.Text = this.nota.TituloDeNota;

                this.nota.GuardarNotaAlFinalDeListaDeNotas();

                if(this.OnRefrescarDataGrid != null)
                {
                    this.OnRefrescarDataGrid.Invoke();
                }
            }
        }

        private void MostrarFuentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog opcionesDeFuente = new FontDialog();
            opcionesDeFuente.AllowScriptChange = false;
            opcionesDeFuente.ShowColor = true;
            opcionesDeFuente.Color = this.rTxtContenidoNota.ForeColor;
            opcionesDeFuente.Font = new Font(this.nota.Fuente, this.nota.TamanioFuente, this.nota.EstiloDeFuente);

            if (opcionesDeFuente.ShowDialog() == DialogResult.OK)
            {
                this.GuardarDatos(opcionesDeFuente);

                this.CargarColoresFuentesYContenidoAlForm(false);
            }
        }

        private void MostrarColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog opcionesDeColor = new ColorDialog();
            opcionesDeColor.Color = this.nota.ColorFondoNota;

            if(opcionesDeColor.ShowDialog() == DialogResult.OK)
            {
                this.nota.ColorFondoNota = opcionesDeColor.Color;

                this.CargarColoresFuentesYContenidoAlForm(true);
            }
        }

        private void NuevaNota_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.OnNotaAbierta != null)
            {
                this.OnNotaAbierta.Invoke(this, true);
            }

            this.nota.SeGuardoNotaAbierta = false;            
        }

        private void FrmNuevaNota_Deactivate(object sender, EventArgs e)
        {
            this.ActualizarUbicacionYTamanio();

            Nota.GuardarNotaEnListaDeNotasYEnArchivo(this.nota);
        }
    }
}
