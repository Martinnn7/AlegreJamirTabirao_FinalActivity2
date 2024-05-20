<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="Tabirao_FinalActivity2.User.UserLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 165px;
        }
        .auto-style3 {
            width: 165px;
            text-align: right;
        }
        .auto-style4 {
            width: 180px;
        }
        .auto-style5 {
            width: 165px;
            height: 51px;
        }
        .auto-style6 {
            width: 180px;
            height: 51px;
        }
        .auto-style7 {
            height: 51px;
        }
        .auto-style8 {
            width: 180px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style3">Email Address:</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblEmail" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Password:</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblPass" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style6">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
           
            <td class="auto-style8"><a href="/Registration.aspx" style="font-size: 14px;">Don't have an account yet? <br />Go to Register</a></td>            
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
