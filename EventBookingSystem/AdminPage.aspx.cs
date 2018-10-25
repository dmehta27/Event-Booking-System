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
    public partial class AdminPage : System.Web.UI.Page
    {
        public string connectionString = @"Data Source=infoinfraids520edrp.database.windows.net;Initial Catalog=InfoInfraIDS520Asp ;User ID=infoinfraids520edrp;Password=Ids520123";
        public SqlConnection sqlConnection;
        int final;
        string emadd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Response.Write("Login Success")
                sqlConnection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("select Number, Performance + ' - ' + CONVERT(varchar,EventDate, 10)  + ' - ' + CONVERT(varchar,EventTime,8) as Com from Event" +
                                                " where EventDate > Convert(date,GetDate(),10) ", sqlConnection);
                sqlConnection.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                DropDownList1.DataTextField = "Com";
                DropDownList1.DataValueField = "Number";
                DropDownList1.DataSource = cmd.ExecuteReader();
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));
                cmd.Dispose();
                sda.Dispose();
                ds.Dispose();

                sqlConnection.Close();

                SqlCommand cmd1 = new SqlCommand("select distinct EmailAddress  as Com from Reservation", sqlConnection);
                sqlConnection.Open();
                DataSet ds1 = new DataSet();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(ds1);
                DropDownList2.DataTextField = "Com";
                DropDownList2.DataSource = cmd1.ExecuteReader();
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("--Select--", "0"));
                cmd1.Dispose();
                sda1.Dispose();
                ds1.Dispose();
                sqlConnection.Close();

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

            String temp = DropDownList1.SelectedItem.Text;
            //Response.Write(temp);
            String var1 = temp.Substring(0, temp.IndexOf(" -"));
            String var2 = temp.Substring(temp.IndexOf("- "), temp.IndexOf(" - "));
            String var3 = temp.Substring(temp.IndexOf(" - "));
            Response.Write(var1);
            Response.Write(var2);
            Response.Write(var3);
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select Number from Event where Performance=@perf And EventDate > Convert(date,GETDATE(),20)", sqlConnection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("perf", var1);
            cmd.Parameters.AddWithValue("EventDate", var2);
            cmd.Parameters.AddWithValue("EventTime", var3);

            SqlDataReader nwReader = cmd.ExecuteReader();
            while (nwReader.Read())
            {
                final = (int)nwReader["Number"];

            }


            Response.Write(final);
            cmd.Dispose();
            sqlConnection.Close();
            Response.Redirect("SeatDetails.aspx?Field1=" + final+"&Field2="+var1);

            }
            catch(Exception ex)
            {
                Response.Write("Please select an Event!");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {

            emadd = DropDownList2.SelectedItem.Text;
            Response.Redirect("AllUser.aspx?Field1=" + emadd.ToString());

            }
            catch(Exception ex)
            {
                Response.Write("Please select an User!");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
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