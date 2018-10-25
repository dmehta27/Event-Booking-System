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
    public partial class Cart : System.Web.UI.Page
    {
        public string connectionString;
        public SqlConnection sqlConnection;
        static List<string> list = new List<String>();
        //static List<string> list1 = new List<String>();

        protected void Page_Load(object sender, EventArgs e)// After successful booking.
        {
            if (!IsPostBack)
            {
                Session["Timer"] = DateTime.Now.AddMinutes(0.25).ToString();
            }



            string username_reg = Session["First_Name"].ToString();//from session header
            Label1.Text = " HI," + username_reg + "! Your selected seats in the cart are: ";
            list = (List<string>)Session["Seats"];
            String booked_hist = "";
            for (int i = 0; i < list.Count(); i++)
            {
                String rowDelete = list[i].Substring(1, 2);
                String noDelete = list[i].Substring(3, 2);
                booked_hist = booked_hist + rowDelete + "-" + noDelete  + " | ";

            }
            Label2.Text = "You have Selected: " + booked_hist + " Seats!";
            //list1.Clear();



            /*
            String Event_Number = Session["Event_Number"].ToString();
            String Email = Session["Email"].ToString();
            int E_NO = Convert.ToInt32(Event_Number);
            connectionString = @"Data Source=infoinfraids520edrp.database.windows.net;Initial Catalog=InfoInfraIDS520Asp ;User ID=infoinfraids520edrp;Password=Ids520123";
            sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select Convert(varchar,RowName) + '-' + Convert(varchar,S_Number) as Seats from Reservation where EmailAddress =\'" + Email + "\' and E_Number = " + E_NO, sqlConnection);//displaying the seats booked by user
            sqlConnection.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            string booked_hist = "";
            while (dataReader.Read())
            {
                booked_hist = dataReader["Seats"].ToString()+", "+booked_hist;
            }
            dataReader.Close();
            cmd.Dispose();
            sqlConnection.Close();
            Label2.Text = "You have Selected: - "  + booked_hist + " Seats!"; */



        }

        protected void Button1_Click(object sender, EventArgs e)//for redirecting to the Login page
        {
            Response.Redirect("Confirm.aspx");
        }

        protected void Timer1_tick(object sender, EventArgs e)
        {
            if (DateTime.Compare(DateTime.Now, DateTime.Parse(Session["Timer"].ToString())) < 0)
            {
                Clock.Text=":" +((Int32)DateTime.Parse(Session["Timer"].ToString()).Subtract(DateTime.Now).TotalMinutes)
                    .ToString() + " Minute " + (((Int32)DateTime.Parse(Session["Timer"].ToString()).Subtract(DateTime.Now).TotalSeconds)%60)
                    .ToString() + " Seconds ";
            }

            else
            {

              
                
                String Email = Session["Email"].ToString();
                String Event_Number = Session["Event_Number"].ToString();
                for (int i = 0; i < list.Count(); i++)
                {
                    String rowDelete = list[i].Substring(1, 2);
                    String noDelete = list[i].Substring(3, 2);
                    String queryDelete = "DELETE FROM Reservation where EmailAddress=" + "\'" + Email + "\'" + "and E_Number=" + "\'" + Event_Number + "\'" + "and RowName=" + "\'" + rowDelete + "\'" + "and S_Number=" + "\'" + noDelete + "\'";
                    connectionString = @"Data Source=infoinfraids520edrp.database.windows.net;Initial Catalog=InfoInfraIDS520Asp ;User ID=infoinfraids520edrp;Password=Ids520123";
                    sqlConnection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand(queryDelete, sqlConnection);
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();

                }
                list.Clear();
                Response.Redirect("SeatMap.aspx");

                /*String Event_Number = Session["Event_Number"].ToString();
                String Email = Session["Email"].ToString();
                String queryDelete = "DELETE FROM Reservation where EmailAddress=" + "\'" + Email + "\'" + "and E_Number=" + "\'" + Event_Number + "\'";
                SqlCommand command = new SqlCommand(queryDelete, sqlConnection);
                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
                Response.Redirect("Event.aspx");*/
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeatMap.aspx");
    
        }
    }
}