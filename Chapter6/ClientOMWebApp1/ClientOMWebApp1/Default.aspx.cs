using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.Client;
using CLOM = Microsoft.SharePoint.Client;

namespace ClientOMWebApp1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTasks.Text = "";
        }

        protected void btnGetTasks_Click(object sender, EventArgs e)
        {
            string SiteCollectionURL = txtSiteCollection.Text;
           
            CLOM.ClientContext context = new CLOM.ClientContext(SiteCollectionURL);
            CLOM.Web site = context.Web;
            CLOM.ListCollection lists = site.Lists;
            var taskList = context.Web.Lists.GetByTitle("Tasks");

            CLOM.CamlQuery query = new CamlQuery();
            CLOM.ListItemCollection myTaskList = taskList.GetItems(query);
            context.Load(myTaskList);
            context.ExecuteQuery();
            
            foreach (CLOM.ListItem tmpTaskItem in myTaskList)
            {
                lblTasks.Text += tmpTaskItem.FieldValues.Values.ElementAt(2).ToString() +"<br/>";
            }


        }
    }
}