using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Service.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebView.Reference
{
    public partial class BzFlexerBranchProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillData();
            }
        }

        public void FillData()
        {
            DataBindTodropDownListBranch();
            DataBindTodropDownListProductCategory();
            DataBindTodropDownListSubProductCat();
            LoadUnmappedProductsRelevantToProCat();
            LoadMappedBranchProduct();
            loadEmptyData();
        }

        public void loadEmptyData()
        {
            List<Biz_Product> ProductList = null;
            List<Biz_BranchProduct> BranchProductList = null;

            gridViewAllProducts.DataSource = ProductList;
            gridViewAllProducts.DataBind();

            gridViewMappedProducts.DataSource = BranchProductList;
            gridViewMappedProducts.DataBind();
        }

        #region "Load Data"

        public void DataBindTodropDownListBranch()
        {
            try
            {
                Biz_BranchService branchService = new Biz_BranchService();

                dropDownListBranch.DataSource = branchService.ReadAllBranch();
                dropDownListBranch.DataValueField = "Id";
                dropDownListBranch.DataTextField = "Description";
                dropDownListBranch.DataBind();
                dropDownListBranch.SelectedIndex = 0;
            }
            catch (Exception exception)
            {

            }
        }

        public void DataBindTodropDownListProductCategory()
        {
            try
            {
                Biz_ProductCategoryService productCategoryService = new Biz_ProductCategoryService();

                dropDownListProductCategory.DataSource = productCategoryService.ReadAllProductCategory();
                dropDownListProductCategory.DataValueField = "Id";
                dropDownListProductCategory.DataTextField = "Description";
                dropDownListProductCategory.DataBind();
                dropDownListProductCategory.SelectedIndex = 0;
            }
            catch (Exception exception)
            {

            }
        }

        public void DataBindTodropDownListSubProductCat()
        {
            try
            {
                Biz_SubProductCategoryService subProductCategoryService = new Biz_SubProductCategoryService();

                dropDownListSubProductCat.DataSource = subProductCategoryService.ReadAllSubProductCategoryByProductId(Convert.ToInt16(dropDownListProductCategory.SelectedValue));
                dropDownListSubProductCat.DataValueField = "Id";
                dropDownListSubProductCat.DataTextField = "Description";
                dropDownListSubProductCat.DataBind();
                dropDownListSubProductCat.SelectedIndex = 0;
            }
            catch (Exception exception)
            {

            }
        }

        public void LoadUnmappedProductsRelevantToProCat()
        {
            try
            {
                Biz_BranchProductService branchProductService = new Biz_BranchProductService();
                Biz_GeneralProductService generalProductService = new Biz_GeneralProductService();

                if (dropDownListProductCategory.SelectedValue != "" && dropDownListBranch.SelectedValue == "" && dropDownListSubProductCat.SelectedValue == "")
                {
                    List<Biz_BranchProduct> BranchProductList = null;

                    gridViewAllProducts.DataSource = generalProductService.ReadGeneralProductByProductCat(
                        Convert.ToInt16(dropDownListProductCategory.SelectedValue));
                    gridViewAllProducts.DataBind(); ;

                    gridViewMappedProducts.DataSource = BranchProductList;
                    gridViewMappedProducts.DataBind();
                }
                if (dropDownListProductCategory.SelectedValue != "" && dropDownListSubProductCat.SelectedValue != "" && dropDownListBranch.SelectedValue == "")
                {
                    List<Biz_BranchProduct> BranchProductList = null;

                    gridViewAllProducts.DataSource = new Biz_GeneralProductService().ReadAllGeneralProductByProductCategoryAndSubProductCategory(
                        Convert.ToInt16(dropDownListProductCategory.SelectedValue),
                        Convert.ToInt16(dropDownListSubProductCat.SelectedValue));
                    gridViewAllProducts.DataBind();

                    gridViewMappedProducts.DataSource = BranchProductList;
                    gridViewMappedProducts.DataBind();
                }
                if (dropDownListBranch.SelectedValue != "" && dropDownListProductCategory.SelectedValue != "" && dropDownListSubProductCat.SelectedValue != "")
                {
                    gridViewAllProducts.DataSource = branchProductService.ReadUnmappedProductsRelevantToroCat(
                        Convert.ToInt16(dropDownListBranch.SelectedValue),
                        Convert.ToInt16(dropDownListProductCategory.SelectedValue),
                        Convert.ToInt16(dropDownListSubProductCat.SelectedValue));
                    gridViewAllProducts.DataBind();
                }

            }
            catch (Exception exception)
            {

            }
        }

        public void LoadMappedBranchProduct()
        {
            try
            {

                Biz_BranchProductService branchProductService = new Biz_BranchProductService();

                gridViewMappedProducts.DataSource = branchProductService.ReadMappedBranchProduct(
                    Convert.ToInt16(dropDownListBranch.SelectedValue),
                    Convert.ToInt16(dropDownListProductCategory.SelectedValue),
                    Convert.ToInt16(dropDownListSubProductCat.SelectedValue));
                gridViewMappedProducts.DataBind();
            }
            catch (Exception exception)
            {

            }
        }

        #endregion

        #region "Operations"

        public void AddBranchProduct()
        {
            try
            {
                Biz_BranchProductService branchProductService = new Biz_BranchProductService();
                Biz_BranchProduct branchProductNew = new Biz_BranchProduct();

                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewAllProducts.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            branchProductNew = new Biz_BranchProduct();
                            branchProductNew.IdBranch = Convert.ToInt16(dropDownListBranch.SelectedValue);
                            branchProductNew.IdProductCategory =
                                Convert.ToInt16(dropDownListProductCategory.SelectedValue);
                            branchProductNew.IdSubProductCategory =
                                Convert.ToInt16(dropDownListSubProductCat.SelectedValue);
                            //branchProductNew.BranchProductId = Convert.ToInt64(gridViewRow.Cells[1].Text);
                            branchProductNew.IdProduct = Convert.ToInt64(gridViewRow.Cells[1].Text);
                            branchProductNew.Auth_Status = "A";

                            //branchProducts.Add(branchProductNew);
                            branchProductService.CreateBranchProduct(branchProductNew);
                            FlashText1.Display("Record(s) Successfully Added.", "okmessage");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record(s) Adding Failed.", "errormessage");
            }
        }

        public void RemoveBranchProduct()
        {
            try
            {
                Biz_BranchProductService branchProductService = new Biz_BranchProductService();
                Biz_BranchProduct branchProductRemove = new Biz_BranchProduct();

                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewMappedProducts.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            branchProductRemove.Id = Convert.ToInt16(gridViewRow.Cells[1].Text.Trim());
                            branchProductService.RemoveBranchProduct(branchProductRemove.Id);
                            FlashText1.Display("Record(s) Successfully Removed.", "okmessage");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record(s) Removing Failed.", "errormessage");
            }
        }

        #endregion

        #region "Events"

        public void buttonAdd_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryBranchProductAdd())
            {
                AddBranchProduct();
                LoadMappedBranchProduct();
                LoadUnmappedProductsRelevantToProCat();
            }
        }

        public void buttonRemove_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryBranchProductRemove())
            {
                RemoveBranchProduct();
                LoadMappedBranchProduct();
                LoadUnmappedProductsRelevantToProCat();
            }
        }

        public void gridViewAllProducts_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewAllProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewAllProducts.PageIndex = e.NewPageIndex;
            LoadUnmappedProductsRelevantToProCat();
        }

        public void dropDownListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUnmappedProductsRelevantToProCat();
            LoadMappedBranchProduct();
        }

        public void dropDownListProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropDownListProductCategory.SelectedValue != "")
            {
                DataBindTodropDownListSubProductCat();
                LoadUnmappedProductsRelevantToProCat();
                LoadMappedBranchProduct();
            }
            if (dropDownListProductCategory.SelectedValue == "")
            {
                dropDownListSubProductCat.Items.Clear();
                dropDownListSubProductCat.Items.Add("-Select-");
                loadEmptyData();
            }
        }

        public void dropDownListSubProductCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUnmappedProductsRelevantToProCat();
            LoadMappedBranchProduct();
        }

        public void gridViewMappedProducts_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewMappedProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewMappedProducts.PageIndex = e.NewPageIndex;
            LoadMappedBranchProduct();
        }

        public void checkBoxHeader_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow gridViewRow in ((GridView)((CheckBox)sender).Parent.Parent.Parent.Parent).Rows)
            {
                ((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked = ((CheckBox)sender).Checked;
            }
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryBranchProductAdd()
        {

            if (dropDownListProductCategory.SelectedValue == string.Empty)
            {
                FlashText1.Display("Product Category not Selected.", "errormessage");
                return false;
            }
            if (dropDownListSubProductCat.SelectedValue == string.Empty)
            {
                FlashText1.Display("Sub Product Category not Selected.", "errormessage");
                return false;
            }
            if (dropDownListBranch.SelectedValue == string.Empty)
            {
                FlashText1.Display("Branch not Selected.", "errormessage");
                return false;
            }
            Boolean isSelect = false;
            foreach (GridViewRow gridViewRow in gridViewAllProducts.Rows)
            {
                if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                {
                    isSelect = true;
                    break;
                }
            }
            if (!isSelect)
            {
                FlashText1.Display("Product(s) not Selected.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryBranchProductRemove()
        {
            Boolean isSelect = false;
            foreach (GridViewRow gridViewRow in gridViewMappedProducts.Rows)
            {
                if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                {
                    isSelect = true;
                    break;
                }
            }
            if (!isSelect)
            {
                FlashText1.Display("Product(s) not Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion
    }
}