using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace Login_Demo
{
    public partial class login : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from login_table where Username = @user and password = @pass";

            SqlCommand cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@user",username.Text);
            cmd.Parameters.AddWithValue("@pass",password.Text);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if(dr.HasRows)
            {
                Session["user"] = username.Text;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Login Successful !!!')</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Login failed !!!')</script>");

            }
            con.Close();
        }
    }
}