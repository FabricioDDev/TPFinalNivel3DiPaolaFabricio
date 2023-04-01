﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainModel;
using BusinessModel;
using System.Drawing;

namespace EcommerceWebApp
{
    public partial class DashBoardWithCards : System.Web.UI.Page
    {
        public DashBoardWithCards()
        {
            articleBusiness = new ArticleBusiness();
            
        }
        public ArticleBusiness articleBusiness;
        public static int IdUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                chargeCards(articleBusiness.Listing());
                chargeDdlCamp();
                User user = (User)Session["activeUser"];
                IdUser = user.idProperty;
                
            }  
            stateCkbxAdvancedFilter();
        }
        private void stateCkbxAdvancedFilter()
        {
            if (CkbxAdvancedFilter.Checked == true)
            {
                LblCamp.Visible = true;
                LblCriterion.Visible = true;
                DdlCamp.Visible = true;
                DdlCriterion.Visible = true;
                BtnApplyFilter.Visible = true;
                LblSearch.Enabled=false;
                TxtSearch.Enabled = false;
            }
            else if (CkbxAdvancedFilter.Checked == false)
            {
                LblSearch.Enabled = true;
                TxtSearch.Enabled = true;
                LblCamp.Visible = false;
                LblCriterion.Visible = false;
                DdlCamp.Visible = false;
                DdlCriterion.Visible = false;
                BtnApplyFilter.Visible = false;
            }
        }
        private void chargeDdlCamp()
        {
            DdlCamp.Items.Clear();
            DdlCamp.Items.Add("Brand");
            DdlCamp.Items.Add("Price");
            DdlCamp.Items.Add("Category");
        }  
        private void chargeCards(List<Article>List)
        {
            RptrCards.DataSource = List;
            RptrCards.DataBind();
        }
        protected void BtnDetail_Click(object sender, EventArgs e)
        {
            string Id = ((Button)sender).CommandArgument;
            Response.Redirect("FrmDetail.aspx?id=" + Id);
        }
        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            List<Article>list = articleBusiness.Listing().FindAll(
                x => x.Code.ToUpper().Contains(TxtSearch.Text.ToUpper()) ||
                x.Name.ToUpper().Contains(TxtSearch.Text.ToUpper()));
            chargeCards(list);
        }
        protected void DdlCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlCriterion.Items.Clear();
            if (DdlCamp.SelectedValue == "Brand")
            {
                BrandBusiness brandBusiness = new BrandBusiness();
                DdlCriterion.DataSource = brandBusiness.Listing();
                DdlCriterion.DataValueField = "Id";
                DdlCriterion.DataTextField= "Name";
                DdlCriterion.DataBind();
            }
            else if (DdlCamp.SelectedValue == "Price")
            {
                DdlCriterion.Items.Add("- to +");
                DdlCriterion.Items.Add("+ to -");
            }
            else if (DdlCamp.SelectedValue == "Category")
            {
                CategoryBusiness categoryBusiness = new CategoryBusiness();
                DdlCriterion.DataSource = categoryBusiness.Listing();
                DdlCriterion.DataValueField = "Id";
                DdlCriterion.DataTextField = "Name";
                DdlCriterion.DataBind();
            }
        }

        protected void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            string Camp = DdlCamp.SelectedValue;
            string Criterion = DdlCriterion.SelectedValue;
            chargeCards(articleBusiness.listFiltered(Camp, Criterion));
        }

        protected void BtnChangeView_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmDashBoardWithGrid.aspx", false);
        }

        protected void BtnFavorites_Click(object sender, EventArgs e)
        {
            FavoriteBusiness favoriteBusiness = new FavoriteBusiness();
            string Id = ((Button)sender).CommandArgument;
            favoriteBusiness.insertFavorite(IdUser,int.Parse(Id));
        }

        
    }
}