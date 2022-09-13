using System;

namespace IgniteYourSigns.Viewmodels
{
    public partial class BaseViewModel : ObservableObject
    {


        internal virtual void OnAppearing() { }

        internal virtual void OnDisappearing() { }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        public bool IsNotBusy => !IsBusy;

    }
}



