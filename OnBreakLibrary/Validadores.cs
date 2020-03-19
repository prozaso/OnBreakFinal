using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class Validadores
    {

        public bool validarRut(string rut)
        {

            try
            {
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                //guardamos el penultimo digito para validar si es guion
                //string guion = rut[rut.Length - 2].ToString();
                ////guardamos el ultimo digito para validar si es un numero
                //string dv = rut[rut.Length - 1].ToString();

                //Regex val = new Regex("^\d{1,2}\.\d{3}\.\d{3}[-][0-9kK]{1}$");

                if (rut.Length > 7 && rut.Length < 10)
                {

                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool validarCorreo(string correo)
        {
            bool isEmail = Regex.IsMatch(correo, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

            return isEmail;
        }

        //public static bool IsValidEmail(string email)
        //{
        //    if (string.IsNullOrWhiteSpace(email))
        //        return false;

        //    try
        //    {
        //        // Normalize the domain
        //        email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
        //                              RegexOptions.None, TimeSpan.FromMilliseconds(200));

        //        // Examines the domain part of the email and normalizes it.
        //        string DomainMapper(Match match)
        //        {
        //            // Use IdnMapping class to convert Unicode domain names.
        //            var idn = new IdnMapping();

        //            // Pull out and process domain name (throws ArgumentException on invalid)
        //            var domainName = idn.GetAscii(match.Groups[2].Value);

        //            return Path.Groups[1].Value + domainName;
        //        }
        //    }
        //    catch (RegexMatchTimeoutException)
        //    {
        //        return false;
        //    }
        //    catch (ArgumentException)
        //    {
        //        return false;
        //    }

        //    try
        //    {
        //        return Regex.IsMatch(email,
        //            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        //            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
        //            RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        //    }
        //    catch (RegexMatchTimeoutException)
        //    {
        //        return false;
        //    }
        //}

        public static bool validadorTexto(string texto)
        {
            Regex validadorLetras = new Regex(@"^[a-zA-Z]+$");

            if (validadorLetras.IsMatch(texto))
            {
                return true;
            }
            return false;
        }

        public static bool validadorTelefono(string correo)
        {
            Regex validadorTelefono = new Regex(@"^[0-9-+]+$");

            if (validadorTelefono.IsMatch(correo))
            {
                return true;
            }
            return false;
        }

        public static bool validadorNumerico(int numero)
        {
            Regex validadorNum = new Regex(@"^[0-9]+$");

            if (validadorNum.IsMatch(numero.ToString()))
            {
                return true;
            }
            return false;
        }



    }
}
