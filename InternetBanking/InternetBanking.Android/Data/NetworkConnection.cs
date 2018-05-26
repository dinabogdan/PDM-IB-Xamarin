using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using InternetBanking.Data;
using InternetBanking.Droid.Data;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkConnection))]
namespace InternetBanking.Droid.Data
{
    public class NetworkConnection : INetworkConnection
    {
        public bool isConnected { get; set; }

        public void checkNetworkConnection()
        {
            var connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            var ActiveNetworkInfo = connectivityManager.ActiveNetworkInfo;
            isConnected = (ActiveNetworkInfo != null && ActiveNetworkInfo.IsConnectedOrConnecting) ? true : false;

        }
    }
}