using InternetBanking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InternetBanking.Views.DetailViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class History : ContentPage
	{
        public ListView ListView { get { return lvHistory; } }
        public List<HistoryState> items;

        public History ()
		{
			InitializeComponent ();
            SetUpItems();
		}

        void SetUpItems()
        {
            items = new List<HistoryState>();
            var historyStates = App.HistoryStateDatabaseController.GetStatesByUserId(App.CurrentUser.Id);
            if (historyStates != null)
            {
                foreach (HistoryState history in historyStates)
                {
                    items.Add(history);
                }
                ListView.ItemsSource = items;
                ListView.IsVisible = true;
                emptyList.IsVisible = false;

            }
            else
            {
                ListView.IsVisible = false;
                emptyList.IsVisible = true;
            }

        }
	}
}