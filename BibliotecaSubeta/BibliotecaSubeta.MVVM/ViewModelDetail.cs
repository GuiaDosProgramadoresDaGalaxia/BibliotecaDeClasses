using BibliotecaSubeta.Dominio;
using BibliotecaSubeta.MVVM.Dialogs;
using BibliotecaSubeta.MVVM.Uteis;
using MaterialDesignThemes.Wpf;
using System.Windows;

namespace BibliotecaSubeta.MVVM
{
    /// <summary>
    /// Classe que contem os comportamentos básicos de janelas de criação e de detelhe de models
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public abstract class ViewModelDetail<TModel> : ViewModelBase, IViewModelDetail where TModel : Model, new()
    {
        /// <summary>
        /// Tipo da janela: Criar ou Editar
        /// </summary>
        public Janela Tipo { get; set; }
   
        private TModel model;

        /// <summary>
        /// Model contextual para os bidings
        /// </summary>
        public TModel Model
        {
            get { return model; }
            set { model = value; OnPropertyChanged("Model"); }
        }

        /// <summary>
        /// Botão de Salvar
        /// </summary>
        public Command<Window> DefaultCommand { get; set; }

        /// <summary>
        /// Botao de cancelar
        /// </summary>
        public Command<Window> CancelCommand { get; set; }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="model">Model contextual</param>
        /// <param name="tipo">Tipo da janela</param>
        /// <param name="repositorio">Repositorio usado na aplicação</param>
        public ViewModelDetail(TModel model, Janela tipo, IRepositorio repositorio) : base(repositorio)
        {
            Tipo = tipo;
            Model = model;
            this.DefaultCommand = new Command<Window>(Confirmar);
            this.CancelCommand = new Command<Window>(Cancelar);
        }

        /// <summary>
        /// Deve ser chamado apos as operações do repositorio, para informar que a janela foi fechada com exito.
        /// Utilize 'CommandParameter="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type Window}}}"' para 
        /// conectar este metodo
        /// </summary>
        /// <param name="e">Janela do contexto</param>
        protected virtual void Confirmar(Window e)
        {
            e.DialogResult = true;
            e.Close();
        }

        /// <summary>
        /// Lança um dialog(CancelarViewModelDialog) de confirmação de fechamento da janela. Esse metodo necessita que o dialog seja injetado atraves
        /// do DependecyService. Utilize 'CommandParameter="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type Window}}}"'para 
        /// conectar este metodo
        /// </summary>
        /// <param name="e">Janela do contexto</param>
        protected async void Cancelar(Window e)
        {
            var dialog = DependecyService.ObterDialog(new CancelarViewModelDialog("Tem Certeza que Dejesa Cancelar?", repositorio));
            var result = await DialogHost.Show(dialog, "MessageBox");
            bool? resultado = result as bool?;

            if (resultado.HasValue && resultado.Value == true)
                e.DialogResult = false;
        }
    }
}
