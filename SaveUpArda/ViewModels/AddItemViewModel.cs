using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SaveUpArda.Models;
using SaveUpArda.Services;
using System;
using System.Threading.Tasks;

namespace SaveUpArda.ViewModels
{
    public partial class AddItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private decimal price;

        private readonly MainViewModel _mainViewModel;

        public AddItemViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        [RelayCommand]
        private async Task SaveItem()
        {
            var newItem = new Item
            {
                Description = Description,
                Price = Price,
                Date = DateTime.Now
            };

            await ItemService.SaveItemAsync(newItem);
            _mainViewModel.UpdateItems();
            await Shell.Current.GoToAsync("..");
        }
    }
}
