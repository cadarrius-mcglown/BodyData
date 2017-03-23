using System;
using System.Collections.Generic;
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
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        string selectedUserName;
        public AdminPage()
        {
            InitializeComponent();

            List<string> patientNames;
            using(DataService.Service1Client s = new DataService.Service1Client())
            {
                patientNames = s.GetPatients().ToList<string>();
            }

            PatientListBox.ItemsSource = patientNames;



        }

        private void Button_GetSessions_Click(object sender, RoutedEventArgs e)
        {
            selectedUserName = PatientListBox.SelectedValue.ToString();

            using (DataService.Service1Client s = new DataService.Service1Client())
            {
               SessionListBox.ItemsSource =  s.GetSessions(selectedUserName);
            }


        }

        private void Button_GoToSession_Click(object sender, RoutedEventArgs e)
        {
            List<string> SessionInfo = new List<string>();
            SessionInfo.Add(selectedUserName);
            SessionInfo.Add(SessionListBox.SelectedValue.ToString());

            AdminSessionReview asr = new AdminSessionReview(SessionInfo);
            this.NavigationService.Navigate(asr);
        }
    }
}
