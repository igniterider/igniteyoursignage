using System;
using IgniteYourSigns.Models;
using IgniteYourSigns.Services;
using CommunityToolkit.Mvvm.Input;


namespace IgniteYourSigns.Viewmodels
{
	public partial class DashboardViewmodel : BaseViewModel
	{
		public ObservableCollection<PremadeSigns> Signs { get; } = new();
		SignService signService;
        IConnectivity connectivity;
		public Command GetSignsCommand { get; }


        public DashboardViewmodel(SignService signService, IConnectivity connectivity)
		{
			this.signService = signService;
			this.connectivity = connectivity;
            GetSignsCommand = new Command(async () => await GetSignsAsync());
        }


		[ObservableProperty]
		bool isRefresing;


		async Task GetSignsAsync()
		{
			if (IsBusy)
                return;
			try
			{
				if (connectivity.NetworkAccess != NetworkAccess.Internet)
				{
					await Shell.Current.DisplayAlert("No connectivity!",
						$"Please check internet and try again.", "OK");
					return;
				}

				IsBusy = true;
				var signs = await signService.GetPremadeSigns();

				if (Signs.Count != 0)
					Signs.Clear();
				foreach (var sign in signs)
					Signs.Add(sign);
			}

            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                
            }

        }


    }

}

