using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace EventBookingSystem
{
    public partial class EventMenu : System.Web.UI.Page
    {
        public string connectionString;
        public SqlConnection sqlConnection;


        protected void Page_Load(object sender, EventArgs e) // on successful login, user redirects here.
        {
            if (Request.QueryString["Field1"]!="")
            {
                string username_reg = Session["First_Name"].ToString();// First name of user is appended in the response hader from Login page.
                Label1.Text = "Welcome  To Moviebuzz! , " + username_reg + "!";
                if (!IsPostBack)
                {
                    //Response.Write("Login Success");
                    connectionString = @"Data Source=infoinfraids520edrp.database.windows.net;Initial Catalog=InfoInfraIDS520Asp ;User ID=infoinfraids520edrp;Password=Ids520123";
                    sqlConnection = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand("select Number, Performance + ' - ' + CONVERT(varchar,EventDate, 10)  + ' - ' + CONVERT(varchar,EventTime,8) as Com from Event where EventDate > Convert(date,GetDate(),10)", sqlConnection);// query for getting the available events
                    sqlConnection.Open();

                    DataSet ds = new DataSet();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);
                    DropDownList1.DataTextField = "Com";
                    DropDownList1.DataValueField = "Number";
                    DropDownList1.DataSource = cmd.ExecuteReader();
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));//default item
                    cmd.Dispose();
                    sda.Dispose();
                    ds.Dispose();



                    sqlConnection.Close();


                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        int final;
        protected void Button1_Click(object sender, EventArgs e)// for redirectign to booking seats page.
        {
            try
            {


                String temp = DropDownList1.SelectedItem.Text;
                //Response.Write(temp);
                String var1 = temp.Substring(0, temp.IndexOf(" -"));
                String var2 = temp.Substring(temp.IndexOf("-") + 2, 8);
                String var3 = temp.Substring(temp.IndexOf("-") + 13, 8);
                Session["Event_Name"] = var1;
                Session["Event_Date"] = var2;
                Session["Event_Time"] = var3;


                connectionString = @"Data Source=infoinfraids520edrp.database.windows.net;Initial Catalog=InfoInfraIDS520Asp ;User ID=infoinfraids520edrp;Password=Ids520123";
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select Number from Event where Performance=@perf And EventDate > Convert(date,GETDATE(),20)", sqlConnection); //Break the selected item and parse them to next page
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("perf", var1);
                cmd.Parameters.AddWithValue("EventDate", var2);
                cmd.Parameters.AddWithValue("EventTime", var3);

                SqlDataReader nwReader = cmd.ExecuteReader();
                while (nwReader.Read())
                {
                    final = (int)nwReader["Number"];

                }
                Session["Event_Number"] = final.ToString();

                Response.Write(final);
                cmd.Dispose();
                sqlConnection.Close();
                Response.Redirect("SeatMap.aspx?" + final);//parsing the Event number with response header.

            }
            catch (Exception ex)
            {
                Response.Write("<h1>Can't proceed without selecting an Event! OOPS!</h1>");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String Email = Session["Email"].ToString();
            Response.Redirect("UserBooking.aspx?Field1=" + Email);
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
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