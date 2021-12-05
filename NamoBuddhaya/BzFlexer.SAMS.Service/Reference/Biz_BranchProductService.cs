using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Reference
{
    public class Biz_BranchProductService
    {
        Biz_BranchProductsData branchProductData = new Biz_BranchProductsData();

    
        public void CreateBranchProduct(Biz_BranchProduct branchProductNew)
        {
            branchProductData.Create(branchProductNew);
        }

        public void RemoveBranchProduct(long branchProductId)
        {
            branchProductData.Delete(branchProductId);
        }

        public Biz_BranchProduct ReadBranchProductById(long branchProductId)
        {
            return branchProductData.ReadBranchProductById(branchProductId);
        }

        public List<Biz_BranchProduct> ReadAllBranchProduct()
        {
            return branchProductData.ReadAllBranchProduct();
        }

        public Biz_BranchProduct ReadBranchProductByBranchIdAndProductId(long branchId, long productId)
        {
            return branchProductData.ReadBranchProductByBranchIdAndProductId(branchId, productId);
        }
        public List<Biz_BranchProduct> ReadMappedBranchProduct(long branchId, long productCategoryId, long subProductCatId)
        {
            return branchProductData.ReadMappedBranchProducts(branchId, productCategoryId, subProductCatId);
        }

        public List<Biz_Product> ReadUnmappedProductsRelevantToroCat(long branchId, long productCategoryId, long subProductCatId)
        {
            return branchProductData.ReadUnmappedProductsRelevantToroCat(branchId, productCategoryId, subProductCatId);


        }

    }
}
