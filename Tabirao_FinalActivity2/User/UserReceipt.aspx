<%@ Page Title="" Language="C#" MasterPageFile="~/UserAccountPage.Master" AutoEventWireup="true" CodeBehind="UserReceipt.aspx.cs" Inherits="Tabirao_FinalActivity2.User.UserReceipt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
.receipt-container {
color: black;
}

.receipt-table {
    width: fit-content;
    border-collapse: collapse;
    border: 1px solid #ccc;
}

.receipt-table td {
    padding: 8px;
    border: 1px solid #ccc;
}

.receipt-table tr:first-child {
    background-color: #f0f0f0;
    font-weight: bold;
}

.receipt-table tr:last-child td {
    text-align: right;
}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="receipt-container">
    <table>
        <tr>
            <td>Receipt for:</td>
            <td>
                <asp:Label ID="lblTransactionID" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <table class="receipt-table">
        <tr>
            <td>Item</td>
            <td>Price (+ 10% Tax)</td>
            <td>Quantity</td>
            <td>Amount</td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# DataBinder.Eval(Container.DataItem, "Product Name") %></td>
                    <td>₱<%# DataBinder.Eval(Container.DataItem, "Price") %></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Quantity") %></td>
                    <td>₱<%# DataBinder.Eval(Container.DataItem, "Amount") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</div>
</asp:Content>
