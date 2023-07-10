<%@ Page Title="" Language="C#" MasterPageFile="~/LogIn_SignUp.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EcommerceWebApp.FrmLogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .txt {
            font-family: 'Gloock', serif;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row">
        <div class="col-12">
             <div class="mb-3">
                <asp:Label ID="LblWarning" CssClass="txt form-label alert alert-danger" Visible="false" runat="server" Text=""></asp:Label>
             </div>
        </div>
    </div>
    <div class="row d-flex justify-content-center align-items-center w-100 h-100">
        <div class =" col-sm-12 col-md-9 col-lg-6 h-100 d-flex flex-column justify-content-center align-items-center">
            
             <div class="mb-3 w-100">
                    <asp:Label ID="LblEmail" CssClass="txt form-label form-label-lg" runat="server" Text="Your Email:"></asp:Label>
                    <asp:TextBox ID="TxtEmail" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
             </div>
             <div class="mb-3 w-100">
                    <asp:Label ID="LblPass" CssClass="txt form-label form-label-lg" runat="server" Text="Pass"></asp:Label>
                    <asp:TextBox ID="TxtPass" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
             </div>
             <div class="mb-3 w-100 d-flex flex-column justify-content-center align-items-center">
                    <asp:Button ID="BtnGo" CssClass="txt btn btn-success" OnClick="BtnGo_Click" runat="server" Text="Go" />
                    <asp:LinkButton ID="LktbtnSignUp" CssClass="txt form-label" OnClick="LktbtnSignUp_Click" runat="server" Text="SignUp"></asp:LinkButton>
             </div>
        </div>
    </div>
   
    
</asp:Content>