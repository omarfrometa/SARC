using System.Collections.Generic;
using System.Linq;

namespace SARC.Service.Helpers
{
    public class Error
    {
        static Dictionary<int, string> errores = new Dictionary<int, string>();

        public const int NotFoundError = 0;
        public const int UnexpectedError = 1;
        public const int RecordNotFound = 2;
        public const int InvalidToken = 3;
        public const int InternalServerError = 4;
        public const int ModelIsNotValid = 5;
        public const int LoginFail = 6;

        static void FillErrors()
        {
            if (errores.Count > 0)
                return;

            errores.Add(0, "Ningun Error Encontrado");
            errores.Add(1, "Se ha Producido un error inesperado");
            errores.Add(2, "El registro no ha sido encontrado");
            errores.Add(3, "Token no Valido");
            errores.Add(4, "Error Interno");
            errores.Add(5, "El Modelo es Invalido");
            errores.Add(6, "Credenciales Invalidas");
        }


        public static string GetErrorMessage(int Error)
        {
            FillErrors();

            return errores.SingleOrDefault(e => e.Key == Error).Value;
        }
    }
}
