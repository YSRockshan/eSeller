using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Reference;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.Reference
{
    public partial class Biz_ProductCategoryData
    {
        public void Create(Biz_ProductCategory productCategory)
        {
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_ProductCategories.AddObject(productCategory);
                _context.SaveChanges();
            }
        }


        public void Update(Biz_ProductCategory productCategory)
        {
            EntityKey key = null;
            object original = null;
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_ProductCategories", productCategory);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, productCategory);
                }
                _context.SaveChanges();
            }
        }


        public void Delete(long productCategoryId)
        {
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var productCategoryList = from ProductCategory in _context.Biz_ProductCategories
                                          where ProductCategory.Id == productCategoryId
                                          select ProductCategory;
                foreach (Biz_ProductCategory productCategory in productCategoryList)
                {
                    _context.DeleteObject(productCategory);
                }
                _context.SaveChanges();
            }
        }


        public Biz_ProductCategory ReadProductCategoryById(long productCategoryId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var productCategoryList = from ProductCategory in _context.Biz_ProductCategories
                                          where ProductCategory.Id == productCategoryId
                                          select ProductCategory;
                foreach (Biz_ProductCategory productCategory in productCategoryList)
                {
                    return productCategory;
                }
            }
            return null;
        }


        public List<Biz_ProductCategory> ReadAllProductCategory()
        {
            List<Biz_ProductCategory> productCategoryList = null;

             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                productCategoryList =
                    (from ProductCategory in _context.Biz_ProductCategories select ProductCategory).ToList();
            }
            return productCategoryList;
        }
        public List<Biz_ProductCategory> ReadProductCategoryByCode(string ProductCatCode)
        {
            List<Biz_ProductCategory> productCategoryList = null;

             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                productCategoryList =
                    (from ProductCategory in _context.Biz_ProductCategories where ProductCategory.Code == ProductCatCode select ProductCategory).ToList();
            }
            return productCategoryList;
        }
    }
}
