<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="Tabirao_FinalActivity2.Admin.Transactions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
    <tr>
        <td class="auto-style3" colspan="2">
            <asp:Label ID="lblNotFound" 
                runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Find By Email:</td>
        <td>
            <asp:TextBox ID="txtEmail" 
                runat="server" TextMode="Email"></asp:TextBox>
            &nbsp
            <asp:Button ID="btnSearch" runat="server" 
                Text="Search" 
                OnClick="btnSearch_Click" />
        </td>
    </tr>
    <tr>
        <td class="auto-style2">User:</td>
        <td>
            <asp:DropDownList ID="drpUser" 
                runat="server" AutoPostBack="True" 
                OnSelectedIndexChanged="drpUser_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">User ID:</td>
        <td>
            <asp:DropDownList ID="drpUserID" 
                runat="server" AutoPostBack="True" 
                OnSelectedIndexChanged="drpUserID_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Transaction: </td>
        <td>
            <asp:DropDownList ID="drpTransaction" 
                runat="server" AutoPostBack="True" 
                OnSelectedIndexChanged="drpTransaction_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </td>
    </tr>
</table>
</asp:Content>
