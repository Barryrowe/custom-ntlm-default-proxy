Custom NTLM Default Proxy for .NET Applications
=========================

A very simple IWebProxy implementation to provide configuration and credentials to an NTLM proxy for any WebRequests within your .NET application. This includes handling 3rd party libraries that may not be configured with NTLM proxy settings. (Example: PushSharp)

Purpose
=========================

I created this to use for situations where I'm stuck behind a proxy which requires NTLM authentication and need to either:

A) make external web calls
or
B) leverage a 3rd party library that makes external web calls and does not provide configuration options for a proxy server.

Usage
=========================

Usage is very simple. 

1. You reference the CustomProxyAssembly.dll from [the Binary distributeion](https://github.com/Barryrowe/custom-ntlm-default-proxy/raw/master/Binary/CustomProxyAssembly.dll), or building the assembly from the CustomProxyAssembly project in this repository.
2. Add the following block to the <system.net> block of your App.config or web.config file:

  ```xml
  <system.net>
    <!--With a reference to the CustomProxyAssembly.dll, setup the custom
        proxy instance with the below configuration 
    -->
    <defaultProxy enabled="true" useDefaultCredentials="false">
      <module type = "CustomProxyAssembly.NTLMProxy, CustomProxyAssembly" />
    </defaultProxy>
  </system.net>
  ```
3. Add the proper <appSettings> key value pairs to your App.config or web.config file:
 
  ```xml
  <appSettings>
    <!-- ... -->
    <!--  Add the below setting Key/Values to configure your 
          NTLMProxy with your environment values
    -->
    <add key="proxyUsername" value="YOUR_AUTH_NAME" />
    <add key="proxyPassword" value="YOUR_AUTH_PASSWORD" />
    <!-- Uncomment to use DOMAIN for NetworkCredentials
    <add key="proxyDomain" value="YOUR_DOMAIN" /> 
    -->
    <add key="proxyServer" value="http://YOUR_PROXY_HOST:8888" />
    <add key="proxyBypass" value="localhost,another_server,your_intranet_host" />
   </appSettings>
   ```

That's it! Now all of your WebRequests will be routed through the custom proxy defined by your appSettings values, using the credentials you also supplied in appSettings.
