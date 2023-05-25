<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoard.Master" AutoEventWireup="true" CodeBehind="FrmDashBoardWithCards.aspx.cs" Inherits="EcommerceWebApp.DashBoardWithCards" EnableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row d-flex justify-content-center align-items-center w-100 mb-2">
        <div class="col-auto d-flex flex-row justify-content-between align-items-center">
            <!-- Filtro Basico -->
             <asp:Label ID="LblSearch" CssClass="txt form-label" runat="server" Text="Search"></asp:Label>
            <asp:TextBox ID="TxtSearch" CssClass="form-control m-2" AutoPostBack="true" OnTextChanged="TxtSearch_TextChanged" runat="server"></asp:TextBox>
        
             <!--Advanced Filter -->
            <asp:CheckBox ID="CkbxAdvancedFilter" CssClass="form-check-input m-2" AutoPostBack="true" runat="server" />
            <div class="d-flex flex-row justify-content-center align-items-center">
                <!-- Camp -->
                <asp:Label ID="LblCamp" CssClass="txt form-label" runat="server" Text="Camp"></asp:Label>
                <asp:DropDownList ID="DdlCamp" CssClass="form-select m-2" OnSelectedIndexChanged="DdlCamp_SelectedIndexChanged"  AutoPostBack="true" runat="server"></asp:DropDownList>

             <!-- criterio -->
                <asp:Label ID="LblCriterion" CssClass="txt form-label" runat="server" Text="Criterion"></asp:Label>
                <asp:DropDownList ID="DdlCriterion" CssClass="form-select m-2"  runat="server"></asp:DropDownList>
            </div>
                <asp:Button ID="BtnApplyFilter" CssClass="btn btn-success m-2" OnClick="BtnApplyFilter_Click" runat="server" Text="Apply" />
            <asp:Button ID="BtnChangeView" CssClass="btn btn-primary" OnClick="BtnChangeView_Click" runat="server" Text="Change View" />
        </div>
    </div>
    <!-- Cards -->
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <div class="col d-flex flex-row">
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
