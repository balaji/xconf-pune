using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xconf_pune;

namespace xconf_pune_test{
    [TestClass]
    public class XconfDetailsTest
    {
        private XConfDetails xconfDetails = new XConfDetails();
        
        [TestMethod]
        public void ShouldReturnHallListBasedOnTheTrack()
        {
            xconfDetails.Track = 1;
            
            ListBox actual = xconfDetails.CurrentListBox();
            Assert.AreEqual(xconfDetails.hall1List, actual);
        }
    }
}