<%@ Page Title="" Language="C#" MasterPageFile="~/LogIn_SignUp.Master" AutoEventWireup="true" CodeBehind="FrmSignUp.aspx.cs" Inherits="EcommerceWebApp.FrmSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="LblEmail" runat="server" Text="Your Email*"></asp:Label>
    <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>

    <asp:Label ID="LblPass" runat="server" Text="Your Pass*"></asp:Label>
    <asp:TextBox ID="TxtPass" runat="server"></asp:TextBox>

    <asp:Label ID="LblName" runat="server" Text="Your Name"></asp:Label>
    <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>

    <asp:Label ID="LblLastName" runat="server" Text="Your Last Name"></asp:Label>
    <asp:TextBox ID="TxtLastName" runat="server"></asp:TextBox>

    <asp:Button ID="BtnGo" OnClick="BtnGo_Click" runat="server" Text="Go" />
    
    <asp:LinkButton ID="LkbtnLogIn" runat="server">Do you already have an account?</asp:LinkButton>
</asp:Content>
