using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceKKreme.Models
{
    public class ResponseBase<T>
    {
        public int codigoResultado { get; set; }

        public int codigoBaseDatos { get; set; }

        public bool esCorrecto { get; set; }

        public IEnumerable<string> detalles { get; set; }

        public string mensaje { get; set; }

        public T elemento { get; set; }

        public IEnumerable<T> lista { get; set; }

        public ResponseBase()
        {
            this.codigoResultado = (int)System.Net.HttpStatusCode.InternalServerError;
            this.esCorrecto = false;
            this.mensaje = "Ocurrió un error al realizar la operación indicada";
            this.detalles = new List<string>();
        }

        /// <summary>
        /// Asigna las propiedades predeterminadas para una consulta correcta
        /// </summary>
        /// <typeparam name="T">Objeto genérico que se regresará como lista o elemento</typeparam>
        /// <param name="r">Resultado estandar utilizado por business y data access</param>
        public void ConsultaCorrecta()
        {
            this.esCorrecto = true;
            this.codigoResultado = (int)System.Net.HttpStatusCode.OK;
            this.mensaje = "Consulta realizada correctamente";
        }

        public void ConsultaNoEncontrada()
        {
            this.esCorrecto = true;
            this.codigoResultado = (int)System.Net.HttpStatusCode.NotFound;
            this.mensaje = "No se encontraron resultados con la consulta solicitada";
        }

        /// <summary>
        /// Asigna las propiedades predeterminadas para una creación
        /// </summary>
        /// <typeparam name="T">Objeto genérico que se regresará como lista o elemento</typeparam>
        /// <param name="r">Resultado estandar utilizado por business y data access</param>
        public void CreacionCorrecta()
        {
            this.esCorrecto = true;
            this.codigoResultado = (int)System.Net.HttpStatusCode.Created;
            this.mensaje = "Información almacenada exitosamente";
        }

        /// <summary>
        /// Asigna las propiedades predeterminadas para una eliminación
        /// </summary>
        /// <typeparam name="T">Objeto genérico que se regresará como lista o elemento</typeparam>
        /// <param name="r">Resultado estandar utilizado por business y data access</param>
        public void EliminacionCorrecta()
        {
            this.esCorrecto = true;
            this.codigoResultado = (int)System.Net.HttpStatusCode.OK;
            this.mensaje = "Información eliminada exitosamente";
        }

        /// <summary>
        /// Asigna las propiedades predeterminadas para una actualización correcta
        /// </summary>
        /// <typeparam name="T">Objeto genérico que se regresará como lista o elemento</typeparam>
        /// <param name="r">Resultado estandar utilizado por business y data access</param>
        public void ActualizacionCorrecta()
        {
            this.esCorrecto = true;
            this.codigoResultado = (int)System.Net.HttpStatusCode.OK;
            this.mensaje = "Información actualizada exitosamente";
        }

        /// <summary>
        /// Asigna las propiedades predeterminades cuando se genera un error
        /// </summary>
        /// <param name="errorCode">Código de error que regresará la api</param>
        /// <param name="mensaje">Texto del mensaje del error</param>
        /// <param name="detalles">Lista de detalles a mostrar</param>
        public void Error(int errorCode, string mensaje, IEnumerable<string> detalles)
        {
            this.esCorrecto = false;
            this.codigoResultado = errorCode;
            this.mensaje = mensaje;
            this.detalles = detalles;
            this.elemento = default(T);
            this.lista = null;
        }
    }
}