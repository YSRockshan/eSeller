using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;

namespace BzFlexer.SAMS.Biz.Reference
{
    [Serializable]
    public class Biz_ProductCategory
    {
        #region "BizProductCategory Properties"
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        #endregion
        #region"Reference Properties"


        public EntityCollection<Biz_SubProductCategory> Biz_SubProductCategories
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
