using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parsmount3.GUI
{
    public partial class WebForm0 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormSignin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string value = Session["privileges"] as string;            
            if (!String.IsNullOrEmpty(value))
            { 
                if (Session["privileges"] == "Admin")
                    Response.Redirect("WebFormEventAdmin.aspx");
                else if (Session["privileges"] == "Member")
                    Response.Redirect("WebFormEventMember.aspx");
            }
            else
                Response.Redirect("WebFormEvent.aspx");
        }
    }
}