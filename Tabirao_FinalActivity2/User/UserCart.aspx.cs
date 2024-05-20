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
    public partial class UserCart : System.Web.UI.Page
    {
        DataAccess myData = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            DataTable dt = myData.GetUserCart(Session["UserID"].ToString());

            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            double total = 0;

            foreach (DataRow dr in dt.Rows)
            {
                total += Convert.ToDouble(dr["Price"].ToString());
            }

            lblTotal.Text = "₱ " + (total + (total * 0.10)).ToString();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            DataTable dt = myData.GetFinalUserCart(Session["UserID"].ToString());
            DateTime dateTime = DateTime.Now;
            string saleCode = "OR-" + Session["UserID"].ToString() + dateTime.ToString("yyyyMMddmmss");

            double total = 0;
            foreach (DataRow dr in dt.Rows)
            {
                total += (Convert.ToDouble(dr["SRP"].ToString()) * Convert.ToDouble(dr["Amount"].ToString()));
            }

            total = total + (total * 0.10);

            double finalTotal;
            if (total > 10000)
            {
                double userDiscount = Convert.ToDouble(myData.GetUserDiscount(Session["UserID"].ToString()).Rows[0]["Discount"]);
                finalTotal = total - (total * (userDiscount / 100));
            }
            else finalTotal = total;

            foreach (DataRow dr in dt.Rows)
            {
                double taxedPrice = Convert.ToDouble(dr["SRP"]) + (Convert.ToDouble(dr["SRP"]) * 0.10);
                myData.CreateTransaction(saleCode, dr["ProductID"].ToString(), Session["UserID"].ToString(), dr["Amount"].ToString(), taxedPrice.ToString("#.##"), dateTime.ToString(""), finalTotal.ToString("#.##"));
            }

            Session["SaleCode"] = saleCode;
            myData.ClearCart(Session["UserID"].ToString());
            Response.Redirect("/User/UserReceipt.aspx");
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label lblProduct = (Label)e.Item.FindControl("lblProductID");
            Label lblAmount = (Label)e.Item.FindControl("lblAmount");
            

            if (e.CommandName == "Increase")
            {
                DataTable dt = myData.GetProduct(lblProduct.Text);

                if (Convert.ToInt32(dt.Rows[0]["Stocks"].ToString()) > Convert.ToInt32(lblAmount.Text))
                {
                    int newAmount = Convert.ToInt32(lblAmount.Text) + 1;
                    myData.UpdateCart(Session["UserID"].ToString(), lblProduct.Text, newAmount.ToString());
                }
            }
            else if (e.CommandName == "Decrease")
            {
                if (Convert.ToInt32(lblAmount.Text) > 0)
                {
                    int newAmount = Convert.ToInt32(lblAmount.Text) - 1;
                    myData.UpdateCart(Session["UserID"].ToString(), lblProduct.Text, newAmount.ToString());

                }
            }

            UpdateLabels();
        }
    }
}