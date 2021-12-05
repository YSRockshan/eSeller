using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Reference
{
    public class Biz_ProductCategoryService
    {
        Biz_ProductCategoryData _productCategoryData = new Biz_ProductCategoryData();

        public void CreateProductCategory(Biz_ProductCategory productCategory)
        {
            _productCategoryData.Create(productCategory);
        }

        public void UpdateProductCategory(Biz_ProductCategory productCategory)
        {
            _productCategoryData.Update(productCategory);
        }

        public void DeleteProductCategories(long productCategoryId)
        {
            _productCategoryData.Delete(productCategoryId);
        }

        public Biz_ProductCategory ReadProductCategoryById(long productCategoryId)
        {
            return _productCategoryData.ReadProductCategoryById(productCategoryId);
        }

        public List<Biz_ProductCategory> ReadAllProductCategory()
        {
            return _productCategoryData.ReadAllProductCategory();
        }

        public List<Biz_ProductCategory> ReadProductCategoryByCode(string ProductCatCode)
        {
            return _productCategoryData.ReadProductCategoryByCode(ProductCatCode);
        }

    }
}
