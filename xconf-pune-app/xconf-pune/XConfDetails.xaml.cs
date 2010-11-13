using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Phone.Controls;
using xconf_pune.XConfService;

namespace xconf_pune
{
    public partial class XConfDetails : PhoneApplicationPage
    {
        private XConfServiceClient client;
        private int Day { get; set; }
        private int Track { get; set; }
        private ObservableCollection<XConfSession> Day1Selected { get; set; }
        private ObservableCollection<XConfSession> Day2Selected { get; set; }

        public XConfDetails()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(XConfDetails_Loaded);
            Day1Selected = new ObservableCollection<XConfSession>();
            Day2Selected = new ObservableCollection<XConfSession>();
        }

        private void XConfDetails_Loaded(object sender, RoutedEventArgs e)
        {
            LoadXConfSessionData(Day, 1);
        }
        
        private void LoadXConfSessionData(int day, int track)
        {
            Day = day; Track = track;
            if (client == null)
            {
                client = new XConfServiceClient(new System.ServiceModel.BasicHttpBinding(), new EndpointAddress("http://localhost:8001/xconf"));
                client.FetchCompleted += new EventHandler<FetchCompletedEventArgs>(Pivot_Completed);
            }
            if (!IsContentAlreadyLoaded()) client.FetchAsync(day, track);
        }

        private bool IsContentAlreadyLoaded()
        {
            return CurrentProgressBar().Visibility == Visibility.Collapsed;
        }

        private ListBox CurrentListBox()
        {
            if (Track == 1) return hall1List;
            if (Track == 2) return hall2List;
            return hall3List;
        }

        private ProgressBar CurrentProgressBar()
        {
            if (Track == 1) return hall1ProgressBar;
            if (Track == 2) return hall2ProgressBar;
            return hall3ProgressBar;
        }

        private void Pivot_Completed(object sender, FetchCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ShowUI(CurrentListBox(), CurrentProgressBar(), e.Result);
            }
        }

        private void ShowUI(ListBox Box, ProgressBar Bar, ObservableCollection<XConfSession> Result)
        {
            Bar.Visibility = Visibility.Collapsed;
            Box.ItemsSource = Result;  
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string day = "";
            if (NavigationContext.QueryString.TryGetValue("day", out day))
            {
                Day = Int16.Parse(day.Substring(day.Length - 1));
            }
        }
            
        private void Pivot_LoadedPivotItem(object sender, PivotItemEventArgs e)
        {
            PivotItem Item = (PivotItem) e.Item;
            if (Item.Header.Equals("hall 2")) LoadXConfSessionData(Day, 2);
            else if (Item.Header.Equals("hall 3")) LoadXConfSessionData(Day, 3);
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            SolidColorBrush accentBrush = (SolidColorBrush)Application.Current.Resources["PhoneAccentBrush"];
            radio.Background = accentBrush;
            radio.Foreground = accentBrush;
        }

        private void StoreSelectedItem(RadioButton radio)
        {
            ObservableCollection<XConfSession> sessions = ((ObservableCollection<XConfSession>)CurrentListBox().ItemsSource);
            int index = 0;
            XConfSession selectedSession = null;
            foreach (XConfSession session in sessions)
            {
                if (session.TimeSlot.Equals(radio.GroupName))
                {
                    selectedSession = session;
                    break;
                }
                index += 1;
            }

            (Day == 1 ? Day1Selected: Day2Selected).Insert(index, selectedSession);
        }

        private Brush Gray = new SolidColorBrush(Colors.LightGray);
        private Brush Black = new SolidColorBrush(Colors.Black);

        private void RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            bool isDarkTheme = (Visibility.Visible == (Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"]);
            RadioButton radio = (RadioButton)sender;
            radio.Background = Gray;
            radio.Foreground = (isDarkTheme) ? Gray : Black;
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}