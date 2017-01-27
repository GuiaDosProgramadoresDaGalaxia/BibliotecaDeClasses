using BibliotecaSubeta.Dominio;
using BibliotecaSubeta.MVVM.Dialogs;
using BibliotecaSubeta.MVVM.Uteis;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace BibliotecaSubeta.MVVM
{
    /// <summary>
    /// Classe que contem os comportamentos básicos de janelas de listagens de models
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public abstract class ViewModelList<TModel> : ViewModelBase, IViewModelList where TModel : Model
    {

        private ObservableCollection<TModel> models;

        /// <summary>
        /// Lista de models
        /// </summary>
        public ObservableCollection<TModel> Models
        {
            get { return models; }
            set { models = value; OnPropertyChanged("Models"); }
        }

        /// <summary>
        /// Objeto de visualização da coleção
        /// </summary>
        public ICollectionView DataView
        {
            get { return CollectionViewSource.GetDefaultView(Models); }
        }

        /// <summary>
        /// Comando para adicionar uma model
        /// </summary>
        public Command AdicionarCommand { get; set; }

        /// <summary>
        /// Comando para excluir uma model
        /// </summary>
        public Command<TModel> ExcluirCommand { get; set; }

        /// <summary>
        /// Comando para editar uma model
        /// </summary>
        public Command<TModel> EditarCommand { get; set; }

        //Filtro
        private string filtro;

        /// <summary>
        /// Propriedade a ser conectada a TextBox de filtro da janela, utilize o "UpdateSourceTrigger=PropertyChanged" para um filtro dinamico
        /// </summary>
        public string Filtro
        {
            get { return this.filtro; }
            set
            {
                this.filtro = value;
                OnPropertyChanged("Filtro");
                OnSearch();
            }
        }

        /// <summary>
        /// Construtor para a tela que necessita de filtros por data
        /// </summary>
        /// <param name="listData">Possui filtro por datas?</param>
        /// <param name="repositorio">Repositorio da aplicação</param>
        public ViewModelList(bool listData, IRepositorio repositorio) : base(repositorio)
        {
            this.AdicionarCommand = new Command(Adicionar);
            this.ExcluirCommand = new Command<TModel>(Remover);
            this.EditarCommand = new Command<TModel>(Editar);
        }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="repositorio">Repositorio da aplicação</param>
        public ViewModelList(IRepositorio repositorio) : base(repositorio)
        {
            this.AdicionarCommand = new Command(Adicionar);
            this.ExcluirCommand = new Command<TModel>(Remover);
            this.EditarCommand = new Command<TModel>(Editar);
            CarregarLista();
        }

        /// <summary>
        /// Limpa o filtro antigo e inicializa o novo, é chamado toda vez que a propriedade Filtro muda
        /// </summary>
        protected void OnSearch()
        {
            DataView.Filter = null;
            DataView.Filter = new Predicate<object>(Busca);
        }

        /// <summary>
        /// Sobrescreva esse metodo para por a logica de filtragem da lista
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected abstract bool Busca(object obj);

        /// <summary>
        /// Metodo chamado quando a tela é iniciada
        /// </summary>
        protected abstract void CarregarLista();

        /// <summary>
        /// Sobrecarregue este metodo para por a logica de adição
        /// </summary>
        protected abstract void Adicionar();

        /// <summary>
        /// Lança um dialog(RemoverViewModelDialog) de confirmação de remoção da model. Esse metodo necessita que o dialog seja injetado atraves
        /// do DependecyService. Remove da lista e chama o metodo 'Deletar()'
        /// </summary>
        /// <param name="model">Model a ser removida</param>
        protected async void Remover(TModel model)
        {
            var dialog = DependecyService.ObterDialog(new RemoverViewModelDialog("Tem certeza que deseja excluir?", repositorio));
            var result = await DialogHost.Show(dialog, "MessageBoxPrincipal");
            bool? resultado = result as bool?;

            if (resultado.HasValue && resultado.Value == true)
            {
                this.Models.Remove(model);
                Deletar(model);
            }
        }

        /// <summary>
        /// Sobrecarregue este metodo para por a logica de remoção do Bando de Dados
        /// </summary>
        /// <param name="model">Model removida da lista</param>
        protected abstract void Deletar(TModel model);

        /// <summary>
        /// Sobrecarregue este metodo para por a logica de edição da model
        /// </summary>
        /// <param name="model">Model a ser editada</param>
        protected abstract void Editar(TModel model);
    }
}
