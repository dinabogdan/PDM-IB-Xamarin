using InternetBanking.Data;
using InternetBanking.UWP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkConnection))]
namespace InternetBanking.UWP.Data
{
    public class NetworkConnection : INetworkConnection
    {
        public bool isConnected { get; set; }

        public void checkNetworkConnection()
        {
            ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
            isConnected = connections != null && connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
            
        }
    }
}
