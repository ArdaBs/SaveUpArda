using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SaveUpArda.Models;
using SaveUpArda.Services;
using System;
using System.Threading.Tasks;

namespace SaveUpArda.ViewModels
{
    /// <summary>
    /// ViewModel for adding a new item.
    /// </summary>
    public partial class AddItemViewModel : ObservableObject
    {
        /// <summary>
        /// The description of the item.
        /// </summary>
        [ObservableProperty]
        private string description;

        /// <summary>
        /// The price of the item.
        /// </summary>
        [ObservableProperty]
        private decimal price;

        /// <summary>
        /// Reference to the MainViewModel to update the items list.
        /// </summary>
        private readonly MainViewModel _mainViewModel;

        /// <summary>
        /// Initializes a new instance of the AddItemViewModel class.
        /// </summary>
        /// <param name="mainViewModel">The main view model.</param>
        public AddItemViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        /// <summary>
        /// Saves the new item asynchronously and navigates back to the previous page.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
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
