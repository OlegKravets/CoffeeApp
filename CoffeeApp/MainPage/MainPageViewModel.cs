using CoffeeApp.Base;
using CoffeeApp.CoffeeList;
using CoffeeApp.Services;
using CommunityToolkit.Mvvm.Input;

namespace CoffeeApp.MainPage
{
    public partial class MainPageViewModel : ViewModelBase
    {
        private readonly LoginService _loginService;

        public MainPageViewModel(LoginService loginService)
        {
            Title = "My Coffee";
            _loginService = loginService;
        }

        public string Login { get; set; }

        public string Password { get; set; }

        [RelayCommand]
        public async Task LoginClicked()
        {
            //await LoginValidation();

            //await _loginService.Login(Login, Password);

            await Shell.Current.GoToAsync(
                nameof(CoffeeListView),
                true,
                new Dictionary<string, object> { });
        }

        [RelayCommand]
        public async Task RegisterClicked()
        {
            // await LoginValidation();

            // await _loginService.Register(Login, Password);

            await Shell.Current.GoToAsync(
                nameof(CoffeeListView),
                true,
                new Dictionary<string, object> { });
        }

        private async Task LoginValidation()
        {
            if (string.IsNullOrEmpty(Login))
            {
                await Shell.Current.DisplayAlert("Error", "Login is empty!", "OK");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await Shell.Current.DisplayAlert("Error", "Password is empty!", "OK");
                return;
            }

            if (Password.Length < 6)
            {
                await Shell.Current.DisplayAlert("Error", "Password should has 6 characters minimum!", "OK");
                return;
            }
        }
    }
}
