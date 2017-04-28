using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LNTrello.Models.Repositories
{
    public class TrelloServiceManager : IServiceManager
    {
        private static readonly TrelloServiceManager _serviceManager = new TrelloServiceManager();
        public static TrelloServiceManager Default
        {
            get { return _serviceManager; }
        }

        public TrelloServiceManager()
        {
            _trelloHttpClient = new HttpClient();
            _trelloHttpClient.BaseAddress = new Uri("https://api.trello.com/");
        }

        private HttpClient _trelloHttpClient;
        public HttpClient HttpClient
        {
            get { return _trelloHttpClient; }
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