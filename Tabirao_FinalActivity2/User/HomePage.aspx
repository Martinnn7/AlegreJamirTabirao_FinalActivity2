<%@ Page Title="" Language="C#" MasterPageFile="~/UserAccountPage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Tabirao_FinalActivity2.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
.productitem {
    margin-bottom: 20px;
}

.product-table {
    width: 100%;
    border-collapse: collapse;
}

.product-table td {
    padding: 5px;
    border: 1px solid #ccc;
}

.product-info {
    width: 25%;
}

.product-actions {
    width: 15%;
    text-align: center;
}

.product-name {
    font-weight: bold;
}

.product-price {
    font-size: 12px;
    color: #666;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Welcome to my Website</h2>
    <p>
        Start shopping now</p>

      Product List:<br />
<asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
    <ItemTemplate>
        <div class="productitem">
            <table class="product-table">
                <tr>
                    <td class="product-info">
                        <asp:Label ID="lblProductID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductID") %>' Font-Size="10"></asp:Label>
                        <asp:Label ID="Label1" runat="server" Font-Size="10">Stocks: <%# DataBinder.Eval(Container.DataItem, "Stocks") %></asp:Label>
                    </td>
                    <td class="product-actions">
                        <asp:Button ID="Button1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "InCart") %>' UseSubmitBehavior="False" CommandName="Add" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="product-name">
                        <asp:Label ID="lblProduct" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductName") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="product-price">
                        <asp:Label ID="lblPrice" runat="server">₱<%# DataBinder.Eval(Container.DataItem, "SRP") %></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </ItemTemplate>
</asp:Repeater>
</asp:Content>
