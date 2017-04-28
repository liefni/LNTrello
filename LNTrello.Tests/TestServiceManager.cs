using LNTrello.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LNTrello.Tests
{
    class TestServiceManager : IServiceManager
    {
        private static readonly TrelloServiceManager _serviceManager = new TrelloServiceManager();
        public static TrelloServiceManager Default
        {
            get { return _serviceManager; }
        }

        public TestServiceManager()
        {
            UserToken = "11a06cf107d00ea9f5a101f493722d71f93467019447fc1130a98cf6b1e633a4";
        }

        public HttpClient HttpClient
        {
            get { return null; }
        }

        public string ApplicationKey
        {
            get { return "a3e16400966567f857abd863e1325efc"; }
        }

        public string UserToken { get; set; }

        public string AuthenticationUrlString
        {
            get { return string.Format("key={0}&token={1}", ApplicationKey, UserToken ?? "none"); }
        }
    }
}
