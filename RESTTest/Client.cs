using System.Net;

namespace RESTTest
{
    /// <summary>
    /// Describes a REST Testing Client. This class will send provided requests and return responses in a safely.
    /// </summary>
    class Client
    {
        private readonly WebClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        public Client()
        {
            client = new WebClient();
        }
    }
}
