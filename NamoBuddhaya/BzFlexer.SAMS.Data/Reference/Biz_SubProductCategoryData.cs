using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Reference;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.Reference
{
    public partial class Biz_SubProductCategoryData
    {
        public void Create(Biz_SubProductCategory subProductCategory)
        {
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_SubProductCategories.AddObject(subProductCategory);
                _context.SaveChanges();
            }
        }

        public void Update(Biz_SubProductCategory subProductCategory)
        {
            EntityKey key = null;
            object original = null;

             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_SubProductCategories", subProductCategory);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, subProductCategory);
                }
                _context.SaveChanges();
            }
        }

       public void Delete(long subProductCategoryId)
        {
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var SubProductCategoryList = from SubProductCategory in _context.Biz_SubProductCategories
                                             where SubProductCategory.Id == subProductCategoryId
                                             select SubProductCategory;
                foreach (Biz_SubProductCategory subProductCategory in SubProductCategoryList)
                {
                    _context.DeleteObject(subProductCategory);
                }
                _context.SaveChanges();
            }
        }

       public Biz_SubProductCategory ReadSubProductCategoryById(long subProductCategoryId)
        {
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var SubProductCategoryList = from SubProductCategory in _context.Biz_SubProductCategories
                                             where SubProductCategory.Id == subProductCategoryId
                                             select SubProductCategory;
                foreach (Biz_SubProductCategory subProductCategory in SubProductCategoryList)
                {
                    return subProductCategory;
                }
                return null;
            }
        }

        public List<Biz_SubProductCategory> ReadAllSubProductCategory()
        {
            List<Biz_SubProductCategory> SubProductCategoryList = null;

             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                SubProductCategoryList = (from SubProductCategory in _context.Biz_SubProductCategories
                                          select SubProductCategory).ToList();

            }
            return SubProductCategoryList;
        }

        public List<Biz_SubProductCategory> ReadAllSubProductCategoryByProductId(long productCategoryId)
        {
            List<Biz_SubProductCategory> SubProductCategoryList = null;
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                SubProductCategoryList = (from SubProductCategory in _context.Biz_SubProductCategories
                                          where SubProductCategory.IdProductCategory == productCategoryId
                                          select SubProductCategory).ToList();
            }
            return SubProductCategoryList;
        }


        public List<Biz_SubProductCategory> ReadSubProductCategoryByCode(long ProductCatId, string SubProductCatCode)
        {
            List<Biz_SubProductCategory> SubProductCategoryList = null;
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                SubProductCategoryList = (from SubProductCategory in _context.Biz_SubProductCategories
                                          where SubProductCategory.IdProductCategory == ProductCatId && SubProductCategory.Code == SubProductCatCode
                                          select SubProductCategory).ToList();
            }
            return SubProductCategoryList;
        }

    }
}
