using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web;

namespace LNTrello.Models.Repositories
{
    public static class ServiceHelpers
    {
        /// <summary>
        /// Throws an unauthorised exception if 401 status code and thorws a HttpRequestException if not success status code other then 401.
        /// </summary>
        public static void EnsureSuccessStatusCode2(this HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new UnauthorisedException(response.ReasonPhrase);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                throw new ResourceNotFoundException();

            response.EnsureSuccessStatusCode();
        }
    }
}