namespace CoffeeApp.DetailedCoffee;

public partial class DetailedCoffeeView : ContentPage
{
	public DetailedCoffeeView(DetailedCoffeeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}