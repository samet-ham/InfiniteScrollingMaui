using InfiniteScrollingMaui.ViewModels;

namespace InfiniteScrollingMaui.Views;

public partial class AnimalListView : ContentPage
{
    public AnimalListView(AnimalListViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}