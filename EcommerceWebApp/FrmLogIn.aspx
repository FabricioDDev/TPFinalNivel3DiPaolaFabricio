<%@ Page Title="" Language="C#" MasterPageFile="~/LogIn_SignUp.Master" AutoEventWireup="true" CodeBehind="FrmLogIn.aspx.cs" Inherits="EcommerceWebApp.FrmLogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LblEmail" runat="server" Text="Your Email:"></asp:Label>
    <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>

    <asp:Label ID="LblPass" runat="server" Text="Pass"></asp:Label>
    <asp:TextBox ID="TxtPass" runat="server"></asp:TextBox>

    <asp:Button ID="BtnGo" OnClick="BtnGo_Click" runat="server" Text="Go" />
    <asp:LinkButton ID="LkbtnRecoveryPass" runat="server">Recovery Password</asp:LinkButton>

    <asp:LinkButton ID="LktbtnSignIn" runat="server" Text="SignIn"></asp:LinkButton>
</asp:Content>