using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
namespace BzFlexer.SAMS.Biz.AgentManagement 
{
    [Serializable]
    public class Biz_Commission
    {
        #region  "Biz_Commission Properties"

        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Mode { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        #endregion
        #region  "Reference Properties"
       
        public EntityCollection<Biz_SingleRate> Biz_SingleRates
        {
            get;
            set;
        }

        public EntityCollection<Biz_SlabValueDetail> Biz_SlabValueDetails
        {
            get;
            set;
        }

        public EntityCollection<Biz_MultipleRate> Biz_MultipleRates
        {
            get;
            set;
        }

        public EntityCollection<Biz_SalesTarget> Biz_SalesTargets
        {
            get;
            set;
        }

        #endregion
    }
    }
