using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;

namespace VisualWebPartTaskList.VisualWebPart1
{
    public partial class VisualWebPart1UserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SPListItem task = SPContext.Current.Web.Lists["Tasks"].Items.Add();
            task["Due Date"] = Calendar1.SelectedDate.ToShortDateString();
            task["Title"] = TextBox1.Text;
            task["Description"] = TextBox2.Text;
            task.Update();
            lblResults.Text = String.Format("Task '{0}' added", TextBox1.Text);
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}
