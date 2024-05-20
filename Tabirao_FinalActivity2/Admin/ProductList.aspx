<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Tabirao_FinalActivity2.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 149px;
            text-align: right;
        }
        .auto-style3 {
            width: 56px;
        }
        .auto-style5 {
            width: 270px;
        }
        .auto-style6 {
            width: 56px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">Product ID:</td>
            <td class="auto-style5">
                <asp:TextBox ID="txtProdId" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style6">Price:</td>
            <td>
                <asp:TextBox ID="txtProdPrice" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Product Name:</td>
            <td class="auto-style5">
                <asp:TextBox ID="txtProdName" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style6">Stocks:</td>
            <td>
                <asp:TextBox ID="txtStocks" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="Add Product" OnClick="btnAdd_Click" />
            </td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table>
    <div>

        <asp:GridView ID="grdProducts" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <br />
        <asp:Button ID="btnEdit" runat="server" Text="Edit Product" OnClick="btnEdit_Click" />

    </div>
</asp:Content>
