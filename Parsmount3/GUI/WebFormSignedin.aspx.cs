using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Parsmount3.GUI
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
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

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            
        }

        protected void Label1_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["privileges"].ToString();
            Label2.Text = Session["email"].ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string email = (String)(Session["email"]);
            //MessageBox.Show(email);
            Response.Write($"<script>alert('{email}');</script>");
        }
    }
}