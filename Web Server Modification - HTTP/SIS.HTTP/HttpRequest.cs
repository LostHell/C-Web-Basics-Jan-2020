using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace SIS.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string httpRequestAsString)
        {
            this.Headers = new List<Header>();
            var lines = httpRequestAsString
                .Split(new string[] { HttpConstants.NewLine }, StringSplitOptions.None);
            var httpInfoHeader = lines[0];
            var infoHeaderParts = httpInfoHeader.Split(' ');

            if (infoHeaderParts.Length != 3)
            {
                throw new HttpServerException("Invalid HTTP header line");
            }

            var httpMethod = infoHeaderParts[0];

            //  C# v.8 new switch
            //this.Method = HttpMethod switch
            //{
            //    "GET" => HttpMethodType.Get,
            //    "POST" => HttpMethodType.Post,
            //    "PUT" => HttpMethodType.Put,
            //    "DELETE" => HttpMethodType.Delete,
            //};

            if (httpMethod == "POST")
            {
                this.Method = HttpMethodType.Post;
            }
            else if (httpMethod == "GET")
            {
                this.Method = HttpMethodType.Get;
            }
            else if (httpMethod == "PUT")
            {
                this.Method = HttpMethodType.Put;
            }
            else if (httpMethod == "DELETE")
            {
                this.Method = HttpMethodType.Delete;
            }

            this.Path = infoHeaderParts[1];

            var httpVersion = infoHeaderParts[2];
            this.Version = httpVersion switch
            {
                "HTTP/1.0" => HttpVersionType.Http10,
                "HTTP/1.1" => HttpVersionType.Http11,
                "HTTP/2.0" => HttpVersionType.Http20,
            };

            bool isInHeader = true;

            StringBuilder bodyBuilder = new StringBuilder();

            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    isInHeader = false;
                }

                if (isInHeader)
                {
                    var headerParts = line
                        .Split(new string[] { ": " }, 2, StringSplitOptions.None);

                    if (headerParts.Length!=2)
                    {
                        throw  new HttpServerException($"Invalid header: {line}");
                    }
                    var header = new Header(headerParts[0],headerParts[1]);
                    this.Headers.Add(header);
                }
                else
                {
                    bodyBuilder.AppendLine(line);
                }
            }
        }
        private HttpMethodType Method { get; set; }

        public string Path { get; set; }

        public HttpVersionType Version { get; set; }

        public IList<Header> Headers { get; set; }

        public string Body { get; set; }
    }
}
