<%@ Page Title="" Language="C#" MasterPageFile="~/LogIn_SignUp.Master" AutoEventWireup="true" CodeBehind="FrmSignUp.aspx.cs" Inherits="EcommerceWebApp.FrmSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row d-flex justify-content-center align-items-center w-100 h-100">
        <div class="col-sm-12 col-md-6 col-lg-6">
            <asp:Label ID="LblWarning" runat="server" Text="" Visible="false"></asp:Label>
        </div>
    </div>
    <div class="row d-flex justify-content-center align-items-center w-100 h-100">
        <div class =" col-sm-12 col-md-9 col-lg-6 h-100 d-flex flex-column justify-content-center align-items-center">
            <div class="mb-3 w-100">
                <asp:Label ID="LblEmail" CssClass="txt form-label form-label-lg" runat="server" Text="Your Email*"></asp:Label>
                <asp:TextBox ID="TxtEmail"  CssClass="form-control form-control-lg"  runat="server"></asp:TextBox>
            </div>
            <div class="mb-3 w-100">
                <asp:Label ID="LblPass" runat="server" CssClass="txt form-label form-label-lg" Text="Your Pass*"></asp:Label>
                <asp:TextBox ID="TxtPass" CssClass="form-control form-control-lg" TextMode="Password" runat="server"></asp:TextBox>
                <asp:Button ID="BtnViewPass" CssClass="btn btn-sm btn-primary" OnClick="BtnViewPass_Click" runat="server" Text="ViewPass" />
            </div>
            <div class="mb-3 w-100">
                <asp:Label ID="LblName" CssClass="txt form-label form-label-lg" runat="server" Text="Your Name"></asp:Label>
                <asp:TextBox ID="TxtName" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3 w-100">
                <asp:Label ID="LblLastName" CssClass="txt form-label form-label-lg" runat="server" Text="Your Last Name"></asp:Label>
                <asp:TextBox ID="TxtLastName" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3 w-100">
                <asp:Button ID="BtnGo" CssClass="txt btn btn-success btn-lg w-100"  OnClick="BtnGo_Click" runat="server" Text="Go" />
                <asp:LinkButton ID="LkbtnLogIn" CssClass="txt form-label form-label-lg" OnClick="LkbtnLogIn_Click" runat="server">Do you already have an account?</asp:LinkButton>
            </div>
        </div>
    </div>

</asp:Content>
