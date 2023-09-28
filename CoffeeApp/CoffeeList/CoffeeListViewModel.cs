using CoffeeApp.Base;
using CoffeeApp.Basket;
using CoffeeApp.DetailedCoffee;
using CoffeeApp.Models;
using CoffeeApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace CoffeeApp.CoffeeList
{
    public partial class CoffeeListViewModel : ViewModelBase
    {
        private readonly CoffeeService _coffeeService;
        private List<Order> _orders;

        public CoffeeListViewModel(CoffeeService coffeeService)
        {
            Title = "Coffee List";
            _coffeeService = coffeeService;
            LoadCoffees();
        }

        public ObservableCollection<Coffee> CoffeeList { get; set; } = new();

        [ObservableProperty]
        bool isRefreshing;

        public bool CanCompleteOrder => _orders.Any();

        [RelayCommand]
        public async Task LoadCoffees()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;

                var coffeeList = await _coffeeService.GetCoffees();

                CoffeeList.Clear();

                foreach (Coffee coffee in coffeeList)
                {
                    CoffeeList.Add(coffee);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        public async Task GoToDetails(Coffee coffee)
        {
            if (coffee is null)
            {
                return;
            }

            await Shell.Current.GoToAsync(
                nameof(DetailedCoffeeView),
                true,
                new Dictionary<string, object> { { nameof(Coffee), coffee } });
        }

        [RelayCommand]
        public void AddToOrder(Coffee coffee)
        {
            if (_orders is null)
            {
                _orders = new List<Order>();
            }

            if (coffee is null)
            {
                return;
            }

            _orders.Add(
                new Order()
                {
                    OrderId = _orders.Any() ? _orders.Max(o => o.OrderId) + 1 : 1,
                    CoffeeId = coffee.Id,
                    UserId = 1 // temporary
                });

            OnPropertyChanged(nameof(CanCompleteOrder));
        }

        [RelayCommand]
        public async Task CompleteOrder()
        {
            await Shell.Current.GoToAsync(
                nameof(BasketView),
                true,
                new Dictionary<string, object> { ["Orders"] = _orders });
        }
    }
}
