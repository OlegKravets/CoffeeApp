namespace CoffeeApp.MainPage
{
    public partial class MainPageView : ContentPage
    {
        public MainPageView(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}