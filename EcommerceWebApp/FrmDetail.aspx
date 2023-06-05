<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmDetail.aspx.cs" Inherits="EcommerceWebApp.FrmDetail" %>

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
        body{
            width:100%;
            height:100vh;
            background-color:#99d98c;
        }
        .container{
            width:100%;
            height:100vh;
            display:flex;
            flex-flow:column nowrap;
            justify-content:center;
            align-items:center;
           background-color:#99d98c;
        }
        .navbar{
            width:100%;
            height:8vh;
            display:flex;
            flex-flow:row nowrap;
            justify-content:space-between;
            align-items:center;
            background-color:#52b69a;
        }
        .section{
            width:100%;
            height:40vh;
            display:flex;
            flex-flow:column nowrap;
            justify-content:center;
            align-items:center;
            background-color:#d9ed92;
        }
        .specifications{
            width:100%;
            height:40vh;
            display:flex;
            flex-flow:column nowrap;
            justify-content:flex-start;
            align-items:center;
            background-color:#d9ed92;
        }
        .txt{
            font-size:1.5em;
        }
        .btn{
            text-decoration:none;
            border:none;
            background-color:transparent;
            font-size:1.5em;
        }
        .img{
            height:70%;
            width:90%;
            object-fit: contain;
        }
        .title{
            font-size:2em;
        }
        .sub-title{
            font-size:2em;
        }
    </style>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-9ndCyUaIbzAi2FUVXJi0CjmCapSmO7SnpJef0486qhLnuZ2cdeRhO02iuK6FUUVM" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-geWF76RCwLtnZ8qwWowPQNguL3RmwHVBC9FhGdlKrxdiJJigb/j/68SIy3Te4Bkz" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server" style="background-color:#99d98c;">
        <div class="container">
            <div class="navbar">
                <asp:Button ID="BtnBack" CssClass = " txt btn" OnClick="BtnBack_Click" runat="server" Text="Back" />
                <asp:Button ID="BtnUpdate" CssClass = " txt btn" OnClick="BtnUpdate_Click" runat="server" Text="Update" />
            </div>
            
            <div class="section">
                <asp:Image ID="ImgArticle" CssClass="img" runat="server" />
                <asp:Label ID="FullName" CssClass="title txt" runat="server" Text=""></asp:Label>
                <asp:Label ID="LblPrice1" CssClass="txt" runat="server" Text=""></asp:Label>
            </div>
           <div class="specifications">
                <label class="sub-title">Specification</label>
            <asp:GridView ID="GvArticle" CssClass="table table-secondary" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField DataField="Code" HeaderText="Code" />
                    <asp:BoundField DataField="Brand.Name" HeaderText="Brand" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Category.Name" HeaderText="Category" />
                </Columns>
            </asp:GridView>
           </div>  
        </div>
    </form>
</body>
</html>
