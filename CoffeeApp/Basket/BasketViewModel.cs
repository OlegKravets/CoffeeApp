using CoffeeApp.Base;
using CoffeeApp.Models;
using CoffeeApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace CoffeeApp.Basket
{
    [QueryProperty("Orders", "Orders")]
    public partial class BasketViewModel : ViewModelBase
    {
        private readonly CoffeeService _coffeeService;
        private List<Coffee> _coffees;
        private ObservableCollection<UserOrder> _orderList;

        public BasketViewModel(CoffeeService coffeeService)
        {
            Title = "Basket";
            _coffeeService = coffeeService;
        }

        [ObservableProperty]
        List<Order> orders;

        public ObservableCollection<UserOrder> OrderList
        {
            get => _orderList;
            set
            {
                _orderList = value;
                OnPropertyChanged(nameof(OrderList));
            }
        }

        partial void OnOrdersChanged(List<Order> value)
        {
            _coffees = (_coffeeService.GetCoffees().Result).ToList();

            OrderList = new ObservableCollection<UserOrder> ();
            foreach (Order o in value.ToList())
            {
                Coffee coffee = _coffees.FirstOrDefault(c => c.Id == o.CoffeeId);

                if (coffee is null)
                {
                    continue;
                }

                var orderItem = OrderList.FirstOrDefault(item => item.CoffeeName == coffee.Name);

                if (orderItem != default)
                {
                    orderItem.Count++;
                    continue;
                }

                OrderList.Add(new UserOrder() { CoffeeName = coffee.Name, Count = 1 });
            }
        }
    }
}
