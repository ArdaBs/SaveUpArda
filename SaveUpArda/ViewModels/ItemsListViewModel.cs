using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SaveUpArda.Models;
using SaveUpArda.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SaveUpArda.ViewModels
{
    public partial class ItemsListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Item> items;

        public ItemsListViewModel(MainViewModel mainViewModel)
        {
            Items = mainViewModel.Items;
        }

        [RelayCommand]
        private void DeleteItem(Item item)
        {
            ItemService.DeleteItem(item);
            Items.Remove(item);
        }

        [RelayCommand]
        private void ClearAll()
        {
            ItemService.ClearAllItems();
            Items.Clear();
        }

        [RelayCommand]
        private async Task NavigateBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
