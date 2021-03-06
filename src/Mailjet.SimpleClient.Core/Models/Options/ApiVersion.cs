﻿namespace Mailjet.SimpleClient.Core.Models.Options
{
    public enum ApiVersion
    {
        V3_1,
        V4
    }

    public enum EmailApiVersion
    {
        V3_1 = ApiVersion.V3_1
    }

    public enum SmsApiVersion
    {
        V4 = ApiVersion.V4
    }

}
