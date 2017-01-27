using BibliotecaSubeta.MVVM.Dialogs;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaSubeta.MVVM.Uteis
{
    /// <summary>
    /// Classe para verificar se os campos 'required' da model foi preenchido corretamente.
    /// </summary>
    public class Validacao
    {
        /// <summary>
        /// Reflete os DataAnnotation [Required()] das Models
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Campos(Model model)
        {
            var result = new List<ValidationResult>();
            var context = new ValidationContext(model, null, null);
            return Validator.TryValidateObject(model, context, result, false);
        }

        /// <summary>
        /// Mostra um dialog (AlertViewModelDialog) para informar falta de preenchimento em campos 'Required'.
        /// O dialog precisa ser injetado atravez do DependecyService
        /// </summary>
        /// <param name="mensagem"></param>
        public static void showDialogValidation(string mensagem)
        {
            var dialog = DependecyService.ObterDialog(new AlertViewModelDialog("Preencha os Campos Obrigatorios!", null));
            var result = DialogHost.Show(dialog, "MessageBox");
        }
    }
}
