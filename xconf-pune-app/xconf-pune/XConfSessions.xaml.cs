using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;
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
        public int Track { get; set; }
        private Dictionary<int, XConfSession> Day1Selected { get; set; }
        private Dictionary<int, XConfSession> Day2Selected { get; set; }

        public XConfDetails()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(XConfDetails_Loaded);
            Day1Selected = new Dictionary<int, XConfSession>();
            Day2Selected = new Dictionary<int, XConfSession>();
        }

        private void XConfDetails_Loaded(object sender, RoutedEventArgs e)
        {
            LoadXConfSessionData(Day, 1);
        }

        private void LoadXConfSessionData(int day, int track)
        {
            Track = track;
            if (client == null)
            {
                client = new XConfServiceClient(new System.ServiceModel.BasicHttpBinding(), new EndpointAddress("http://localhost:8001/xconf"));
                client.FetchXConfSessionCompleted += new EventHandler<FetchXConfSessionCompletedEventArgs>(Pivot_Completed);
            }
            if (!IsContentAlreadyLoaded()) client.FetchXConfSessionAsync(day, track);
        }

        private bool IsContentAlreadyLoaded()
        {
            return CurrentProgressBar().Visibility == Visibility.Collapsed;
        }

        public ListBox CurrentListBox()
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

        private void Pivot_Completed(object sender, FetchXConfSessionCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ShowUI(CurrentListBox(), CurrentProgressBar(), e.Result);
            }
            else
            {
                ErrorPage.Exception = e.Error;
                NavigationService.Navigate(new Uri("/ErrorPage.xaml", UriKind.Relative));
            }
        }

        private void ShowUI(ListBox Box, ProgressBar Bar, ObservableCollection<XConfSession> Result)
        {
            if (Result == null || Result.Count == 0)
            {
                MessageBox.Show("No Sessions for this Track :(");
                xconfPivot.SelectedItem = hall1Pivot;
                return;
            }
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
                xconfPivot.Title = "xconf pune sessions - day " + Day;
            }
        }

        private void Pivot_LoadedPivotItem(object sender, PivotItemEventArgs e)
        {
            string Item = ((PivotItem)e.Item).Header.ToString();
            LoadXConfSessionData(Day, Int16.Parse(Item.Substring(Item.Length - 1)));
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            SolidColorBrush accentBrush = (SolidColorBrush)Application.Current.Resources["PhoneAccentBrush"];
            radio.Background = accentBrush;
            radio.Foreground = accentBrush;
            StoreSelectedItem(radio);
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

            CurrentDay()[index] = selectedSession;
        }

        private Dictionary<int, XConfSession> CurrentDay()
        {
            return Day == 1 ? Day1Selected : Day2Selected;
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
            foreach (KeyValuePair<int, XConfSession> entry in CurrentDay())
            {
                (Day == 1 ? App.ViewModel.Day1Items : App.ViewModel.Day2Items)[entry.Key] = entry.Value;
            }

            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            SaveInFile();
        }

        private void SaveInFile()
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("xconfpune.dat", FileMode.Create, isf))
                {
                    DataContractSerializer dcs = new DataContractSerializer(typeof(Dictionary<int, ObservableCollection<XConfSession>>));
                    dcs.WriteObject(stream, new Dictionary<int, ObservableCollection<XConfSession>> 
                    { { 1, App.ViewModel.Day1Items }, 
                    { 2, App.ViewModel.Day2Items } });
                }
            }
        }
    }
}