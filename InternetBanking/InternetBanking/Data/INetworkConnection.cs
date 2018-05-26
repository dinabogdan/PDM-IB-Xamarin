using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Data
{
    public interface INetworkConnection
    {
        bool isConnected { get; }
        void checkNetworkConnection();
    }
}
