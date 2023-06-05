<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoard.Master" AutoEventWireup="true" CodeBehind="FrmDashBoardWithGrid.aspx.cs" Inherits="EcommerceWebApp.DashBoardWithGrid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-9ndCyUaIbzAi2FUVXJi0CjmCapSmO7SnpJef0486qhLnuZ2cdeRhO02iuK6FUUVM" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-geWF76RCwLtnZ8qwWowPQNguL3RmwHVBC9FhGdlKrxdiJJigb/j/68SIy3Te4Bkz" crossorigin="anonymous"></script>
    <style>
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
        .tbContainer{
            display:flex;
            justify-content:center;
            align-items:center;
            width:100%;
            height:100%;
            position:absolute;
            top:12vh;
            left:0px;
            background-color:#d9ed92;
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
            <asp:Button ID="BtnView" CssClass="button" OnClick="BtnView_Click" runat="server" Text=" Change View" />
         </div>

         <div style="display:flex; justify-content:space-between; align-items:center; height:100%;">
             <!-- Filtro Basico -->
                <asp:Label ID="LblSearch" CssClass="txt" runat="server" Text="Search"></asp:Label>
                <asp:TextBox ID="TxtSearch" CssClass="input" AutoPostBack="true" OnTextChanged="TxtSearch_TextChanged" runat="server"></asp:TextBox>
   
             <!-- Advanced Filter -->
                <asp:CheckBox ID="CkbxAdvancedFilter" AutoPostBack="true" runat="server" />
             <!-- Camp -->
                <asp:Label ID="LblCamp" runat="server" Text="Camp"></asp:Label>
                <asp:DropDownList ID="DdlCamp" OnSelectedIndexChanged="DdlCamp_SelectedIndexChanged"  AutoPostBack="true" runat="server"></asp:DropDownList>

             <!-- criterion -->
                <asp:Label ID="LblCriterion" runat="server" Text="Criterion"></asp:Label>
                <asp:DropDownList ID="DdlCriterion"  runat="server"></asp:DropDownList>

                <asp:Button ID="BtnApplyFilter" CssClass="button" OnClick="BtnApplyFilter_Click" runat="server" Text="Apply" />
            </div>
    </div>
     
    <div class="tbContainer">
        <!-- Grid -->
        <asp:GridView ID="GvArticles" CssClass="table table-secondary" DataKeyNames="Id"  AutoGenerateColumns="false" OnSelectedIndexChanged="GvArticles_SelectedIndexChanged" runat="server">
            <Columns>
                <asp:CommandField ShowSelectButton="true" HeaderText="command" SelectText="Select" />
                <asp:BoundField DataField="Code" HeaderText="Code" />
                <asp:BoundField DataField="Brand" HeaderText="Brand"/>
                <asp:BoundField DataField="Name" HeaderText="Name"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
