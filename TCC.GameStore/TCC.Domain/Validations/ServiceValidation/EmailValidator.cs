using System.Text.RegularExpressions;

namespace TCC.GameStore.Domain.Validations.ServiceValidation
{
    public static class EmailValidator
    {
        public static bool IsValidEmail(this string email)
        {
            string regex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(email, regex);
        }
    }
}
