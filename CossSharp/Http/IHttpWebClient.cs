using System.Collections.Generic;

namespace CossSharp.Http
{
    public interface IHttpWebClient
    {
        string GetSync(string url);
        string HttpSync(string url, string verb = null, byte[] body = null, string contentType = null, Dictionary<string, string> headers = null);
    }
}
