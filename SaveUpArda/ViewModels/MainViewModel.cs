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
    /// <summary>
    /// ViewModel for the main page, managing navigation and item collection.
    /// </summary>
    public partial class MainViewModel : ObservableObject
    {
        /// <summary>
        /// The collection of items.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Item> items;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Items = new ObservableCollection<Item>(ItemService.LoadItems());
        }

        /// <summary>
        /// Navigates to the AddItemPage asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous navigation operation.</returns>
        [RelayCommand]
        private async Task NavigateToAddItem()
        {
            await Shell.Current.GoToAsync(nameof(AddItemPage));
        }

        /// <summary>
        /// Navigates to the ItemsListPage asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous navigation operation.</returns>
        [RelayCommand]
        private async Task NavigateToList()
        {
            await Shell.Current.GoToAsync(nameof(ItemsListPage));
        }

        /// <summary>
        /// Updates the items collection from the local storage and notifies the UI about the changes.
        /// </summary>
        public void UpdateItems()
        {
            Items = new ObservableCollection<Item>(ItemService.LoadItems());
            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(TotalSaved));
        }

        /// <summary>
        /// Gets the total saved amount as a formatted string.
        /// </summary>
        public string TotalSaved => Items.Sum(i => i.Price).ToString("C");
    }
}
