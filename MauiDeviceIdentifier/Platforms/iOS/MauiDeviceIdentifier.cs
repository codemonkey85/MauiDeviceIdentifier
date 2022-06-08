using UIKit;

namespace MauiDeviceIdentifier;

public class MauiDeviceIdentifier : IMauiDeviceIdentifier
{
    private string id = null;

    public string GetIdentifier()
    {
        if (!string.IsNullOrWhiteSpace(id))
        {
            return id;
        }

        try
        {
            id = UIDevice.CurrentDevice.IdentifierForVendor.AsString();
        }
        catch (Exception)
        {
            id = "unsupported";
        }

        return id;
    }
}
