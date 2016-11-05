using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Orders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string queryString = "SELECT SalesOrderId, SalesOrderNumber FROM [AdventureWorksLT2008].[SalesLT].[SalesOrderHeader]";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString))
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
                        ddSalesOrder.Items.Insert(0, "Select Sales Order");

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
        string queryString = "SELECT OrderQty, ProductID, UnitPrice, UnitPriceDiscount, LineTotal FROM [AdventureWorksLT2008].[SalesLT].[SalesOrderDetail] WHERE SalesOrderId = " +
            ddSalesOrder.SelectedValue.ToString();

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString))
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

}