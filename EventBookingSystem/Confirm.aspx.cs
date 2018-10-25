using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventBookingSystem
{
    public partial class Confirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String Email = Session["Email"].ToString();
            string username_reg = Session["First_Name"].ToString();//from session header
            Label1.Text = username_reg;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Event.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String Email = Session["Email"].ToString();
            Response.Redirect("UserBooking.aspx?Field1=" + Email);
        }

        public void disablebrowserbackbutton()
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();
        }
    }
}