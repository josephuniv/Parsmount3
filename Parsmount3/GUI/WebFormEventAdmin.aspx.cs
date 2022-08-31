using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parsmount3.GUI
{
    public partial class WebFormEventAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Contents.RemoveAll();
            Response.Redirect("WebFormIndex.aspx");

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

        }

        protected void Label1_Load(object sender, EventArgs e)
        {            
            Label1.Text = Session["privileges"].ToString();
            Label2.Text = Session["email"].ToString();
        }
    }
}