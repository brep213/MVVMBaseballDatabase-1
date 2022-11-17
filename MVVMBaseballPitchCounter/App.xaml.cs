using MVVMBaseballPitchCounter.ViewModels;

namespace MVVMBaseballPitchCounter;

public partial class App : Application
{
	
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		
	}
}
