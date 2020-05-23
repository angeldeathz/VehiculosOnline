using System;
using Newtonsoft.Json;

namespace VehiculosOnline.Transversal.Errores
{
    public class ErrorDetail
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string ObtenerException(Exception exception)
        {
            var excepcionCompleta = string.Empty;

            while (exception != null)
            {
                excepcionCompleta += exception.StackTrace + "\r\n";
                exception = exception.InnerException;
            }

            return excepcionCompleta;

            //if (exception == null) return null;
            //var stackTrace = exception.StackTrace + "\r\n";
            //if (exception.InnerException != null) this.ObtenerException(exception.InnerException);
            //return stackTrace;
        }
    }
}
