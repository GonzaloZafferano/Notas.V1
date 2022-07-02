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
    public partial class FrmNotas : Form
    {        
        private List<FrmNuevaNota> notasAbiertas;
        private static Tema tema;
        private DataGridViewColumn columna;
        private DataGridViewButtonColumn botonEliminar;

        public FrmNotas(Tema tema)
        {
            InitializeComponent();

            FrmNotas.tema = tema;

            this.notasAbiertas = new List<FrmNuevaNota>();
            this.columna = new DataGridViewColumn();
            this.botonEliminar = new DataGridViewButtonColumn();

            Nota.OnMensajeDeError += this.MensajeError;
            Nota.LeerNotasDeArchivo();
        }

        public static Tema temaAplicacion
        {
            get
            {
                return FrmNotas.tema;
            }
        }

        /// <summary>
        /// Actualiza los datos del datagrid.
        /// </summary>
        private void RefrescarDataGrid()
        {     
            BindingList<Nota> notas = new BindingList<Nota>();

            for(int i = Nota.Notas.Count -1; i >= 0 ; i--)
            {
                notas.Add(Nota.Notas[i]);
            }

            this.dtgvNotas.DataSource = null;
            this.dtgvNotas.DataSource = notas;

            this.OrganizarDataGrid();
            this.CargarTemaEnDataGrid();
        }

        /// <summary>
        /// Prepara y da estilo a la columna con botones de eliminar.
        /// </summary>
        private void PrepararBotonEliminar()
        {
            this.botonEliminar.Name = "eliminar";
            this.botonEliminar.HeaderText = "Eliminar";
            this.botonEliminar.DefaultCellStyle.Font = new Font(this.Font.FontFamily, 20, FontStyle.Bold);
            this.botonEliminar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.botonEliminar.UseColumnTextForButtonValue = true;
            this.botonEliminar.Text = "-";
            this.botonEliminar.Width = 50;
        }

        /// <summary>
        /// Prepara y da estilo a la columna de notas.
        /// </summary>
        private void PrepararColumnaNotas()
        {
            this.columna.Name = "notas";
            this.columna.HeaderText = "Notas";
            this.columna.DataPropertyName = "TituloDeNota";
            this.columna.DefaultCellStyle.Font = new Font(this.Font.FontFamily, 14, FontStyle.Bold);
            this.columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.columna.CellTemplate = new DataGridViewTextBoxCell();
        }

        /// <summary>
        /// Organiza el datagrid, asignando una columna, titulo y estilos.
        /// </summary>
        private void OrganizarDataGrid()
        {
            this.dtgvNotas.Columns.Clear();
            this.dtgvNotas.Columns.Add(this.columna);
            this.dtgvNotas.Columns.Add(this.botonEliminar);

            this.dtgvNotas.Columns["eliminar"].DisplayIndex = 0;
            this.dtgvNotas.Columns["notas"].DisplayIndex = 1;
        }

        /// <summary>
        /// Muestra un mensaje con el texto recibido por parametro.
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar.</param>
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Evalua si una nota ya esta abierta.
        /// </summary>
        /// <param name="idNota">Id de la nota.</param>
        /// <returns>True si la nota ya esta abierta, caso contrario False.</returns>
        private bool EstaNotaAbierta(int idNota)
        {
            for (int i = this.notasAbiertas.Count -1; i >= 0; i--)
            {
                if (this.notasAbiertas[i].Nota.IdDeNota == idNota)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Carga o elimina la nota recibida por parametro, en la lista de notas abiertas.
        /// </summary>
        /// <param name="nota">Nota que se cargara a la lista.</param>
        /// <param name="eliminar">True para eliminar la nota de la lista, false para cargar la nota a la lista.</param>
        private void ActualizarListaDeNotasAbiertas(FrmNuevaNota nota, bool eliminar)
        {
            if(nota != null)
            {
                if(eliminar)
                {
                    this.notasAbiertas.Remove(nota);
                }
                else
                {
                    this.notasAbiertas.Add(nota);
                }
            }
        }

        /// <summary>
        /// Cierra una nota.
        /// </summary>
        /// <param name="id">Id de la nota a eliminar.</param>
        private void CerrarNotaAbiertaPorIdentificador(int id)
        {
            for(int i = 0; i < this.notasAbiertas.Count; i++)
            {
                if(this.notasAbiertas[i].Nota.IdDeNota == id && !this.notasAbiertas[i].IsDisposed)
                {
                    this.CerrarNotaAbiertaPorIndice(i);
                }
            }
        }

        /// <summary>
        /// Cierra todas las notas abiertas.
        /// </summary>
        private void CerrarTodasLasNotasAbiertas()
        {
            for(int i = this.notasAbiertas.Count -1; i >= 0 ; i--)
            {
                this.CerrarNotaAbiertaPorIndice(i);
            }
        }

        /// <summary>
        /// Cierra una nota abierta por su indice.
        /// </summary>
        /// <param name="indice">Indice de la nota que se cerrara.</param>
        /// <exception cref="IndexOutOfRangeException">Indice fuera de rango.</exception>
        private void CerrarNotaAbiertaPorIndice(int indice)
        {
            this.notasAbiertas[indice].OnRefrescarDataGrid -= this.RefrescarDataGrid;
            this.notasAbiertas[indice].Close();
        }

        /// <summary>
        /// Abre las notas que no se han cerrado al salir de la aplicacion la ultima vez.
        /// </summary>
        private void AbrirNotasActivas()
        {
            for(int i = 0; i < Nota.Notas.Count; i++)
            {
                if(Nota.Notas[i].SeGuardoNotaAbierta)
                {
                    this.CargarEventosYAbrirNota(Nota.Notas[i]);
                }
            }
        }

        /// <summary>
        /// Carga los eventos en el objeto de tipo "NuevaNota" y abre el formulario.
        /// </summary>
        /// <param name="nota">Nota a partir de la cual se abrira el formulario.</param>
        private void CargarEventosYAbrirNota(Nota nota)
        {
            FrmNuevaNota nuevaNota = new FrmNuevaNota(nota);
            nuevaNota.OnRefrescarDataGrid += this.RefrescarDataGrid;
            nuevaNota.OnNotaAbierta += this.ActualizarListaDeNotasAbiertas;

            nuevaNota.Show();
        }

        private void Notas_Load(object sender, EventArgs e)
        {
            this.Hide();                     

            this.btnAgregarNota.BringToFront();
            this.dtgvNotas.ColumnHeadersVisible = false;
            this.dtgvNotas.RowTemplate.Height = 100;

            this.PrepararBotonEliminar();
            this.PrepararColumnaNotas();

            this.RefrescarDataGrid();

            this.CargarTema();

            this.Show();

            this.AbrirNotasActivas();
        }

        private void dtgvNotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dtgvNotas.Rows.Count > e.RowIndex && this.dtgvNotas.Columns.Count > e.ColumnIndex)
                {
                    Nota nota = this.dtgvNotas.Rows[e.RowIndex].DataBoundItem as Nota;

                    if (((DataGridView)sender).Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {
                        DialogResult respuesta = MessageBox.Show("¿Desea eliminar esta nota?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (respuesta == DialogResult.Yes)
                        {
                            if (nota is not null)
                            {
                                this.CerrarNotaAbiertaPorIdentificador(nota.IdDeNota);

                                Nota.EliminarNota(nota);
                                this.RefrescarDataGrid();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void dtgvNotas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dtgvNotas.Rows.Count > e.RowIndex && this.dtgvNotas.Columns.Count > e.ColumnIndex)
                {
                    Nota nota = this.dtgvNotas.Rows[e.RowIndex].DataBoundItem as Nota;

                    if (nota is not null && ((DataGridView)sender).Columns[e.ColumnIndex] is DataGridViewColumn)
                    {
                        this.CerrarNotaAbiertaPorIdentificador(nota.IdDeNota);

                        nota.GuardarNotaAlFinalDeListaDeNotas();

                        this.CargarEventosYAbrirNota(nota);
                    }
                }
            }
            catch(Exception)
            {
            }
        }

        private void btnAgregarNota_Click(object sender, EventArgs e)
        {
            this.CargarEventosYAbrirNota(null);
        }

        #region Carga de Tema
        private void botonTema_Click(object sender, EventArgs e)
        {
            if(object.ReferenceEquals(sender, this.azulToolStripMenuItem))
            {
                tema = new Tema(Tema.Temas.Azul);
            }
            else if(object.ReferenceEquals(sender, this.verdeToolStripMenuItem))
            {
                tema = new Tema(Tema.Temas.Verde);
            }
            else
            {
                tema = new Tema(Tema.Temas.Rosa);
            }
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

            this.abrirTodasLasNotasToolStripMenuItem.BackColor = tema.ColorDeFondoAplicacion;
            this.abrirTodasLasNotasToolStripMenuItem.ForeColor = tema.ColorDeLetra;
            this.cerrarTodasLasNotasToolStripMenuItem.BackColor = tema.ColorDeFondoAplicacion;
            this.cerrarTodasLasNotasToolStripMenuItem.ForeColor = tema.ColorDeLetra; 
            this.borrarTodasLasNotasToolStripMenuItem.BackColor = tema.ColorDeFondoAplicacion;
            this.borrarTodasLasNotasToolStripMenuItem.ForeColor = tema.ColorDeLetra;

            this.CargarTemaEnDataGrid();

            this.botonEliminar.FlatStyle = FlatStyle.Flat;
            this.botonEliminar.DefaultCellStyle.SelectionBackColor = tema.ColorDeBordeDeBoton;
            this.dtgvNotas.Columns["eliminar"].DefaultCellStyle.BackColor = tema.ColorDeBordeDeBoton;
            this.dtgvNotas.Columns["eliminar"].DefaultCellStyle.ForeColor = tema.ColorDeLetra;

            this.dtgvNotas.BackgroundColor = tema.ColorDeBordeDeBoton;
            this.dtgvNotas.RowsDefaultCellStyle.SelectionBackColor = tema.ColorDeFondoLabelYListBox;

            Properties.Settings.Default["TemaAplicacion"] = tema.TemaAplicado.ToString();
            Properties.Settings.Default.Save(); 
        }

        /// <summary>
        /// Carga un tema en el datagrid.
        /// </summary>
        /// <param name="tema"></param>
        private void CargarTemaEnDataGrid()
        {
            for (int i = 0; i < this.dtgvNotas.Rows.Count; i++)
            {
                this.dtgvNotas.Rows[i].DefaultCellStyle.BackColor = tema.ColorDeBordeDeBoton;
            }
        }

        #endregion

        private void abrirTodasLasNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < Nota.Notas.Count; i++)
            {
                if(!EstaNotaAbierta(Nota.Notas[i].IdDeNota))
                {
                    this.CargarEventosYAbrirNota(Nota.Notas[i]);
                }
            }
        }

        private void cerrarTodasLasNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CerrarTodasLasNotasAbiertas();

            Nota.GuardarNotasEnArchivo();
        }

        private void borrarTodasLasNotasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(Nota.Notas.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show("¿Desea eliminar todas las notas?", "Aviso: Eliminar todas las notas.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    this.CerrarTodasLasNotasAbiertas();

                    Nota.EliminarTodasLasNotas();

                    this.RefrescarDataGrid();
                }
            }
        }

        private void passwordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPassword formularioDePassword = new FrmPassword();
            if(formularioDePassword.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Contraseña activada con exito! Se cerrara la sesion.", "Aviso: Cambio de contraseña exitoso.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.CerrarTodasLasNotasAbiertas();

                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
