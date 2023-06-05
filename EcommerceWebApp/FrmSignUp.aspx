<%@ Page Title="" Language="C#" MasterPageFile="~/LogIn_SignUp.Master" AutoEventWireup="true" CodeBehind="FrmSignUp.aspx.cs" Inherits="EcommerceWebApp.FrmSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="LblEmail" CssClass="txt form-label form-label-lg" runat="server" Text="Your Email*"></asp:Label>
    <asp:TextBox ID="TxtEmail" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>

    <asp:Label ID="LblPass" CssClass="txt form-label form-label-lg" runat="server" Text="Your Pass*"></asp:Label>
    <asp:TextBox ID="TxtPass" CssClass="form-control form-control-lg" TextMode="Password" runat="server"></asp:TextBox>
    <asp:Button ID="BtnViewPass" CssClass="btn btn-sm btn-primary" OnClick="BtnViewPass_Click" runat="server" Text="ViewPass" />

    <asp:Label ID="LblName" CssClass="txt form-label form-label-lg" runat="server" Text="Your Name"></asp:Label>
    <asp:TextBox ID="TxtName" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>

    <asp:Label ID="LblLastName" CssClass="txt form-label form-label-lg" runat="server" Text="Your Last Name"></asp:Label>
    <asp:TextBox ID="TxtLastName" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>

    <asp:Button ID="BtnGo" CssClass="btn btn-sm btn-primary" OnClick="BtnGo_Click" runat="server" Text="Go" />
    <asp:Label ID="LblWarning" CssClass="txt form-label form-label-lg" runat="server" Text="" Visible="false"></asp:Label>
    
    <asp:LinkButton ID="LkbtnLogIn" OnClick="LkbtnLogIn_Click" runat="server">Do you already have an account?</asp:LinkButton>
</asp:Content>
