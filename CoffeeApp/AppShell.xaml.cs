using CoffeeApp.Basket;
using CoffeeApp.CoffeeList;
using CoffeeApp.DetailedCoffee;

namespace CoffeeApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CoffeeListView), typeof(CoffeeListView));
            Routing.RegisterRoute(nameof(DetailedCoffeeView), typeof(DetailedCoffeeView));
            Routing.RegisterRoute(nameof(BasketView), typeof(BasketView));
        }
    }
}