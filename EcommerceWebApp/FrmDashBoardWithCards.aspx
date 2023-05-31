<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoard.Master" AutoEventWireup="true" CodeBehind="FrmDashBoardWithCards.aspx.cs" Inherits="EcommerceWebApp.DashBoardWithCards" EnableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        *{
            margin:0px;
            padding:0px;
        }
        .sub_bar{
            display:flex;
            flex-flow:row wrap;
            justify-content:space-between;
            align-items:center;
            width:100%;
            height: 6vh;
            position:absolute;
            top:8vh;
            left:0px;
            z-index:90;
            background-color:#94bbe9;
        }
        .catalog-container{
            display:flex;
            align-items:center;
            width:100%;
            height:100%;
            position:absolute;
            top:12vh;
            left:0px;
        }
        
        .img-container{
            width:50%;
            height:50%;
            min-width: 200px;
            display:flex;
            flex-flow:column;
            justify-content:center;
            align-items:center;
            border: solid 1px black;
        }
        .img{
            height:70%;
            width:100%;
            object-fit: contain;
        }
        .btnCard{
            width:50%;
            height:5%;
            border:none;
            background-color:lawngreen;
        }
        @media screen and (min-width:1000px){
            .sub_bar{
                top:10vh;
            }
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sub_bar">
        <div style="margin-right:5px;">
            <asp:Button ID="BtnChangeView" CssClass="button" OnClick="BtnChangeView_Click" runat="server" Text="Change View" />
        </div>
        <div style="display:flex; justify-content:space-between; align-items:center; height:100%;">
             <!-- Filtro Basico -->
             <asp:Label ID="LblSearch" CssClass="txt" runat="server" Text="Search"></asp:Label>
            <asp:TextBox ID="TxtSearch" CssClass="input" AutoPostBack="true" OnTextChanged="TxtSearch_TextChanged" runat="server"></asp:TextBox>
   
             <!--Advanced Filter -->
            <asp:CheckBox ID="CkbxAdvancedFilter" AutoPostBack="true" runat="server" />
            <!-- Camp -->
                <asp:Label ID="LblCamp" runat="server" Text="Camp"></asp:Label>
                <asp:DropDownList ID="DdlCamp" OnSelectedIndexChanged="DdlCamp_SelectedIndexChanged"  AutoPostBack="true" runat="server"></asp:DropDownList>

             <!-- criterio -->
                <asp:Label ID="LblCriterion" runat="server" Text="Criterion"></asp:Label>
                <asp:DropDownList ID="DdlCriterion"  runat="server"></asp:DropDownList>
        
            <asp:Button ID="BtnApplyFilter" CssClass="button" OnClick="BtnApplyFilter_Click" runat="server" Text="Apply" />
        </div>
        
    </div>
    
    <!-- Cards -->
    <div class="catalog-container">
        <asp:Repeater ID="RptrCards" runat="server">
                <ItemTemplate>
                    <div class="img-container">
                        <img src="<%#Eval("Image") %>" class="img" alt="...">
                        <h5 class="card-title"><%#Eval("Name")%></h5>
                        <p>$<%#Eval("PriceStringFormat") %></p>
                        <asp:Button ID="BtnDetail" CssClass="btnCard" OnClick="BtnDetail_Click" runat="server" Text="Detail" CommandArgument='<%#Eval("Id")%>'/>
                        <asp:Button ID="BtnFavorites"  CssClass="btnCard" OnClick="BtnFavorites_Click" runat="server" Text="Add to Favorites" CommandArgument='<%#Eval("Id")%>' />                  
                    </div>
                </ItemTemplate>
            </asp:Repeater>
    </div>
</asp:Content>
