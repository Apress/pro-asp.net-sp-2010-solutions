using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WebPartTaskList.TaskListAdd
{
    [ToolboxItemAttribute(false)]
    public class TaskListAdd : WebPart
    {
        Calendar calendar1 = new Calendar();
        Label lblTask = new Label();
        Label lblDescription = new Label();
        Label lblResult = new Label();
        TextBox txtTask = new TextBox();
        TextBox txtDescription = new TextBox();
        Button btnAddTask = new Button();

        protected override void CreateChildControls()
        {
            lblTask.Text = "Task:  ";
            lblDescription.Text = "Description:  ";
            btnAddTask.Text = "Add Task";
            Controls.Add(calendar1);
            Controls.Add(new LiteralControl("<br/>"));
            Controls.Add(lblTask);
            Controls.Add(txtTask);
            Controls.Add(new LiteralControl("<br/>"));
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(new LiteralControl("<br/>"));
            Controls.Add(btnAddTask);
            Controls.Add(new LiteralControl("<br/>"));
            Controls.Add(lblResult);
            btnAddTask.Click += new EventHandler(btnAddTask_Click);
        }

        void btnAddTask_Click(object sender, EventArgs e)
        {
            SPListItem task = SPContext.Current.Web.Lists["Tasks"].Items.Add();
            task["Due Date"] = calendar1.SelectedDate.ToShortDateString();
            task["Title"] = txtTask.Text;
            task["Description"] = txtDescription.Text;
            task.Update();
            lblResult.Text = String.Format("Task '{0}' added", txtTask.Text);
            txtTask.Text = "";
            txtDescription.Text = "";
        }
    }
}
