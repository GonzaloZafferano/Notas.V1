using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class Nota
    {
        public static event Action<string> OnMensajeDeError;
        private const string rutaRelativaArchivo = "Notas/Notas";
        private static List<Nota> notas;
        private int idDeNota;
        private string tituloDeNota;
        private string textoDeNota;
        private string fuente;
        private FontStyle estiloDeFuente;
        private float tamanioFuente;
        private Dimension tamanioVentanaNota;
        private Dimension posicionVentanaNota;
        private ColorARGB colorFondo;
        private ColorARGB colorLetra;
        private bool seGuardoNotaAbierta;

        [JsonConstructor]
        public Nota()
        {

        }

        public Nota(string titulo)
        {
            this.TituloDeNota = titulo;
            this.TamanioVentanaNota = new Dimension(100, 100);
            this.IdDeNota = IdentificadorUnico.IdentificadorUnicoNota.ObtenerIdUnicoParaNota();
        }

        public string TituloDeNota
        {
            get
            {
                string retorno = this.tituloDeNota;

                if (string.IsNullOrWhiteSpace(this.tituloDeNota))
                {
                    retorno = string.Format("Nota sin titulo - Nota número: {0:D4}", this.IdDeNota);
                }
                return retorno;
            }            
            set
            {
                this.tituloDeNota = value;
            }
        }       

        [JsonIgnore]
        public static List<Nota> Notas { get => notas; }

        [JsonIgnore]
        [Browsable(false)]
        public string ModificarTituloNota
        {
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new NullReferenceException("Debe indicar un título para la nota.");
                }
                
                for(int i = 0; i < Nota.notas.Count; i++)
                {
                    if(Nota.notas[i].TituloDeNota == value)
                    {
                        throw new ArgumentException("El titulo de la nota ya existe.");
                    }
                }

                this.tituloDeNota = value;
            }
        }

        [JsonIgnore]
        [Browsable(false)]
        public Color ColorFondoNota
        {
            get
            {
                if (this.colorFondo == null)
                {
                    return Color.White;
                }
                return Color.FromArgb(this.ColorFondo.Alfa, this.ColorFondo.Rojo, this.ColorFondo.Verde, this.ColorFondo.Azul);
            }
            set
            {
                this.ColorFondo = new ColorARGB(value.R, value.G, value.B, value.A);
            }
        }

        [JsonIgnore]
        [Browsable(false)]
        public Color ColorLetraNota
        {
            get
            {
                if(this.colorLetra == null)
                {
                    return Color.Black;
                }
                return Color.FromArgb(this.ColorLetra.Alfa, this.ColorLetra.Rojo, this.ColorLetra.Verde, this.ColorLetra.Azul);
            }
            set
            {
                this.ColorLetra = new ColorARGB(value.R, value.G, value.B, value.A);
            }
        }

        [JsonIgnore]
        [Browsable(false)]
        public Point PointNota
        {
            get
            {
                if(this.posicionVentanaNota == null)
                {
                    return new Point(0, 0);
                }
                return new Point(this.posicionVentanaNota.HorizontalX, this.posicionVentanaNota.VerticalY);
            }
            set
            {
                this.posicionVentanaNota = new Dimension(value.Y, value.X);
            }
        }

        [Browsable(false)]
        public string Texto { get => textoDeNota; set => textoDeNota = value; }

        [Browsable(false)]
        public FontStyle EstiloDeFuente { get => estiloDeFuente; set => estiloDeFuente = value; }

        [Browsable(false)]
        public float TamanioFuente { get => tamanioFuente; set => tamanioFuente = value; }         

        [Browsable(false)]
        public int IdDeNota { get => idDeNota; set => idDeNota = value; }

        [Browsable(false)]
        public string Fuente { get => fuente; set => fuente = value; }

        [Browsable(false)]
        public ColorARGB ColorFondo { get => colorFondo; set => colorFondo = value; }

        [Browsable(false)]
        public ColorARGB ColorLetra { get => colorLetra; set => colorLetra = value; }

        [Browsable(false)]
        public Dimension TamanioVentanaNota { get => tamanioVentanaNota; set => tamanioVentanaNota = value; }

        [Browsable(false)]
        public Dimension PosicionVentanaNota { get => posicionVentanaNota; set => posicionVentanaNota = value; }

        [Browsable(false)]
        public bool SeGuardoNotaAbierta { get => seGuardoNotaAbierta; set => seGuardoNotaAbierta = value; }

        /// <summary>
        /// Guarda las notas en un archivo .json
        /// </summary>
        public static void GuardarNotasEnArchivo()
        {
            try
            {  
               SerializadorJSON<List<Nota>>.Guardar(Nota.rutaRelativaArchivo, notas);
            }
            catch(Exception ex)
            {
                if(Nota.OnMensajeDeError != null)
                {
                    Nota.OnMensajeDeError.Invoke(ex.Message +"Ha ocurrido un error al intentar guardar cambios. Por favor reintente más tarde.");
                }
            }
        }

        /// <summary>
        /// Lee las notas de un archivo .json
        /// </summary>
        /// <returns></returns>
        public static bool LeerNotasDeArchivo()
        {
            try
            {
                Nota.notas = SerializadorJSON<List<Nota>>.Leer(Nota.rutaRelativaArchivo);

                return true;
            }
            catch (Exception)
            {
                if (Nota.OnMensajeDeError != null)
                {
                    Nota.OnMensajeDeError.Invoke("No se encontraron notas para leer. Se creara una nueva lista de notas.");
                }
                Nota.notas = new List<Nota>();
                return false;
            }
        }

        /// <summary>
        /// Guarda una nota (no guarda null ni duplicados) en la lista de notas, y luego guarda todas las notas en el archivo.
        /// </summary>
        /// <param name="nota">Nota a guardar.</param>
        public static void GuardarNotaEnListaDeNotasYEnArchivo(Nota nota)
        {
            Nota.GuardarNotaEnListaDeNotas(nota);
            Nota.GuardarNotasEnArchivo();
        }

        /// <summary>
        /// Guarda una nota (no guarda null ni duplicados) en la lista de notas.
        /// </summary>
        /// <param name="nota">Nota a guardar.</param>
        public static void GuardarNotaEnListaDeNotas(Nota nota)
        {
            if (nota != null && Nota.notas != nota)
            {
                Nota.notas.Add(nota);
            }
        }

        /// <summary>
        /// Elimina todas las notas, y guarda el archivo.
        /// </summary>
        public static void EliminarTodasLasNotas()
        {
            Nota.notas.Clear();
            Nota.GuardarNotasEnArchivo();
        }

        /// <summary>
        /// Elimina una nota de la lista de notas.
        /// </summary>
        /// <param name="nota">Nota a eliminar.</param>
        public static void EliminarNota(Nota nota)
        {
            if(nota is not null)
            {
                for(int i = 0; i < Nota.notas.Count; i++)
                {
                    if(Nota.notas[i].IdDeNota == nota.IdDeNota)
                    {
                        Nota.notas.RemoveAt(i);
                        Nota.GuardarNotasEnArchivo();    
                        
                        break;
                    }
                }
            }
        }

        public static bool operator ==(List<Nota> notas, Nota nota)
        {
            bool retorno = false;
            if(notas is not null && nota is not null)
            {
                for (int i = 0; i < notas.Count; i++)
                {
                    if(notas[i].IdDeNota == nota.IdDeNota)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }

        public static bool operator !=(List<Nota> notas, Nota nota)
        {
            return !(notas == nota);
        }
    }
}
