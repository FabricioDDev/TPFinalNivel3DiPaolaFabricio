<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoard.Master" AutoEventWireup="true" CodeBehind="FrmDashBoardWithGrid.aspx.cs" Inherits="EcommerceWebApp.DashBoardWithGrid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Filtro Basico -->
             <asp:Label ID="LblSearch" runat="server" Text="Search"></asp:Label>
            <asp:TextBox ID="TxtSearch" AutoPostBack="true" OnTextChanged="TxtSearch_TextChanged" runat="server"></asp:TextBox>
   
    <!--Advanced Filter -->
        <asp:CheckBox ID="CkbxAdvancedFilter" AutoPostBack="true" runat="server" />
        <!-- Camp -->
            <asp:Label ID="LblCamp" runat="server" Text="Camp"></asp:Label>
            <asp:DropDownList ID="DdlCamp" OnSelectedIndexChanged="DdlCamp_SelectedIndexChanged"  AutoPostBack="true" runat="server"></asp:DropDownList>

         <!-- criterio -->
            <asp:Label ID="LblCriterion" runat="server" Text="Criterion"></asp:Label>
            <asp:DropDownList ID="DdlCriterion"  runat="server"></asp:DropDownList>

            <asp:Button ID="BtnApplyFilter" OnClick="BtnApplyFilter_Click" runat="server" Text="Apply" />

    <!-- Grid -->
    <asp:GridView ID="GvArticles" DataKeyNames="Id" OnSelectedIndexChanged="GvArticles_SelectedIndexChanged" runat="server">
        <Columns>
            <asp:CommandField ShowSelectButton="true" HeaderText="command" SelectText="Select" />
            <asp:BoundField DataField="Code" />
            <asp:BoundField DataField="Brand" />
            <asp:BoundField DataField="Name" />
        </Columns>
    </asp:GridView>
</asp:Content>
