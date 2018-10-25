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
    public partial class SeatDetails : System.Web.UI.Page
    {
        public string connectionString = @"Data Source=infoinfraids520edrp.database.windows.net;Initial Catalog=InfoInfraIDS520Asp ;User ID=infoinfraids520edrp;Password=Ids520123";
        public SqlConnection sqlConnection;


        protected void Page_Load(object sender, EventArgs e)
        {

            String eNumb = Request.QueryString["Field1"];
            String ename = Request.QueryString["Field2"];

            Label1.Text = ename;
            sqlConnection = new SqlConnection(connectionString);
            //Query for fetching the seats booked for the selectd event
            SqlCommand cmd = new SqlCommand("select E_Number, EmailAddress+': Row-'+ RowName+' Seat-'+ convert(varchar,S_Number) as seat from Reservation where E_Number= convert(int," + eNumb+")", sqlConnection);
            sqlConnection.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            DropDownList1.DataTextField ="seat";
            DropDownList1.DataValueField = "E_Number";
            DropDownList1.DataSource = cmd.ExecuteReader();
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("--View--", "0"));
            cmd.Dispose();
            sda.Dispose();
            ds.Dispose();

            sqlConnection.Close();

            //additional count details
            SqlCommand cmd1 = new SqlCommand("select Count (*) as cnt from Reservation where E_number = convert(int,"+eNumb+")", sqlConnection);
            sqlConnection.Open();
            DataSet ds1 = new DataSet();
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
            sda1.Fill(ds1);
            Label2.Text = ds1.Tables[0].Rows.Count.ToString();//getting the total seats count booked.
            DropDownList2.DataTextField = "Cnt";
            DropDownList2.DataSource = cmd1.ExecuteReader();
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("--Select--", "0"));
            cmd1.Dispose();
            sda1.Dispose();
            ds1.Dispose();
            sqlConnection.Close();

        
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
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