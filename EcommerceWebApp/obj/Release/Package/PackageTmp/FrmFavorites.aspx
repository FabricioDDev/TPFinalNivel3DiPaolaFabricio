<%@ Page Title="" Language="C#" MasterPageFile="~/Profile.Master" AutoEventWireup="true" CodeBehind="FrmFavorites.aspx.cs" Inherits="EcommerceWebApp.FrmFavorites" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .favorite{
            width:100%;
            height:80vh;
            display:flex;
            flex-flow:column nowrap;
        }
        .sub{
            width:100%;
            height:8%;
            display:flex;
            flex-flow:row nowrap;
            justify-content:space-around;
            align-items:center;
        }
        .catalog-container{
            display:flex;
            flex-flow: row wrap;
            align-items:center;
            width:100%;
            height:100%;
            background-color:#cce3de;
        }
        
        .img-container{
            width:49%;
            height:50vh;
            min-width: 49%;
            display:flex;
            flex-flow:column;
            justify-content:center;
            align-items:center;
            border: solid 2px #cce3de;
            border-radius: 3%;
            z-index:50;
            background-color:white;
        }
        .card-body{
            height:50%;
            width:100%;
            display:flex;
            justify-content:center;
            align-items:center;
            flex-flow:column nowrap;
        }
        .img{
            height:50%;
            width:100%;
            object-fit: contain;
        }
        .btnCard{
            margin-bottom:2px;
            width:50%;
            height:10%;
            border:none;
            background-color:lawngreen;
        }
        .empty{
            font-size:3em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="favorite">
         <div class="sub">
         <h1 style="color:white;">Favorites!<3</h1>
         <asp:Button ID="BtnDeleteAll" CssClass="btn" OnClick="BtnDeleteAll_Click" runat="server" Text="Delete All Favorites" />
         </div>
         
         <div class="catalog-container">
             <asp:Repeater ID="RptrFavorites" runat="server">
            <ItemTemplate>
                            <div class="img-container" >
                                <img src="<%#Eval("Image")%>" class="img"   alt="...">
                                <div class="card-body">
                                    <h5 ><%#Eval("Name")%></h5>
                                    <p><%#Eval("Price") %></p>
                                    <asp:Button ID="BtnDetail"  CssClass="btnCard" OnClick="BtnDetail_Click"  runat="server" Text="Detail" CommandArgument='<%#Eval("Id")%>'/>
                                    <asp:Button ID="BtnDeleteFavorite"  CssClass="btnCard" OnClick="BtnDeleteFavorite_Click" CommandArgument='<%#Eval("Id")%>' runat="server" Text="X" />
                                </div>
                            </div>
            </ItemTemplate>
            </asp:Repeater>
            
         </div>
    
        <asp:Label ID="LblEmpty" CssClass="empty" runat="server" Text="Empty" Visible="false"></asp:Label>
    </div>
    
</asp:Content>
