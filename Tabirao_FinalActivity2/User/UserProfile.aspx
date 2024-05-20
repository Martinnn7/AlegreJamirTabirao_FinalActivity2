<%@ Page Title="" Language="C#" MasterPageFile="~/UserAccountPage.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Tabirao_FinalActivity2.User.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 40%;
            border:solid
        }
        table tr td {
            padding: 5px;
        }
        table, th, td{
            border: 1px solid black;
            border-collapse: collapse;
        }
        .auto-style2 {
            width: 432px;
            text-align: right;
        }
        .auto-style3 {
            width: 958px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">Email Address:</td>
            <td class="auto-style3">
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">First Name:</td>
            <td class="auto-style3">
                <asp:Label ID="lblFname" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Last Name:</td>
            <td class="auto-style3">
                <asp:Label ID="lblLname" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Membership Type:</td>
            <td class="auto-style3">
                <asp:Label ID="lblMembership" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:Button ID="btnChange" runat="server" Text="Change Password" OnClick="btnChange_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
