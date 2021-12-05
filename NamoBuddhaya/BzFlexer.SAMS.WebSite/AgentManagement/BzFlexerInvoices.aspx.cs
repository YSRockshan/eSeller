using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Service.AgentManagement;
using BzFlexer.SAMS.Service.Reference;
using BzFlexer.SAMS.WebView.Home;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebView.AgentManagement
{
    public partial class BzFlexerInvoices : System.Web.UI.Page
    {
        int x = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["InvoiceDetail"] = null;
                LoadData();
                DisableButtons();
            }
        }

        #region "Load Data"

        public void LoadData()
        {
            try
            {
                textBoxTransactionDate.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" +
                                              DateTime.Now.Year.ToString();

                DataBindToDropDownListTransactionNumber();
                DataBindTodropDownListBranch();
                if (Session[Global.BizCurrentBranchId] != null)
                {
                    dropDownListBranch.SelectedValue = Convert.ToInt16(Session[Global.BizCurrentBranchId]).ToString();
                    //dropDownListBranch.Enabled = false;
                    textBoxBranch.Text = new Biz_BranchService().ReadBranchById(Convert.ToInt16(Session[Global.BizCurrentBranchId])).Code;
                    textBoxBranch.Enabled = false;
                }
                DataBindToDropDownListSalesPerson();
                DataBindToDropDownListPriceBook();
                GetDataTodropDownListProduct();
                DataBindToDropDownListSalesTarget();
                DataBindToDropDownListUnitOfMeasure();
                CleargridViewInvoice();
            }
            catch (Exception)
            { }
        }

        public void DataBindToDropDownListTransactionNumber()
        {
            Biz_SalesTransactionService salesTransactionService = new Biz_SalesTransactionService();
            DropDownListTransactionNumber.DataSource = salesTransactionService.ReadAllSalesTransactions();
            DropDownListTransactionNumber.DataValueField = "Id";
            DropDownListTransactionNumber.DataTextField = "Invoice_No";
            DropDownListTransactionNumber.DataBind();
        }

        public void DataBindTodropDownListBranch()
        {
            Biz_BranchService branchService = new Biz_BranchService();

            dropDownListBranch.DataSource = branchService.ReadAllBranch();
            dropDownListBranch.DataValueField = "Id";
            dropDownListBranch.DataTextField = "Description";
            dropDownListBranch.DataBind();
        }

        public void DataBindToDropDownListSalesPerson()
        {
            Biz_BranchSalesAgentService branchSelesRepService = new Biz_BranchSalesAgentService();
            List<Biz_Stakeholder> branchSelesAgentList = new List<Biz_Stakeholder>();

            branchSelesAgentList = branchSelesRepService.ReadBranchSalesAgentsByBranchWise(Convert.ToInt16(dropDownListBranch.SelectedValue));
            DropDownListSalesPerson.DataSource = branchSelesAgentList;
            DropDownListSalesPerson.DataTextField = "FullName";
            DropDownListSalesPerson.DataValueField = "Id";
            DropDownListSalesPerson.DataBind();

            DropDownListSalesPerson.SelectedValue = Session[Global.BizLoginUserStakeholderId].ToString();
        }

        public void DataBindToDropDownListPriceBook()
        {
            Biz_BranchPriceBookService branchPriceBookService = new Biz_BranchPriceBookService();
            List<Biz_PriceBook> priceBooks = new List<Biz_PriceBook>();
            priceBooks = branchPriceBookService.ReadBranchWisePriceBook(Convert.ToInt16(dropDownListBranch.SelectedValue));
            DropDownListPriceBook.DataSource = priceBooks;
            DropDownListPriceBook.DataTextField = "Description";
            DropDownListPriceBook.DataValueField = "Id";
            DropDownListPriceBook.DataBind();
        }

        public void DataBindTodropDownListProductCategory()
        {
            Biz_ProductCategoryService productCategoryService = new Biz_ProductCategoryService();

            dropDownListProductCategory.DataSource = productCategoryService.ReadAllProductCategory();
            dropDownListProductCategory.DataTextField = "Description";
            dropDownListProductCategory.DataValueField = "Id";
            dropDownListProductCategory.DataBind();
        }

        public void DataBindToDropDownListSalesTarget()
        {
            List<Biz_SalesTarget> salesTargets = new List<Biz_SalesTarget>();
            salesTargets = new Biz_SalesTargetService().ReadAllSalesTargets();

            DropDownListSalesTarget.DataSource = salesTargets;
            DropDownListSalesTarget.DataTextField = "Description";
            DropDownListSalesTarget.DataValueField = "Id";
            DropDownListSalesTarget.DataBind();
        }

        public void DataBindToDropDownListUnitOfMeasure()
        {
            DropDownListUnitOfMeasure.DataSource = new Biz_UnitOfMeasureService().ReadAllUnitOfMeasure();
            DropDownListUnitOfMeasure.DataValueField = "Id";
            DropDownListUnitOfMeasure.DataTextField = "Description";
            DropDownListUnitOfMeasure.DataBind();
        }

        public void DataBindTodropDownListSubProductCategory()
        {
            Biz_SubProductCategoryService subProductCategoryService = new Biz_SubProductCategoryService();
            List<Biz_SubProductCategory> subProductCategories = new List<Biz_SubProductCategory>();
            subProductCategories = subProductCategoryService.ReadAllSubProductCategory();
            if (dropDownListProductCategory.SelectedIndex > 0)
            {
                subProductCategories = (from subprocat in subProductCategories
                                        where
                                            subprocat.IdProductCategory ==
                                            Convert.ToInt16(dropDownListProductCategory.SelectedValue)
                                        select subprocat).ToList();
                GetdropDownListSubProductCategory(subProductCategories);
            }
            else
            {
                CleardropDownListSubProductCategory();
            }
        }

        public void GetdropDownListSubProductCategory(List<Biz_SubProductCategory> subProductCategories)
        {
            dropDownListSubProductCategory.DataSource = subProductCategories;
            dropDownListSubProductCategory.DataTextField = "Description";
            dropDownListSubProductCategory.DataValueField = "Id";
            dropDownListSubProductCategory.DataBind();
        }

        public void GetDataTodropDownListProduct()
        {
            Biz_GeneralProductService generalProductService = new Biz_GeneralProductService();
            List<Biz_Product> products = new List<Biz_Product>();

            products = new Biz_InventoryItemService().ReadProductByBranchId(Convert.ToInt16(dropDownListBranch.SelectedValue));

            if (dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCategory.SelectedIndex < 1)
            {
                products = generalProductService.ReadGeneralProductByProductCat(Convert.ToInt16(dropDownListProductCategory.SelectedValue));
            }
            if (dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCategory.SelectedIndex > 0)
            {
                products = generalProductService.ReadAllGeneralProductByProductCategoryAndSubProductCategory(Convert.ToInt16(dropDownListProductCategory.SelectedValue), Convert.ToInt16(dropDownListSubProductCategory.SelectedValue));
            }
            //else if (dropDownListProductCategory.SelectedIndex < 1 && dropDownListSubProductCategory.SelectedIndex < 1)
            //{
            //    products = generalProductService.GetAllProduct();
            //}

            if (products != null)
            {
                CleardropDownListProduct();
                DataBindTodropDownListProduct(products);
            }
            else
            {
                CleardropDownListProduct();
            }
        }

        public void DataBindTodropDownListProduct(List<Biz_Product> products)
        {
            DropDownListProduct.DataSource = products;
            DropDownListProduct.DataValueField = "Id";
            DropDownListProduct.DataTextField = "Description";
            DropDownListProduct.DataBind();
        }

        public void GetProductDiscount()
        {
            List<Biz_PriceBookDetail> priceBookDetails = new List<Biz_PriceBookDetail>();
            priceBookDetails = new Biz_PriceBookDetailsService().ReadAllPriceBookDetails();

            if (DropDownListProduct.SelectedIndex > 0)
            {
                priceBookDetails = (from priceBookDetail in priceBookDetails
                                    where
                                        priceBookDetail.IdPriceBook == Convert.ToInt16(DropDownListProduct.SelectedValue)
                                    select priceBookDetail).ToList();
                foreach (Biz_PriceBookDetail priceBookDetail in priceBookDetails)
                {
                    textBoxPricePerUnit.Text = priceBookDetail.PricePer_Unit.ToString();
                    textBoxDiscountRate.Text = priceBookDetail.Discount_Rate.ToString();
                    textBoxDiscountValue.Text =
                        (Convert.ToDecimal(textBoxPricePerUnit.Text) * priceBookDetail.Discount_Rate / 100).
                            ToString();
                }
            }
            else
            {
                textBoxPricePerUnit.Text = Convert.ToDecimal(0).ToString();
                textBoxDiscountRate.Text = Convert.ToDecimal(0).ToString();
                textBoxDiscountValue.Text = Convert.ToDecimal(0).ToString();
            }
        }

        public void DataBindToDropDownListItem(List<Biz_InventoryItem> inventoryItems)
        {
            DropDownListItem.DataSource = inventoryItems;
            DropDownListItem.DataTextField = "CodeInventoryItem";
            DropDownListItem.DataValueField = "Id";
            DropDownListItem.DataBind();
        }

        public void GetDataToDropDownListItem()
        {
            if (DropDownListProduct.SelectedIndex > 0)
            {
                if (Session["InvoiceDetail"] == null)
                {
                    List<Biz_InventoryItem> inventoryItems = new List<Biz_InventoryItem>();
                    inventoryItems = new Biz_InventoryItemService().ReadAllInventoryItems();
                    inventoryItems = (from inventoryItem in inventoryItems
                                      where inventoryItem.IdProduct ==
                                            Convert.ToInt16(DropDownListProduct.SelectedValue)
                                            && inventoryItem.Status.Trim() == "A"
                                      select inventoryItem).ToList();
                    DataBindToDropDownListItem(inventoryItems);

                }
                else
                {
                    List<Biz_Invoice> mapInvoice = (List<Biz_Invoice>)Session["InvoiceDetail"];
                    List<long> mapId = (from id in mapInvoice select id.IdItem).ToList();

                    List<Biz_InventoryItem> inventoryItems = new List<Biz_InventoryItem>();
                    inventoryItems = new Biz_InventoryItemService().ReadAllInventoryItems();
                    inventoryItems = (from inventoryItem in inventoryItems
                                      where inventoryItem.IdProduct ==
                                            Convert.ToInt16(DropDownListProduct.SelectedValue)
                                            && inventoryItem.Status.Trim() == "A"
                                      select inventoryItem).ToList();
                    List<long> allId = (from id in inventoryItems select id.Id).ToList();

                    List<long> unmapId = allId.Except(mapId).ToList();

                    inventoryItems =
                        (from itm in inventoryItems where unmapId.Contains(itm.Id) select itm).ToList();

                    DataBindToDropDownListItem(inventoryItems);
                }
            }
            else
            {
                ClearDropDownListItem();
            }
        }

        public void DataBindTogridViewInvoice(List<Biz_Invoice> invoices)
        {
            gridViewInvoice.DataSource = null;
            gridViewInvoice.DataSource = invoices;
            gridViewInvoice.DataBind();

        }

        // Clear DropdownList
        public void CleardropDownListSubProductCategory()
        {
            dropDownListSubProductCategory.Items.Clear();
            dropDownListSubProductCategory.Items.Add("-Select-");
        }

        public void CleardropDownListProduct()
        {
            DropDownListProduct.Items.Clear();
            DropDownListProduct.Items.Add("-Select-");
        }

        public void ClearDropDownListItem()
        {
            DropDownListItem.Items.Clear();
            DropDownListItem.Items.Add("-Select-");
        }

        public void ClearDropDownListTransactionNumber()
        {
            DropDownListTransactionNumber.Items.Clear();
            DropDownListTransactionNumber.Items.Add("-Select-");
        }

        public void CleargridViewInvoice()
        {
            gridViewInvoice.DataSource = null;
            gridViewInvoice.DataBind();
        }

        public void ClearDropDownListPriceBook()
        {
            DropDownListPriceBook.Items.Clear();
            DropDownListPriceBook.Items.Add("-Select-");
        }

        #endregion

        #region "Operations"

        public void LoadInvoice(long transId)
        {

            Biz_SalesTransaction salesTransaction = new Biz_SalesTransaction();
            salesTransaction = new Biz_SalesTransactionService().ReadSalesTransactionById(transId);

            CheckStatus(salesTransaction.Status.Trim());

            List<Biz_Invoice> invoices = new List<Biz_Invoice>();

            invoices = new Biz_InvoiceService().ReadAllInvoices();
            invoices = (from invoice in invoices
                        where invoice.IdSalesTransaction == transId
                        select invoice).ToList();
            gridViewInvoice.DataSource = invoices;
            gridViewInvoice.DataBind();

            DataTable dt = GridConvertDatatable(invoices);
            Session["InvoiceDetail"] = dt;
        }

        public DataTable GridConvertDatatable(List<Biz_Invoice> invoices)
        {
            DataTable dt = new DataTable(Key.InvoiceDetail);

            dt.Columns.Add("Seq");
            dt.Columns.Add("Item");
            dt.Columns.Add("Description");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("UnitofMeasure");
            dt.Columns.Add("Total Value [LKR]", typeof(decimal));
            dt.Columns.Add("Discount");
            dt.Columns.Add("Price", typeof(decimal));

            foreach (Biz_Invoice invoice in invoices)
            {
                DataRow dr;
                dr = dt.NewRow();

                dr[0] = invoice.serialNo;
                dr[1] = invoice.Biz_InventoryItems != null ? invoice.Biz_InventoryItems.CodeInventoryItem : "";
                dr[2] = invoice.Biz_BranchProducts.Biz_Products != null ? invoice.Biz_BranchProducts.Biz_Products.Description : "";
                dr[3] = invoice.Quantity;
                dr[4] = invoice.Biz_UnitOfMeasures != null ? invoice.Biz_UnitOfMeasures.Description : "";
                dr[5] = invoice.Total_Value;
                dr[6] = ((invoice.Discount_Value * 100) / invoice.Total_Value).ToString() + " %";
                dr[7] = invoice.Total_Value - invoice.Discount_Value;

                dt.Rows.Add(dr);
            }
            return dt;
        }


        public Biz_BranchProduct GetBranchProduct(long id, String description, String code)
        {
            Biz_BranchProduct branchProduct = new Biz_BranchProduct();
            Biz_Product product = new Biz_Product();
            product.Id = id;
            product.Description = description;
            product.Code = code;

            branchProduct.IdProduct = id;
            branchProduct.Biz_Products = product;

            return branchProduct;
        }

        public void SelectSalesTarget()
        {
            if (DropDownListItem.SelectedIndex > 0)
            {
                Biz_SalesTargetDetail salesTargetDetail = new Biz_SalesTargetDetail();

                salesTargetDetail = new Biz_SalesTargetDetailsService().ReadSalesTargetDetailByItem(Convert.ToInt16(DropDownListItem.SelectedValue));

                if (salesTargetDetail != null)
                {
                    DropDownListSalesTarget.SelectedValue = salesTargetDetail.IdSalesTarget.ToString();
                }
                else
                {
                    DropDownListSalesTarget.SelectedIndex = 0;
                }
            }
        }

        public void FillDataToTextBoxes()
        {
            if (DropDownListPriceBook.SelectedIndex > 0)
            {
                SelectSalesTarget();
                if (DropDownListProduct.SelectedIndex > 0)
                {
                    List<Biz_PriceBookDetail> priceBookDetails = new List<Biz_PriceBookDetail>();
                    Biz_PriceBookDetail priceBookDetailnew = new Biz_PriceBookDetail();
                    priceBookDetails = new Biz_PriceBookDetailsService().ReadAllPriceBookDetails();

                    priceBookDetails = (from priceBookDetail in priceBookDetails
                                        where
                                            priceBookDetail.IdProduct ==
                                            Convert.ToInt16(DropDownListProduct.SelectedValue) &&
                                            priceBookDetail.IdPriceBook ==
                                            Convert.ToInt16(DropDownListPriceBook.SelectedValue)
                                        select priceBookDetail).ToList();

                    priceBookDetailnew = priceBookDetails.FirstOrDefault();

                    DropDownListUnitOfMeasure.SelectedValue = priceBookDetailnew.IdUnitOfMeasure.ToString();
                    textBoxPricePerUnit.Text = priceBookDetailnew.PricePer_Unit.ToString();
                    textBoxQuantity.Text = "1";
                    textBoxTotalValue.Text =
                        (Convert.ToDecimal(textBoxPricePerUnit.Text) * Convert.ToDecimal(textBoxQuantity.Text)).ToString();
                    textBoxDiscountRate.Text = priceBookDetailnew.Discount_Rate.ToString();
                    textBoxDiscountValue.Text =
                        (priceBookDetailnew.PricePer_Unit * priceBookDetailnew.Discount_Rate / 100).ToString();
                    textBoxCostPerUnit.Text = (Convert.ToDecimal(textBoxPricePerUnit.Text) -
                                              Convert.ToDecimal(textBoxDiscountValue.Text)).ToString();
                    textBoxTotalDiscount.Text =
                        (Convert.ToDecimal(textBoxDiscountValue.Text) * Convert.ToDecimal(textBoxQuantity.Text)).ToString();
                    textBoxCommissionRate.Text = priceBookDetailnew.Commission_Rate.ToString();
                    textBoxCommissionValue.Text = ((Convert.ToDecimal(priceBookDetailnew.PricePer_Unit) *
                                              Convert.ToDecimal(priceBookDetailnew.Commission_Rate)) / 100).ToString();
                    textBoxTotalCommission.Text =
                        (Convert.ToDecimal(textBoxCommissionValue.Text) * Convert.ToDecimal(textBoxQuantity.Text)).ToString();
                    textBoxStatus.Text = "G";
                }
            }
        }

        public void AddRecords()
        {
            try
            {
                if (Page.IsValid)
                {
                    // Add Invoice Details
                    List<Biz_Invoice> invoices = new List<Biz_Invoice>();

                    if (Session["InvoiceDetail"] != null)
                    {
                        invoices = (List<Biz_Invoice>)Session["InvoiceDetail"];
                    }


                    if (invoices != null)
                    {
                        x = invoices.Count;
                    }
                    x = x + 1;

                    Biz_InvoiceService invoiceService = new Biz_InvoiceService();
                    Biz_Invoice invoice = new Biz_Invoice();
                    invoice.serialNo = x;
                    invoice.IdSalesTransaction = null;
                    invoice.Status = "E";
                    invoice.IdBranch = Convert.ToInt16(dropDownListBranch.SelectedValue);
                    invoice.Biz_Branches = new Biz_BranchService().ReadBranchById(Convert.ToInt16(dropDownListBranch.SelectedValue));
                    invoice.IdSalesPerson = Convert.ToInt16(DropDownListSalesPerson.SelectedValue);
                    invoice.DateCreated = DateTime.Now;

                    List<Biz_BranchPriceBook> branchPriceBooks =
                        new Biz_BranchPriceBookService().ReadMappedBranchPriceBookByBranchId(Convert.ToInt16(dropDownListBranch.SelectedValue));
                    branchPriceBooks = (from branchPriceBook in branchPriceBooks
                                        where
                                            branchPriceBook.IdPriceBook ==
                                            Convert.ToInt16(DropDownListPriceBook.SelectedValue)
                                        select branchPriceBook).ToList();

                    invoice.IdBranchPriceBook = branchPriceBooks.FirstOrDefault().Id;
                    invoice.Biz_BranchPriceBooks = branchPriceBooks.FirstOrDefault();
                    invoice.Quantity = Convert.ToInt16(textBoxQuantity.Text);

                    if (DropDownListSalesTarget.SelectedIndex > 0)
                    {
                        invoice.IdSalesTarget = Convert.ToInt16(DropDownListSalesTarget.SelectedValue);
                        invoice.Biz_SalesTargets = new Biz_SalesTargetService().ReadSalesTargetById(Convert.ToInt16(DropDownListSalesTarget.SelectedValue));
                    }
                    else
                    {
                        invoice.IdSalesTarget = null;
                        invoice.Biz_SalesTargets = null;
                    }

                    invoice.DateModified = DateTime.Now;
                    invoice.Total_Value = Convert.ToDecimal(textBoxTotalValue.Text);
                    invoice.IdBranchProduct = new Biz_BranchProductService().ReadBranchProductByBranchIdAndProductId(Convert.ToInt16(dropDownListBranch.SelectedValue), Convert.ToInt16(DropDownListProduct.SelectedValue)).Id;
                    invoice.Biz_BranchProducts = new Biz_BranchProductService().ReadBranchProductByBranchIdAndProductId(Convert.ToInt16(dropDownListBranch.SelectedValue), Convert.ToInt16(DropDownListProduct.SelectedValue));
                    invoice.Biz_BranchProducts.Biz_Products = new Biz_GeneralProductService().ReadProductById(Convert.ToInt16(DropDownListProduct.SelectedValue));

                    if (textBoxTotalCommission.Text != string.Empty)
                    {
                        invoice.Commission_Value = Convert.ToDecimal(textBoxTotalCommission.Text);
                    }

                    invoice.Discount_Value = Convert.ToDecimal(textBoxTotalDiscount.Text);
                    invoice.IdItem = Convert.ToInt16(DropDownListItem.SelectedValue);
                    invoice.Biz_InventoryItems = new Biz_InventoryItemService().ReadInventoryItemById(Convert.ToInt16(DropDownListItem.SelectedValue));
                    invoice.IdUnitOfMeasure = Convert.ToInt16(DropDownListUnitOfMeasure.SelectedValue);
                    invoice.Biz_UnitOfMeasures = new Biz_UnitOfMeasureService().ReadUnitOfMeasureById(Convert.ToInt16(DropDownListUnitOfMeasure.SelectedValue));

                    invoices.Add(invoice);

                    Session["InvoiceDetail"] = invoices;
                    DataBindTogridViewInvoice(invoices);

                   FlashText1.Display("Record Successfully Added.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Adding Failed.", "errormessage");
            }

        }

        public void DeleteRecord()
        {
            try
            {
                if (Page.IsValid)
                {
                    List<Biz_Invoice> invoices = new List<Biz_Invoice>();
                    Biz_Invoice deleteInvoice = new Biz_Invoice();

                    invoices = (List<Biz_Invoice>)Session["InvoiceDetail"];
                    if (textBoxSerialModify.Text != string.Empty)
                    {
                        deleteInvoice =
                            (from invoice in invoices
                             where invoice.serialNo == Convert.ToInt16(textBoxSerialModify.Text)
                             select invoice).ToList().FirstOrDefault();
                    }

                    invoices.Remove(deleteInvoice);
                    Session["nvoiceDetail"] = invoices;
                    DataBindTogridViewInvoice(invoices);

                   FlashText1.Display("Record Successfully Deleted.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Deleting Failed.", "errormessage");
            }
        }

        public void CancelButtonClick()
        {
            DropDownListSalesTarget.SelectedIndex = 0;
            DropDownListUnitOfMeasure.SelectedIndex = 0;
            textBoxPricePerUnit.Text = "";
            textBoxQuantity.Text = "";
            textBoxTotalValue.Text = "";
            textBoxDiscountRate.Text = "";
            textBoxDiscountValue.Text = "";
            textBoxTotalDiscount.Text = "";
            textBoxCommissionRate.Text = "";
            textBoxCommissionValue.Text = "";
            textBoxTotalCommission.Text = "";
            textBoxSerialModify.Text = "";
            textBoxInvoiceIdModify.Text = "";
            textBoxStatus.Text = "";
            ClearDropDownListItem();
            GetDataToDropDownListItem();
            accordionInputs.SelectedIndex = 0;
            gridViewInvoice.SelectedIndex = -1;
        }

        public void SaveDetails()
        {
            try
            {
                if (Page.IsValid)
                {
                    long serialNumber;
                    string invNumber;
                    // Create Invoice No
                    Biz_SerialService serialService = new Biz_SerialService();
                    Biz_Serial serial = new Biz_Serial();
                    serial = new Biz_SerialService().ReadSerialByCode("INV");
                    serialNumber = serial.Serial_No;
                    serialNumber = serialNumber + 1;

                    invNumber = textBoxBranch.Text.Trim() + "/" + Convert.ToInt16(Session[Global.BizLoginUserStakeholderId]).ToString("000") + "/" + textBoxTransactionDate.Text.Trim() + "/" +
                                serialNumber.ToString("00000000");

                    //Update Transaction 

                    Biz_SalesTransaction salesTransaction = new Biz_SalesTransaction();
                    Biz_SalesTransactionService salesTransactionService = new Biz_SalesTransactionService();

                    salesTransaction.Invoice_No = invNumber;
                    salesTransaction.Status = "G";
                    salesTransaction.DateCreated = DateTime.Now;
                    salesTransaction.DateModified = DateTime.Now;

                    salesTransactionService.CreateSalesTransaction(salesTransaction);

                    // Update Invoice No in Invoice Table
                    Biz_InvoiceService invoiceService = new Biz_InvoiceService();
                    Biz_Invoice invoice = new Biz_Invoice();
                    List<Biz_Invoice> invoiceList = new List<Biz_Invoice>();

                    invoiceList = (List<Biz_Invoice>)Session["InvoiceDetail"];

                    foreach (Biz_Invoice newInvoice in invoiceList)
                    {
                        invoice.serialNo = newInvoice.serialNo;
                        invoice.IdSalesTransaction = salesTransaction.Id;
                        invoice.Status = "G";
                        invoice.IdBranch = newInvoice.IdBranch;
                        invoice.IdSalesPerson = newInvoice.IdSalesPerson;
                        invoice.DateCreated = DateTime.Now;
                        invoice.IdBranchPriceBook = newInvoice.IdBranchPriceBook;
                        //invoice.BranchPriceBook = newInvoice.BranchPriceBook;
                        invoice.Quantity = newInvoice.Quantity;
                        invoice.IdSalesTarget = newInvoice.IdSalesTarget;
                        //invoice.SalesTarget = newInvoice.SalesTarget;
                        invoice.DateModified = DateTime.Now;
                        invoice.Total_Value = newInvoice.Total_Value;
                        invoice.IdBranchProduct = newInvoice.IdBranchProduct;
                        //invoice.BranchProduct = newInvoice.BranchProduct;
                        //invoice.BranchProduct.Product = newInvoice.BranchProduct.Product;
                        invoice.Commission_Value = newInvoice.Commission_Value;
                        invoice.Discount_Value = newInvoice.Discount_Value;
                        invoice.IdItem = newInvoice.IdItem;
                        //invoice.InventoryItem = newInvoice.InventoryItem;
                        invoice.IdUnitOfMeasure = newInvoice.IdUnitOfMeasure;

                        invoiceService.CreateInvoice(invoice);

                        //Inactive Item
                        if (newInvoice.IdItem > 0)
                        {
                            Biz_InventoryItemService inventoryItemService = new Biz_InventoryItemService();
                            Biz_InventoryItem inventoryItem = new Biz_InventoryItem();
                            inventoryItem = inventoryItemService.ReadInventoryItemById(Convert.ToInt16(newInvoice.IdItem));

                            inventoryItem.Status = "I";
                            inventoryItem.DateModified = DateTime.Now;

                            inventoryItemService.UpdateInventoryItem(inventoryItem);
                        }
                    }

                    serial.Serial_No = serialNumber;
                    serialService.UpdateSerial(serial);
                   FlashText1.Display("Record(s) Successfully Saved.", "okmessage");
                    textBoxSalesTranasaionIdModify.Text = invNumber;
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record(s) Saving Failed.", "errormessage");
            }
        }

        public void DisableButtons()
        {
            buttonConfirm.Enabled = false;
            buttonPrint.Enabled = false;
        }

        public void PrintInvoice()
        {
            if (gridViewInvoice.HeaderRow.Cells.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW",
           "window.open( '../ReprotViewerForm.aspx?mainform=InvoiceForm&busUnit=" + Session[Global.BizLoginBranchName] +
           "&busUName=" + Session[Global.BizLoginUserStakeholderName] + "&busUCode=" + Session[Global.BizLoginBranchCode] +
           "', null, 'height=600,width=1100,status=yes,toolbar=no,menubar=no,location=no' );", true);
                //  ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW",
                //"window.open( '../ReprotViewerForm.aspx?mainform=InvoiceForm&busUnit=" + String.Empty +
                //"&busUName=" + String.Empty + "&busUCode=" + String.Empty +
                //"', null, 'height=600,width=1100,status=yes,toolbar=no,menubar=no,location=no' );", true);
            }
            else
            {
               FlashText1.Display("No Records to print", "okmessage");
            }
        }

        #endregion

        #region "Events"

        protected void gridViewInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewInvoice.PageIndex = e.NewPageIndex;
            gridViewInvoice.DataBind();
        }

        protected void gridViewInvoice_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[10].Visible = false;
            }
        }

        public void dropDownListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dropDownListBranch.SelectedIndex > 0)
                {
                    Biz_Branch branch = new Biz_Branch();
                    branch = new Biz_BranchService().ReadBranchById(Convert.ToInt16(dropDownListBranch.SelectedValue));
                    textBoxBranch.Text = branch.Code;
                }
                else
                {
                    textBoxBranch.Text = string.Empty;
                }
                DataBindToDropDownListSalesPerson();
                DataBindToDropDownListPriceBook();
                GetDataTodropDownListProduct();
                //GetDataTodropDownListProductEdit();
            }
            catch (Exception exception)
            {

            }
        }

        public void DropDownListProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CancelButtonClick();
                ClearDropDownListItem();
                GetDataToDropDownListItem();
            }
            catch (Exception exception)
            {

            }
        }

        public void DropDownListItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillDataToTextBoxes();
            }
            catch (Exception exception)
            { }
        }

        public void DropDownListPriceBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillDataToTextBoxes();
            }
            catch (Exception exception)
            { }
        }

        public void buttonAdd_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldAdd())
            {
                AddRecords();
                CancelButtonClick();
            }
        }

        public void buttonCancel_Click(object sender, EventArgs e)
        {
            CancelButtonClick();
        }

        public void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            textBoxTotalValue.Text =
                        (Convert.ToDecimal(textBoxPricePerUnit.Text) * Convert.ToDecimal(textBoxQuantity.Text)).ToString();
            textBoxTotalDiscount.Text =
                        (Convert.ToDecimal(textBoxDiscountValue.Text) * Convert.ToDecimal(textBoxQuantity.Text)).ToString();
            textBoxTotalCommission.Text =
                        (Convert.ToDecimal(textBoxCommissionValue.Text) * Convert.ToDecimal(textBoxQuantity.Text)).ToString();
        }

        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckInvoiceAdd())
            {
                SaveDetails();
                ClearDropDownListTransactionNumber();
                DataBindToDropDownListTransactionNumber();
                ClearDropDownListPriceBook();
                DataBindToDropDownListPriceBook();
                CleardropDownListProduct();
                GetDataTodropDownListProduct();
            }
        }

        public void DropDownListTransactionNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListTransactionNumber.SelectedIndex > 0)
            {
                textBoxSalesTranasaionIdModify.Text = DropDownListTransactionNumber.SelectedItem.Text;
                LoadInvoice(Convert.ToInt16(DropDownListTransactionNumber.SelectedValue));
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldDelete())
            {
                DeleteRecord();
                CancelButtonClick();
            }
        }

        protected void gridViewInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewInvoice.SelectedRow;
            textBoxInvoiceIdModify.Text = row.Cells[1].Text;
            textBoxSerialModify.Text = row.Cells[2].Text;
        }

        public void buttonConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxSalesTranasaionIdModify.Text != null)
                {
                    Biz_SalesTransaction salesTransaction = new Biz_SalesTransaction();
                    Biz_SalesTransactionService salesTransactionService = new Biz_SalesTransactionService();
                    salesTransaction =
                        new Biz_SalesTransactionService().ReadSalesTransactionByInvoiceNo(textBoxSalesTranasaionIdModify.Text.Trim());
                    if (salesTransaction.Status.Trim() == "G")
                    {
                        salesTransaction.Status = "C";
                        salesTransaction.DateModified = DateTime.Now;

                        salesTransactionService.UpdateSalesTransaction(salesTransaction);
                       FlashText1.Display("Invoice Successfully Confirmed.", "okmessage");
                    }
                    else
                    {
                        CheckInvoiceStatusConfirm(salesTransaction.Status.Trim());
                    }
                    LoadInvoice(salesTransaction.Id);
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Invoice Confirming Failed.", "okmessage");
            }
        }

        public void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxSalesTranasaionIdModify.Text != null)
                {
                    Biz_SalesTransaction salesTransaction = new Biz_SalesTransaction();
                    Biz_SalesTransactionService salesTransactionService = new Biz_SalesTransactionService();
                    salesTransaction =
                        new Biz_SalesTransactionService().ReadSalesTransactionByInvoiceNo(textBoxSalesTranasaionIdModify.Text.Trim());
                    if (salesTransaction.Status.Trim() == "C")
                    {
                        PrintInvoice();
                        //salesTransaction.Status = "P";
                        salesTransaction.DateModified = DateTime.Now;

                        salesTransactionService.UpdateSalesTransaction(salesTransaction);
                       FlashText1.Display("Invoice Successfully Printed.", "okmessage");
                    }
                    LoadInvoice(salesTransaction.Id);
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Invoice Confirming Failed.", "okmessage");
            }
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryFieldAdd()
        {
            if (DropDownListPriceBook.SelectedIndex < 1)
            {
               FlashText1.Display("Price Book is not Selected.", "errormessage");
                return false;
            }
            if (DropDownListProduct.SelectedIndex < 1)
            {
               FlashText1.Display("Product is not Selected.", "errormessage");
                return false;
            }
            if (DropDownListItem.SelectedIndex < 1)
            {
               FlashText1.Display("Item is not Selected.", "errormessage");
                return false;
            }
            if (textBoxQuantity.Text == string.Empty)
            {
               FlashText1.Display("Quantity Cannot be a Blank.", "errormessage");
                return false;
            }

            return true;
        }

        private Boolean CheckInvoiceAdd()
        {
           // if (Session["InvoiceDetail"] == null)
                if (Session["InvoiceDetail"] == null)
                {
               FlashText1.Display("Item Details not added.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryFieldDelete()
        {
            if (textBoxInvoiceIdModify.Text == string.Empty)
            {
               FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckInvoiceStatusConfirm(string invStatus)
        {
            if (invStatus == "C")
            {
               FlashText1.Display("Invoice Already Confirmed.", "errormessage");
                return false;
            }
            if (invStatus == "P")
            {
               FlashText1.Display("Invoice Already Confirmed and Printed.", "errormessage");
                return false;
            }
            return true;
        }

        public void CheckStatus(string invStatus)
        {
            if (invStatus == "G")
            {
                buttonAdd.Enabled = false;
                buttonDelete.Enabled = false;
                buttonSave.Enabled = false;
                buttonConfirm.Enabled = true;
                buttonPrint.Enabled = false;
            }
            if (invStatus == "C")
            {
                buttonAdd.Enabled = false;
                buttonDelete.Enabled = false;
                buttonSave.Enabled = false;
                buttonConfirm.Enabled = false;
                buttonPrint.Enabled = true;
            }
            if (invStatus == "P")
            {
                buttonAdd.Enabled = false;
                buttonDelete.Enabled = false;
                buttonSave.Enabled = false;
                buttonConfirm.Enabled = false;
                buttonPrint.Enabled = false;
            }
        }

        #endregion

        public void DropDownListSalesTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillDataToTextBoxes();
            }
            catch (Exception exception)
            { }
        }
    }
}