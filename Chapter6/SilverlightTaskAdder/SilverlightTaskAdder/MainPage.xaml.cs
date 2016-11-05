using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using CLOM = Microsoft.SharePoint.Client;

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
            CLOM.ClientContext context = new CLOM.ClientContext(CLOM.ApplicationContext.Current.Url);

            CLOM.List taskList = context.Web.Lists.GetByTitle("Tasks");

            CLOM.ListItemCreationInformation itemCreateInfo = new CLOM.ListItemCreationInformation();
            CLOM.ListItem newItem = taskList.AddItem(itemCreateInfo);
            newItem["Title"] = textBox1.Text;
            newItem["DueDate"] = calendar1.SelectedDate.Value.ToShortDateString();
            newItem.Update();

            context.ExecuteQueryAsync(ClientRequestSucceeded, ClientRequestFailed);
        }

        private void ClientRequestSucceeded(object sender, CLOM.ClientRequestSucceededEventArgs args)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                label2.Content = "Task '" + textBox1.Text + "' added for you!";
                textBox1.Text = "";
            });
        }

        private void ClientRequestFailed(object sender, CLOM.ClientRequestFailedEventArgs args)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                MessageBox.Show("Connection failed. Error code: "
                        + args.ErrorCode.ToString() + ". Message: " + args.Message);
            });
        }
    }
}
