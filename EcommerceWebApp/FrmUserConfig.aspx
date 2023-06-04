<%@ Page Title="" Language="C#" MasterPageFile="~/Profile.Master" AutoEventWireup="true" CodeBehind="FrmUserConfig.aspx.cs" Inherits="EcommerceWebApp.UserConfig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .img{
            width:60%;
            object-fit: contain;
        }
        .form{
            width:100%;
            height:80vh;
            display:flex;
            flex-flow:row wrap;
            justify-content:center;
            align-content:center;
        }
        .form div{
            height:100%;
            width:50%;
            display:flex;
            flex-flow:column nowrap;
            justify-content:center;
            align-items:center;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="form">
        <div >
            <asp:Label ID="LblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>

            <asp:Label ID="LblPassWord" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="TxtPassword" runat="server"></asp:TextBox>

            <asp:Label ID="LblName" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>

            <asp:Label ID="LblLastName" runat="server" Text="LastName"></asp:Label>
            <asp:TextBox ID="TxtLastName" runat="server"></asp:TextBox>

            <asp:Button ID="BtnSave" OnClick="BtnSave_Click" runat="server" Text="Save" />
        </div>
        <div>
            <asp:Image ID="ImgProfile" CssClass="img" runat="server" />
            <asp:Label ID="LblImageTitle" runat="server" Text="Image"></asp:Label>
            <asp:Label ID="LblLocal" runat="server" Text="Local"></asp:Label>
            <input type="file" runat="server" id="InputFile" />
            <asp:Label ID="LblUrl" runat="server" Text="Url"></asp:Label>
            <asp:TextBox ID="TxtUrl" runat="server"></asp:TextBox>
        </div>
    </div>
            

    

</asp:Content>
