using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CustomProxyAssemblyDemo
{
    //Run this Demo Project after updating the App.config with your environments
    //  proxy settings to confirm your configuration settings are valid.
    class ProxyDemo
    {
        static void Main(string[] args)
        {
            //This will make a simple webRequest, which will go through our NTLMProxy.
            //  Any 3rd party library will also be routed through the NTLMProxy for
            //  WebClient and/or WebRequest connections.
            WebRequest webRequest = WebRequest.Create("http://pineapplepiranha.com/");
            WebResponse webResp = webRequest.GetResponse();

            System.Diagnostics.Debug.WriteLine(webResp.ContentType);
            System.Diagnostics.Debug.WriteLine(webResp.ContentLength);

            Console.Read();
        }
    }
}
