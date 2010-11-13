using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace XConfPune
{
    [ServiceContract]
    interface IXConfService
    {
        [OperationContract]
        ObservableCollection<XConfSession> FetchXConfSession(int day, int track);

        [OperationContract]
        ObservableCollection<SessionDetail> FetchSessionDetails(String topic);
    }

    class XConfService: IXConfService
    {
        public List<XConfSession> XConfSessions
        {
            get;
            set;
        }
        public List<SessionDetail> SessionDetails
        {
            get;
            set;
        }
        public void LoadXconfSessionData()
        {
            if (XConfSessions != null && XConfSessions.Count > 0)
            {
                return;
            }

            XConfSessions = new List<XConfSession>();
            XConfSessions.Add(new XConfSession() { Topic = "acid one", Presenters = "Maecenas praesent accumsan bibendum", TimeSlot = "0700 - 0800", Day = 1, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "acid two", Presenters = "Dictumst eleifend facilisi faucibus", TimeSlot = "0900 - 1000", Day = 1, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "acid three", Presenters = "Habitant inceptos interdum lobortis", TimeSlot = "1100 - 1200", Day = 1, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "acid four", Presenters = "Nascetur pharetra placerat pulvinar", TimeSlot = "1300 - 1400", Day = 1, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "acid five", Presenters = "Maecenas praesent accumsan bibendum", TimeSlot = "1500 - 1600", Day = 1, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "acid six", Presenters = "Dictumst eleifend facilisi faucibus", TimeSlot = "1700 - 1800", Day = 1, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "alkaline one", Presenters = "Maecenas praesent accumsan bibendum", TimeSlot = "0700 - 0800", Day = 1, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "alkaline two", Presenters = "Dictumst eleifend facilisi faucibus", TimeSlot = "0900 - 1000", Day = 1, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "alkaline three", Presenters = "Habitant inceptos interdum lobortis", TimeSlot = "1100 - 1200", Day = 1, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "alkaline four", Presenters = "Nascetur pharetra placerat pulvinar", TimeSlot = "1300 - 1400", Day = 1, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "alkaline five", Presenters = "Maecenas praesent accumsan bibendum", TimeSlot = "1500 - 1600", Day = 1, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "alkaline six", Presenters = "Dictumst eleifend facilisi faucibus", TimeSlot = "1700 - 1800", Day = 1, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "neutral one", Presenters = "Maecenas praesent accumsan bibendum", TimeSlot = "0700 - 0800", Day = 1, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "neutral two", Presenters = "Dictumst eleifend facilisi faucibus", TimeSlot = "0900 - 1000", Day = 1, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "neutral three", Presenters = "Habitant inceptos interdum lobortis", TimeSlot = "1100 - 1200", Day = 1, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "neutral four", Presenters = "Nascetur pharetra placerat pulvinar", TimeSlot = "1300 - 1400", Day = 1, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "neutral five", Presenters = "Maecenas praesent accumsan bibendum", TimeSlot = "1500 - 1600", Day = 1, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "neutral six", Presenters = "Dictumst eleifend facilisi faucibus", TimeSlot = "1700 - 1800", Day = 1, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "acid2 one", Presenters = "Maecenas praesent accumsan bibendum", TimeSlot = "0700 - 0800", Day = 2, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "acid2 two", Presenters = "Dictumst eleifend facilisi faucibus", TimeSlot = "0900 - 1000", Day = 2, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "acid2 three", Presenters = "Habitant inceptos interdum lobortis", TimeSlot = "1100 - 1200", Day = 2, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "acid2 four", Presenters = "Nascetur pharetra placerat pulvinar", TimeSlot = "1300 - 1400", Day = 2, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "acid2 five", Presenters = "Maecenas praesent accumsan bibendum", TimeSlot = "1500 - 1600", Day = 2, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "acid2 six", Presenters = "Dictumst eleifend facilisi faucibus", TimeSlot = "1700 - 1800", Day = 2, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "alkaline2 one", Presenters = "Maecenas praesent accumsan bibendum", TimeSlot = "0700 - 0800", Day = 2, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "alkaline2 two", Presenters = "Dictumst eleifend facilisi faucibus", TimeSlot = "0900 - 1000", Day = 2, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "alkaline2 three", Presenters = "Habitant inceptos interdum lobortis", TimeSlot = "1100 - 1200", Day = 2, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "alkaline2 four", Presenters = "Nascetur pharetra placerat pulvinar", TimeSlot = "1300 - 1400", Day = 2, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "alkaline2 five", Presenters = "Maecenas praesent accumsan bibendum", TimeSlot = "1500 - 1600", Day = 2, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "alkaline2 six", Presenters = "Dictumst eleifend facilisi faucibus", TimeSlot = "1700 - 1800", Day = 2, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "neutral2 one", Presenters = "Maecenas praesent accumsan bibendum", TimeSlot = "0900 - 1000", Day = 2, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "neutral2 two", Presenters = "Dictumst eleifend facilisi faucibus", TimeSlot = "0900 - 1000", Day = 2, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "neutral2 three", Presenters = "Habitant inceptos interdum lobortis", TimeSlot = "1100 - 1200", Day = 2, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "neutral2 four", Presenters = "Nascetur pharetra placerat pulvinar", TimeSlot = "1300 - 1400", Day = 2, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "neutral2 five", Presenters = "Maecenas praesent accumsan bibendum", TimeSlot = "1500 - 1600", Day = 2, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "neutral2 six", Presenters = "Dictumst eleifend facilisi faucibus", TimeSlot = "1700 - 1800", Day = 2, Track = 3 });
        }

        public void LoadSessionDetailsData()
        {
            if (SessionDetails != null && SessionDetails.Count > 0)
            {
                return;
            }

            SessionDetails = new List<SessionDetail>();
            SessionDetails.Add(new SessionDetail() { Topic = "acid one", Details = "Maecenas praesent accumsan bibendum" });
            SessionDetails.Add(new SessionDetail() { Topic = "acid two", Details = "Dictumst eleifend facilisi faucibus" });
            SessionDetails.Add(new SessionDetail() { Topic = "acid three", Details = "Habitant inceptos interdum lobortis" });
            SessionDetails.Add(new SessionDetail() { Topic = "acid four", Details = "Nascetur pharetra placerat pulvinar" });
            SessionDetails.Add(new SessionDetail() { Topic = "acid five", Details = "Maecenas praesent accumsan bibendum" });
            SessionDetails.Add(new SessionDetail() { Topic = "acid six", Details = "Dictumst eleifend facilisi faucibus" });
            SessionDetails.Add(new SessionDetail() { Topic = "alkaline one", Details = "Maecenas praesent accumsan bibendum" });
            SessionDetails.Add(new SessionDetail() { Topic = "alkaline two", Details = "Dictumst eleifend facilisi faucibus" });
            SessionDetails.Add(new SessionDetail() { Topic = "alkaline three", Details = "Habitant inceptos interdum lobortis" });
            SessionDetails.Add(new SessionDetail() { Topic = "alkaline four", Details = "Nascetur pharetra placerat pulvinar" });
            SessionDetails.Add(new SessionDetail() { Topic = "alkaline five", Details = "Maecenas praesent accumsan bibendum" });
            SessionDetails.Add(new SessionDetail() { Topic = "alkaline six", Details = "Dictumst eleifend facilisi faucibus" });
            SessionDetails.Add(new SessionDetail() { Topic = "neutral one", Details = "Maecenas praesent accumsan bibendum" });
            SessionDetails.Add(new SessionDetail() { Topic = "neutral two", Details = "Dictumst eleifend facilisi faucibus" });
            SessionDetails.Add(new SessionDetail() { Topic = "neutral three", Details = "Habitant inceptos interdum lobortis" });
            SessionDetails.Add(new SessionDetail() { Topic = "neutral four", Details = "Nascetur pharetra placerat pulvinar" });
            SessionDetails.Add(new SessionDetail() { Topic = "neutral five", Details = "Maecenas praesent accumsan bibendum" });
            SessionDetails.Add(new SessionDetail() { Topic = "neutral six", Details = "Dictumst eleifend facilisi faucibus" });
            SessionDetails.Add(new SessionDetail() { Topic = "acid2 one", Details = "Maecenas praesent accumsan bibendum" });
            SessionDetails.Add(new SessionDetail() { Topic = "acid2 two", Details = "Dictumst eleifend facilisi faucibus" });
            SessionDetails.Add(new SessionDetail() { Topic = "acid2 three", Details = "Habitant inceptos interdum lobortis" });
            SessionDetails.Add(new SessionDetail() { Topic = "acid2 four", Details = "Nascetur pharetra placerat pulvinar" });
            SessionDetails.Add(new SessionDetail() { Topic = "acid2 five", Details = "Maecenas praesent accumsan bibendum" });
            SessionDetails.Add(new SessionDetail() { Topic = "acid2 six", Details = "Dictumst eleifend facilisi faucibus" });
            SessionDetails.Add(new SessionDetail() { Topic = "alkaline2 one", Details = "Maecenas praesent accumsan bibendum" });
            SessionDetails.Add(new SessionDetail() { Topic = "alkaline2 two", Details = "Dictumst eleifend facilisi faucibus" });
            SessionDetails.Add(new SessionDetail() { Topic = "alkaline2 three", Details = "Habitant inceptos interdum lobortis" });
            SessionDetails.Add(new SessionDetail() { Topic = "alkaline2 four", Details = "Nascetur pharetra placerat pulvinar" });
            SessionDetails.Add(new SessionDetail() { Topic = "alkaline2 five", Details = "Maecenas praesent accumsan bibendum" });
            SessionDetails.Add(new SessionDetail() { Topic = "alkaline2 six", Details = "Dictumst eleifend facilisi faucibus" });
            SessionDetails.Add(new SessionDetail() { Topic = "neutral2 one", Details = "Maecenas praesent accumsan bibendum" });
            SessionDetails.Add(new SessionDetail() { Topic = "neutral2 two", Details = "Dictumst eleifend facilisi faucibus" });
            SessionDetails.Add(new SessionDetail() { Topic = "neutral2 three", Details = "Habitant inceptos interdum lobortis" });
            SessionDetails.Add(new SessionDetail() { Topic = "neutral2 four", Details = "Nascetur pharetra placerat pulvinar" });
            SessionDetails.Add(new SessionDetail() { Topic = "neutral2 five", Details = "Maecenas praesent accumsan bibendum" });
            SessionDetails.Add(new SessionDetail() { Topic = "neutral2 six", Details = "Dictumst eleifend facilisi faucibus" });
        }

        public ObservableCollection<XConfSession> FetchXConfSession(int day, int track)
        {
            LoadXconfSessionData();
            var query = from session in XConfSessions where session.Day == day && session.Track == track select session;
            
            ObservableCollection<XConfSession> result = new ObservableCollection<XConfSession>();
            foreach (XConfSession session in query)
            {
                result.Add(session);
            }
            return result;
        }

        public ObservableCollection<SessionDetail> FetchSessionDetails(String topic)
        {
            LoadSessionDetailsData();
            var query = from sessionDetail in SessionDetails where sessionDetail.Topic == topic select sessionDetail;
            
            ObservableCollection<SessionDetail> result = new ObservableCollection<SessionDetail>();
            foreach (SessionDetail sessionDetail in query)
            {
                result.Add(sessionDetail);
            }
            
            return result;
        }
    }
}
