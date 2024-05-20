using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataHelperDB
{
    public class DataAccess
    {
        static string ConnStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Visual Studio Programs\Tabirao_FinalActivity2\Tabirao_FinalActivity2\App_Data\Database1.mdf"";Integrated Security=True";
        SqlConnection myConn = new SqlConnection(ConnStr);

        public void SaveNewProduct(string prodId, string prodName, decimal prodPrice, int prodStocks)
        {
            myConn.Open();
            SqlCommand saveCmd = new SqlCommand("SaveNewProduct", myConn);
            saveCmd.CommandType = System.Data.CommandType.StoredProcedure;

            saveCmd.Parameters.Add("@ProductID", SqlDbType.NVarChar).Value = prodId;
            saveCmd.Parameters.Add("@ProductName", SqlDbType.VarChar).Value = prodName;
            saveCmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = prodPrice;
            saveCmd.Parameters.Add("@Stocks", SqlDbType.Int).Value = prodStocks;

            decimal srp = prodPrice * 0.15m + prodPrice;
            saveCmd.Parameters.Add("@SRP", SqlDbType.Decimal).Value = srp;
            saveCmd.ExecuteNonQuery();
            myConn.Close();
        }
        public DataTable GetProducts()
        {
            SqlDataAdapter da = new SqlDataAdapter("GetProducts", myConn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;

        }

        public void UpdateProduct(string productNumber, string productID, string productName, string stocks, string price)
        {
            myConn.Open();
            SqlCommand cmd = new SqlCommand("UpdateProduct", myConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProductNumber", SqlDbType.Int).Value = productNumber;
            cmd.Parameters.Add("@ProductID", SqlDbType.NVarChar).Value = productID;
            cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = productName;
            cmd.Parameters.Add("@Stocks", SqlDbType.NVarChar).Value = stocks;
            cmd.Parameters.Add("@Price", SqlDbType.NVarChar).Value = price;
            cmd.ExecuteNonQuery();
            myConn.Close();
        }

        public void DeleteProduct(string prodNum)
        {
            myConn.Open();
            SqlCommand saveCmd = new SqlCommand("DeleteProduct", myConn);
            saveCmd.CommandType = CommandType.StoredProcedure;

            saveCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = prodNum;
            saveCmd.ExecuteNonQuery();
            myConn.Close();
        }

        public DataTable GetUserAccount(string email)
        {
            SqlDataAdapter da = new SqlDataAdapter("GetAccount", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = email;

            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }

        public DataTable GetUserByUserID(string userID)
        {
            SqlDataAdapter da = new SqlDataAdapter("GetUserByUserID", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public void CreateAccount(string email, string fName, string lName, string password)
        {
            myConn.Open();
            SqlCommand saveCmd = new SqlCommand("CreateAccount", myConn);

            saveCmd.CommandType = CommandType.StoredProcedure;
            saveCmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = email;
            saveCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = fName;
            saveCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lName;
            saveCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
            saveCmd.Parameters.Add("@Role", SqlDbType.NVarChar).Value = "User";
            saveCmd.Parameters.Add("@MembershipType", SqlDbType.NVarChar).Value = "Basic";
            saveCmd.ExecuteNonQuery();
            myConn.Close();
        }
        public bool CheckEmail(string email)
        {
            SqlDataAdapter da = new SqlDataAdapter("GetAccount", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = email;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt.Rows.Count > 0;
        }
        public DataTable GetUserByEmail(string email)
        {
            SqlDataAdapter da = new SqlDataAdapter("GetUserByEmail", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = email;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public void ChangeUserPassword(string AccountID, string password)
        {
            myConn.Open();
            SqlCommand saveCmd = new SqlCommand("ChangePassword", myConn);

            saveCmd.CommandType = CommandType.StoredProcedure;
            saveCmd.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
            saveCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
            saveCmd.ExecuteNonQuery();
            myConn.Close();
        }

        public DataTable GetUsers()
        {
            SqlDataAdapter da = new SqlDataAdapter("GetAccounts", myConn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable GetUserCart(string userID)
        {
            SqlDataAdapter da = new SqlDataAdapter("CheckUserCart", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@AccountID", SqlDbType.Int).Value = userID;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public void UpdateCart(string AccountID, string productID, string amount)
        {
            myConn.Open();
            SqlCommand cmd = new SqlCommand("UpdateCart", myConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
            cmd.Parameters.Add("@ProductID", SqlDbType.NVarChar).Value = productID;
            cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = amount;
            cmd.ExecuteNonQuery();
            myConn.Close();
        }

        public void ClearCart(string AccountID)
        {
            myConn.Open();
            SqlCommand cmd = new SqlCommand("ClearCart", myConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AccountID", SqlDbType.NVarChar).Value = AccountID;
            cmd.ExecuteNonQuery();
            myConn.Close();
        }

        public DataTable GetUserDiscount(string AccountID)
        {
            SqlDataAdapter da = new SqlDataAdapter("GetDiscount", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public void CreateTransaction(string saleCode, string productID, string customerID, string quantity, string pricePurchased, string purchaseDate, string finalPrice)
        {
            SqlDataAdapter da = new SqlDataAdapter("GetProduct", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@ProductID", SqlDbType.NVarChar).Value = productID;
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (Convert.ToInt32(dt.Rows[0]["Stocks"].ToString()) > Convert.ToInt32(quantity))
            {
                myConn.Open();
                SqlCommand cmd = new SqlCommand("CreateTransaction", myConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SaleCode", SqlDbType.NVarChar).Value = saleCode;
                cmd.Parameters.Add("@ProductID", SqlDbType.NVarChar).Value = productID;
                cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                cmd.Parameters.Add("@PricePurchased", SqlDbType.Money).Value = pricePurchased;
                cmd.Parameters.Add("@PurchaseDate", SqlDbType.DateTime).Value = purchaseDate;
                cmd.Parameters.Add("@FinalPrice", SqlDbType.Money).Value = finalPrice;
                cmd.ExecuteNonQuery();
                myConn.Close();

                int newStock = Convert.ToInt32(dt.Rows[0]["Stocks"].ToString()) - Convert.ToInt32(quantity);
                UpdateProduct(dt.Rows[0]["ProductNumber"].ToString(), dt.Rows[0]["ProductID"].ToString(), dt.Rows[0]["ProductName"].ToString(), newStock.ToString(), dt.Rows[0]["Price"].ToString());
            }

        }

        public DataTable GetProduct(string productID)
        {
            SqlDataAdapter da = new SqlDataAdapter("GetProduct", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@ProductID", SqlDbType.NVarChar).Value = productID;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable GetFinalUserCart(string AccountID)
        {
            SqlDataAdapter da = new SqlDataAdapter("GetCartFinal", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable GetCart(string AccountID)
        {
            SqlDataAdapter da = new SqlDataAdapter("CheckCart", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable GetCartItem(string AccountID, string productID)
        {
            SqlDataAdapter da = new SqlDataAdapter("GetCartItem", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@AccountID", SqlDbType.NVarChar).Value = AccountID;
            da.SelectCommand.Parameters.Add("@ProductID", SqlDbType.NVarChar).Value = productID;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public bool checkIfCartHasItem(string AccountID, string productID)
        {
            SqlDataAdapter da = new SqlDataAdapter("CheckCart", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0) return false;

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ProductID"].ToString() == productID) return true;
            }

            return false;
        }

        public void AddToCart(string AccountID, string productID)
        {
            if (checkIfCartHasItem(AccountID, productID))
            {
                SqlDataAdapter da = new SqlDataAdapter("CheckCart", myConn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
                DataTable dt = new DataTable();
                da.Fill(dt);

                int amount = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["ProductID"].ToString().Equals(productID)) amount = Convert.ToInt32(dr["Amount"].ToString());
                }

                myConn.Open();
                SqlCommand cmd = new SqlCommand("UpdateCart", myConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
                cmd.Parameters.Add("@ProductID", SqlDbType.NVarChar).Value = productID;
                cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = (amount += 1);
                cmd.ExecuteNonQuery();
                myConn.Close();
            }
            else
            {
                myConn.Open();
                SqlCommand cmd = new SqlCommand("AddToCart", myConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
                cmd.Parameters.Add("@ProductID", SqlDbType.NVarChar).Value = productID;
                cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = 1;
                cmd.ExecuteNonQuery();
                myConn.Close();
            }
        }

        public DataTable GetTransactionsByID(int AccountID)
        {
            SqlDataAdapter da = new SqlDataAdapter("GetTransactionsByID", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable GetTransactionByID(string AccountID, string saleCode)
        {
            SqlDataAdapter da = new SqlDataAdapter("GetTransactionByID", myConn);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
            da.SelectCommand.Parameters.Add("@SaleCode", SqlDbType.NVarChar).Value = saleCode;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable GetUserTransaction(string ID)
        {
            SqlDataAdapter da = new SqlDataAdapter("GetTransactionBySaleCode", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@SaleCode", SqlDbType.NVarChar).Value = ID;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable GetUserTransactions(string ID)
        {
            SqlDataAdapter da = new SqlDataAdapter("GetTransactionsBySaleCode", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@CustomerID", SqlDbType.Int).Value = ID;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    } 
}
