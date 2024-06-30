using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SaveUpArda.Models;
using SaveUpArda.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SaveUpArda.ViewModels
{
    /// <summary>
    /// ViewModel for managing the list of items.
    /// </summary>
    public partial class ItemsListViewModel : ObservableObject
    {
        /// <summary>
        /// The collection of items.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Item> items;

        /// <summary>
        /// Initializes a new instance of the ItemsListViewModel class.
        /// </summary>
        /// <param name="mainViewModel">The main view model to get the items collection from.</param>
        public ItemsListViewModel(MainViewModel mainViewModel)
        {
            Items = mainViewModel.Items;
        }

        /// <summary>
        /// Deletes the specified item from the list and the local storage.
        /// </summary>
        /// <param name="item">The item to delete.</param>
        [RelayCommand]
        private void DeleteItem(Item item)
        {
            ItemService.DeleteItem(item);
            Items.Remove(item);
        }

        /// <summary>
        /// Clears all items from the list and the local storage.
        /// </summary>
        [RelayCommand]
        private void ClearAll()
        {
            ItemService.ClearAllItems();
            Items.Clear();
        }

        /// <summary>
        /// Navigates back to the previous page asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous navigation operation.</returns>
        [RelayCommand]
        private async Task NavigateBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
