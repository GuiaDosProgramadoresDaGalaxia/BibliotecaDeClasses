using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BibliotecaSubeta.MVVM.Uteis
{
    /// <summary>
    /// Classe de injeção de dependencia para Janelas, Listagens, dialogs e classes. Utilize no 'OnStartup' da aplicação.
    /// </summary>
    public static class DependecyService
    {
        private static readonly Dictionary<Type, Type> janelas = new Dictionary<Type, Type>();
        private static readonly Dictionary<Type, Type> listagens = new Dictionary<Type, Type>();
        private static readonly Dictionary<Type, Type> dialogs = new Dictionary<Type, Type>();
        private static readonly Dictionary<Type, Type> classes = new Dictionary<Type, Type>();

        /// <summary>
        /// Registra uma Janela (Window) as sua respectiva ViewModel
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel tipo Detail</typeparam>
        /// <typeparam name="TView">Janela (Window)</typeparam>
        public static void RegistrarJanela<TViewModel, TView>() where TView : Window where TViewModel : ViewModelBase, IViewModelDetail
        {
            janelas.Add(typeof(TViewModel), typeof(TView));
        }

        /// <summary>
        /// Registra uma listagem (UserControl) as sua respectiva ViewModel
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel tipo List</typeparam>
        /// <typeparam name="TView">Listagem (UserControl)</typeparam>
        public static void RegistrarListagem<TViewModel, TView>() where TView : UserControl where TViewModel : ViewModelBase, IViewModelList
        {
            listagens.Add(typeof(TViewModel), typeof(TView));
        }

        /// <summary>
        /// Registra uma dialog (UserControl) as sua respectiva ViewModel
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel tipo Dialog</typeparam>
        /// <typeparam name="TView">Listagem (UserControl)</typeparam>
        public static void RegistrarDialog<TViewModel, TView>() where TView : UserControl where TViewModel : ViewModelBase, IViewModelDialog
        {
            dialogs.Add(typeof(TViewModel), typeof(TView));
        }

        /// <summary>
        /// Registra uma interface a sua respectiva classe de implementação
        /// </summary>
        /// <typeparam name="TInterface">Interface</typeparam>
        /// <typeparam name="TClasse">Classe que implemente a interface</typeparam>
        public static void RegistrarDependencia<TInterface, TClasse>() where TInterface : class where TClasse : class, TInterface
        {
            classes.Add(typeof(TInterface), typeof(TClasse));
        }

        /// <summary>
        /// Cria uma instancia da janela conectada a sua view model
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel tipo Detail</typeparam>
        /// <param name="viewModel">ViewModel a ser injetada</param>
        /// <returns></returns>
        public static Window ObterJanela<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase
        {
            Type viewType;
            janelas.TryGetValue(typeof(TViewModel), out viewType);

            return Activator.CreateInstance(viewType, viewModel) as Window;
        }

        /// <summary>
        /// Cria uma isntantica do UserControl de listagem conectado a sua view model
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel tipo List</typeparam>
        /// <param name="viewModel">ViewModel a ser injetada</param>
        /// <returns></returns>
        public static UserControl ObterListagem<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase
        {
            Type viewType;
            listagens.TryGetValue(typeof(TViewModel), out viewType);

            return Activator.CreateInstance(viewType, viewModel) as UserControl;
        }

        /// <summary>
        /// Cria uma intancia do dialog conectado a sua view model
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel tipo Dialog</typeparam>
        /// <param name="viewModel">ViewModel a ser injetada</param>
        /// <returns></returns>
        public static UserControl ObterDialog<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase
        {
            Type viewType;
            dialogs.TryGetValue(typeof(TViewModel), out viewType);

            return Activator.CreateInstance(viewType, viewModel) as UserControl;
        }

        /// <summary>
        /// Cria uma instancia da classe que implemente a interface
        /// </summary>
        /// <typeparam name="TInterface">Interface</typeparam>
        /// <returns></returns>
        public static TInterface ObterDependencias<TInterface>() where TInterface : class
        {
            Type viewType;
            classes.TryGetValue(typeof(TInterface), out viewType);

            return Activator.CreateInstance(viewType) as TInterface;
        }
    }
}
