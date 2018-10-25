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
    public partial class AllUser : System.Web.UI.Page
    {
        public string connectionString = @"Data Source=infoinfraids520edrp.database.windows.net;Initial Catalog=InfoInfraIDS520Asp ;User ID=infoinfraids520edrp;Password=Ids520123";
        public SqlConnection sqlConnection;

        protected void Page_Load(object sender, EventArgs e)
        {
            String emailAdd = Request.QueryString["Field1"];//from response header
            Label1.Text = emailAdd;

            sqlConnection = new SqlConnection(connectionString);
            // Query for fetching seats and events booked by the user.
            SqlCommand cmd = new SqlCommand("select distinct Convert(varchar,r.E_Number)+' '+e.Performance +' '+ r.RowName +' '+ Convert(varchar,r.S_Number) as Com " +
                                            "from Reservation r, Event e, Account a" +
                                            " where r.E_Number = e.Number and r.EmailAddress ='" + emailAdd + "'", sqlConnection);
            sqlConnection.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            DropDownList1.DataTextField = "Com";

            DropDownList1.DataSource = cmd.ExecuteReader();
            DropDownList1.DataBind();
            //DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));


            cmd.Dispose();
            sda.Dispose();
            ds.Dispose();

            sqlConnection.Close();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)//on Logout click
        {
            Response.Redirect("Login.aspx");
            Session.Abandon();
        }

        public void disablebrowserbackbutton()
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();
        }

    }
}