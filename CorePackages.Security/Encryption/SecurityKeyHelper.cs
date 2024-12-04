﻿using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace CorePackages.Security.Encryption;
public static class SecurityKeyHelper
{
    public static SecurityKey CreateSecurityKey(string securityKey) =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
}
