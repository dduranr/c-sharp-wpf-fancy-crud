namespace WPF_Fancy_CRUD.Misc
{
    public class Helpers
    {
        /// <summary>
        /// Convierte en mayúscula la 1ra letra de la cadena que se le pasa como parámetro.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Letra1Mayus(string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }

    }
}
