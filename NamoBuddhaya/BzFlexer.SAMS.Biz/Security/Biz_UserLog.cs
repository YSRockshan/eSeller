using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Biz.Security
{
    [Serializable]
    public class Biz_UserLog
    {
        #region  "Biz_UserLog Properties"
        public long Login_Id { get; set; }
        public long IdUserStakeholder { get; set; }
        public string TerminalUser_Name { get; set; }
        public string Terminal_Ip { get; set; }
        public long IdOrgStructure { get; set; }
        public long IdCountryStructure { get; set; }
        public DateTime DateLoggedIn { get; set; }
        public DateTime TimeLoggedIn { get; set; }
        public DateTime DateLoggedoff { get; set; }
        public DateTime TimeLoggedff { get; set; }
        public long IdLoginStatus { get; set; }
      

        #endregion
    }
}
