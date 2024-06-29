using SaveUpArda.ViewModels;

namespace SaveUpArda.Views
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel _viewModel;

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.UpdateItems();
        }
    }
}
