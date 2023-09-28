namespace CoffeeApp.Basket;

public partial class BasketView : ContentPage
{
    public BasketView(BasketViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

    }
}