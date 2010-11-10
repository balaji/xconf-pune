using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ServiceModel;
using xconf_pune.XConfService;

using Microsoft.Phone.Controls;

namespace xconf_pune
{
    public partial class XConfDetails : PhoneApplicationPage
    {
        private XConfServiceClient client;
        private int Day { get; set; }
        private int Track { get; set; }

        public XConfDetails()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(XConfDetails_Loaded);
        }

        private void XConfDetails_Loaded(object sender, RoutedEventArgs e)
        {
            LoadXConfSessionData(1, 1);
        }
        
        private void LoadXConfSessionData(int day, int track)
        {
            Day = day; Track = track;
            if (client == null)
            {
                client = new XConfServiceClient(new System.ServiceModel.BasicHttpBinding(), new EndpointAddress("http://localhost:8001/xconf"));
                client.FetchCompleted += new EventHandler<FetchCompletedEventArgs>(Pivot1_Completed);
            }
            client.FetchAsync(day, track);
        }

        private void Pivot1_Completed(object sender, FetchCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (Track == 1) ShowUI(hall1List, hall1ProgressBar, e.Result);
                else if (Track == 2) ShowUI(hall2List, hall2ProgressBar, e.Result);
                else if (Track == 3) ShowUI(hall3List, hall3ProgressBar, e.Result);
            }
        }

        private void ShowUI(ListBox Box, ProgressBar Bar, ObservableCollection<XConfSession> Result)
        {
            Bar.Visibility = Visibility.Collapsed;
            Box.ItemsSource = Result;
        }
            
        private void Pivot_LoadedPivotItem(object sender, PivotItemEventArgs e)
        {
            PivotItem Item = (PivotItem) e.Item;
            if (Item.Header.Equals("hall 2")) LoadXConfSessionData(1, 2);
            else if (Item.Header.Equals("hall 3")) LoadXConfSessionData(1, 3);
        }
    }
}