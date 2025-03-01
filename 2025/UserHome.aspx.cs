using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindComplaintStatus();
        }
    }
    protected void btnSubmitComplaint_Click(object sender, EventArgs e)
    {
        string complaint = txtComplaint.Text.Trim();

        if (string.IsNullOrEmpty(complaint))
        {
            // Handle empty input
            return;
        }

        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (MySqlConnection conn = new MySqlConnection(connString))
        {
            conn.Open();
            string query = "INSERT INTO Complaints (UserId, Description) VALUES ((SELECT Id FROM Users WHERE Username = @Username), @Description)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", Session["Username"]);
            cmd.Parameters.AddWithValue("@Description", complaint);
            cmd.ExecuteNonQuery();
        }

        txtComplaint.Text = string.Empty; // Clear input field
        BindComplaintStatus(); // Refresh status grid
    }

    private void BindComplaintStatus()
    {
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (MySqlConnection conn = new MySqlConnection(connString))
        {
            conn.Open();
            string query = "SELECT Id, Description, Status FROM Complaints WHERE UserId = (SELECT Id FROM Users WHERE Username = @Username)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", Session["Username"]);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvComplaintStatus.DataSource = dt;
            gvComplaintStatus.DataBind();
        }
    }
    
    protected void btnSubmitFeedback_Click(object sender, EventArgs e)
    {
        string feedback = txtFeedback.Text.Trim();

        if (string.IsNullOrEmpty(feedback))
        {
            // Handle empty input
            return;
        }

        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (MySqlConnection conn = new MySqlConnection(connString))
        {
            conn.Open();
            string query = "INSERT INTO Feedback (UserId, Message) VALUES ((SELECT Id FROM Users WHERE Username = @Username), @Message)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", Session["Username"]);
            cmd.Parameters.AddWithValue("@Message", feedback);
            cmd.ExecuteNonQuery();
        }

        txtFeedback.Text = string.Empty; // Clear input field
    }
}