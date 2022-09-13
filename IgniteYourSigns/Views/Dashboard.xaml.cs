namespace IgniteYourSigns.Views;

public partial class Dashboard : ContentPage
{
	public Dashboard(DashboardViewmodel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
