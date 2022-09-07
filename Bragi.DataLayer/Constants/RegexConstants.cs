namespace Bragi.DataLayer.Constants
{
    public class RegexConstants
    {
        public static string Names = @"^[a-zA-ZñÑ][a-zA-ZñÑ\s]*$";
        public static string Document = @"^(?!^0+$)([aA-zZ0-9]{5,10})$";
        public static string PhoneNumber = @"^[0-9]{3}-[0-9]{3}-[0-9]{4}$";
        public static string PhoneNumberDO = @"^(829|809|849)-\d{3}-\d{4}$";
        public static string Address = @"^[.#0-9a-zA-Z][.#0-9a-zA-Z\s]*$";
        //public static string RussianCharacters = @"[ЁёА-я]";
        public static string RussianCharacters = "/[а-яА-ЯЁё]/";
        public static string Cedula = "^[0-9]{3}-[0-9]{7}-[0-9]{1}$";
        public static string Passport = @"^[a-zA-Z0-9]+$";
    }
}
