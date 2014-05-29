using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;

namespace CustomProxyAssembly
{
    public class NTLMProxy : IWebProxy
    {
        public ICredentials Credentials
        {
            get
            {      
                //If recreating this from scratch, you need to import System.Configuration
                //  in order to use the newer ConfigurationManager object.
                string username = ConfigurationManager.AppSettings["proxyUsername"];
                string password = ConfigurationManager.AppSettings["proxyPassword"];
                string domain = ConfigurationManager.AppSettings["proxyDomain"];

                NetworkCredential credential;
                if (domain != null)
                {
                    credential = new NetworkCredential(username, password, domain);
                }
                else
                {
                    credential = new NetworkCredential(username, password);
                }                
                return credential;
            }
            set { }
        }

        public Uri GetProxy(Uri destination)
        {
            Uri proxy = null;

            // Use the proxy server specified in AppSettings
            string serverName = ConfigurationManager.AppSettings["proxyServer"];            
            if (serverName != null)
            {
                proxy = new Uri(serverName);
            }

            return proxy;
        }

        public bool IsBypassed(Uri host)
        {

            string byPass = ConfigurationManager.AppSettings["proxyBypass"];
            if (byPass != null)
            {
                string[] bypassUris = byPass.Split(',');

                foreach (string bypassUri in bypassUris)
                {
                    if (host.AbsoluteUri.ToLower().Contains(bypassUri.Trim().ToLower()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
