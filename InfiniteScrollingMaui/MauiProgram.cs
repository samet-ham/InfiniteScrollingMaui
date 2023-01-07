using InfiniteScrollingMaui.Services;
using InfiniteScrollingMaui.ViewModels;
using InfiniteScrollingMaui.Views;

namespace InfiniteScrollingMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<AnimalService>();
		builder.Services.AddSingleton<AnimalListView>();
		builder.Services.AddSingleton<AnimalListViewModel>();

		return builder.Build();
	}
}
