<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="Tabirao_FinalActivity2.Admin.EditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 230px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style3">Select Product:</td>
            <td>
                <asp:DropDownList ID="drpProducts" runat="server" OnSelectedIndexChanged="drpProducts_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Product Number:</td>
            <td>
                <asp:Label ID="lblProdNum" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Product ID:</td>
            <td>
                <asp:TextBox ID="txtProductID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Product Name:</td>
            <td>
                <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Product Stocks:</td>
            <td>
                <asp:TextBox ID="txtStocks" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Product Price:</td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            </td>
            <td>
                &emsp; <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                &emsp;<asp:Label ID="lblDelete" runat="server" ForeColor="#0066CC"></asp:Label>
                &emsp;<asp:Label ID="lblUpdate" runat="server" ForeColor="#0066CC"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
