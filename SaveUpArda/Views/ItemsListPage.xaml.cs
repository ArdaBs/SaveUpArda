using SaveUpArda.ViewModels;

namespace SaveUpArda.Views
{
    public partial class ItemsListPage : ContentPage
    {
        public ItemsListPage(ItemsListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
