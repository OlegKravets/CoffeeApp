using CoffeeApp.Base;
using CoffeeApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeApp.DetailedCoffee
{
    [QueryProperty(nameof(Coffee), "Coffee")]
    public partial class DetailedCoffeeViewModel : ViewModelBase
    {
        public DetailedCoffeeViewModel()
        {
        }

        [ObservableProperty]
        Coffee coffee;
    }
}
