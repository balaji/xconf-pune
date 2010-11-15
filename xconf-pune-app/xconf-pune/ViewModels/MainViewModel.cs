using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;
using System.Windows;
using xconf_pune.XConfService;


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
            this.Day1Items.Add(new XConfSession() { Topic = "<slot empty/>", Presenters = "<slot empty/>", TimeSlot = "0945 - 1030"});
            this.Day1Items.Add(new XConfSession() { Topic = "<slot empty/>", Presenters = "<slot empty/>", TimeSlot = "1030 - 1115"});
            this.Day1Items.Add(new XConfSession() { Topic = "<slot empty/>", Presenters = "<slot empty/>", TimeSlot = "1125 - 1210"});
            this.Day1Items.Add(new XConfSession() { Topic = "<slot empty/>", Presenters = "<slot empty/>", TimeSlot = "1210 - 1255"});
            this.Day1Items.Add(new XConfSession() { Topic = "<slot empty/>", Presenters = "<slot empty/>", TimeSlot = "1425 - 1525"});
            this.Day1Items.Add(new XConfSession() { Topic = "<slot empty/>", Presenters = "<slot empty/>", TimeSlot = "1535 - 1620"});
            this.Day1Items.Add(new XConfSession() { Topic = "<slot empty/>", Presenters = "<slot empty/>", TimeSlot = "1620 - 1705"});
            this.Day1Items.Add(new XConfSession() { Topic = "<slot empty/>", Presenters = "<slot empty/>", TimeSlot = "1720 - 1805"});
            this.Day1Items.Add(new XConfSession() { Topic = "<slot empty/>", Presenters = "<slot empty/>", TimeSlot = "1805 - 1835" });

            this.Day2Items.Add(new XConfSession() { Topic = "<slot empty/>", Presenters = "<slot empty/>", TimeSlot = "0930 - 1015" });
            this.Day2Items.Add(new XConfSession() { Topic = "<slot empty/>", Presenters = "<slot empty/>", TimeSlot = "1015 - 1100" });
            this.Day2Items.Add(new XConfSession() { Topic = "<slot empty/>", Presenters = "<slot empty/>", TimeSlot = "1115 - 1200" });
            this.Day2Items.Add(new XConfSession() { Topic = "<slot empty/>", Presenters = "<slot empty/>", TimeSlot = "1200 - 1245" });
            this.Day2Items.Add(new XConfSession() { Topic = "<slot empty/>", Presenters = "<slot empty/>", TimeSlot = "1415 - 1515" });

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
                        DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<int, ObservableCollection<XConfSession>>));
                        Dictionary<int, ObservableCollection<XConfSession>> f =
                            serializer.ReadObject(stream) as Dictionary<int, ObservableCollection<XConfSession>>;

                        foreach (XConfSession s in f[1])
                        {
                            this.Day1Items.Add(new XConfSession() { Topic = s.Topic, Presenters = s.Presenters, TimeSlot = s.TimeSlot });                            
                        }
                        foreach (XConfSession s in f[2])
                        {
                            this.Day2Items.Add(new XConfSession() { Topic = s.Topic, Presenters = s.Presenters, TimeSlot = s.TimeSlot });
                        }
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