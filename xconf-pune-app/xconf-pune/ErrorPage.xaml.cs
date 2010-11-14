using System;
using Microsoft.Phone.Controls;
using System.Windows.Navigation;

namespace xconf_pune
{
    public partial class ErrorPage : PhoneApplicationPage
    {
        public ErrorPage()
        {
            InitializeComponent();
        }

        public static Exception Exception;

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ErrorText.Text = Exception.ToString();
        }
    }
}