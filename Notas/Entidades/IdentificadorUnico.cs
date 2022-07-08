using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class IdentificadorUnico 
    {
        private const string rutaRelativaArchivo = "Ids/UltimoIdNotas";
        private static IdentificadorUnico identificadorUnicoNota;
        private static int notaId;

        /// <summary>
        /// Constructor estatico de la clase IdentificadorUnico. Inicializa un objeto de tipo IdentificadorUnico.
        /// Lee el archivo de Ids y los carga en el sistema.
        /// </summary>
        static IdentificadorUnico()
        {                 
            if (!IdentificadorUnico.LeerArchivoDeIds())
            {
                IdentificadorUnico.identificadorUnicoNota = new IdentificadorUnico();
                IdentificadorUnico.IdentificadorUnicoNota.NotaId = 0; 
            }
        }

        /// <summary>
        /// Retorna el objeto estatico que contiene el ultimo id de las notas.
        /// </summary>
        public static IdentificadorUnico IdentificadorUnicoNota
        {
            get
            {
                return IdentificadorUnico.identificadorUnicoNota;
            }
            private set
            {
                IdentificadorUnico.identificadorUnicoNota = value;
            }
        }

        /// <summary>
        /// Propiedad para Serializacion. Obtiene y setea el id de la ultima nota. 
        /// </summary>
        public int NotaId
        {
            get
            {
                return IdentificadorUnico.notaId;
            }
            set
            {
                IdentificadorUnico.notaId = value;
            }
        }

        /// <summary>
        /// Obtiene un Id Unico para una Nota
        /// </summary>
        /// <returns>Id Unico para una Nota</returns>
        /// <exception cref="Exception">Error externo.</exception>
        public int ObtenerIdUnicoParaNota()
        {
            int retorno = ++this.NotaId;

            try
            {
                this.GuardarArchivo();
            }
            catch (Exception) { }

            return retorno;
        }

        /// <summary>
        /// Guarda los ids en un archivo.
        /// </summary>
        /// <exception cref="Exception">Error externo.</exception>
        private bool GuardarArchivo()
        {
            try
            {
                return SerializadorJSON<IdentificadorUnico>.Guardar(IdentificadorUnico.rutaRelativaArchivo, IdentificadorUnico.IdentificadorUnicoNota);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error externo al sistema al intentar serializar los Ids. Clase IdentificadorUnico. Revisar InnerException", ex);
            }
        }

        /// <summary>
        /// Obtiene los datos de IDS que estan respaldados en un archivo, y lo carga al sistema.
        /// </summary>
        /// <returns>True si leyo el archivo sin problemas, caso contrario False.</returns>
        private static bool LeerArchivoDeIds()
        {
            try
            {
                IdentificadorUnico.IdentificadorUnicoNota = SerializadorJSON<IdentificadorUnico>.Leer(IdentificadorUnico.rutaRelativaArchivo);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
