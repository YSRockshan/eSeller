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
    public partial class BzFlexerInventoryItem : System.Web.UI.Page
    {
        #region "Variables"

        public string brCode;
        public string prCode;
        public string itemCode;
        public long SelectItemId;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillData();
            }
        }

        #region "Load Data"

        public void FillData()
        {
            DataBindTodropDownListBranch();
            DataBindTodropDownListProductCategory();
            DataBindTogridViewInventoryItem();
        }

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

        public void DataBindTodropDownListProduct()
        {
            List<Biz_Product> products = new List<Biz_Product>();
            if (dropDownListBranch.SelectedIndex > 0)
            {
                products = new Biz_InventoryItemService().ReadProductByBranchId(Convert.ToInt16(dropDownListBranch.SelectedValue));
                if (dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCat.SelectedValue.Trim() != string.Empty)
                {
                    products = (from product in products
                                where
                                    product.IdProductCategory ==
                                    Convert.ToInt16(dropDownListProductCategory.SelectedValue) &&
                                    product.IdSubProductCategory ==
                                    Convert.ToInt16(dropDownListSubProductCat.SelectedValue)
                                select product).ToList();
                }

                DataLodingTodropDownListProduct(products);
            }
            else
            {
                CleardropDownListProduct();
            }
        }

        public void DataLodingTodropDownListProduct(List<Biz_Product> products)
        {
            dropDownListProduct.DataSource = products;
            dropDownListProduct.DataValueField = "Id";
            dropDownListProduct.DataTextField = "Description";
            dropDownListProduct.DataBind();
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

                if (dropDownListProductCategory.SelectedIndex > 0)
                {
                    dropDownListSubProductCat.DataSource = subProductCategoryService.ReadAllSubProductCategoryByProductId(Convert.ToInt16(dropDownListProductCategory.SelectedValue));
                    dropDownListSubProductCat.DataValueField = "Id";
                    dropDownListSubProductCat.DataTextField = "Description";
                    dropDownListSubProductCat.DataBind();
                }
                else
                {
                    CleardropDownListSubProductCat();
                }
            }
            catch (Exception exception)
            {

            }
        }

        public void DataBindTogridViewInventoryItem()
        {
            try
            {
                List<Biz_InventoryItem> inventoryItems = new List<Biz_InventoryItem>();
                inventoryItems = new Biz_InventoryItemService().ReadAllInventoryItems();
                if (dropDownListBranch.SelectedIndex > 0 && dropDownListProduct.SelectedValue.Trim() != string.Empty)
                {
                    inventoryItems = (from inventoryItem in inventoryItems
                                      where inventoryItem.IdBranch == Convert.ToInt16(dropDownListBranch.SelectedValue) &&
                                          inventoryItem.IdProduct == Convert.ToInt16(dropDownListProduct.SelectedValue)
                                      select inventoryItem).ToList();
                }
                else
                {
                    inventoryItems = null;
                }

                DataLodingTogridViewInventoryItem(inventoryItems);
            }
            catch (Exception exception)
            { }
        }

        public void DataLodingTogridViewInventoryItem(List<Biz_InventoryItem> inventoryItems)
        {
            gridViewInventoryItem.DataSource = inventoryItems;
            gridViewInventoryItem.DataBind();
        }

        public void CleardropDownListProduct()
        {
            dropDownListProduct.Items.Clear();
            dropDownListProduct.Items.Add("-Select-");
        }

        public void CleardropDownListSubProductCat()
        {
            dropDownListSubProductCat.Items.Clear();
            dropDownListSubProductCat.Items.Add("-Select-");
        }

        public void CleardropDownListBranch()
        {
            dropDownListBranch.Items.Clear();
            dropDownListBranch.Items.Add("-Select-");
        }

        public void CleardropDownListProductCategory()
        {
            dropDownListProductCategory.Items.Clear();
            dropDownListProductCategory.Items.Add("-Select-");
        }

        public void GetItemCodePart()
        {
            //if (dropDownListBranch.SelectedIndex > 0)
            //{
            //    brCode = new BranchService().GetBranchById(Convert.ToInt16(dropDownListBranch.SelectedValue)).Code.Trim();
            //}
            //else
            //{
            //    brCode = "";
            //}
            if (dropDownListProduct.SelectedValue.Trim() != string.Empty)
            {
                prCode =
                    new Biz_GeneralProductService().ReadProductById(Convert.ToInt16(dropDownListProduct.SelectedValue)).Code.
                        Trim();
            }
            else
            {
                prCode = "";
            }
            //textBoxItemCode.Text = brCode + "-" + prCode;
            textBoxItemCode.Text = prCode;
        }

        public void ClearData()
        {
            textBoxInventoryItemCode.Text = "";
            textBoxInventoryItemCode2.Text = "";
            textBoxMoreDetail.Text = "";
            textBoxMoreDetail2.Text = "";
            CleardropDownListBranch();
            CleardropDownListProduct();
            CleardropDownListProductCategory();
            CleardropDownListSubProductCat();
            DataBindTogridViewInventoryItem();
            gridViewInventoryItem.SelectedIndex = -1;
            accordionInputs.SelectedIndex = 0;
        }

        #endregion

        #region "Operations"

        public void AddInventoryItem()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_InventoryItemService inventoryItemService = new Biz_InventoryItemService();
                    Biz_InventoryItem inventoryItem = new Biz_InventoryItem();

                    inventoryItem.CodeInventoryItem = textBoxItemCode.Text.Trim() + "-" + textBoxInventoryItemCode.Text.Trim();
                    inventoryItem.Description = textBoxMoreDetail.Text.Trim();
                    inventoryItem.Status = "A";
                    inventoryItem.IdProduct = Convert.ToInt16(dropDownListProduct.SelectedValue);
                    inventoryItem.IdBranch = Convert.ToInt16(dropDownListBranch.SelectedValue);
                    //inventoryItem.BranchProduct = new BranchProductService().GetBranchProductByBranchIdAndProductId(
                    //    Convert.ToInt16(dropDownListBranch.SelectedValue),
                    //Convert.ToInt16(dropDownListProduct.SelectedValue));
                    inventoryItem.IdBranchproduct = Convert.ToInt16(
                        new Biz_BranchProductService().ReadBranchProductByBranchIdAndProductId(
                            Convert.ToInt16(dropDownListBranch.SelectedValue),
                            Convert.ToInt16(dropDownListProduct.SelectedValue)).Id);
                    inventoryItem.DateCreated = DateTime.Now;
                    inventoryItem.DateModified = DateTime.Now;
                    //inventoryItem.Branch = new BranchService().GetBranchById(Convert.ToInt16(dropDownListBranch.SelectedValue));

                    inventoryItemService.CreateInventoryItem(inventoryItem);

                }
                FlashText1.Display("Record Successfully saved.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Saving Failed.", "errormessage");
            }
        }

        public void ModifyInventoryItem()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_InventoryItemService inventoryItemService = new Biz_InventoryItemService();
                    Biz_InventoryItem inventoryItem = new Biz_InventoryItem();

                    inventoryItem.Id = Convert.ToInt16(ViewState["SelectItemId"]);
                    inventoryItem = inventoryItemService.ReadInventoryItemById(inventoryItem.Id);

                    inventoryItem.CodeInventoryItem = textBoxInventoryItemCode2.Text.Trim();
                    inventoryItem.Description = textBoxMoreDetail2.Text.Trim();
                    inventoryItem.IdProduct = Convert.ToInt16(dropDownListProduct.SelectedValue);
                    inventoryItem.IdBranch = Convert.ToInt16(dropDownListBranch.SelectedValue);
                    //inventoryItem.BranchProduct = new BranchProductService().GetBranchProductByBranchIdAndProductId(
                    //    Convert.ToInt16(dropDownListBranch.SelectedValue),
                    //Convert.ToInt16(dropDownListProduct.SelectedValue));
                    inventoryItem.IdBranchproduct = Convert.ToInt16(
                        new Biz_BranchProductService().ReadBranchProductByBranchIdAndProductId(
                            Convert.ToInt16(dropDownListBranch.SelectedValue),
                            Convert.ToInt16(dropDownListProduct.SelectedValue)).Id);
                    inventoryItem.DateModified = DateTime.Now;
                    //inventoryItem.Branch = new BranchService().GetBranchById(Convert.ToInt16(dropDownListBranch.SelectedValue));

                    inventoryItemService.UpdateInventoryItem(inventoryItem);
                }
                FlashText1.Display("Record Successfully Modified.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        public void DeleteInventoryItem()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_InventoryItemService inventoryItemService = new Biz_InventoryItemService();
                    inventoryItemService.DeleteInventoryItems(Convert.ToInt16(ViewState["SelectItemId"]));
                }
                FlashText1.Display("Record Successfully Deleted.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Deleting Failed.", "errormessage");
            }
        }


        #endregion

        #region "Events"

        public void dropDownListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleardropDownListProduct();
            DataBindTodropDownListProduct();
            DataBindTogridViewInventoryItem();
            GetItemCodePart();
        }

        public void dropDownListProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBindTodropDownListSubProductCat();
            CleardropDownListProduct();
            DataBindTodropDownListProduct();
            DataBindTogridViewInventoryItem();
            GetItemCodePart();
        }

        public void dropDownListSubProductCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleardropDownListProduct();
            DataBindTodropDownListProduct();
            DataBindTogridViewInventoryItem();
            GetItemCodePart();
        }

        public void dropDownListProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBindTogridViewInventoryItem();
            GetItemCodePart();
        }

        public void gridViewInventoryItem_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewInventoryItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewInventoryItem.SelectedRow;

            ViewState["SelectItemId"] = row.Cells[1].Text.Trim();

            textBoxInventoryItemCode2.Text = row.Cells[2].Text.Trim();
            textBoxMoreDetail2.Text =
                new Biz_InventoryItemService().ReadInventoryItemById(Convert.ToInt16(ViewState["SelectItemId"])).Description.Trim();
            accordionInputs.SelectedIndex = 1;
        }

        public void gridViewInventoryItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewInventoryItem.PageIndex = e.NewPageIndex;
            DataBindTogridViewInventoryItem();
        }

        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldAdd())
            {
                AddInventoryItem();
                textBoxInventoryItemCode.Text = "";
                textBoxMoreDetail.Text = "";
                DataBindTogridViewInventoryItem();
                //ClearData();
                //FillData();
            }
        }

        public void buttonModify_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldModify())
            {
                ModifyInventoryItem();
                //ClearData();
                FillData();
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldDelete())
            {
                DeleteInventoryItem();
                //ClearData();
                FillData();
            }
        }

        public void buttonCancel1_Click(object sender, EventArgs e)
        {
            ClearData();
            FillData();
        }

        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            ClearData();
            FillData();
        }

        #endregion

        #region "Validation"

        private Boolean CheckMandatoryFieldAdd()
        {
            if (dropDownListBranch.SelectedIndex < 1)
            {
                FlashText1.Display("Branch is not Selected.", "errormessage");
                return false;
            }

            if (dropDownListProduct.SelectedValue.Trim() == string.Empty)
            {
                FlashText1.Display("Product is not Selected.", "errormessage");
                return false;
            }

            if (textBoxInventoryItemCode.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Invalid Item Code.", "errormessage");
                return false;
            }

            if (textBoxInventoryItemCode.Text.Trim() != string.Empty)
            {
                Biz_InventoryItemService inventoryItemService = new Biz_InventoryItemService();
                List<Biz_InventoryItem> inventoryItemList = new List<Biz_InventoryItem>();

                itemCode = textBoxItemCode.Text.Trim() + "-" + textBoxInventoryItemCode.Text.Trim();

                inventoryItemList = inventoryItemService.ReadInventoryItmByCode(itemCode.Trim());
                if (inventoryItemList.Count > 0)
                {
                    FlashText1.Display("Record Already Exists.", "errormessage");
                    return false;
                }
            }
            return true;
        }

        private Boolean CheckMandatoryFieldModify()
        {
            if (ViewState["SelectItemId"] == null)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }

            if (dropDownListBranch.SelectedIndex < 1)
            {
                FlashText1.Display("Branch is not Selected.", "errormessage");
                return false;
            }

            if (dropDownListProduct.SelectedValue.Trim() == string.Empty)
            {
                FlashText1.Display("Product is not Selected.", "errormessage");
                return false;
            }

            if (textBoxInventoryItemCode2.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Invalid Item Code.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryFieldDelete()
        {
            if (ViewState["SelectItemId"] == null)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion
    }
}