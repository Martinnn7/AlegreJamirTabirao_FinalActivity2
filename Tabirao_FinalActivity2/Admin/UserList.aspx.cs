using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelperDB;

namespace Tabirao_FinalActivity2.Admin
{
    public partial class UserList : System.Web.UI.Page
    {
        DataAccess myData = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            grdUsers.DataSource = myData.GetUsers();
            grdUsers.DataBind();
        }
    }
}