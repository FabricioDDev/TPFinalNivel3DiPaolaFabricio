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
            background-color:#cce3de;
        }
        .catalog-container{
            display:flex;
            align-items:center;
            width:100%;
            height:100%;
            position:absolute;
            top:16vh;
            left:0px;
            background-color:#cce3de;
        }
        
        .img-container{
            width:50%;
            height:50%;
            min-width: 200px;
            display:flex;
            flex-flow:column;
            justify-content:center;
            align-items:center;
            border: solid 2px #cce3de;
            border-radius: 3%;
            z-index:50;
            background-color:white;
        }
        .img{
            height:70%;
            width:100%;
            object-fit: contain;
        }
        .btnCard{
            margin-bottom:2px;
            width:50%;
            height:5%;
            border:none;
            background-color:#b5e48c;
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
            <asp:Button ID="BtnChangeView" CssClass="button txt" OnClick="BtnChangeView_Click" runat="server" Text="Change View" />
        </div>
        <div style="display:flex; justify-content:space-between; align-items:center; height:100%;">
             <!-- Filtro Basico -->
             <asp:Label ID="LblSearch" CssClass="txt" runat="server" Text="Search"></asp:Label>
            <asp:TextBox ID="TxtSearch" CssClass="input" AutoPostBack="true" OnTextChanged="TxtSearch_TextChanged" runat="server"></asp:TextBox>
   
             <!--Advanced Filter -->
            <asp:CheckBox ID="CkbxAdvancedFilter" AutoPostBack="true" runat="server" />
            <!-- Camp -->
                <asp:Label ID="LblCamp" CssClass="txt" runat="server" Text="Camp"></asp:Label>
                <asp:DropDownList ID="DdlCamp" OnSelectedIndexChanged="DdlCamp_SelectedIndexChanged"  AutoPostBack="true" runat="server"></asp:DropDownList>

             <!-- criterio -->
                <asp:Label ID="LblCriterion" CssClass="txt"  runat="server" Text="Criterion"></asp:Label>
                <asp:DropDownList ID="DdlCriterion"  runat="server"></asp:DropDownList>
        
            <asp:Button ID="BtnApplyFilter" CssClass="button txt" OnClick="BtnApplyFilter_Click" runat="server" Text="Apply" />
        </div>
        
    </div>
    
    <!-- Cards -->
    <div class="catalog-container">
        <asp:Repeater ID="RptrCards" runat="server">
                <ItemTemplate>
                    <div class="img-container">
                        <img src="<%#Eval("Image") %>" class="img" alt="...">
                        <h5 class="txt"><%#Eval("Name")%></h5>
                        <p class="txt">$<%#Eval("PriceStringFormat") %></p>
                        <asp:Button ID="BtnDetail" CssClass="btnCard txt" OnClick="BtnDetail_Click" runat="server" Text="Detail" CommandArgument='<%#Eval("Id")%>'/>
                        <asp:Button ID="BtnFavorites"  CssClass="btnCard txt" OnClick="BtnFavorites_Click" runat="server" Text="Add to Favorites" CommandArgument='<%#Eval("Id")%>' />                  
                    </div>
                </ItemTemplate>
            </asp:Repeater>
    </div>
</asp:Content>
