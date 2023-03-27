<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmArticleRegister.aspx.cs" Inherits="EcommerceWebApp.FrmArticleRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="BtnBack" runat="server" Text="Back" />
            <asp:Button ID="BtnSave" runat="server" Text="Save" />

            <asp:Label ID="LblCode" runat="server" Text="Code"></asp:Label>
            <asp:TextBox ID="TxtCode" runat="server"></asp:TextBox>

            <asp:Label ID="LblName" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>

            <asp:Label ID="LblDescription" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="TxtDescription" runat="server"></asp:TextBox>

            <asp:Label ID="LblBrand" runat="server" Text="Brand"></asp:Label>
            <asp:DropDownList ID="DdlBrand" runat="server"></asp:DropDownList>

            <asp:Label ID="LblCategory" runat="server" Text="Category"></asp:Label>
            <asp:DropDownList ID="DdlCategory" runat="server"></asp:DropDownList>

            <asp:Label ID="LblImageTitle" runat="server" Text="Image"></asp:Label>
            <asp:Label ID="LblLocal" runat="server" Text="Local"></asp:Label>
            <input type="file" runat="server" id="InputFile" />
            <asp:Label ID="LblUrl" runat="server" Text="Url"></asp:Label>
            <asp:TextBox ID="TxtUrl" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
