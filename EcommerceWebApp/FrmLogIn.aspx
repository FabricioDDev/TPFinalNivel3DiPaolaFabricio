<%@ Page Title="" Language="C#" MasterPageFile="~/LogIn_SignUp.Master" AutoEventWireup="true" CodeBehind="FrmLogIn.aspx.cs" Inherits="EcommerceWebApp.FrmLogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .txt {
            font-family: 'Gloock', serif;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Label ID="LblWarning" CssClass="txt form-label alert alert-danger" Visible="false" runat="server" Text=""></asp:Label>
    <asp:Label ID="LblEmail" CssClass="txt form-label" runat="server" Text="Your Email:"></asp:Label>
    <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server"></asp:TextBox>

    <asp:Label ID="LblPass" CssClass="txt form-label" runat="server" Text="Pass"></asp:Label>
    <asp:TextBox ID="TxtPass" CssClass="form-control" runat="server"></asp:TextBox>

    <asp:Button ID="BtnGo" CssClass="txt btn btn-success" OnClick="BtnGo_Click" runat="server" Text="Go" />
    
    <asp:LinkButton ID="LktbtnSignUp" CssClass="txt form-label" OnClick="LktbtnSignUp_Click" runat="server" Text="SignUp"></asp:LinkButton>
</asp:Content>