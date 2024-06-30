using SaveUpArda.ViewModels;

namespace SaveUpArda.Views
{
    public partial class ItemsListPage : ContentPage
    {
        public ItemsListPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            BindingContext = new ItemsListViewModel(mainViewModel);
        }
    }

}
