namespace CoffeeApp.CoffeeList;

public partial class CoffeeListView : ContentPage
{
	public CoffeeListView(CoffeeListViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}