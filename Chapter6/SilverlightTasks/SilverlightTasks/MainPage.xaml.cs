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

namespace SilverlightTasks
{
    public partial class MainPage : UserControl, IDisposable
    {
        SilverlightTasks.ViewModel.TaskViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            viewModel = new ViewModel.TaskViewModel();
            this.DataContext = viewModel;
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            lblStatus.Content = "Starting data retrieval...";
            viewModel.GetTasks();
            lblStatus.Content = "Data retrieval complete...";
            
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                viewModel.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
