using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
namespace BzFlexer.SAMS.Biz.Reference
{
    [Serializable]
    public class Biz_SubProductCategory
    {
        #region "BizSubProductCategory Properties"
        public long Id { get; set; }
        public long IdProductCategory { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        #endregion
        #region"Reference Properties" 
        public Biz_ProductCategory Biz_ProductCategories
        {
            get;
            set;
        }

        public EntityCollection<Biz_Product> Biz_Products
        {
            get;
            set;
        }

        public EntityCollection<Biz_BranchProduct> Biz_BranchProducts
        {
            get;
            set;
        }


        #endregion
    }
}
