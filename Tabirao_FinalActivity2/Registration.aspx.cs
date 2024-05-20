using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelperDB;

namespace Tabirao_FinalActivity2
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        DataAccess myData = new DataAccess();
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (myData.CheckEmail(txtEmail.Text))
                {
                    lblRegistered.Text = "* Email Already Registered";
                }
                else
                {
                    myData.CreateAccount(txtEmail.Text, txtFname.Text, txtLname.Text, txtPass.Text);

                    DataTable dt = myData.GetUserByEmail(txtEmail.Text);

                    foreach (DataRow dr in dt.Rows)
                    {
                        Session["Name"] = dr["FirstName"].ToString();
                        Session["UserID"] = dr["AccountID"].ToString();
                        Session["MembershipType"] = dr["MembershipType"].ToString();
                        Session["Role"] = dr["Role"].ToString();

                        if (dr["Role"].ToString() == "Admin")
                        {
                            Response.Redirect("/Admin/Home.aspx");
                        }
                        else
                        {
                            Response.Redirect("/User/UserLogin.aspx");
                        }
                    }
                }
            }
        }
    }
}