using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelperDB;

namespace Tabirao_FinalActivity2
{
    public partial class HomePage : System.Web.UI.Page
    {
        DataAccess myData = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateItems();
            }
        }

        private void UpdateItems()
        {
            DataTable dt = myData.GetProducts();
            DataTable dt2 = myData.GetCart(Session["UserID"].ToString());
            dt.Columns.Add("InCart");

            foreach (DataRow dr in dt.Rows)
            {
                dr["InCart"] = "Add to Cart";
                foreach (DataRow dr2 in dt2.Rows)
                {
                    if (dr["ProductID"].ToString() == dr2["ProductID"].ToString())
                    {
                        dr["InCart"] = "Add to Cart (" + dr2["Amount"].ToString() + ")";
                        break;
                    }
                }
            }
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                Label productID = (Label)e.Item.FindControl("lblProductID");
                DataTable dt = myData.GetProduct(productID.Text);
                DataTable dt2 = myData.GetCartItem(Session["UserID"].ToString(), productID.Text);

                if (dt2.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["Stocks"].ToString()) > Convert.ToInt32(dt2.Rows[0]["Amount"].ToString()))
                    {
                        myData.AddToCart(Session["UserID"].ToString(), productID.Text);
                        UpdateItems();
                    }
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows[0]["Stocks"].ToString()) > 0)
                    {
                        myData.AddToCart(Session["UserID"].ToString(), productID.Text);
                        UpdateItems();
                    }
                }

            }
        }
    }
}
    
