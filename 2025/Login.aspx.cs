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

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = TextBox1 .Text;
        string password = TextBox2.Text;

        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (MySqlConnection conn = new MySqlConnection(connString))
        {
            conn.Open();
            string query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            object role = cmd.ExecuteScalar();

            if (role != null)
            {
                Session["Role"] = role.ToString();
                Session["Username"] = username;

                if (role.ToString() == "Admin") Response.Redirect("AdminDashboard.aspx");
                else if (role.ToString() == "User") Response.Redirect("UserHome.aspx");
                else if (role.ToString() == "Worker") Response.Redirect("WorkerDashboard.aspx");
            }
            else
            {
                // Invalid login
            }
        }
    }
}