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
    public partial class BzFlexerUOM : System.Web.UI.Page
    {
        #region "Variables"

        private long SelectUnitOfMeasureId;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindToUnitOfMeasureType();
                DataBindToUnitOfMeasure();
            }
        }

        #region "Load Data"

        public void DataBindToUnitOfMeasureType()
        {
            Biz_UnitOfMeasureTypeService unitOfMeasureTypeService = new Biz_UnitOfMeasureTypeService();

            dropDownListUnitOfMeasureType.DataSource = unitOfMeasureTypeService.ReadAllUnitOfMeasureType();
            dropDownListUnitOfMeasureType.DataValueField = "Id";
            dropDownListUnitOfMeasureType.DataTextField = "Description";
            dropDownListUnitOfMeasureType.DataBind();
        }

        public void DataBindToUnitOfMeasure()
        {
            if (dropDownListUnitOfMeasureType.SelectedIndex > 0)
            {
                LoadUnitOfMeasure();
            }
            else
            {
                ClearUnitOfMeasure();
            }
        }

        public void LoadUnitOfMeasure()
        {
            try
            {
                Biz_UnitOfMeasureService unitOfMeasureService = new Biz_UnitOfMeasureService();

                gridViewUnitOfMeasure.DataSource = unitOfMeasureService.ReadUnitOfMeasureByUnitOfMeasureTypeId(Convert.ToInt16(dropDownListUnitOfMeasureType.SelectedValue));
                gridViewUnitOfMeasure.DataBind();
            }
            catch (Exception exception)
            {

            }
        }

        public void ClearUnitOfMeasure()
        {
            gridViewUnitOfMeasure.DataSource = null;
            gridViewUnitOfMeasure.DataBind();
        }

        #endregion

        #region "Operations"

        public void AddUnitOfMeasure()
        {
            try
            {
                Biz_UnitOfMeasureService unitOfMeasureService = new Biz_UnitOfMeasureService();
                Biz_UnitOfMeasure unitOfMeasure = new Biz_UnitOfMeasure();

                if (Page.IsValid)
                {
                    if (dropDownListUnitOfMeasureType.SelectedIndex > 0)
                    {
                        unitOfMeasure.IdUnitOfMeasureType = Convert.ToInt16(dropDownListUnitOfMeasureType.SelectedValue);
                    }
                    if (textBoxUnitOfMeasureCode.Text.Trim() != string.Empty)
                    {
                        unitOfMeasure.Code = textBoxUnitOfMeasureCode.Text.Trim().ToUpper();
                    }
                    if (textBoxDescription.Text.Trim() != string.Empty)
                    {
                        unitOfMeasure.Description = textBoxDescription.Text.Trim();
                    }
                    if (textBoxSymbol.Text.Trim() != string.Empty)
                    {
                        unitOfMeasure.Symbol = textBoxSymbol.Text.Trim();
                    }

                    unitOfMeasure.DateCreated = DateTime.Now;
                    unitOfMeasure.DateModified = DateTime.Now;

                    unitOfMeasureService.CreateUnitOfMeasure(unitOfMeasure);
                }
                FlashText1.Display("Record successfully Saved.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Saving Failed.", "okmessage");
            }
        }

        public void ModifyUnitOfMeasure()
        {
            try
            {
                Biz_UnitOfMeasure unitOfMeasure = new Biz_UnitOfMeasure();
                Biz_UnitOfMeasureService unitOfMeasureService = new Biz_UnitOfMeasureService();

                if (Page.IsValid)
                {
                    unitOfMeasure.Id  = Convert.ToInt16(ViewState["SelectUnitOfMeasureId"]);
                    unitOfMeasure = unitOfMeasureService.ReadUnitOfMeasureById(unitOfMeasure.Id);

                    if (dropDownListUnitOfMeasureType.SelectedIndex > 0)
                    {
                        unitOfMeasure.IdUnitOfMeasureType = Convert.ToInt16(dropDownListUnitOfMeasureType.SelectedValue);
                    }
                    if (textBoxUnitOfMeasureCode2.Text.Trim() != string.Empty)
                    {
                        unitOfMeasure.Code = textBoxUnitOfMeasureCode2.Text.Trim().ToUpper();
                    }
                    if (textBoxDescription2.Text.Trim() != string.Empty)
                    {
                        unitOfMeasure.Description = textBoxDescription2.Text.Trim();
                    }
                    if (textBoxSymbol2.Text.Trim() != string.Empty)
                    {
                        unitOfMeasure.Symbol = textBoxSymbol2.Text.Trim();
                    }

                    unitOfMeasure.DateModified = DateTime.Now;

                    unitOfMeasureService.UpdateUnitOfMeasure(unitOfMeasure);
                }
                FlashText1.Display("Record Successfully Modified.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        public void DeleteUnitOfMeasure()
        {
            try
            {
                Biz_UnitOfMeasureService unitOfMeasureService = new Biz_UnitOfMeasureService();

                if (Page.IsValid)
                {
                    unitOfMeasureService.DeleteUnitOfMeasures(Convert.ToInt16(ViewState["SelectUnitOfMeasureId"]));
                }
                FlashText1.Display("Record Successfully Deleted.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Deleting Failed.", "errormessage");
            }
        }

        #endregion

        #region "Display Handling"

        public void ClearData()
        {
            textBoxUnitOfMeasureCode.Text = "";
            textBoxDescription.Text = "";
            textBoxSymbol.Text = "";
            textBoxUnitOfMeasureCode2.Text = "";
            textBoxDescription2.Text = "";
            textBoxSymbol2.Text = "";
            ViewState["SelectUnitOfMeasureId"] = null;
            gridViewUnitOfMeasure.SelectedIndex = -1;
            accordianInputs.SelectedIndex = 0;
        }

        #endregion

        #region "Events"

        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryUnitOfMeasureAdd())
            {
                AddUnitOfMeasure();
                ClearData();
                LoadUnitOfMeasure();
            }
        }

        public void buttonModify_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryUnitOfMeasureModify())
            {
                ModifyUnitOfMeasure();
                ClearData();
                LoadUnitOfMeasure();
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryUnitOfMeasureDelete())
            {
                DeleteUnitOfMeasure();
                ClearData();
                LoadUnitOfMeasure();
            }
        }

        public void buttonCancel1_Click(object sender, EventArgs e)
        {
            ClearData();
            textBoxUnitOfMeasureCode.Focus();
        }

        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            ClearData();
            textBoxUnitOfMeasureCode.Focus();
        }

        public void dropDownListUnitOfMeasureType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUnitOfMeasure();
        }

        public void gridViewUnitOfMeasure_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewUnitOfMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gridViewUnitOfMeasure.SelectedRow;

                ViewState["SelectUnitOfMeasureId"] = row.Cells[1].Text.Trim();
                textBoxUnitOfMeasureCode2.Text = row.Cells[2].Text.Trim();
                textBoxDescription2.Text = row.Cells[3].Text.Trim();
                textBoxSymbol2.Text = row.Cells[4].Text.Trim();
                accordianInputs.SelectedIndex = 1;
            }
            catch (Exception exception)
            { }

        }

        public void gridViewUnitOfMeasure_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewUnitOfMeasure.PageIndex = e.NewPageIndex;
            gridViewUnitOfMeasure.DataBind();
            LoadUnitOfMeasure();
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryUnitOfMeasureAdd()
        {
            if (dropDownListUnitOfMeasureType.SelectedIndex < 1)
            {
                FlashText1.Display("Please Select the Unit of Measure Type.", "errormessage");
                return false;
            }
            if (textBoxUnitOfMeasureCode.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Unit of Measure Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxDescription.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxSymbol.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Symbol Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxUnitOfMeasureCode.Text.Trim() != string.Empty)
            {
                Biz_UnitOfMeasureService unitOfMeasureService = new Biz_UnitOfMeasureService();
                List<Biz_UnitOfMeasure> unitOfMeasureList = new List<Biz_UnitOfMeasure>();

                unitOfMeasureList = unitOfMeasureService.ReadUnitofMesureByUOMCodeAndType(Convert.ToInt16(dropDownListUnitOfMeasureType.SelectedValue), textBoxUnitOfMeasureCode.Text.Trim());
                if (unitOfMeasureList.Count > 0)
                {
                    FlashText1.Display("Record Already Exists.", "errormessage");
                    return false;
                }

            }

            return true;
        }

        private Boolean CheckMandatoryUnitOfMeasureModify()
        {
            if (dropDownListUnitOfMeasureType.SelectedIndex < 1)
            {
                FlashText1.Display("Please Select the Unit of Measure Type.", "errormessage");
                return false;
            }
            if (ViewState["SelectUnitOfMeasureId"] == null)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }

            if (textBoxUnitOfMeasureCode2.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Unit of Measure Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxDescription2.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxSymbol2.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Symbol Cannot be Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryUnitOfMeasureDelete()
        {
            if (ViewState["SelectUnitOfMeasureId"] == null)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion
    }
}