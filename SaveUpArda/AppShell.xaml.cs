using SaveUpArda.Views;
using Microsoft.Maui.Controls;

namespace SaveUpArda
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(AddItemPage), typeof(AddItemPage));
            Routing.RegisterRoute(nameof(ItemsListPage), typeof(ItemsListPage));
        }
    }
}
