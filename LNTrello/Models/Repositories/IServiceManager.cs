using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LNTrello.Models.Repositories
{
    /// <summary>
    /// Specified properties to access resource for connecting to a service
    /// </summary>
    public interface IServiceManager
    {
        HttpClient HttpClient { get; }
        string ApplicationKey { get; }
        string UserToken { get; set; }
        string AuthenticationUrlString { get; }
    }
}
