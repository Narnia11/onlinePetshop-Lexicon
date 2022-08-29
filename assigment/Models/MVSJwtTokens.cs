using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assigment.Models
{
    public class MVSJwtTokens
    {
        public const string Issuer = "MV5";
        public const string Audience = "ApiUser";
        public const string key = "1234567890123456";
        public const string AuthSchemes = "Identity.Application" + "," + JwtBearerDefaults.AuthenticationScheme;
    }
}

