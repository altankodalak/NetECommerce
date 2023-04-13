using System;
using System.Collections.Generic;
using System.Text;
using System.Net;//ip işlemleri

namespace NetECommerce.Common
{
    public static class IpAddressFinder
    {
        public static string GetHostName()
        {
            string ip = "";

            var hostName = Dns.GetHostName();
            var addresses = Dns.GetHostAddresses(hostName);
            foreach ( var address in addresses )
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ip=address.ToString();
                };
            }


            return ip; 
        }
    }
}
