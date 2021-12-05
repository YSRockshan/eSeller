using System.Collections.Generic;
using System.Linq;
using BzFlexer.SAMS.Biz.Reference;
using System.Data;
using BzFlexer.SAMS.Biz.Connection;

namespace BzFlexer.SAMS.Data.Reference
{
    public partial class Biz_GeneralProductsData
    {// Using Reference.Biz_BranchProductsData
        public Biz_Product ReadProductsById(long productId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var _productList = from BizProduct in _context.Biz_Products
                                  where
                                      BizProduct.Id == productId
                                  select BizProduct;
                foreach (Biz_Product products in _productList)
                {
                    return products;
                }
                return null;
            }
        }
        public void Create(Biz_Product product)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_Products.AddObject(product);
                _context.SaveChanges();
            }
        }


        public void Update(Biz_Product product)
        {
            EntityKey key = null;
            object original = null;

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_Products", product);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, product);
                }
                _context.SaveChanges();
            }
        }


        public void Delete(long productId)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var ProductList = from Product in _context.Biz_Products
                                  where
                                      Product.Id == productId
                                  select Product;
                foreach (Biz_Product product in ProductList)
                {
                    _context.DeleteObject(product);
                }
                _context.SaveChanges();
            }
        }

        public List<Biz_Product> ReadAllProduct()
        {
            List<Biz_Product> ProductList = null;
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                ProductList = (from Product in _context.Biz_Products where Product.IdProductCategory  != null select Product).ToList();
            }
            return ProductList;
        }

        public List<Biz_Product> ReadAllGeneralProductByProductCategoryAndSubProductCategory(long ProductCategoryId, long SubProductCategoryId)
        {
            List<Biz_Product> ProductList = null;

               using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                ProductList = (from Product in _context.Biz_Products
                               where
                                   Product.IdProductCategory == ProductCategoryId &&
                                   Product.IdSubProductCategory == SubProductCategoryId
                               select Product).ToList();
            }
            return ProductList;
        }

         public List<Biz_Product> ReadGeneralProductByProductCat(long ProductCategoryId)
        {
            List<Biz_Product> ProductList = null;

               using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                ProductList = (from Product in _context.Biz_Products
                               where
                                   Product.IdProductCategory == ProductCategoryId
                               select Product).ToList();
            }
            return ProductList;
        }

        public List<Biz_Product> ReadGeneralProductByProductCodeAndProductCategoryAndSubProdctCategory(long ProductCategoryId, long SubProductCategoryId, string ProductCode)
        {
            List<Biz_Product> ProductList = null;
               using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                ProductList = (from Product in _context.Biz_Products
                               where Product.IdProductCategory == ProductCategoryId &&
                                   Product.IdSubProductCategory == SubProductCategoryId && Product.Code == ProductCode
                               select Product).ToList();
            }
            return ProductList;
        }


    }
}
