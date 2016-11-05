using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.SharePoint.Client;

namespace SilverlightTaskAdder
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ClientContext context = new ClientContext(ApplicationContext.Current.Url);

            List taskList = context.Web.Lists.GetByTitle("Tasks");

            ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
            ListItem newItem = taskList.AddItem(itemCreateInfo);
            newItem["Title"] = txtTask.Text;
            newItem["DueDate"] = calendar1.SelectedDate.Value.ToShortDateString();
            newItem.Update();

            context.ExecuteQueryAsync(ClientRequestSucceeded, ClientRequestFailed);
        }

        private void ClientRequestSucceeded(object sender, ClientRequestSucceededEventArgs args)
        {
            // Use the dispatcher and Lamda to execute your code on the UI thread
            Dispatcher.BeginInvoke(() =>
            {
                label2.Content = String.Format("Task '{0}' added for you!", txtTask.Text);
                txtTask.Text = "";
            });
        }

        private void ClientRequestFailed(object sender, ClientRequestFailedEventArgs args)
        {
            Dispatcher.BeginInvoke(() =>
            {
                MessageBox.Show("Connection failed. Error code: "
                        + args.ErrorCode.ToString() + ". Message: " + args.Message);
            });
        }
    }
}
