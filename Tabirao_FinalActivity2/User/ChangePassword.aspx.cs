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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        DataAccess myData = new DataAccess();
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            DataTable dt = myData.GetUserByUserID(Session["UserID"].ToString());

            if (dt.Rows[0]["Password"].Equals(txtCurrent.Text))
            {
                myData.ChangeUserPassword(Session["UserID"].ToString(), txtNew.Text);
                Session["Name"] = string.Empty;
                Session["UserID"] = string.Empty;
                Session["MembershipType"] = string.Empty;
                Session["Role"] = null;
                Response.Redirect("/User/UserLogin.aspx");
            }
            else lblCurrent.Text = "Invalid Password";
        }
    }
}