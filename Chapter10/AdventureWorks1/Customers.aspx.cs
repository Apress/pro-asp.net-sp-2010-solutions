using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Customers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string queryString = "SELECT CustomerID, CompanyName FROM [AdventureWorksLT2008].[SalesLT].[Customer]";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString))
            {
                using (SqlDataAdapter sdaSO = new SqlDataAdapter(queryString, connection))
                {
                    try
                    {
                        DataTable dtSO = new DataTable();
                        sdaSO.Fill(dtSO);
                        ddCustomer.DataSource = dtSO;
                        ddCustomer.DataTextField = "CompanyName";
                        ddCustomer.DataValueField = "CustomerID";
                        ddCustomer.DataBind();
                        ddCustomer.Items.Insert(0, "Select Customer");

                    }
                    catch (Exception ex)
                    {
                        lblErrorMessage.Text = "Error retrieving data " + ex.Message;
                    }
                }
            }
        }
    }

    public void ddCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        string queryString = "SELECT CompanyName, EmailAddress, Phone, FirstName, LastName FROM [AdventureWorksLT2008].[SalesLT].[Customer] WHERE CustomerID = " +
            ddCustomer.SelectedValue.ToString();

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString))
        {
            using (SqlDataAdapter sdaSO = new SqlDataAdapter(queryString, connection))
            {
                try
                {
                    DataTable dtSO = new DataTable();
                    sdaSO.Fill(dtSO);
                    dvCustomerDetail.DataSource = dtSO;
                    dvCustomerDetail.DataBind();
                }
                catch (Exception ex)
                {
                    lblErrorMessage.Text = "Error retrieving data " + ex.Message;
                }
            }

        }
    }
}