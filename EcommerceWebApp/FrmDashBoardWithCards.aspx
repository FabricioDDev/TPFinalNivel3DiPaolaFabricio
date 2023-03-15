<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoard.Master" AutoEventWireup="true" CodeBehind="FrmDashBoardWithCards.aspx.cs" Inherits="EcommerceWebApp.DashBoardWithCards" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Filtro Basico -->
            <label>Buscar</label>
            <asp:TextBox ID="TxtSearch" AutoPostBack="true" OnTextChanged="TxtSearch_TextChanged" runat="server"></asp:TextBox>
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <div class="col">
             <asp:Repeater ID="RptrCards" runat="server">
                <ItemTemplate>
                    
                        <div class="card" style="width: 18rem;">
                            <img src="<%#Eval("Image")%>" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Name")%></h5>
                                <asp:Button ID="BtnDetail" OnClick="BtnDetail_Click" runat="server" Text="Detail" CommandArgument='<%#Eval("Id")%>'/>
                            </div>
                        </div>
                   
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
   
</asp:Content>
