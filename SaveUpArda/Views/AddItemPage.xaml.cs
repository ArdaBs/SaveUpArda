using SaveUpArda.ViewModels;

namespace SaveUpArda.Views
{
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage(AddItemViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
