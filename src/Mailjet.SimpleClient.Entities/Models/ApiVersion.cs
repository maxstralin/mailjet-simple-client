﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models
{
    public enum ApiVersion
    {
        V3,
        V3_1,
        V4
    }

    public enum EmailApiVersion
    {
        V3 = ApiVersion.V3,
        V3_1 = ApiVersion.V3_1
    }

    public enum SmsApiVersion
    {
        V4 = ApiVersion.V4
    }

}
