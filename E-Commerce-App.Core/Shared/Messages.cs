using System;
using System.IO;
using System.Threading.Tasks;

namespace E_Commerce_App.Core.Shared
{
    public static class Messages
    {
        public const string REQUIRED_INPUT = "Este campo no puede dejarse en blanco.";
        public static string RANGE_INPUT(string min, string max)
            => $"Este campo puede tomar valores entre {min} y {max}";


        public static string JSON_CREATE_MESSAGE(string type, bool state = true)
        {
            if (state == true) return $"{type} creado exitosamente.";
            else return $"{type} se produjo un error al crear.";
        }
        public static string JSON_REMOVE_MESSAGE(string type, bool state = true)
        {
            if (state == true) return $"{type} eliminado con éxito.";
            else return $"{type} Se produjo un error al eliminar";
        }

        public static string EMAIL_CONFIRM_MESSAGE()
        {
            return "";
        }


        public static string EMAIL_CONFIRM_HTML(string user, string url)
        {
            string file = System.IO.Path.GetDirectoryName(Directory.GetCurrentDirectory()) + "\\E-Commerce-App.Core\\Shared\\email-template.html";


            string emailHtml = System.IO.File.ReadAllText(file);

            emailHtml = emailHtml.Replace("#Usuario#", user);
            emailHtml = emailHtml.Replace("#Enlace#", url);

            return emailHtml;
        }



    }
}