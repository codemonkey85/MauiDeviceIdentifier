namespace MauiDeviceIdentifier.TestApp;

public partial class MainPage : ContentPage
{
    public MainPage(IMauiDeviceIdentifier mauiDeviceIdentifier)
    {
        InitializeComponent();
        IdLabel.Text = mauiDeviceIdentifier.GetIdentifier();
    }
}
