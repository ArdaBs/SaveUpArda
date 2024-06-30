using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using SaveUpArda.Models;

namespace SaveUpArda.Services
{
    /// <summary>
    /// A static service class to handle CRUD operations for items saved locally.
    /// </summary>
    public static class ItemService
    {
        // The file path where the items will be saved.
        private static readonly string FileName = Path.Combine(FileSystem.AppDataDirectory, "items.json");

        /// <summary>
        /// Loads the items from the local storage.
        /// </summary>
        /// <returns>A list of items.</returns>
        public static List<Item> LoadItems()
        {
            if (File.Exists(FileName))
            {
                var json = File.ReadAllText(FileName);
                return JsonSerializer.Deserialize<List<Item>>(json);
            }
            return new List<Item>();
        }

        /// <summary>
        /// Saves a new item asynchronously to the local storage.
        /// </summary>
        /// <param name="item">The item to save.</param>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public static async Task SaveItemAsync(Item item)
        {
            var items = LoadItems();
            items.Add(item);
            var json = JsonSerializer.Serialize(items);
            await File.WriteAllTextAsync(FileName, json);
        }

        /// <summary>
        /// Deletes an item from the local storage.
        /// </summary>
        /// <param name="item">The item to delete.</param>
        public static void DeleteItem(Item item)
        {
            var items = LoadItems();
            var itemToDelete = items.FirstOrDefault(i => i.Description == item.Description && i.Price == item.Price && i.Date == item.Date);
            if (itemToDelete != null)
            {
                items.Remove(itemToDelete);
                var json = JsonSerializer.Serialize(items);
                File.WriteAllText(FileName, json);
            }
        }

        /// <summary>
        /// Clears all items from the local storage.
        /// </summary>
        public static void ClearAllItems()
        {
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }
        }
    }
}
