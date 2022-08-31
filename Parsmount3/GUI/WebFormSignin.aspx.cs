using Parsmount3.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace Parsmount3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<Event> listEvent = new List<Event>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)        
        {
            Event ev = new Event();
            Event eve = ev.search("event_id", Convert.ToInt32(TextBox1.Text));            
            if (eve != null)
                MessageBox.Show($"{eve.Event_Id} {eve.Name} {eve.DateTime.ToShortDateString()}" +
                    $" {eve.DateTime.ToShortTimeString()} {eve.Category} {eve.Max_Number}");
            else
                Response.Write("<script>alert('Not Found');</script>");   /////////////

            //listEvent = ev.searchMany("name", "yyy");

                //foreach (Event ee in listEvent)
                //{
                //    MessageBox.Show($"{ee.Event_Id} {ee.Name} {ee.DateTime.ToShortDateString()}" +
                //        $" {ee.DateTime.ToShortTimeString()} {ee.Category} {ee.Max_Number}");
                //}

        }

        

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Event ev = new Event();
            ev.Name = "mmm";
            ev.Category = "c5";
            ev.insert(ev);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Event ev = new Event();
            ev.Name = "qqq";
            ev.Category = "c6";
            ev.update(3, ev);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Event ev = new Event();
            ev.delete(3);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string x = "i";
            Image1.ImageUrl = $@"~/Images/{x}.png";
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                Member mem = new Member();
                mem.email = TextBox2.Text;
                mem.password = TextBox3.Text;
                String email = mem.LogIn(mem);
                if (email != "-1")
                {
                    Session["email"] = email;
                    Session["privileges"] = "Member";
                    Response.Redirect("WebFormSignedin.aspx");
                }
                else
                    Response.Write("<script>alert('Enter a correct Email and Password');</script>");
            }
            else if (RadioButton2.Checked)
            {
                Admin ad = new Admin();
                ad.email = TextBox2.Text;
                ad.password = TextBox3.Text;
                String email = ad.LogIn(ad);
                if (email != "-1")
                {
                    Session["email"] = email;
                    Session["privileges"] = "Admin";
                    Response.Redirect("WebFormSignedin.aspx");
                }
                else
                    Response.Write("<script>alert('Enter a correct Email, Password');</script>");
            }
            
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Button7_Click1(object sender, EventArgs e)
        {
            Response.Redirect("WebFormSignUp.aspx");

        }

        protected void Button7_Click2(object sender, EventArgs e)
        {

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormEvent.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {

        }
    }
}