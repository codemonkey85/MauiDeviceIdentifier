namespace MauiDeviceIdentifier.TestApp;

public partial class App : Application
{
    public App(IMauiDeviceIdentifier mauiDeviceIdentifier)
    {
        InitializeComponent();
        MainPage = new MainPage(mauiDeviceIdentifier);
    }
}
