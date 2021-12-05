using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Reference
{
    public class Biz_SubProductCategoryService
    {
        Biz_SubProductCategoryData _subProductCategoryData = new Biz_SubProductCategoryData();

        public void CreateSubProductCategory(Biz_SubProductCategory subProductCategory)
        {
            _subProductCategoryData.Create(subProductCategory);
        }

        public void UpdateSubProductCategory(Biz_SubProductCategory subProductCategory)
        {
            _subProductCategoryData.Update(subProductCategory);
        }

        public void DeleteSubProductCategory(long subProductCategoryId)
        {
            _subProductCategoryData.Delete(subProductCategoryId);
        }

        public Biz_SubProductCategory ReadSubProductCategoryById(long subProductCategoryId)
        {
            return _subProductCategoryData.ReadSubProductCategoryById(subProductCategoryId);
        }

        public List<Biz_SubProductCategory> ReadAllSubProductCategory()
        {
            return _subProductCategoryData.ReadAllSubProductCategory();
        }

        public List<Biz_SubProductCategory> ReadAllSubProductCategoryByProductId(long productCategoryId)
        {
            return _subProductCategoryData.ReadAllSubProductCategoryByProductId(productCategoryId);
        }

        public List<Biz_SubProductCategory> ReadSubProductCategoryByCode(long ProductCatId, string SubProductCatCode)
        {
            return _subProductCategoryData.ReadSubProductCategoryByCode(ProductCatId, SubProductCatCode);
        }

    }
}
