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
            <asp:Button ID="BtnUpdate" OnClick="BtnUpdate_Click" runat="server" Text="Update" />
            <asp:Button ID="BtnBack" OnClick="BtnBack_Click" runat="server" Text="Back" />

            <asp:Label ID="FullName" runat="server" Text=""></asp:Label>

            <asp:Image ID="ImgArticle" runat="server" />
            <asp:Label ID="LblPrice1" runat="server" Text=""></asp:Label>


            <label>Specification</label>

           

            <asp:GridView ID="GvArticle" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField DataField="Code" HeaderText="Code" />
                    <asp:BoundField DataField="Brand.Name" HeaderText="Brand" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Category.Name" HeaderText="Category" />
                </Columns>
            </asp:GridView>

            
        </div>
    </form>
</body>
</html>
