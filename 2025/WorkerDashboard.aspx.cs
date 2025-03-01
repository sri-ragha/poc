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
            BindTasks();
        }
    }
    private void BindTasks()
    {
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (MySqlConnection conn = new MySqlConnection(connString))
        {
            conn.Open();
            string query = "SELECT Id, Description, Status FROM Complaints WHERE WorkerId = (SELECT Id FROM Users WHERE Username = @Username)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", Session["Username"]);
            gvTasks.DataSource = cmd.ExecuteReader();
            gvTasks.DataBind();
        }
    }
    protected void gvTasks_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "UpdateStatus")
        {
            int taskId = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
            string status = ddlStatus.SelectedValue;

            UpdateTaskStatus(taskId, status);
            BindTasks();
        }
    }

    private void UpdateTaskStatus(int taskId, string status)
    {
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (MySqlConnection conn = new MySqlConnection(connString))
        {
            conn.Open();
            string query = "UPDATE Complaints SET Status = @Status WHERE Id = @TaskId";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@TaskId", taskId);
            cmd.ExecuteNonQuery();
        }
    }

}