using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelperDB;

namespace Tabirao_FinalActivity2
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            grdProducts.DataSource = myData.GetProducts();
            grdProducts.DataBind();
        }

        DataAccess myData = new DataAccess();
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            myData.SaveNewProduct(txtProdId.Text, txtProdName.Text, Convert.ToDecimal(txtProdPrice.Text), Convert.ToInt32(txtStocks.Text));
            grdProducts.DataSource = myData.GetProducts();
            grdProducts.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/EditProduct.aspx");
        }
    }
}