using System;
using System.ComponentModel;

namespace XConfPune
{
    public class XConfSession
    {
        public string Topic
        {
            get;
            set;
        }

        public string Presenters
        {
            get;
            set;
        }

        public string TimeSlot
        {
            get;
            set;
        }
        
        public int Day
        {
            get;
            set;
        }
        
        public int Track
        {
            get;
            set;
        }
    }
}