using BzFlexer.SAMS.Biz.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Biz.Security
{//PasswordHistory Representaion
    [Serializable]
    public class Biz_PasswordHistory
    {
        #region "Biz_PasswordHistory Properties"
        public long Id { get; set; }
        public string Status { get; set; }
        public string User_Name { get; set; }
        public string Old_Password { get; set; }
        public string New_Password { get; set; }
        public System.DateTime EffectiveDate { get; set; }
        public DateTime ? ExpiryDate { get; set; }
        public long ChangedByUser { get; set; }
        public string ChangedByTerminalId { get; set; }
        public System.DateTime sys_DateCreation { get; set; }
        public System.DateTime sys_DateLastModification { get; set; }
        public long IdStakeholder { get; set; }

        #endregion
        #region"Reference Properties"
        public Biz_Stakeholder Biz_Stakeholders
        {
            get;
            set;
        }
        #endregion
    }
}
