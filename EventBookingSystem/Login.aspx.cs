using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventBookingSystem
{
    public partial class Login : System.Web.UI.Page
    {
        public string connectionString;
        public SqlConnection sqlConnection;
        protected void Page_Load(object sender, EventArgs e) // Basic Login page code for user authentication
        {
            

        
            connectionString = @"Data Source=infoinfraids520edrp.database.windows.net;Initial Catalog=InfoInfraIDS520Asp ;User ID=infoinfraids520edrp;Password=Ids520123"; // conncetion to azure database.
            
            sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            TextBox3.Attributes.Add("readonly", "readonly");
            TextBox3.Text = null;

            //Response.Write("Connection Made");



        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e) //For new user, redirect to Registration page.
        {
            Response.Redirect("Register.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e) //User authentication module
        {
            String userName = Request.Form["userName"];
            String password = Request.Form["password"];
            try // for checking if user exists and if not, then throws an exception.
            {


                SqlCommand cmd = new SqlCommand("select count (*) as cnt from Account where EmailAddress=@usr and EmailPassword=@pwd", sqlConnection);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@usr", userName);
                cmd.Parameters.AddWithValue("@pwd", password);

                if (cmd.ExecuteScalar().ToString() == "1")// if true, user already exists
                {
                    Session["Email"] = userName;
                    //Response.Write("valid");
                    cmd.Dispose();
                    SqlCommand cmd1 = new SqlCommand("select FirstName from Account where EmailAddress=@usr", sqlConnection);
                    cmd1.Parameters.Clear();
                    cmd1.Parameters.AddWithValue("@usr", userName);
                    //Response.Write("valid1");
                    
                    //Response.Write("valid12");
                    string UserName = cmd1.ExecuteScalar().ToString();
                    //Response.Write(UserName);
                    cmd1.Dispose();
                    sqlConnection.Close();

                    if (userName.ToString() == "admin@admin") // if admin, then redirect to admin page
                    {
                        Response.Redirect("AdminPage.aspx");
                    }
                    else
                    {
                        Session["First_Name"] = UserName;
                        Response.Redirect("Event.aspx?Field1="+userName);
                    }
                }
                else
                {
                    TextBox3.Text = null;
                    TextBox3.Text = "Username Password invalid";
                    Response.Write("User Does not Exist! Please Register");
                }
                


                
            }
            catch(Exception ex)
            {
                if (userName == null || password == null)
                {
                    TextBox3.Text = null;
                    TextBox3.Text = "Username Password invalid";
                }
                //Response.Write("User Does not Exist! Please Register");
            }
            


        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}