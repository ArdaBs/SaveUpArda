using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SaveUpArda.Models;
using SaveUpArda.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;
using Microsoft.Maui.Controls;

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

        private readonly MainViewModel _mainViewModel;

        /// <summary>
        /// Initializes a new instance of the ItemsListViewModel class.
        /// </summary>
        /// <param name="mainViewModel">The main view model to get the items collection from.</param>
        public ItemsListViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            Items = new ObservableCollection<Item>(mainViewModel.Items);
        }

        /// <summary>
        /// Deletes the specified item from the list and the local storage.
        /// </summary>
        /// <param name="item">The item to delete.</param>
        [RelayCommand]
        private void DeleteItem(Item item)
        {
            try
            {
                ItemService.DeleteItem(item);
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (Items.Contains(item))
                    {
                        Items.Remove(item);
                        Console.WriteLine($"Item removed: {item.Description}");
                    }
                    else
                    {
                        Console.WriteLine("Item not found in collection.");
                    }
                    _mainViewModel.UpdateItems();
                });
            }
            catch (ObjectDisposedException ex)
            {
                // Log the error or handle it appropriately
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Catch other exceptions that might occur
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        /// <summary>
        /// Clears all items from the list and the local storage.
        /// </summary>
        [RelayCommand]
        private void ClearAll()
        {
            try
            {
                ItemService.ClearAllItems();
                Device.BeginInvokeOnMainThread(() =>
                {
                    Items.Clear();
                    Console.WriteLine("All items cleared.");
                    _mainViewModel.UpdateItems();
                });
            }
            catch (ObjectDisposedException ex)
            {
                // Log the error or handle it appropriately
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Catch other exceptions that might occur
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
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
