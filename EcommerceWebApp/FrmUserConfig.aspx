<%@ Page Title="" Language="C#" MasterPageFile="~/Profile.Master" AutoEventWireup="true" CodeBehind="FrmUserConfig.aspx.cs" Inherits="EcommerceWebApp.UserConfig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Image ID="ImgProfile" runat="server" />

    <asp:Label ID="LblEmail" runat="server" Text="Email:"></asp:Label>
    <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>

    <asp:Label ID="LblPassWord" runat="server" Text="Password:"></asp:Label>
    <asp:TextBox ID="TxtPassword" runat="server"></asp:TextBox>

    <asp:Label ID="LblName" runat="server" Text="Name:"></asp:Label>
    <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>

    <asp:Label ID="LblLastName" runat="server" Text="LastName"></asp:Label>
    <asp:TextBox ID="TxtLastName" runat="server"></asp:TextBox>
     
    <asp:Label ID="LblImageTitle" runat="server" Text="Image"></asp:Label>
            <asp:Image ID="ImgArticle" runat="server" />
            <asp:Label ID="LblLocal" runat="server" Text="Local"></asp:Label>
            <input type="file" runat="server" id="InputFile" />
            <asp:Label ID="LblUrl" runat="server" Text="Url"></asp:Label>
            <asp:TextBox ID="TxtUrl" runat="server"></asp:TextBox>

    <asp:Button ID="BtnSave" OnClick="BtnSave_Click" runat="server" Text="Save" />

</asp:Content>
