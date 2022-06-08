using static Android.Provider.Settings;

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
            var context = Android.App.Application.Context;
            id = Secure.GetString(context.ContentResolver, Secure.AndroidId);
        }
        catch (Exception)
        {
            id = "unsupported";
        }
        return id;
    }
}
