<%@ Page Title="" Language="C#" MasterPageFile="~/UserAccountPage.Master" AutoEventWireup="true" CodeBehind="UserCart.aspx.cs" Inherits="Tabirao_FinalActivity2.User.UserCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:fit-content; color: black;" 
    class="regform" border="1">
    <tr>
        <td class="auto-style1">Product ID</td>
        <td class="auto-style1">Product Name</td>
        <td class="auto-style2">Amount</td>
        <td class="auto-style3">Price</td>
        <td class="auto-style3">&nbsp;</td>
    </tr>
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="lblProductID" runat="server" Text=<%#DataBinder.Eval(Container,"DataItem.ProductID")%>></asp:Label></td>
                <td class="auto-style1">
                    <asp:Label ID="lblProductName" runat="server" Text=<%#DataBinder.Eval(Container,"DataItem.ProductName")%>></asp:Label></td>
                <td class="auto-style2">
                    <asp:Label ID="lblAmount" runat="server" Text=<%#DataBinder.Eval(Container,"DataItem.Amount")%>></asp:Label></td>
                <td class="auto-style3">₱ <%#DataBinder.Eval(Container,"DataItem.Price")%></td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="+" UseSubmitBehavior="False" CommandName="Increase"/>&nbsp<asp:Button
                        ID="Button2" runat="server" Text="-" UseSubmitBehavior="False" CommandName="Decrease"/></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style4" colspan="2">Total 
            (+10% Tax): <asp:Label ID="lblTotal" runat="server" 
            Text=""></asp:Label></td>
        <td class="auto-style3">
            <asp:Button ID="btnCheckout" runat="server" 
                Text="Check Out" 
                OnClick="btnCheckout_Click"/>
        </td>
        <td class="auto-style3">
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
