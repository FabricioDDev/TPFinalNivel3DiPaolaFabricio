<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmArticleRegister.aspx.cs" Inherits="EcommerceWebApp.FrmArticleRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        *{
            padding:0px;
            margin:0px;
            box-sizing:border-box;
        }
        .body{
            width:100%;
            height:100vh;
            display:flex;
            flex-flow:column nowrap;
             
        }
        .container{
            width:100%;
            height:100vh;
            display:flex;
            flex-flow:column nowrap;
            justify-content: flex-start;
            align-items:center;
            background-color:#99d98c;
        }
        .navbar{
            width:100%;
            height:8vh;
            display:flex;
            flex-flow:row wrap;
            justify-content:space-around;
            align-items:center;
            background-color:#99d98c;
        }
        .section{
            width:90%;
            height:70%;
            display:flex;
            flex-flow: row wrap;
            justify-content:center;
            align-items:center;
            background-color:#d9ed92;
        }
        .section div{
            display:flex;
            flex-flow:column nowrap;
            justify-content:center;
            align-items:center;
            width:30%;
            height:100%;
        }
        .btn{
            text-decoration:none;
            border:none;
            background-color:transparent;
            font-size:1.5em;
        }
        .input{
            width:70%;
            height:6%;
        }
        .img{
            height:70%;
            width: 100%;
            object-fit: contain;
        }
        .warning{
            color:red;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="navbar">
                <asp:Button ID="BtnBack" CssClass="btn" OnClick="BtnBack_Click" runat="server" Text="Back" />
                <asp:Button ID="BtnSave" CssClass="btn" OnClick="BtnSave_Click" runat="server" Text="Save" />
                
                <div style="display:flex; border:solid 1px red; border-radius:5px; justify-content:space-around; width:30%;">
                    <asp:Button ID="BtnDelete" CssClass="btn" Visible="false" OnClick="BtnDelete_Click" runat="server" Text="Delete" />
                    <asp:Label ID="LblConfirmDelete" CssClass="btn" Visible="false" runat="server" Text="Are you Sure?"></asp:Label>
                    <asp:Button ID="BtnConfirmDelete" CssClass="btn warning" Visible="false" OnClick="BtnConfirmDelete_Click" runat="server" Text="Yes" />
                </div>
            </div>
            <div class="section">
                <div>
                    <asp:Label ID="LblId" runat="server" Text="Id"></asp:Label>
                    <asp:TextBox ID="TxtId" CssClass="input" Enabled="false" runat="server"></asp:TextBox>

                    <asp:Label ID="LblCode" runat="server" Text="Code"></asp:Label>
                    <asp:TextBox ID="TxtCode" CssClass="input" runat="server"></asp:TextBox>

                    <asp:Label ID="LblName" runat="server" Text="Name"></asp:Label>
                    <asp:TextBox ID="TxtName" CssClass="input" runat="server"></asp:TextBox>
                
                    <asp:Label ID="LblPrice" runat="server" Text="Price"></asp:Label>
                    <asp:TextBox ID="TxtPrice" CssClass="input" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ErrorMessage="Only Numbers" ControlToValidate="TxtPrice" ValidationExpression="^[0-9.]+$" runat="server" />

                    <asp:Label ID="LblDescription" runat="server" Text="Description"></asp:Label>
                    <asp:TextBox ID="TxtDescription" CssClass="input" runat="server"></asp:TextBox>

                    <asp:Label ID="LblBrand" runat="server" Text="Brand"></asp:Label>
                    <asp:DropDownList ID="DdlBrand" CssClass="input" runat="server"></asp:DropDownList>

                    <asp:Label ID="LblCategory" runat="server" Text="Category"></asp:Label>
                    <asp:DropDownList ID="DdlCategory" CssClass="input" runat="server"></asp:DropDownList>
                </div>
                <div>
                    <asp:Image ID="ImgArticle" CssClass="img" runat="server" />
                    <asp:Label ID="LblLocal" runat="server" Text="Local"></asp:Label>
                    <input type="file" runat="server" id="InputFile" />
                    <asp:Label ID="LblUrl" runat="server" Text="Url"></asp:Label>
                    <asp:TextBox ID="TxtUrl" CssClass="input" runat="server"></asp:TextBox>
                </div>

                
            </div>
           
        </div>
    </form>
</body>
</html>
