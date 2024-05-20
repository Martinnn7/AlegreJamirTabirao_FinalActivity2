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
    public partial class EditProduct : System.Web.UI.Page
    {
        DataAccess myData = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!drpProducts.Items.Contains(new ListItem("Select Product"))) drpProducts.Items.Add("SelectProduct");
                foreach (DataRow dr in myData.GetProducts().Rows)
                {
                    if (!drpProducts.Items.Contains(new ListItem(dr["ProductName"].ToString())))
                    {
                        drpProducts.Items.Add(dr["ProductName"].ToString());
                    }
                }
            }
        }

        protected void drpProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpProducts.SelectedIndex == 0) return;
            foreach (DataRow dr in myData.GetProducts().Rows)
            {
                if (dr["ProductName"].Equals(drpProducts.SelectedItem.Text))
                {
                    lblProdNum.Text = dr["ProductNumber"].ToString();
                    txtProductID.Text = dr["ProductID"].ToString();
                    txtProductName.Text = dr["ProductName"].ToString();
                    txtStocks.Text = dr["Stocks"].ToString();
                    txtPrice.Text = dr["Price"].ToString();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            myData.UpdateProduct(lblProdNum.Text, txtProductID.Text, txtProductName.Text, txtPrice.Text, txtStocks.Text);
            lblUpdate.Text = "* Product Updated Successfully";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            myData.DeleteProduct(lblProdNum.Text);
            lblDelete.Text = "* Product Deleted Successfully";
            drpProducts.SelectedIndex = 0;
            lblProdNum.Text = string.Empty;
            txtProductID.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtStocks.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }
    }
}