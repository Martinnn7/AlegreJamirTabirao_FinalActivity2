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
    public partial class Transactions : System.Web.UI.Page
    {
        DataAccess myData = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!drpUser.Items.Contains(new ListItem("Select User"))) drpUser.Items.Add("Select User");
                if (!drpUserID.Items.Contains(new ListItem("Select UserID"))) drpUserID.Items.Add("Select UserID");

                foreach (DataRow dr in myData.GetUsers().Rows)
                {
                    if (!drpUser.Items.Contains(new ListItem(dr["Name"].ToString())))
                    {
                        drpUser.Items.Add(dr["Name"].ToString());
                        drpUser.Items.FindByText(dr["Name"].ToString()).Value = dr["AccountID"].ToString();
                    }

                    if (!drpUserID.Items.Contains(new ListItem(dr["AccountID"].ToString())))
                    {
                        drpUserID.Items.Add(dr["AccountID"].ToString());
                        drpUserID.Items.FindByText(dr["AccountID"].ToString()).Value = dr["AccountID"].ToString();
                    }
                }
            }
        }

        private void UpdateTransactionDrp()
        {
            drpTransaction.Items.Clear();
            if (!drpTransaction.Items.Contains(new ListItem("Select Transaction"))) drpTransaction.Items.Add("Select Transaction");
            foreach (DataRow dr in myData.GetUserTransactions(drpUserID.SelectedValue).Rows)
            {
                if (!drpTransaction.Items.Contains(new ListItem(dr["SaleCode"].ToString())))
                {
                    drpTransaction.Items.Add(dr["SaleCode"].ToString());
                }
            }
        }

        protected void drpUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpUser.SelectedIndex == 0)
            {
                drpUserID.SelectedIndex = 0;
                return;
            }

            drpUserID.SelectedIndex = drpUserID.Items.IndexOf(new ListItem(drpUser.SelectedValue));

            UpdateTransactionDrp();
        }

        protected void drpUserID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpUserID.SelectedIndex == 0)
            {
                drpUser.SelectedIndex = 0;
                return;
            }

            drpUser.SelectedValue = drpUserID.SelectedValue;
            UpdateTransactionDrp();
        }

        protected void drpTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = myData.GetUserTransaction(drpTransaction.SelectedItem.Text);
            GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (myData.GetUserByEmail(txtEmail.Text).Rows.Count > 0)
            {
                DataTable dt = myData.GetUserByEmail(txtEmail.Text);

                drpUser.SelectedValue = dt.Rows[0]["AccountID"].ToString();
                drpUserID.SelectedValue = dt.Rows[0]["AccountID"].ToString();
                UpdateTransactionDrp();
            }
            else
            {
                lblNotFound.Text = "* Email not found";
            }
        }
    }
}