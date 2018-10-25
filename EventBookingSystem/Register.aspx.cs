using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace EventBookingSystem
{
    public partial class Register : System.Web.UI.Page
    {
        public string connectionString;
        public SqlConnection sqlConnection;
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = @"Data Source=infoinfraids520edrp.database.windows.net;Initial Catalog=InfoInfraIDS520Asp ;User ID=infoinfraids520edrp;Password=Ids520123";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            //Response.Write("Connection Made");

        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            String firstName = Request.Form["FirstName"];
            String lastName = Request.Form["LastName"];
            String userName = Request.Form["EmailId"];
            String password = Request.Form["Password"];

            //Response.Write(firstName + " " + lastName);
            try
            {
                String query = "Insert into Account (LastName, FirstName, EmailAddress, EmailPassword) values (\'" + lastName + "\' , \'" + firstName + "\' , \'" + userName + "\' , \'" + password + "\')";
               // Response.Write(query);
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                command = new SqlCommand(query, sqlConnection);
                adapter.InsertCommand = new SqlCommand(query, sqlConnection);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                sqlConnection.Close();
                //Response.Write("Qurey inseted");
                Response.Redirect("login.aspx");

            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
                Response.Write("User Already exists!");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        public void disablebrowserbackbutton()
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();
        }
    }
}