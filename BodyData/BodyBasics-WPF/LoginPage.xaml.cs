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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(textBox_FirstN.Text == "admin" & textBox_LastN.Text == "admin")
            {
                AdminPage ap = new AdminPage();
                this.NavigationService.Navigate(ap);
            }else
            {
                string user = textBox_FirstN.Text + " " + textBox_LastN.Text;
                UserDashboard ud = new UserDashboard(user);
                this.NavigationService.Navigate(ud);
            }

           
        }
    }
}
