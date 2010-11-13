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
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;


namespace xconf_pune
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Day1Items = new ObservableCollection<XConfSession>();
            this.Day2Items = new ObservableCollection<XConfSession>();
        }

        public ObservableCollection<XConfSession> Day1Items { get; set; }
        public ObservableCollection<XConfSession> Day2Items { get; set; }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadDefaultData()
        {
            this.Day1Items.Add(new XConfSession() { Topic = "runtime one", Presenters = "Maecenas praesent accumsan bibendum"});
            this.Day1Items.Add(new XConfSession() { Topic = "runtime two", Presenters = "Dictumst eleifend facilisi faucibus" });
            this.Day1Items.Add(new XConfSession() { Topic = "runtime three", Presenters = "Habitant inceptos interdum lobortis" });
            this.Day1Items.Add(new XConfSession() { Topic = "runtime four", Presenters = "Nascetur pharetra placerat pulvinar"});
            this.Day1Items.Add(new XConfSession() { Topic = "runtime five", Presenters = "Maecenas praesent accumsan bibendum"});
            this.Day1Items.Add(new XConfSession() { Topic = "runtime six", Presenters = "Dictumst eleifend facilisi faucibus"});

            this.Day2Items.Add(new XConfSession() { Topic = "runtime2 one", Presenters = "Maecenas praesent accumsan bibendum" });
            this.Day2Items.Add(new XConfSession() { Topic = "runtime2 two", Presenters = "Dictumst eleifend facilisi faucibus" });
            this.Day2Items.Add(new XConfSession() { Topic = "runtime2 three", Presenters = "Habitant inceptos interdum lobortis" });
            this.Day2Items.Add(new XConfSession() { Topic = "runtime2 four", Presenters = "Nascetur pharetra placerat pulvinar" });
            this.Day2Items.Add(new XConfSession() { Topic = "runtime2 five", Presenters = "Maecenas praesent accumsan bibendum" });
            this.Day2Items.Add(new XConfSession() { Topic = "runtime2 six", Presenters = "Dictumst eleifend facilisi faucibus" });
            
            this.IsDataLoaded = true;
        }

        public void LoadAData()
        {
            using (IsolatedStorageFile isoStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                try
                {
                    using (IsolatedStorageFileStream stream = isoStorage.OpenFile("xconfpune.dat", FileMode.OpenOrCreate))
                    {
                        if (stream.Length == 0)
                        {
                            LoadDefaultData();
                            this.IsDataLoaded = true;
                            return;
                        }
                        DataContractSerializer serializer = new DataContractSerializer(typeof(ObservableCollection<XConfSession>));
                        ObservableCollection<XConfSession> f =
                            serializer.ReadObject(stream) as ObservableCollection<XConfSession>;
                    }
                    this.IsDataLoaded = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error loading." + ex.Message);
                }
            }
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