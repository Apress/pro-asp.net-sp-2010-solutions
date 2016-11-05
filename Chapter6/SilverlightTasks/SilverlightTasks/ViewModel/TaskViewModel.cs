using System;
using System.Net;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using CLOM = Microsoft.SharePoint.Client;
using SilverlightTasks.Entities;
using SilverlightTasks;

namespace SilverlightTasks.ViewModel
{
    public class TaskViewModel : INotifyPropertyChanged, IDisposable
    {
        CLOM.ClientContext context;
        CLOM.ListItemCollection taskListItems;

        public ObservableCollection<Task> Tasks { get; private set; }
        

        public TaskViewModel()
        {
            context = new CLOM.ClientContext(CLOM.ApplicationContext.Current.Url);
            Tasks = new ObservableCollection<Task>();
        }

        public void GetTasks()
        {
            Tasks.Clear();
            CLOM.List taskList = context.Web.Lists.GetByTitle("Tasks");
            CLOM.CamlQuery query = new CLOM.CamlQuery();
            taskListItems = taskList.GetItems(query);
            context.Load(taskListItems);
            context.ExecuteQueryAsync(onQuerySucceeded, onQueryFailed);
        }

        private void onQuerySucceeded(object sender, CLOM.ClientRequestSucceededEventArgs args)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                foreach (var item in taskListItems)
                {
                    Task task = new Task();
                    task.Title = item["Title"].ToString();
                    task.Description = item["Body"].ToString();
                    task.DueDate = DateTime.Parse(item["DueDate"].ToString());
                    Tasks.Add(task);
                }
            });
        }

        private void onQueryFailed(object sender, CLOM.ClientRequestFailedEventArgs args)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() => MessageBox.Show("Execution Failed:" + args.Exception.InnerException.Message));
        }


        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
    }
}
