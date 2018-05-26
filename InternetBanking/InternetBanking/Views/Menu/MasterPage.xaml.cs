using InternetBanking.Model;
using InternetBanking.Views.DetailViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InternetBanking.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listview; } }
        public List<MasterMenuItem> items;

        public MasterPage()
        {
            InitializeComponent();
            SetItems();
        }

        void SetItems()
        {

            items = new List<MasterMenuItem>();
            items.Add(new MasterMenuItem("Dashboard", "DashboardIcon.png", Color.White, typeof(Dashboard)));
            items.Add(new MasterMenuItem("History", "DashboardIcon.png", Color.White, typeof(History)));
            ListView.ItemsSource = items;

        }

        void Logout(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }
    }
}