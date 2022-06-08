﻿using Windows.Foundation.Metadata;
using Windows.System.Profile;

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
            if (ApiInformation.IsTypePresent("Windows.System.Profile.SystemIdentification"))
            {
                var systemId = SystemIdentification.GetSystemIdForPublisher();

                // Make sure this device can generate the IDs
                if (systemId.Source != SystemIdentificationSource.None)
                {
                    // The Id property has a buffer with the unique ID
                    var hardwareId = systemId.Id;
                    var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(hardwareId);

                    var bytes = new byte[hardwareId.Length];
                    dataReader.ReadBytes(bytes);

                    id = Convert.ToBase64String(bytes);
                }
            }

            if (id == null && ApiInformation.IsTypePresent("Windows.System.Profile.HardwareIdentification"))
            {
                var token = HardwareIdentification.GetPackageSpecificToken(null);
                var hardwareId = token.Id;
                var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(hardwareId);

                var bytes = new byte[hardwareId.Length];
                dataReader.ReadBytes(bytes);

                id = Convert.ToBase64String(bytes);
            }

            if (id == null)
            {
                id = "unsupported";
            }

        }
        catch (Exception)
        {
            id = "unsupported";
        }

        return id;
    }
}
