using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui;
using IgniteYourSigns.Services;

namespace IgniteYourSigns;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().UseMauiCommunityToolkitCore();
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

        builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
		builder.Services.AddSingleton<SignService>();
		builder.Services.AddSingleton<DashboardViewmodel>();
		builder.Services.AddSingleton<Dashboard>();

        return builder.Build();
	}
}

