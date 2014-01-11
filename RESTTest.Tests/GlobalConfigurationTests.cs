using System;
using System.IO;
using MbUnit.Framework;
using Newtonsoft.Json.Linq;

namespace RESTTest.Tests
{
    [TestFixture]
    class GlobalConfigurationTests
    {
        private string configPath;

        private GlobalConfiguration target;

        [SetUp]
        void SetUp()
        {
            configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
            target = new GlobalConfiguration(JToken.Parse(File.ReadAllText(configPath)));
        }

        [Test]
        void Headers_Count()
        {
            Assert.Count(2, target.Headers);
        }

        [Test]
        void Headers_AuthenticationHeader()
        {
            Assert.ContainsKey(target.Headers, "Authentication");
            Assert.AreEqual(target.Headers["Authentication"], "Basic dHJ1ZmZsZW11ZmZpbjpwYXNzd29yZA==");
        }
    }
}
