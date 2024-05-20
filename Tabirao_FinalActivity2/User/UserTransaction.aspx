<%@ Page Title="" Language="C#" MasterPageFile="~/UserAccountPage.Master" AutoEventWireup="true" CodeBehind="UserTransaction.aspx.cs" Inherits="Tabirao_FinalActivity2.User.UserTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .transaction-container {
            width: 60%;
            color: black;
            margin-bottom: 20px;
        }

        .transaction-table {
            width: 100%;
            border-collapse: collapse;
        }

        .transaction-table td {
            padding: 5px;
            border: 1px solid #ccc;
        }

        .transaction-info {
            width: 50%;
        }

        .transaction-total {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
    <ItemTemplate>
        <div class="transaction-container">
            <table class="transaction-table">
                <tr>
                    <td class="transaction-info">Transaction ID:&nbsp;
                        <asp:Label ID="lblTransactionID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SaleCode") %>'></asp:Label>
                    </td>
                    <td class="transaction-info">Transaction Date:&nbsp;
                        <asp:Label ID="lblTransacDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PurchaseDate") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84"
                            BorderStyle="None" BorderWidth="1px" CellPadding="4" CellSpacing="2" Width="100">
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="transaction-total">
                        Total: ₱
                        <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </ItemTemplate>
</asp:Repeater>
    </asp:Content>
