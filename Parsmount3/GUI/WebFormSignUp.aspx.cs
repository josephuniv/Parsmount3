using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Parsmount3.GUI
{
    public partial class WebFormSignUp : System.Web.UI.Page
    {
        static string connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Parsmount;Integrated Security=True";
        static SqlConnection cnn;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(RadioButton1.Checked)
            {
                if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "")
                {
                    cnn = new SqlConnection(connetionString);
                    cnn.Open();
                    SqlCommand command;
                    SqlDataReader dataReader;
                    String sql;
                    sql = $"insert into member (first_name,last_name,email,password)values('{TextBox3.Text}','{TextBox3.Text}','{TextBox1.Text}','{TextBox2.Text}')";
                    command = new SqlCommand(sql, cnn);
                    dataReader = command.ExecuteReader();
                    Response.Write("<script>alert('Member created');</script>");
                    Response.Redirect("WebFormIndex.aspx");
                    
                }
                else
                    Response.Write("<script>alert('Please enter all the requard field');</script>");
            }
            else if (RadioButton2.Checked)
            {
                if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" && TextBox5.Text != "")
                {
                    if (TextBox5.Text == "AdminKey")
                    { 
                        cnn = new SqlConnection(connetionString);
                        cnn.Open();
                        SqlCommand command;
                        SqlDataReader dataReader;
                        String sql;
                        sql = $"insert into admin (first_name,last_name,email,password)values('{TextBox3.Text}','{TextBox3.Text}','{TextBox1.Text}','{TextBox2.Text}')";
                        command = new SqlCommand(sql, cnn);
                        dataReader = command.ExecuteReader();
                        Response.Write("<script>alert('Admin created');</script>");
                        Response.Redirect("WebFormIndex.aspx");
                        
                    }
                    else
                        Response.Write("<script>alert('Please enter a correct Admin Key');</script>");
                }
                else
                    Response.Write("<script>alert('Please enter all the requard field');</script>");
            }



        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormEvent.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormSignin.aspx");
        }
    }
}