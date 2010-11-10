using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using xconf_pune.XConfService;


namespace xconf_pune
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<XConfSession>();
        }

        /// <summary>
        /// A collection for XConfSession objects.
        /// </summary>
        public ObservableCollection<XConfSession> Items { get; set; }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few XConfSession objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            this.Items.Add(new XConfSession() { Topic = "runtime one", Presenters = "Maecenas praesent accumsan bibendum"});
            this.Items.Add(new XConfSession() { Topic = "runtime two", Presenters = "Dictumst eleifend facilisi faucibus"});
            this.Items.Add(new XConfSession() { Topic = "runtime three", Presenters = "Habitant inceptos interdum lobortis"});
            this.Items.Add(new XConfSession() { Topic = "runtime four", Presenters = "Nascetur pharetra placerat pulvinar"});
            this.Items.Add(new XConfSession() { Topic = "runtime five", Presenters = "Maecenas praesent accumsan bibendum"});
            this.Items.Add(new XConfSession() { Topic = "runtime six", Presenters = "Dictumst eleifend facilisi faucibus"});
            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}