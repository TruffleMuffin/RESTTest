using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace RESTTest
{
    /// <summary>
    /// Describes a Global Configuration 
    /// </summary>
    public class GlobalConfiguration
    {
        /// <summary>
        /// Gets the headers that should be applied to the request.
        /// </summary>
        public IDictionary<string, string> Headers { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalConfiguration"/> class.
        /// </summary>
        /// <param name="configurationToken">The configuration token.</param>
        public GlobalConfiguration(JToken configurationToken)
        {
            // Initialise the Headers
            this.Headers = new Dictionary<string, string>();

            // Parse the config to pull out the headers
            var headers = configurationToken.SelectToken("headers");
            if (headers != null)
            {
                this.Headers = headers.ToObject<Dictionary<string, string>>();
            }

            // Parse the authentication element into a header
            var authentication = configurationToken.SelectToken("authentication");
            if (authentication != null)
            {
                this.Headers.Add(authentication.ToObject<AuthenticationConfiguration>().ToHeader());
            }
        }
    }
}