using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SaveUpArda.Models;
using SaveUpArda.Services;
using SaveUpArda.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SaveUpArda.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Item> items;

        public MainViewModel()
        {
            Items = new ObservableCollection<Item>(ItemService.LoadItems());
        }

        [RelayCommand]
        private async Task NavigateToAddItem()
        {
            await Shell.Current.GoToAsync(nameof(AddItemPage));
        }

        [RelayCommand]
        private async Task NavigateToList()
        {
            await Shell.Current.GoToAsync(nameof(ItemsListPage));
        }

        public void UpdateItems()
        {
            Items = new ObservableCollection<Item>(ItemService.LoadItems());
            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(TotalSaved));
        }

        public string TotalSaved => Items.Sum(i => i.Price).ToString("C");
    }
}
