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
    public partial class BzFlexerUOMType : System.Web.UI.Page
    {
        #region "Variables"

        private long SelectUnitOfMeasureTypeId;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUnitOFMeasureType();
                textBoxUnitofMeasureTypeCode.Attributes.Add("onchange", "javascript:this.value=toUpperCase(this.value);");
                textBoxDescription.Attributes.Add("onchange", "javascript:this.value=toTitleCase(this.value);");
                textBoxUnitofMeasureTypeCode2.Attributes.Add("onchange", "javascript:this.value=toUpperCase(this.value);");
                textBoxDescription2.Attributes.Add("onchange", "javascript:this.value=toTitleCase(this.value);");
            }
        }

        #region "Load Data"

        public void LoadUnitOFMeasureType()
        {
            Biz_UnitOfMeasureTypeService unitOfMeasureTypeService = new Biz_UnitOfMeasureTypeService();

            try
            {
                gridViewUnitOfMeasureType.DataSource = unitOfMeasureTypeService.ReadAllUnitOfMeasureType();
                gridViewUnitOfMeasureType.DataBind();
            }
            catch (Exception exception)
            {

            }
        }

        #endregion

        #region "Display Handling"

        public void ClearData()
        {
            textBoxUnitofMeasureTypeCode.Text = "";
            textBoxDescription.Text = "";
            textBoxUnitofMeasureTypeCode2.Text = "";
            textBoxDescription2.Text = "";
            ViewState["SelectUnitOfMeasureTypeId"] = null;
            gridViewUnitOfMeasureType.SelectedIndex = -1;
            accordianInputs.SelectedIndex = 0;
        }

        #endregion

        #region "Oprations"

        public void AddUnitOfMeasureType()
        {
            try
            {
                Biz_UnitOfMeasureType unitOfMeasureType = new Biz_UnitOfMeasureType();
                Biz_UnitOfMeasureTypeService unitOfMeasureTypeService = new Biz_UnitOfMeasureTypeService();

                if (Page.IsValid)
                {
                    if (textBoxUnitofMeasureTypeCode.Text.Trim() != string.Empty)
                    {
                        unitOfMeasureType.Code = textBoxUnitofMeasureTypeCode.Text.Trim().ToUpper();
                    }
                    if (textBoxDescription.Text.Trim() != string.Empty)
                    {
                        unitOfMeasureType.Description = textBoxDescription.Text.Trim();
                    }
                    unitOfMeasureType.DateCreated = DateTime.Now;
                    unitOfMeasureType.DateModified = DateTime.Now;

                    unitOfMeasureTypeService.AddUnitOfMeasureType(unitOfMeasureType);
                }
                FlashText1.Display("Record Successfully Saved.", "okmessage");
            }
            catch (Exception)
            {
                FlashText1.Display("Record Already Exists.", "errormessage");
            }
        }

        public void ModifyUnitOfMeasureType()
        {
            try
            {
                Biz_UnitOfMeasureType unitOfMeasureType = new Biz_UnitOfMeasureType();
                Biz_UnitOfMeasureTypeService unitOfMeasureTypeService = new Biz_UnitOfMeasureTypeService();

                if (Page.IsValid)
                {
                    unitOfMeasureType.Id = Convert.ToInt16(ViewState["SelectUnitOfMeasureTypeId"]);
                    unitOfMeasureType = unitOfMeasureTypeService.ReadUnitOfMeasureTypeById(unitOfMeasureType.Id);

                    if (textBoxUnitofMeasureTypeCode2.Text.Trim() != string.Empty)
                    {
                        unitOfMeasureType.Code = textBoxUnitofMeasureTypeCode2.Text.Trim().ToUpper();
                    }
                    if (textBoxDescription2.Text.Trim() != string.Empty)
                    {
                        unitOfMeasureType.Description = textBoxDescription2.Text.Trim();
                    }
                    unitOfMeasureType.DateModified = DateTime.Now;

                    unitOfMeasureTypeService.ModifyUnitOfMeasureType(unitOfMeasureType);
                }
                FlashText1.Display("Record Successfully Modified.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        public void DeleteUnitOfMeasureType()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_UnitOfMeasureType unitOfMeasureType = new Biz_UnitOfMeasureType();
                    Biz_UnitOfMeasureTypeService unitOfMeasureTypeService = new Biz_UnitOfMeasureTypeService();

                    unitOfMeasureType.Id = Convert.ToInt16(ViewState["SelectUnitOfMeasureTypeId"]);
                    unitOfMeasureTypeService.DeleteUnitOfMeasureType(unitOfMeasureType.Id);
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

        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryUnitOfMeasureTypeAdd())
            {
                AddUnitOfMeasureType();
                ClearData();
                LoadUnitOFMeasureType();
            }

        }

        public void buttonModify_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryUnitOfMeasureTypeModify())
            {
                ModifyUnitOfMeasureType();
                ClearData();
                LoadUnitOFMeasureType();
            }
        }

        public void buttoDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryUnitOfMeasureTypeDelete())
            {
                DeleteUnitOfMeasureType();
                ClearData();
                LoadUnitOFMeasureType();
            }
        }

        public void buttonCancel1_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadUnitOFMeasureType();
        }

        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadUnitOFMeasureType();
        }

        public void gridViewUnitOfMeasureType_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewUnitOfMeasureType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewUnitOfMeasureType.SelectedRow;

            ViewState["SelectUnitOfMeasureTypeId"] = row.Cells[1].Text.Trim();
            textBoxUnitofMeasureTypeCode2.Text = row.Cells[2].Text.Trim();
            textBoxDescription2.Text = row.Cells[3].Text.Trim();

            accordianInputs.SelectedIndex = 1;
        }

        public void gridViewUnitOfMeasureType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadUnitOFMeasureType();
            gridViewUnitOfMeasureType.PageIndex = e.NewPageIndex;
            gridViewUnitOfMeasureType.DataBind();
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryUnitOfMeasureTypeAdd()
        {
            if (textBoxUnitofMeasureTypeCode.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Unit of Measure Type Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxDescription.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryUnitOfMeasureTypeModify()
        {
            if (ViewState["SelectUnitOfMeasureTypeId"] == null)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            if (textBoxUnitofMeasureTypeCode2.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Unit of Measure Type Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxDescription2.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryUnitOfMeasureTypeDelete()
        {
            if (textBoxUnitofMeasureTypeCode2.Text.Trim() == string.Empty)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion
    }
}