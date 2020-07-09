using ExtractImages.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtractImages.Services.Security
{
    public class UserSecurity 
    {
        public bool AuthenticateUser(string username, string password)
        {
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                if (username.Equals(SecurityConstants.xUsername) && password.Equals(SecurityConstants.xPassword))
                    return true;
                else return false;
            }

            return false;
        }
    }
}
