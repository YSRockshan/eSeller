using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BzFlexer.SAMS.Biz.Reference
{
    [Serializable]
    public class Biz_Serial
    {
        #region "BizSerial Properties"
        public long Id { get; set; }
        public string Code { get; set; }
        public long Serial_No { get; set; }
        #endregion
      
    }
}
