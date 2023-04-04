<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoard.Master" AutoEventWireup="true" CodeBehind="FrmDashBoardWithCards.aspx.cs" Inherits="EcommerceWebApp.DashBoardWithCards" EnableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="BtnChangeView" OnClick="BtnChangeView_Click" runat="server" Text="Change View" />
     <!-- Filtro Basico -->
             <asp:Label ID="LblSearch" runat="server" Text="Search"></asp:Label>
            <asp:TextBox ID="TxtSearch" AutoPostBack="true" OnTextChanged="TxtSearch_TextChanged" runat="server"></asp:TextBox>
   
        <ContentTemplate>
             <!--Advanced Filter -->
            <asp:CheckBox ID="CkbxAdvancedFilter" AutoPostBack="true" runat="server" />
            <!-- Camp -->
                <asp:Label ID="LblCamp" runat="server" Text="Camp"></asp:Label>
                <asp:DropDownList ID="DdlCamp" OnSelectedIndexChanged="DdlCamp_SelectedIndexChanged"  AutoPostBack="true" runat="server"></asp:DropDownList>

             <!-- criterio -->
                <asp:Label ID="LblCriterion" runat="server" Text="Criterion"></asp:Label>
                <asp:DropDownList ID="DdlCriterion"  runat="server"></asp:DropDownList>
        
    <asp:Button ID="BtnApplyFilter" OnClick="BtnApplyFilter_Click" runat="server" Text="Apply" />
    <!-- Cards -->
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <div class="col">
             <asp:Repeater ID="RptrCards" runat="server">
                <ItemTemplate>
                    
                        <div class="card" style="width: 18rem;">
                            <img src="<%#Eval("Image") %>" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Name")%></h5>
                                <p><%#Eval("PriceStringFormat") %></p>
                                <asp:Button ID="BtnDetail" OnClick="BtnDetail_Click" runat="server" Text="Detail" CommandArgument='<%#Eval("Id")%>'/>
                                <asp:Button ID="BtnFavorites" OnClick="BtnFavorites_Click" runat="server" Text="Add to Favorites" CommandArgument='<%#Eval("Id")%>' />
                            </div>
                        </div>
                   
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
   
</asp:Content>
