using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelperDB;

namespace Tabirao_FinalActivity2.User
{
    public partial class UserLogin : System.Web.UI.Page
    {
        DataAccess myData = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool EmailExist = true;
            bool PasswordExist = true;

            DataTable dt = myData.GetUserAccount(txtEmail.Text);

            if(dt == null)
            {
                lblEmail.Text = "* Email not found";
                EmailExist = false;
                return;
            }

            foreach (DataRow dr in dt.Rows )
            {
                if (!dr["Password"].Equals(txtPassword.Text))
                {
                    lblPass.Text = "* Invalid Password";
                    PasswordExist = false;
                    return;
                }
            }

            if (EmailExist && PasswordExist)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Session["Name"] = dr["FirstName"].ToString();
                    Session["UserID"] = dr["AccountID"].ToString();
                    Session["MembershipType"] = dr["MembershipType"].ToString();
                    Session["Role"] = dr["Role"].ToString();

                    if (dr["Role"].ToString() == "Admin")
                    {
                        Response.Redirect("/Admin/ProductList.aspx");
                    }
                    else
                    {
                        Response.Redirect("/User/HomePage.aspx");
                    }
                }
            }
        }
    }
}