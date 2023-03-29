<%@ Page Title="" Language="C#" MasterPageFile="~/Profile.Master" AutoEventWireup="true" CodeBehind="FrmFavorites.aspx.cs" Inherits="EcommerceWebApp.FrmFavorites" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Favorites!<3</h1>
    <asp:Button ID="BtnDeleteAll" runat="server" Text="Delete All Favorites" />
    <asp:Repeater ID="RptrFavorites" runat="server">
        <ItemTemplate>
                        <div class="card" style="width: 18rem;">
                            <img src="<%#Eval("Image")%>" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Name")%></h5>
                                <p><%#Eval("Price") %></p>
                                <asp:Button ID="BtnDetail" OnClick="BtnDetail_Click"  runat="server" Text="Detail" CommandArgument='<%#Eval("Id")%>'/>
                                <asp:Button ID="BtnDeleteFavorite" CommandArgument='<%#Eval("Id")%>' runat="server" Text="X" />
                            </div>
                        </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
