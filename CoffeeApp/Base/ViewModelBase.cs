using CommunityToolkit.Mvvm.ComponentModel;

namespace CoffeeApp.Base
{
    public partial class ViewModelBase : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        private bool _isBusy;

        [ObservableProperty]
        private string _title;

        public bool IsNotBusy => !IsBusy;
    }
}
