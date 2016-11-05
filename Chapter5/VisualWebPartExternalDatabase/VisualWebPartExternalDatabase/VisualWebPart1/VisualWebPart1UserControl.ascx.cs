using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Linq;
using System.Xml.Linq;
using System.Data.SqlClient;
using Microsoft.SharePoint;

namespace VisualWebPartExternalDatabase.VisualWebPart1
{
    public partial class VisualWebPart1UserControl : UserControl
    {
        public string connectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = GetConnectionString1();
            connectionString = GetConnectionString2();
            connectionString = GetConnectionString3();

            if (!Page.IsPostBack)
            {
                string queryString = "SELECT SalesOrderId, SalesOrderNumber FROM [AdventureWorksLT2008R2].[SalesLT].[SalesOrderHeader]";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlDataAdapter sdaSO = new SqlDataAdapter(queryString, connection))
                    {
                        try
                        {
                            DataTable dtSO = new DataTable();
                            sdaSO.Fill(dtSO);
                            ddSalesOrder.DataSource = dtSO;
                            ddSalesOrder.DataTextField = "SalesOrderNumber";
                            ddSalesOrder.DataValueField = "SalesOrderId";
                            ddSalesOrder.DataBind();
                        }
                        catch (Exception ex)
                        {
                            lblErrorMessage.Text = "Error retrieving data " + ex.Message;
                        }
                    }
                }
            }
        }

   

        public void ddSalesOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            string queryString = "SELECT * FROM [AdventureWorksLT2008R2].[SalesLT].[SalesOrderDetail] WHERE SalesOrderId = " +
                ddSalesOrder.SelectedValue.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter sdaSO = new SqlDataAdapter(queryString, connection))
                {
                    try
                    {
                        DataTable dtSO = new DataTable();
                        sdaSO.Fill(dtSO);
                        gvSalesOrderDetail.DataSource = dtSO;
                        gvSalesOrderDetail.DataBind();
                    }
                    catch (Exception ex)
                    {
                        lblErrorMessage.Text = "Error retrieving data " + ex.Message;
                    }
                }

            }
        }

        private static string GetConnectionString1()
        {
            string featureDir = @"C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\TEMPLATE\FEATURES\VisualWebPartExternalDatabase_Feature1\VisualWebPart1\";
            XElement xEl = XElement.Load(featureDir + "ConnectionStrings.xml");
            XElement xElConnection = (from x in xEl.Elements("add")
                                where (string)x.Attribute("name") == "AdventureWorks"
                                select x).First();
            return xElConnection.Attribute("connectionString").Value;
        }

        private string GetConnectionString2()
        {
            SPList csList = SPContext.Current.Web.Lists["Connection Strings"];
            SPQuery query = new SPQuery();
            query.Query = "<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>AdventureWorks</Value></Eq></Where>";
            SPListItemCollection csItems = csList.GetItems(query);
            if (csItems.Count == 1)
                return csItems[0]["ConnectionString"].ToString();
            else
                return string.Empty;
        }
        
        private string GetConnectionString3()
        {
            return ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString;
        }
    }
}
