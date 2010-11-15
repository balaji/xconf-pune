using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace XConfPune
{
    [ServiceContract]
    interface IXConfService
    {
        [OperationContract]
        ObservableCollection<XConfSession> FetchXConfSession(int day, int track);
    }

    class XConfService: IXConfService
    {
        public List<XConfSession> XConfSessions
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
            XConfSessions.Add(new XConfSession() { Topic = "Scalable Architecture", Presenters = "Notes from LinkedIn, Facebook, Twitter - Rajesh Muppalla",    TimeSlot = "0945 - 1030", Day = 1, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "Windows Phone 7",       Presenters = "Hands On - Balaji Damodaran, Ramanathan Balakrishnan",        TimeSlot = "1030 - 1115", Day = 1, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "Real Time Web Apps",    Presenters = "Scalable real-time web applications - Kishore NC",            TimeSlot = "1125 - 1210", Day = 1, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "Performance Tracing",   Presenters = "Tracing Application Performance - Ram",                       TimeSlot = "1210 - 1255", Day = 1, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "Lightning Talks",       Presenters = "Anay N, Nikhil J, Mark N, Ashwin R, Rajesh B, Anand B",       TimeSlot = "1425 - 1525", Day = 1, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "Google Maps API",       Presenters = "Unusual Usage - Anand Agarwal, Pranav Nabar",                 TimeSlot = "1535 - 1620", Day = 1, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "MapReduce on AWS",      Presenters = "A Demo in Amazon Web Services - Prasanna Venkatesan",         TimeSlot = "1620 - 1705", Day = 1, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "Understanding Search",  Presenters = "A discussion on Search techniques - Ravindra Jaju",           TimeSlot = "1720 - 1805", Day = 1, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "Lightning Talks",       Presenters = "Rajesh T, Vivek J, Kaavya T, Anand B",                        TimeSlot = "1805 - 1835", Day = 1, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "Rapid Prototyping",     Presenters = "For creating Hi-Fi/Lo-Fi Prototypes - Jayalaxmi Dinni",       TimeSlot = "0900 - 1000", Day = 1, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "Cognitive Science",     Presenters = "Lessons for Business Analysts - Ram Ramalingam",              TimeSlot = "1100 - 1200", Day = 1, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "Usability Testing",     Presenters = "Hows and Whys - Aditya R, Hemanshu Narsana",                  TimeSlot = "1300 - 1400", Day = 1, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "Lightning Talks",       Presenters = "Anay N, Nikhil J, Mark N, Ashwin R, Rajesh B, Anand B",       TimeSlot = "1425 - 1525", Day = 1, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "What Type You Are?",    Presenters = "Personality Types - Shilpa Nair, Mukesh Kumar",               TimeSlot = "1500 - 1600", Day = 1, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "TLB - Parallelize",     Presenters = "tests to cut time - Pavan KS, Janmejay Singh",                TimeSlot = "1700 - 1800", Day = 1, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "Happiness Psychology",  Presenters = "The science, economics and psychology of Happiness - Ram",    TimeSlot = "0700 - 0800", Day = 1, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "Sales",                 Presenters = "Where do our projects come from - Shaun Jayaraj",             TimeSlot = "0900 - 1000", Day = 1, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "Lightning Talks",       Presenters = "Rajesh T, Vivek J, Kaavya T, Anand B",                        TimeSlot = "1805 - 1835", Day = 1, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "Program Nuggets - I",   Presenters = "Simple Programming Nuggets - Vivek Singh",                    TimeSlot = "0900 - 1030", Day = 1, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "Program Nuggets - II",  Presenters = "Simple Programming Nuggets - Vivek Singh",                    TimeSlot = "1030 - 1115", Day = 1, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "Project Planning - I",  Presenters = "Value based Project Planning - Akshay Dhavle, Chetan",        TimeSlot = "1125 - 1210", Day = 1, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "Project Planning - II", Presenters = "Value based Project Planning - Akshay Dhavle, Chetan",        TimeSlot = "1210 - 1255", Day = 1, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "Lightning Talks",       Presenters = "Anay N, Nikhil J, Mark N, Ashwin R, Rajesh B, Anand B",       TimeSlot = "1425 - 1525", Day = 1, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "JVM Tuning - I",        Presenters = "Power your JVM with effective GC tuning - Vivekanand Jha",    TimeSlot = "1535 - 1420", Day = 1, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "JVM Tuning - II",       Presenters = "Power your JVM with effective GC tuning - Vivekanand Jha",    TimeSlot = "1620 - 1705", Day = 1, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "What Customer Wants",   Presenters = "What Customer Wants? - Amitendra, Shilpa, Mukesh",            TimeSlot = "1720 - 1805", Day = 1, Track = 3 });
            XConfSessions.Add(new XConfSession() { Topic = "Lightning Talks",       Presenters = "Rajesh T, Vivek J, Kaavya T, Anand B",                        TimeSlot = "1805 - 1835", Day = 1, Track = 3 });

            XConfSessions.Add(new XConfSession() { Topic = "Implementing Cloud",    Presenters = "walk through of OpenStack - Ajey Gore, Ranjib Dey",           TimeSlot = "0930 - 1015", Day = 2, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "Functional Test",       Presenters = "Collective Ownership of TEAM - Sudeep Somani",                TimeSlot = "1015 - 1100", Day = 2, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "Multi-Agent Systems",   Presenters = "Game Theory and Playing God using LOGO - Ritesh M Nayak",     TimeSlot = "1115 - 1200", Day = 2, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "Photography",           Presenters = "and Photoshop. Dispelling the myths - Aroj P George",         TimeSlot = "1200 - 1245", Day = 2, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "Lightning Talks",       Presenters = "Prasanna V, Rajesh M, Pankaj K, Dharshini D, Vivek S",        TimeSlot = "1415 - 1515", Day = 2, Track = 1 });
            XConfSessions.Add(new XConfSession() { Topic = "F# Programming - I",    Presenters = "Object Functional Programming Using F# - Ashish Sharma",      TimeSlot = "0930 - 1015", Day = 2, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "F# Programming - II",   Presenters = "Object Functional Programming Using F# - Ashish Sharma",      TimeSlot = "1015 - 1100", Day = 2, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "Presentation Zen - I",  Presenters = "Interactive Talk on Presentations - Sumeet Moghe",            TimeSlot = "1115 - 1200", Day = 2, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "Presentation Zen - II", Presenters = "Interactive Talk on Presentations - Sumeet Moghe",            TimeSlot = "1200 - 1245", Day = 2, Track = 2 });
            XConfSessions.Add(new XConfSession() { Topic = "Lightning Talks", Presenters = "Prasanna V, Rajesh M, Pankaj K, Dharshini D, Vivek S",              TimeSlot = "1415 - 1515", Day = 2, Track = 2 });
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
    }
}
