<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmDetail.aspx.cs" Inherits="EcommerceWebApp.FrmDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LblCode" runat="server" Text="Code"></asp:Label>
            <asp:TextBox ID="TxtCode" Enabled="false" runat="server"></asp:TextBox>

            <asp:Label ID="LblName" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>

            <asp:Label ID="LblDescription" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="TxtDescription" runat="server"></asp:TextBox>

            <asp:Label ID="LblPrice" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="TxtPrice" runat="server"></asp:TextBox>

             <asp:Label ID="LblBrand" runat="server" Text="Brand"></asp:Label>
            <asp:DropDownList ID="DdlBrand" runat="server"></asp:DropDownList>

            <asp:Label ID="LblCategory" runat="server" Text="Category"></asp:Label>
            <asp:DropDownList ID="DdlCategory" runat="server"></asp:DropDownList>

            <asp:Label ID="LblImage" runat="server" Text="Image"></asp:Label>
            <input type="file" />
            <asp:Image ID="ImgArticle" runat="server" />

            <asp:Button ID="BtnSave" runat="server" Text="Save" />
        </div>
    </form>
</body>
</html>
