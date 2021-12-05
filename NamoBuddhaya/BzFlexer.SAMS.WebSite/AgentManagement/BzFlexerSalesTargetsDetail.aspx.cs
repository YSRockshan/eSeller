using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Service.AgentManagement;
using BzFlexer.SAMS.Service.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebView.AgentManagement
{
    public partial class BzFlexerSalesTargetsDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindTodropDownListBranch();
                DataBindTodropDownListSalesTarget();
                DataBindTodropDownListProductCategory();
                DataBindTodropDownListProduct();
                DataBindToDataGrids();
            }
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
            }
            catch (Exception exception)
            { }
        }

        public void DataBindTodropDownListSalesTarget()
        {
            try
            {
                Biz_SalesTargetService salesTargetService = new Biz_SalesTargetService();
                dropDownListSalesTarget.DataSource = salesTargetService.ReadAllSalesTargets();
                dropDownListSalesTarget.DataValueField = "Id";
                dropDownListSalesTarget.DataTextField = "Description";
                dropDownListSalesTarget.DataBind();
            }
            catch (Exception exception)
            { }
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
            }
            catch (Exception exception)
            { }
        }

        public void DataBindTodropDownListSubProductCategory()
        {
            try
            {
                Biz_SubProductCategoryService subProductCategoryService = new Biz_SubProductCategoryService();
                if (dropDownListProductCategory.SelectedValue != "")
                {
                    dropDownListSubProductCategory.DataSource =
                        subProductCategoryService.ReadAllSubProductCategoryByProductId(Convert.ToInt16(dropDownListProductCategory.SelectedValue));
                    dropDownListSubProductCategory.DataValueField = "Id";
                    dropDownListSubProductCategory.DataTextField = "Description";
                    dropDownListSubProductCategory.DataBind();
                }
            }
            catch (Exception exception)
            { }
        }

        public void DataBindTodropDownListProduct()
        {
            try
            {
                Biz_GeneralProductService generalProductService = new Biz_GeneralProductService();
                List<Biz_Product> products = new List<Biz_Product>();

                if (dropDownListBranch.SelectedIndex > 0)
                {
                    products = new Biz_SalesTargetDetailsService().ReadProductsByBranch(Convert.ToInt16(dropDownListBranch.SelectedValue));
                    if (dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCategory.SelectedIndex == 0)
                    {
                        products = (from product in products
                                    where
                                        product.IdProductCategory ==
                                        Convert.ToInt16(dropDownListProductCategory.SelectedValue)
                                    select product).ToList();
                    }
                    if (dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCategory.SelectedIndex > 0)
                    {
                        products = (from product in products
                                    where
                                        product.IdProductCategory ==
                                        Convert.ToInt16(dropDownListProductCategory.SelectedValue) && product.IdSubProductCategory == Convert.ToInt16(dropDownListSubProductCategory.SelectedValue)
                                    select product).ToList();
                    }

                    dropDownListProduct.DataSource = products;
                    dropDownListProduct.DataTextField = "Description";
                    dropDownListProduct.DataValueField = "Id";
                    dropDownListProduct.DataBind();
                }
                else
                {
                    CleardropDownListProduct();
                }
            }
            catch (Exception exception)
            {

            }
        }

        public void CleardropDownListSubProductCategory()
        {
            dropDownListSubProductCategory.Items.Clear();
            dropDownListSubProductCategory.Items.Add("-Select-");
        }

        public void CleardropDownListProduct()
        {
            dropDownListProduct.Items.Clear();
            dropDownListProduct.Items.Add("-Select-");
        }

        public void CleargridViewAllInventoryItems()
        {
            gridViewAllInventoryItems.DataSource = null;
            gridViewAllInventoryItems.DataBind();
        }

        public void CleargridViewMappedInventoryItem()
        {
            gridViewMappedInventoryItem.DataSource = null;
            gridViewMappedInventoryItem.DataBind();
        }

        public void DataBindToDataGrids()
        {
            Biz_SalesTargetDetailsService salesTargetDetailService = new Biz_SalesTargetDetailsService();
            List<Biz_InventoryItem> inventoryItems = new List<Biz_InventoryItem>();

            if (dropDownListBranch.SelectedIndex > 0 && dropDownListSalesTarget.SelectedIndex > 0 && dropDownListProduct.SelectedIndex > 0)
            {
                inventoryItems = salesTargetDetailService.ReadUnmappedItemBybranchIdsalesTargetIdAndProductId(Convert.ToInt16(dropDownListBranch.SelectedValue), Convert.ToInt16(dropDownListSalesTarget.SelectedValue), Convert.ToInt16(dropDownListProduct.SelectedValue));
                //    if (dropDownListProductCategory.SelectedIndex > 0)
                //    {
                //        products = (from prd in products where prd.ProductCategoryId == Convert.ToInt16(dropDownListProductCategory.SelectedValue) select prd).ToList();
                //    }
                //    if (dropDownListSubProductCategory.SelectedIndex > 0)
                //    {
                //        products = (from prd in products where prd.SubProductCategoryId == Convert.ToInt16(dropDownListSubProductCategory.SelectedValue) select prd).ToList();
                //    }
                DataBindTogridViewMappedInventoryItem();
                DataBindgridViewAllInventoryItems(inventoryItems);
            }
            else
            {
                CleargridViewAllInventoryItems();
                CleargridViewMappedInventoryItem();
            }
        }

        public void DataBindgridViewAllInventoryItems(List<Biz_InventoryItem> inventoryItems)
        {
            gridViewAllInventoryItems.DataSource = inventoryItems;
            gridViewAllInventoryItems.DataBind();
        }

        public void DataBindTogridViewMappedInventoryItem()
        {
            try
            {
                Biz_SalesTargetDetailsService salesTargetetailService = new Biz_SalesTargetDetailsService();
                List<Biz_SalesTargetDetail> salesTargetDetails = new List<Biz_SalesTargetDetail>();
                salesTargetDetails = salesTargetetailService.ReadSalesTargetByBranchAndTarget(
                        Convert.ToInt16(dropDownListBranch.SelectedValue),
                        Convert.ToInt16(dropDownListSalesTarget.SelectedValue));

                if (dropDownListProduct.SelectedIndex > 0)
                {
                    salesTargetDetails = (from salesTargetDetail in salesTargetDetails
                                          where
                                              salesTargetDetail.Biz_InventoryItems.IdProduct ==
                                              Convert.ToInt16(dropDownListProduct.SelectedValue)
                                          select salesTargetDetail).ToList();
                }

                //if (dropDownListProductCategory.SelectedIndex > 0)
                //{
                //    salesTargetDetails = (from salesTargetDet in salesTargetDetails where salesTargetDet.InventoryItem.Product.ProductCategoryId == Convert.ToInt16(dropDownListProductCategory.SelectedValue) select salesTargetDet).ToList();
                //}
                //if (dropDownListSubProductCategory.SelectedIndex > 0)
                //{
                //    salesTargetDetails = (from salesTargetDet in salesTargetDetails where salesTargetDet.InventoryItem.Product.SubProductCategoryId == Convert.ToInt16(dropDownListSubProductCategory.SelectedValue) select salesTargetDet).ToList();
                //}

                gridViewMappedInventoryItem.DataSource = salesTargetDetails;
                gridViewMappedInventoryItem.DataBind();
                SelectUnitofMeasureValue();
            }
            catch (Exception exception)
            { }
        }

        public void SelectUnitofMeasureValue()
        {
            try
            {
                for (int i = 0; i < gridViewMappedInventoryItem.Rows.Count + 1; i++)
                {
                    Biz_SalesTargetDetail salesTargetDetail = new Biz_SalesTargetDetail();
                    salesTargetDetail =
                        new Biz_SalesTargetDetailsService().ReadSalesTargetDetailById(Convert.ToInt16(gridViewMappedInventoryItem.Rows[i].Cells[1].Text.Trim()));
                    var unitofmeasureId = salesTargetDetail.IdUnitOfMeasure;

                    DropDownList downList;
                    downList = (DropDownList)
                                gridViewMappedInventoryItem.Rows[i].Cells[3].FindControl("dropDownListType");
                    downList.SelectedValue = "Q";

                    if (downList.SelectedValue == "Q")
                    {
                        downList =
                            (DropDownList)
                            gridViewMappedInventoryItem.Rows[i].Cells[6].FindControl(
                                "dropDownListUnitOfMeasure");

                        downList.SelectedValue = unitofmeasureId.ToString();
                    }
                }
            }
            catch (Exception exception)
            { }
        }

        #endregion

        #region "Operations"

        public void AddSalesTargetDetail()
        {
            try
            {
                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewAllInventoryItems.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            Biz_SalesTargetDetailsService salesTargetDetailService = new Biz_SalesTargetDetailsService();
                            Biz_SalesTargetDetail salesTargetDetail = new Biz_SalesTargetDetail();

                            salesTargetDetail.IdBranch = Convert.ToInt16(dropDownListBranch.SelectedValue);
                            salesTargetDetail.IdSalesTarget = Convert.ToInt16(dropDownListSalesTarget.SelectedValue);
                            salesTargetDetail.IdInventoryItem = Convert.ToInt16(gridViewRow.Cells[1].Text.Trim());
                            salesTargetDetail.Type = "Q";
                            salesTargetDetail.Quantity = 1;

                            Biz_InventoryItem inventoryItem = new Biz_InventoryItem();
                            inventoryItem = new Biz_InventoryItemService().ReadInventoryItemById(salesTargetDetail.IdInventoryItem);
                            Biz_PriceBookDetail priceBookDetail = new Biz_PriceBookDetail();
                            List<Biz_PriceBookDetail> priceBookDetails = new List<Biz_PriceBookDetail>();
                            priceBookDetails = new Biz_PriceBookDetailsService().ReadAllPriceBookDetails();
                            priceBookDetails =
                                (from bookDetail in priceBookDetails
                                 where bookDetail.IdProduct == inventoryItem.IdProduct
                                 select bookDetail).ToList();
                            priceBookDetail = priceBookDetails.FirstOrDefault();

                            salesTargetDetail.IdUnitOfMeasure = priceBookDetail.IdUnitOfMeasure;
                            salesTargetDetail.Value = priceBookDetail.PricePer_Unit;
                            salesTargetDetail.DateCreated = DateTime.Now;
                            salesTargetDetail.DateModified = DateTime.Now;

                            salesTargetDetailService.CreateSalesTargetDetail(salesTargetDetail);

                           FlashText1.Display("Record(s) Successfully Added.", "okmessage");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record(s) Adding Failed.", "okmessage");
            }
        }

        public void ModifySalesTargetDetail()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_SalesTargetDetailsService salesTargetDetailService = new Biz_SalesTargetDetailsService();
                    Biz_SalesTargetDetail salesTargetDetail = new Biz_SalesTargetDetail();
                    DropDownList downList;
                    TextBox textBox;
                    Label label;
                    for (int i = 0; i < gridViewMappedInventoryItem.Rows.Count; i++)
                    {

                        salesTargetDetail =
                            salesTargetDetailService.ReadSalesTargetDetailById(Convert.ToInt16(gridViewMappedInventoryItem.Rows[i].Cells[1].Text.Trim()));
                        salesTargetDetail.Id =
                            Convert.ToInt16(gridViewMappedInventoryItem.Rows[i].Cells[1].Text.Trim());
                        if (dropDownListSalesTarget.SelectedIndex > 0)
                        {
                            salesTargetDetail.IdSalesTarget = Convert.ToInt16(dropDownListSalesTarget.SelectedValue);
                        }
                        if (dropDownListBranch.SelectedIndex > 0)
                        {
                            salesTargetDetail.IdBranch = Convert.ToInt16(dropDownListBranch.SelectedValue);
                        }
                        label = (Label)gridViewMappedInventoryItem.Rows[i].Cells[7].FindControl("LabelProductId");
                        if (label != null)
                        {
                            if (label.Text != String.Empty)
                            {
                                salesTargetDetail.IdInventoryItem = Convert.ToInt16((label.Text.Trim()));
                            }
                        }

                        downList = (DropDownList)gridViewMappedInventoryItem.Rows[i].Cells[3].FindControl("dropDownListType");
                        if (downList.SelectedIndex > 0)
                        {
                            salesTargetDetail.Type = downList.SelectedValue;
                            if (downList.SelectedValue == "V")
                            {
                                textBox = (TextBox)gridViewMappedInventoryItem.Rows[i].Cells[4].FindControl("textBoxValue");
                                if (textBox != null)
                                {
                                    if (textBox.Text != string.Empty && textBox.Text.Trim() != "0")
                                    {
                                        salesTargetDetail.Value = Convert.ToDecimal(textBox.Text);
                                    }
                                }
                            }
                            if (downList.SelectedValue == "Q")
                            {
                                textBox = (TextBox)gridViewMappedInventoryItem.Rows[i].Cells[5].FindControl("textBoxQuantity");
                                if (textBox != null)
                                {
                                    if (textBox.Text != string.Empty && textBox.Text.Trim() != "0")
                                    {
                                        salesTargetDetail.Value = (salesTargetDetail.Value / Convert.ToDecimal(salesTargetDetail.Quantity)) * Convert.ToDecimal(textBox.Text);

                                        salesTargetDetail.Quantity = Convert.ToDecimal(textBox.Text);
                                    }
                                }

                                downList =
                                    (DropDownList)
                                    gridViewMappedInventoryItem.Rows[i].Cells[6].FindControl("dropDownListUnitOfMeasure");
                                if (downList != null)
                                {
                                    if (downList.SelectedIndex > 0)
                                    {
                                        salesTargetDetail.IdUnitOfMeasure = Convert.ToInt16(downList.SelectedValue);
                                    }
                                }
                            }
                        }

                        salesTargetDetail.DateModified = DateTime.Now;
                        salesTargetDetailService.UpdateSalesTargetDetail(salesTargetDetail);
                    }
                   FlashText1.Display("Record(s) Successfully Saved.", "okmessage");
                }

            }
            catch (Exception exception)
            {
               FlashText1.Display("Record(s) Saving Failed.", "errormessage");
            }
        }

        public void RemoveSalesTargetDetails()
        {
            try
            {
                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewMappedInventoryItem.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            Biz_SalesTargetDetailsService salesTargetDetailService = new Biz_SalesTargetDetailsService();
                            salesTargetDetailService.DeleteSalesTargetDetails(Convert.ToInt16(gridViewRow.Cells[1].Text.Trim()));
                           FlashText1.Display("Record(s) Successfully Deleted.", "okmessage");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record(s) Deleting Failed.", "errormessage");
            }
        }

        #endregion

        #region "Events"

        public void dropDownListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleardropDownListProduct();
            DataBindTodropDownListProduct();
            DataBindToDataGrids();
        }

        public void dropDownListSalesTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBindToDataGrids();
        }

        public void dropDownListProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleardropDownListSubProductCategory();
            DataBindTodropDownListSubProductCategory();
            CleardropDownListProduct();
            DataBindTodropDownListProduct();
            //DataBindToDataGrids();
        }

        public void dropDownListSubProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleardropDownListProduct();
            DataBindTodropDownListProduct();
        }

        public void dropDownListProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBindToDataGrids();
        }

        public void gridViewAllInventoryItems_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewMappedInventoryItem_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[7].Visible = false;
            }
        }

        public void gridViewAllInventoryItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataBindToDataGrids();
            gridViewAllInventoryItems.PageIndex = e.NewPageIndex;
            gridViewAllInventoryItems.DataBind();
        }

        public void gridViewMappedInventoryItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataBindToDataGrids();
            gridViewMappedInventoryItem.PageIndex = e.NewPageIndex;
            gridViewMappedInventoryItem.DataBind();
        }

        public void checkBoxHeader_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow gridViewRow in ((GridView)((CheckBox)sender).Parent.Parent.Parent.Parent).Rows)
            {
                ((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked = ((CheckBox)sender).Checked;
            }
        }

        public void buttonAdd_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldAdd())
            {
                AddSalesTargetDetail();
                DataBindToDataGrids();
            }
        }

        public void buttonRemove_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldRemove())
            {
                RemoveSalesTargetDetails();
                DataBindToDataGrids();
            }
        }

        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldModify())
            {
                ModifySalesTargetDetail();
                DataBindToDataGrids();
            }
        }

        public void dropDownListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox textBox;
            TextBox textBoxnull;
            DropDownList downList = (DropDownList)sender;
            GridViewRow gridViewRow = (GridViewRow)(((DropDownList)sender).Parent.Parent);

            textBox = (TextBox)gridViewRow.Cells[4].FindControl("textBoxValue");
            if (textBox != null)
            {
                textBox.Enabled = false;
            }
            textBox = (TextBox)gridViewRow.Cells[5].FindControl("textBoxQuantity");
            if (textBox != null)
            {
                textBox.Enabled = false;
            }
            DropDownList downListUOM;
            downListUOM = (DropDownList)gridViewRow.Cells[6].FindControl("dropDownListUnitOfMeasure");
            if (downListUOM != null)
            {
                downListUOM.Enabled = false;
            }
            if (downList.SelectedValue == "V")
            {
                textBoxnull = (TextBox)gridViewRow.Cells[5].FindControl("textBoxQuantity");
                textBoxnull.Text = string.Empty;
                downListUOM.SelectedIndex = 0;
                textBox = (TextBox)gridViewRow.Cells[4].FindControl("textBoxValue");
                if (textBox != null)
                {
                    textBox.Enabled = true;
                }

            }
            if (downList.SelectedValue == "Q")
            {
                textBoxnull = (TextBox)gridViewRow.Cells[4].FindControl("textBoxValue");
                textBoxnull.Text = string.Empty;
                textBox = (TextBox)gridViewRow.Cells[5].FindControl("textBoxQuantity");
                if (textBox != null)
                {
                    textBox.Enabled = true;
                }
                downListUOM = (DropDownList)gridViewRow.Cells[6].FindControl("dropDownListUnitOfMeasure");
                if (downListUOM != null)
                {
                    downListUOM.Enabled = true;
                }
            }
        }

        public void TextBox_TextChange(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text != String.Empty)
            {
                textBox.Text = String.Format("{0:0.00}", textBox.Text);
            }

        }

        public void gridViewMappedInventoryItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((TextBox)e.Row.Cells[4].FindControl("textBoxValue")).Attributes.Add("style", "text-align:right");
                ((TextBox)e.Row.Cells[4].FindControl("textBoxValue")).Attributes.Add("onkeypress", "javascript:return handleNumbersOnly(event,this)");
                ((TextBox)e.Row.Cells[5].FindControl("textBoxQuantity")).Attributes.Add("style", "text-align:right");
                ((TextBox)e.Row.Cells[5].FindControl("textBoxQuantity")).Attributes.Add("onkeypress", "javascript:return handleNumbersOnly(event,this)");
            }
            foreach (GridViewRow gridViewRow in gridViewMappedInventoryItem.Rows)
            {
                DropDownList downList =
                    ((DropDownList)gridViewRow.Cells[6].FindControl("DropDownListUnitOfMeasure"));
                if (downList != null)
                {
                    Biz_UnitOfMeasureService unitOfMeasureService = new Biz_UnitOfMeasureService();
                    downList.DataSource = unitOfMeasureService.ReadAllUnitOfMeasure();
                    downList.DataValueField = "Id";
                    downList.DataTextField = "Description";
                    downList.DataBind();
                }
            }

        }


        #endregion

        #region "Validations"

        private Boolean CheckMandatoryFieldAdd()
        {
            if (dropDownListBranch.SelectedValue == string.Empty)
            {
               FlashText1.Display("Branch is not Selected.", "errormessage");
                return false;
            }
            if (dropDownListSalesTarget.SelectedValue == string.Empty)
            {
               FlashText1.Display("Sales Target is not Selected.", "errormessage");
                return false;
            }

            Boolean isSelect = false;
            foreach (GridViewRow gridViewRow in gridViewAllInventoryItems.Rows)
            {
                if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                {
                    isSelect = true;
                    break;
                }
            }
            if (!isSelect)
            {
               FlashText1.Display("Item(s) not Selected.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryFieldModify()
        {
            Biz_SalesTargetDetail salesTargetDetail = new Biz_SalesTargetDetail();
            DropDownList downList;
            TextBox textBox;

            for (int i = 0; i < gridViewMappedInventoryItem.Rows.Count; i++)
            {
                downList = (DropDownList)gridViewMappedInventoryItem.Rows[i].Cells[3].FindControl("dropDownListType");
                if (downList.SelectedIndex > 0)
                {
                    salesTargetDetail.Type = downList.SelectedValue;
                    if (downList.SelectedValue == "V")
                    {
                        textBox = (TextBox)gridViewMappedInventoryItem.Rows[i].Cells[4].FindControl("textBoxValue");
                        if (textBox.Text == string.Empty || textBox.Text.Trim() == "0")
                        {
                           FlashText1.Display("Value Cannot be Blank.", "errormessage");
                            return false;
                        }
                    }
                    if (downList.SelectedValue == "Q")
                    {
                        textBox = (TextBox)gridViewMappedInventoryItem.Rows[i].Cells[5].FindControl("textBoxQuantity");
                        if (textBox.Text == string.Empty || textBox.Text.Trim() == "0")
                        {
                           FlashText1.Display("Quantity Cannot be Blank.", "errormessage");
                            return false;
                        }

                        downList =
                            (DropDownList)
                            gridViewMappedInventoryItem.Rows[i].Cells[6].FindControl("dropDownListUnitOfMeasure");
                        if (downList != null)
                        {
                            if (downList.SelectedIndex < 1)
                            {
                               FlashText1.Display("No Unit of Measure is Selected.", "errormessage");
                                return false;
                            }
                        }
                    }
                }
                if (downList.SelectedIndex < 1)
                {
                   FlashText1.Display("No Type is Selected.", "errormessage");
                    return false;
                }
            }
            return true;
        }

        private Boolean CheckMandatoryFieldRemove()
        {
            Boolean isSelect = false;

            foreach (GridViewRow gridViewRow in gridViewMappedInventoryItem.Rows)
            {
                if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                {
                    isSelect = true;
                    break;
                }
            }
            if (!isSelect)
            {
               FlashText1.Display("Item(s) not Selected.", "errormessage");
                return false;
            }

            return true;
        }


        #endregion

    }
}