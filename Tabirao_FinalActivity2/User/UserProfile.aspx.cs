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
    public partial class UserProfile : System.Web.UI.Page
    {
        DataAccess myData = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = myData.GetUserByUserID(Session["UserID"].ToString());

            lblEmail.Text = dt.Rows[0]["EmailAddress"].ToString();
            lblFname.Text = dt.Rows[0]["FirstName"].ToString();
            lblLname.Text = dt.Rows[0]["LastName"].ToString();
            lblMembership.Text = dt.Rows[0]["MembershipType"].ToString();


        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("/User/ChangePassword.aspx");
        }
    }
}