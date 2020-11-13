using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace KodeRefactoring
{
    public class DHCP
    {
        public List<string> GetDhcpServerAddresses()
        {
            List<string> DhcpServers = new List<string>();

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapteradapterProperties = adapter.GetIPProperties();
                IPAddressCollection addresses = adapteradapterProperties.DhcpServerAddresses;
                if (addresses.Count > 0)
                {
                   DhcpServers.Add(adapter.Description);
                    foreach (IPAddress address in addresses)
                    {
                        DhcpServers.Add("  DHCP Address ............................ : " + address.ToString());
                    }
                }
            }
            return DhcpServers;
        }
    }
}
