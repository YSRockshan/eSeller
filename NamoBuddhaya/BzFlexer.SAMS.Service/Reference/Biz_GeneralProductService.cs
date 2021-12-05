using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Reference
{
    public class Biz_GeneralProductService
    {
        Biz_GeneralProductsData _generalProductData = new Biz_GeneralProductsData();

        public void CreateGeneralProduct(Biz_Product product)
        {
            _generalProductData.Create(product);
        }

        public void UpdateGeneralProduct(Biz_Product product)
        {
            _generalProductData.Update(product);
        }

        public void DeleteGeneralProducts(long productId)
        {
            _generalProductData.Delete(productId);
        }

        public Biz_Product ReadProductById(long productId)
        {
            return _generalProductData.ReadProductsById(productId);
        }

        public List<Biz_Product> ReadAllGeneralProductByProductCategoryAndSubProductCategory(long ProductCategoryId, long SubProductCategoryId)
        {
            return _generalProductData.ReadAllGeneralProductByProductCategoryAndSubProductCategory(ProductCategoryId, SubProductCategoryId);
        }

        public List<Biz_Product> ReadGeneralProductByProductCat(long ProductCategoryId)
        {
            return _generalProductData.ReadGeneralProductByProductCat(ProductCategoryId);
        }

        public List<Biz_Product> ReadAllProduct()
        {
            return _generalProductData.ReadAllProduct();
        }

        public List<Biz_Product> ReadGeneralProductByProductCodeAndProductCategoryAndSubProdctCategory(long ProductCategoryId, long SubProductCategoryId, string ProductCode)
        {
            return _generalProductData.ReadGeneralProductByProductCodeAndProductCategoryAndSubProdctCategory(ProductCategoryId, SubProductCategoryId, ProductCode);
        }

    }
}
