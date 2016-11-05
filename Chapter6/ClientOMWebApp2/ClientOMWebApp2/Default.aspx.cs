using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.Client;
using CLOM = Microsoft.SharePoint.Client;

namespace ClientOMWebApp2
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                lblResult.Text = "";
        }

        protected void btnAddTask_Click(object sender, EventArgs e)
        {
            string SiteCollectionURL = txtSiteCollection.Text;

            CLOM.ClientContext context = new CLOM.ClientContext(SiteCollectionURL);
            CLOM.List taskList = context.Web.Lists.GetByTitle("Tasks");
            CLOM.CamlQuery query = new CamlQuery();
            CLOM.ListItemCollection myTaskList = taskList.GetItems(query);

            context.Load(myTaskList,
                itms => itms.ListItemCollectionPosition,
                itms => itms.Include(
                    itm => itm["Title"],
                    itm => itm["Body"],
                    itm => itm["DueDate"]));

            context.ExecuteQuery();

            ListItemCreationInformation newTask = new ListItemCreationInformation();
            CLOM.ListItem newTaskItem = taskList.AddItem(newTask);

            newTaskItem["Title"] = txtTitle.Text;
            newTaskItem["Body"] = txtDesc.Text;
            newTaskItem["DueDate"] = Calendar1.SelectedDate;
            newTaskItem.Update();

            context.ExecuteQuery();

            lblResult.Text = "Added Task " + txtTitle.Text;
        }
    }
}