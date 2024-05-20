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
    public partial class UserReceipt : System.Web.UI.Page
    {
        DataAccess myData = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = myData.GetTransactionByID(Session["UserID"].ToString(), Session["SaleCode"].ToString());

            lblTransactionID.Text = Session["SaleCode"].ToString();

            foreach (DataRow dr in dt.Rows)
            {
                dr["Amount"] = (Convert.ToDouble(dr["Amount"].ToString()) + (Convert.ToDouble(dr["Amount"].ToString()) * 0.10)).ToString("#.##");
            }

            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            double total = 0;
            foreach (DataRow dr in dt.Rows)
            {
                total += Convert.ToDouble(dr["Amount"].ToString());
            }

            double finalTotal = total;
            if (total > 10000)
            {
                double userDiscount = Convert.ToDouble(myData.GetUserDiscount(Session["UserID"].ToString()).Rows[0]["Discount"]);
                finalTotal = finalTotal - (total * Convert.ToDouble(userDiscount / 100));
                lblTotal.Text = "Total (" + (int)userDiscount + "% off): ₱" + finalTotal.ToString("#.##");
            }
            else lblTotal.Text = "Total: ₱" + finalTotal.ToString("#.##");
        }
    }
}
    
