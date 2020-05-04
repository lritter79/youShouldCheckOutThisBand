using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.CustomServices
{
    public class AuthMessageSenderOptions
    {

        public readonly string SendGridUser;
        public readonly string ClientSecret;

        public AuthMessageSenderOptions(IConfiguration config)
        {
            SendGridUser = config.GetValue<string>("SendGridTokens:SendGridUser");
            ClientSecret = config.GetValue<string>("SendGridTokens:ClientSecret");
        }

    }
}
