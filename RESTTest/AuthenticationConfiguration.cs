using System;
using System.Collections.Generic;
using System.Text;

namespace RESTTest
{
    /// <summary>
    /// Describes the configuration element for authentication
    /// </summary>
    class AuthenticationConfiguration
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Converst this instance into an Authentication Header
        /// </summary>
        public KeyValuePair<string, string> ToHeader()
        {
            return new KeyValuePair<string, string>("Authentication", FormatAuthenticationHeader(Username, Password));
        }

        /// <summary>
        /// Formats the basic authentication header.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>A value for an authentication header</returns>
        public static string FormatAuthenticationHeader(string username, string password)
        {
            return string.Format("Basic {0}", Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", username, password))));
        }
    }
}