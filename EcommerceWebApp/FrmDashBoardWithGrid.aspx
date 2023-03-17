<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoard.Master" AutoEventWireup="true" CodeBehind="FrmDashBoardWithGrid.aspx.cs" Inherits="EcommerceWebApp.DashBoardWithGrid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="BtnView" OnClick="BtnView_Click" runat="server" Text=" Change View" />
     <!-- Filtro Basico -->
             <asp:Label ID="LblSearch" runat="server" Text="Search"></asp:Label>
            <asp:TextBox ID="TxtSearch" AutoPostBack="true" OnTextChanged="TxtSearch_TextChanged" runat="server"></asp:TextBox>
   
    <!-- Advanced Filter -->
        <asp:CheckBox ID="CkbxAdvancedFilter" AutoPostBack="true" runat="server" />
        <!-- Camp -->
            <asp:Label ID="LblCamp" runat="server" Text="Camp"></asp:Label>
            <asp:DropDownList ID="DdlCamp" OnSelectedIndexChanged="DdlCamp_SelectedIndexChanged"  AutoPostBack="true" runat="server"></asp:DropDownList>

         <!-- criterion -->
            <asp:Label ID="LblCriterion" runat="server" Text="Criterion"></asp:Label>
            <asp:DropDownList ID="DdlCriterion"  runat="server"></asp:DropDownList>

            <asp:Button ID="BtnApplyFilter" OnClick="BtnApplyFilter_Click" runat="server" Text="Apply" />

    <!-- Grid -->
    <asp:GridView ID="GvArticles" DataKeyNames="Id"  AutoGenerateColumns="false" OnSelectedIndexChanged="GvArticles_SelectedIndexChanged" runat="server">
        <Columns>
            <asp:CommandField ShowSelectButton="true" HeaderText="command" SelectText="Select" />
            <asp:BoundField DataField="Code" HeaderText="Code" />
            <asp:BoundField DataField="Brand" HeaderText="Brand"/>
            <asp:BoundField DataField="Name" HeaderText="Name"/>
        </Columns>
    </asp:GridView>
</asp:Content>
