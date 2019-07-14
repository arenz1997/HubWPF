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
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using ChatHubWPF.ServiceChat;
using System.Threading;
using System.Net.Http;
using ChatHubWPF.Models;
using Newtonsoft.Json;
using TestApi.Models;
using System.Text.RegularExpressions;

namespace ChatHubWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        static string messageapi = "http://localhost:51591/api/values";
        static string updateinfoapi = "http://localhost:51586/api/values";
        static string Username;
        static string Name;
        static List<object> oldList = new List<object>();
        public Window1(string name, string username)
        {
            Username = username;
            Name = name;
            InitializeComponent();
            
            oldList.Add("Vzgo");
            oldList.Add("Tigran");
            oldList.Add("Suren");
            oldList.Add("Areg");
            oldList.Add("Narek");
            oldList.Add("Arthur");
            foreach (var item in oldList)
            {
                RadGridView.Items.Add(item);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserNameLabel.Content = Username;//Username;
            NameUser.Content = Name;//User's name;
            
            //loopi mej kanchelu a update@(cerekov kanenq hesht a)
            //HttpClient client = new HttpClient();
            //while (true)
            //{
            //    var response = client.GetAsync(updateinfoapi+"/online");//.Result.Content.ReadAsStringAsync().Result;
            //    var jsonresult = response.Result.Content.ReadAsStringAsync().Result;
            //    var result = JsonConvert.DeserializeObject<List<Message>>(jsonresult);
            //    Thread.Sleep(3000);
            //}
        }
        private void MessageTextbox_MouseEnter(object sender, MouseEventArgs e)
        {
            if(MessageTextbox.Text== "Type your message here...")
            MessageTextbox.Text = "";
        }

        private void MessageTextbox_MouseLeave(object sender, MouseEventArgs e)
        {
            if(MessageTextbox.Text=="")
            MessageTextbox.Text = "Type your message here...";
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
        private void ButtonMinimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private async void MessageTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (MessageTextbox.Text == "Type your message here...") MessageTextbox.Text = "";
            if (e.Key == Key.Enter)
            {
                if (MessageTextbox.Text == "") return;
                //Call sendMessageService
                HttpClient client = new HttpClient();
                //Post client
                Message message = new Message(Username, RadGridView.SelectedItem.ToString(), MessageTextbox.Text, false);
                var Json = JsonConvert.SerializeObject(message);
                var httpContent = new StringContent(Json, Encoding.UTF8, "application/json");
                await client.PostAsync(messageapi, httpContent);
                //post client
                //Call sendMessageService

                var response = client.GetAsync(string.Format("{0}/{1}/{2}", messageapi,Username, RadGridView.SelectedItem.ToString()));//.Result.Content.ReadAsStringAsync().Result;
                var jsonresult = response.Result.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<Message>>(jsonresult);

                foreach (var item in result)
                {
                    if (!ChatMessages.Items.Contains(item.MessageText)) ChatMessages.Items.Add(item.MessageText);
                }
                MessageTextbox.Text = "";
            }
        }

        

        private async void SendMessageButtonClick(object sender, RoutedEventArgs e)
        {
            if ((MessageTextbox.Text == "") || (MessageTextbox.Text == "Type your message here...")) return;

            //Call sendMessageService
            HttpClient client = new HttpClient();
            //Post client
            Message message = new Message(Username, RadGridView.SelectedItem.ToString(), MessageTextbox.Text, false);
            var Json = JsonConvert.SerializeObject(message);
            var httpContent = new StringContent(Json, Encoding.UTF8, "application/json");
            await client.PostAsync(messageapi, httpContent);
            //post client
            //Call sendMessageService

            var response = client.GetAsync(string.Format("{0}/{1}/{2}",messageapi, Username, RadGridView.SelectedItem.ToString()));//.Result.Content.ReadAsStringAsync().Result;
            var jsonresult = response.Result.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<Message>>(jsonresult);

            foreach (var item in result)
            {
                if (!ChatMessages.Items.Contains(item.MessageText)) ChatMessages.Items.Add(item.MessageText);
            }
            MessageTextbox.Text = "Type your message here...";
        }


        private void RadGridView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ChatMessages.Items.Clear();
            HttpClient client = new HttpClient();
            var response = client.GetAsync(string.Format("{0}/{1}/{2}", messageapi, Username, RadGridView.SelectedItem.ToString()));//.Result.Content.ReadAsStringAsync().Result;
            var jsonresult = response.Result.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<Message>>(jsonresult);

            foreach (var item in result)
            {
                if(!ChatMessages.Items.Contains(item.MessageText)) ChatMessages.Items.Add(item.MessageText);
            }
            MessageTextbox.Text = "Type your message here...";
        }






        private void ChatMessages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete) ChatMessages.Items.Remove(ChatMessages.SelectedItem);
        }

        private void EndVideoCallButtonClick(object sender, RoutedEventArgs e)
        {
            EndVideoCallButton.IsEnabled = false;
            StartVideoCallButton.IsEnabled = true;
            VideoFrame.Visibility = Visibility.Collapsed;
            ChatMessages.Visibility = Visibility.Visible;
            MessageTextbox.Visibility = Visibility.Visible;
        }

        private void StartVideoCallButtonClick(object sender, RoutedEventArgs e)
        {
            //Call videoCallService
            StartVideoCallButton.IsEnabled = false;
            EndVideoCallButton.IsEnabled = true;
            VideoFrame.Visibility = Visibility.Visible;
            ChatMessages.Visibility = Visibility.Collapsed;
            MessageTextbox.Visibility = Visibility.Collapsed;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            await httpClient.DeleteAsync(messageapi);
            ChatMessages.Items.Clear();
        }

        private void SearchTextBoxMouseEnter(object sender, MouseEventArgs e)
        {
            if (SearchTexBox.Text == "Search user")
                SearchTexBox.Text = "";
        }

        private void SearchTextBoxMouseLeave(object sender, MouseEventArgs e)
        {
            if (SearchTexBox.Text == "")
                SearchTexBox.Text = "Search user";
        }
        private void SearchTexBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if ((SearchTexBox.Text == "")||(SearchTexBox.Text=="Search user"))
            {
                RadGridView.Items.Clear();
                foreach (var item in oldList)
                {
                    RadGridView.Items.Add(item);
                }
                return;
            }
            RadGridView.Items.Clear();
            foreach (var item in oldList)
            {
                if (Regex.IsMatch(item.ToString(), Regex.Escape(SearchTexBox.Text), RegexOptions.IgnoreCase))
                {
                    RadGridView.Items.Add(item);
                }
            }
        }
    }
}