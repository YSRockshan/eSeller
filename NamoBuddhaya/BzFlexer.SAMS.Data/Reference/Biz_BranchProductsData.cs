using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Reference;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.Reference
{
    public partial class Biz_BranchProductsData 
    {
        public void Create(Biz_BranchProduct branchProductNew)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_BranchProducts.AddObject(branchProductNew);
                _context.SaveChanges();
            }
        }

        public void Update(Biz_BranchProduct branchProduct)
        {
            EntityKey key = null;
            object original = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_BranchProducts", branchProduct);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, branchProduct);
                }
                _context.SaveChanges();
            }
        }

        public void Delete(long branchProductId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var BranchProductList = from BranchProduct in _context.Biz_BranchProducts
                                        where BranchProduct.Id == branchProductId
                                        select BranchProduct;
                foreach (Biz_BranchProduct branchProduct in BranchProductList)
                {
                    _context.DeleteObject(branchProduct);
                }
                _context.SaveChanges();
            }
        }

        public List<Biz_BranchProduct> ReadMappedBranchProducts(long _branchId, long _productCategoryId, long _subProductCatId)
        {
            List<Biz_BranchProduct> _branchProductList = null;
            List<Biz_BranchProduct> _branchProducts = new List<Biz_BranchProduct>();

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _branchProductList =
                    (from BizBranchProduct in _context.Biz_BranchProducts
                     where
                         BizBranchProduct.IdBranch == _branchId &&
                         BizBranchProduct.IdProductCategory == _productCategoryId &&
                         BizBranchProduct.IdSubProductCategory == _subProductCatId
                     select BizBranchProduct).ToList();
            }
            foreach (Biz_BranchProduct _branchProduct in _branchProductList)
            {
                if (_branchProduct.IdProduct > 0)
                {
                    _branchProduct.Biz_Products = new Biz_GeneralProductsData().ReadProductsById(_branchProduct.IdProduct);
                    //new Biz_GeneralProductsData().GetProductById(branchProduct.BranchProductId);
                }
                _branchProducts.Add(_branchProduct);
            }
            return _branchProducts;
        }
                                
        public Biz_BranchProduct ReadBranchProductByBranchIdAndProductId(long branchId, long productId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var _branchProductsList = from BizBranchProduct in _context.Biz_BranchProducts where BizBranchProduct.IdBranch == branchId && BizBranchProduct.IdProduct == productId select BizBranchProduct;
                foreach (Biz_BranchProduct branchProducts  in _branchProductsList)
                {
                    return branchProducts;
                }
                return null;
            }
        }

        public Biz_BranchProduct ReadBranchProductsByProductId(long productId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var _branchProductsList = from BranchProduct in _context.Biz_BranchProducts where BranchProduct.Id == productId select BranchProduct;
                foreach (Biz_BranchProduct branchProducts in _branchProductsList)
                {
                    return branchProducts;
                }
                return null;
            }
        }

     
        public Biz_BranchProduct ReadBranchProductById(long branchProductId)
        {
          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var branchProductList = from BranchProduct in _context.Biz_BranchProducts where BranchProduct.Id == branchProductId select BranchProduct;
                foreach (Biz_BranchProduct branchProduct in branchProductList)
                {
                    return branchProduct;
                }
                return null;
            }
        }

        public List<Biz_BranchProduct> ReadAllBranchProduct()
        {
            List<Biz_BranchProduct> branchProductList = null;

          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                branchProductList = (from BranchProduct in _context.Biz_BranchProducts select BranchProduct).ToList();
            }
            return branchProductList;
        }

        public List<Biz_Product> ReadUnmappedProductsRelevantToroCat(long branchId, long productCategoryId, long subProductCatId)
        {
            List<Biz_BranchProduct> branchProductByBranchIdAndProductCatIdAndSubProCatId = new List<Biz_BranchProduct>();
            List<Biz_Product> productByProductCatIdAndSubProCatId = new List<Biz_Product>();
            List<Biz_Product> UnmappedProductList = new List<Biz_Product>();

            branchProductByBranchIdAndProductCatIdAndSubProCatId = this.ReadMappedBranchProducts(branchId, productCategoryId, subProductCatId);
            productByProductCatIdAndSubProCatId = new Biz_GeneralProductsData().ReadAllGeneralProductByProductCategoryAndSubProductCategory(productCategoryId, subProductCatId);

            UnmappedProductList = (from product in productByProductCatIdAndSubProCatId
                                   where
                                       !(from branchProduct in branchProductByBranchIdAndProductCatIdAndSubProCatId
                                         select branchProduct.IdProduct).Contains(product.Id)
                                   select product).ToList();
            return UnmappedProductList;

        }
    }
}
