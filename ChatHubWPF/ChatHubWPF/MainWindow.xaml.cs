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
using System.Data.SqlClient;

namespace ChatHubWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SignInUsernameBoxMouseEnter(object sender, MouseEventArgs e)
        {
            if (SignInUsernameBox.Text == "Username") SignInUsernameBox.Text = "";
        }

        private void SignInUsernameBoxMouseLeave(object sender, MouseEventArgs e)
        {
            if (SignInUsernameBox.Text == "") SignInUsernameBox.Text = "Username";
        }

        private void SignInPasswordBoxMouseEnter(object sender, MouseEventArgs e)
        {
            if (SignInPasswordBox.Password == "password") SignInPasswordBox.Password = "";
        }

        private void SignInPasswordBoxMouseLeave(object sender, MouseEventArgs e)
        {
            if (SignInPasswordBox.Password == "") SignInPasswordBox.Password = "password";
        }

        private void SignUpNameBoxMouseEnter(object sender, MouseEventArgs e)
        {
            if (SignUpNameBox.Text == "Name") SignUpNameBox.Text = "";
        }

        private void SignUpNameBoxMouseLeave(object sender, MouseEventArgs e)
        {
            if (SignUpNameBox.Text == "") SignUpNameBox.Text = "Name";
        }

        private void SignupEmailBoxMouseEnter(object sender, MouseEventArgs e)
        {
            if (SignUpEmailBox.Text == "Email") SignUpEmailBox.Text = "";
        }

        private void SignupEmailBoxMouseLeave(object sender, MouseEventArgs e)
        {
            if (SignUpEmailBox.Text == "") SignUpEmailBox.Text = "Email";
        }

        private void SignUpUsernameBoxMouseEnter(object sender, MouseEventArgs e)
        {
            if (SignUpUsernameBox.Text == "Username") SignUpUsernameBox.Text = "";
        }

        private void SignUpUsernameBoxMouseLeave(object sender, MouseEventArgs e)
        {
            if (SignUpUsernameBox.Text == "") SignUpUsernameBox.Text = "Username";
        }

        private void SignUpPasswordBoxMouseEnter(object sender, MouseEventArgs e)
        {
            if (SignUpPasswordBox.Password == "password") SignUpPasswordBox.Password = "";
        }

        private void SignUpPasswordBoxMouseLeave(object sender, MouseEventArgs e)
        {
            if (SignUpPasswordBox.Password == "") SignUpPasswordBox.Password = "password";
        }

        private void ButtonMinimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1(SignInUsernameBox.Text);
            window1.Show();
            this.Close();
            //pti kpnenw login service-in
        }

        private void RegistrationButtonClick(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1(SignInUsernameBox.Text);
            window1.Show();
            this.Close();
            //pti kpnenq registration service-in
        }
    }
}