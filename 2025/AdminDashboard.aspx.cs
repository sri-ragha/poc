using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindComplaints();
            BindFeedback();
        }
    }
    private void BindComplaints()
    {
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (MySqlConnection conn = new MySqlConnection(connString))
        {
            conn.Open();
            string query = "SELECT Id, Description, Status FROM Complaints";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            gvComplaints.DataSource = cmd.ExecuteReader();
            gvComplaints.DataBind();
        }

        // Populate worker dropdowns
        foreach (GridViewRow row in gvComplaints.Rows)
        {
            DropDownList ddlWorkers = (DropDownList)row.FindControl("ddlWorkers");
            PopulateWorkersDropdown(ddlWorkers);
        }
    }

    private void PopulateWorkersDropdown(DropDownList ddlWorkers)
    {
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (MySqlConnection conn = new MySqlConnection(connString))
        {
            conn.Open();
            string query = "SELECT Id, Username FROM Users WHERE Role = 'Worker'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            ddlWorkers.DataSource = cmd.ExecuteReader();
            ddlWorkers.DataTextField = "Username";
            ddlWorkers.DataValueField = "Id";
            ddlWorkers.DataBind();
        }
    }
    private void BindFeedback()
    {
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (MySqlConnection conn = new MySqlConnection(connString))
        {
            conn.Open();
            string query = "SELECT Id, Message FROM Feedback";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            gvFeedback.DataSource = cmd.ExecuteReader();
            gvFeedback.DataBind();
        }
    }
    protected void gvComplaints_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Assign")
        {
            int complaintId = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            DropDownList ddlWorkers = (DropDownList)row.FindControl("ddlWorkers");
            int workerId = Convert.ToInt32(ddlWorkers.SelectedValue);

            AssignComplaintToWorker(complaintId, workerId);
            BindComplaints();
        }
    }

    private void AssignComplaintToWorker(int complaintId, int workerId)
    {
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (MySqlConnection conn = new MySqlConnection(connString))
        {
            conn.Open();
            string query = "UPDATE Complaints SET WorkerId = @WorkerId, Status = 'Assigned' WHERE Id = @ComplaintId";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@WorkerId", workerId);
            cmd.Parameters.AddWithValue("@ComplaintId", complaintId);
            cmd.ExecuteNonQuery();
        }
    }


}