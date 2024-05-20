<%@ Page Title="" Language="C#" MasterPageFile="~/UserAccountPage.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Tabirao_FinalActivity2.User.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 40%;
            border: solid;
        }
        table, th, td{
            border: 1px solid black;
            border-collapse: collapse;
        }
        table tr td{
            padding: 5px;
        }
        .auto-style2 {
            width: 150px;
        }
        .auto-style3 {
            width: 150px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <br />
        <tr>
            <td class="auto-style3">Current Password:</td>
            <td>
                <asp:TextBox ID="txtCurrent" runat="server" TextMode="Password"></asp:TextBox>
                <asp:Label ID="lblCurrent" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">New Password:</td>
            <td>
                <asp:TextBox ID="txtNew" runat="server" TextMode="Password"></asp:TextBox>               
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" />
                &emsp; 
            </td>
        </tr>
    </table>
</asp:Content>
