using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CossSharp.Lib.Http
{
    public class HttpWebClient : IHttpWebClient
    {
        public string GetSync(string url)
        {
            return HttpSync(url, null, null, null, null);
        }

        public string HttpSync(string url, string verb = null, byte[] body = null, string contentType = null, Dictionary<string, string> headers = null)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);

            if (!string.IsNullOrWhiteSpace(contentType))
            {
                req.ContentType = contentType;
            }

            if (headers != null)
            {
                foreach (var key in headers.Keys)
                {
                    req.Headers.Add(key, headers[key]);
                }
            }

            if (!string.IsNullOrWhiteSpace(verb) && !string.Equals(verb, "GET", StringComparison.InvariantCultureIgnoreCase))
            { req.Method = verb; }

            if (body != null && body.Length > 0)
            {
                req.ContentLength = body.Length;
                using (var reqStream = req.GetRequestStream())
                {
                    reqStream.Write(body, 0, body.Length);
                }
            }

            var response = req.GetResponse();
            var responseStream = response.GetResponseStream();
            var reader = new StreamReader(responseStream);
            var contents = reader.ReadToEnd();

            return contents;
        }
    }
}
