using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SQLite;
using SQLitePrism.Models;
using System;
using System.Collections.ObjectModel;
using Prism.Services;

namespace SQLitePrism.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly IPageDialogService _pageDialogService;

        private SQLiteAsyncConnection _databaseConnection;

        private ObservableCollection<Recipe> _recipes;
        public ObservableCollection<Recipe> Recipes
        {
            get { return _recipes; }
            set { SetProperty(ref _recipes, value); }
        }

        public DelegateCommand AddCommand => new DelegateCommand(Add);
        public DelegateCommand UpdateCommand => new DelegateCommand(Update);
        public DelegateCommand DeleteCommand => new DelegateCommand(Delete);

        private async void Delete()
        {
            var confirmation = await _pageDialogService.DisplayAlertAsync("Alert", "Are you sure?", "Delete", "Cancel");
            if (!confirmation) return;
            var recipe = Recipes[0];
            await _databaseConnection.DeleteAsync(recipe);
            Recipes.Remove(recipe);
        }

        private async void Update()
        {
            var recipe = Recipes[0];
            recipe.Name += " [updated]";
            await _databaseConnection.UpdateAsync(recipe);

        }

        private async void Add()
        {
            var recipe = new Recipe { Name = $"Name {DateTime.UtcNow.Ticks}" };
            await _databaseConnection.InsertAsync(recipe);

            Recipes.Insert(0, recipe);
        }

        public MainPageViewModel(IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await _databaseConnection.CreateTableAsync<Recipe>();

            var recipes = await _databaseConnection.Table<Recipe>().ToListAsync();

            Recipes = new ObservableCollection<Recipe>(recipes);

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            _databaseConnection = Xamarin.Forms.DependencyService.Get<ISQLiteDb>().GetConnection();
        }
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }
    }
}