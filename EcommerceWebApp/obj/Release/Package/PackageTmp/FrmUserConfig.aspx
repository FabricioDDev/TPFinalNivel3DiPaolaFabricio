<%@ Page Title="" Language="C#" MasterPageFile="~/Profile.Master" AutoEventWireup="true" CodeBehind="FrmUserConfig.aspx.cs" Inherits="EcommerceWebApp.UserConfig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .img{
            width:60%;
            object-fit: contain;
        }
        .form{
            width:60%;
            height:80vh;
            display:flex;
            flex-flow:row wrap;
            justify-content:center;
            align-content:center;
            background-color:#d9ed92;
            border-radius:2%;
        }
        .form div{
            height:100%;
            width:50%;
            display:flex;
            flex-flow:column nowrap;
            justify-content:center;
            align-items:center;
        }
        .btnSave{
            border:none;
            padding:0.5%;
            border-radius:5%;
           background-color:#52b69a;
        }
        .input{
            width:70%;
            height:6%;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="form">
        <div>
            <asp:Label ID="LblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="TxtEmail" CssClass="input" runat="server"></asp:TextBox>

            <asp:Label ID="LblPassWord" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="TxtPassword"  CssClass="input" runat="server"></asp:TextBox>

            <asp:Label ID="LblName" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox ID="TxtName"  CssClass="input" runat="server"></asp:TextBox>

            <asp:Label ID="LblLastName" runat="server" Text="LastName"></asp:Label>
            <asp:TextBox ID="TxtLastName"  CssClass="input" runat="server"></asp:TextBox>

            <asp:Button ID="BtnSave" CssClass="btnSave" OnClick="BtnSave_Click" runat="server" Text="Save" />
        </div>
        <div>
            <asp:Image ID="ImgProfile" CssClass="img" runat="server" />
            <asp:Label ID="LblImageTitle" runat="server" Text="Image"></asp:Label>
            <asp:Label ID="LblLocal" runat="server" Text="Local"></asp:Label>
            <input type="file" runat="server" id="InputFile" />
            <asp:Label ID="LblUrl" runat="server" Text="Url"></asp:Label>
            <asp:TextBox ID="TxtUrl"  CssClass="input" runat="server"></asp:TextBox>
        </div>
    </div>
            

    

</asp:Content>
