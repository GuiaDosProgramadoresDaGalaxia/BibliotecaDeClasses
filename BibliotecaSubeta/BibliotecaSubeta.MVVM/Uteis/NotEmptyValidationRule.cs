using System.Globalization;
using System.Windows.Controls;

namespace BibliotecaSubeta.MVVM.Uteis
{
    /// <summary>
    /// Validação basica para compos de texto da view
    /// </summary>
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false, "Campo Obrigatorio")
                : ValidationResult.ValidResult;
        }
    }
}
