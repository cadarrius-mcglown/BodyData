using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Microsoft.Samples.Kinect.BodyBasics
{
    /// <summary>
    /// Interaction logic for UserDashboard.xaml
    /// </summary>
    public partial class UserDashboard : Page
    {
        public string uname;

        public UserDashboard(string username)
        {
            InitializeComponent();

            uname = username;
            UserWelcomeLabel.Content = username + "'s Dashboard";

            //Allow Video titles to be file entires
            //string[] fileEntries = Directory.GetFiles(@"C:\UTVids\");

            string[] fileEntries = { "BodyData Study" };
            VideoListBox.ItemsSource= fileEntries;
        }

       
        private void Button_GoToSession_Click(object sender, RoutedEventArgs e)
        {
            List<string> SessionInfo = new List<string>();
            SessionInfo.Add(uname);
            SessionInfo.Add(VideoListBox.SelectedValue.ToString());

            //Normal page with video etc
            //UserSessionPage sp = new UserSessionPage(SessionInfo);
            //this.NavigationService.Navigate(sp);


            StudyUserSessionPage sp = new StudyUserSessionPage(SessionInfo);
            this.NavigationService.Navigate(sp);
        }
    }
}
