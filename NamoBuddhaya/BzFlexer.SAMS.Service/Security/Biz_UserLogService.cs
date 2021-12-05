using BzFlexer.SAMS.Biz.Security;
using BzFlexer.SAMS.Data.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Security
{
    public class Biz_UserLogService
    {
        Biz_UserLogData userLogData = new Biz_UserLogData();

        
        public Boolean CreateUserLog(Biz_UserLog userLog)
        {
            Boolean isSuccess = false;
            if (userLog != null)
            {
                isSuccess = userLogData.Create(userLog);
            }
            return isSuccess;
        }

    
        public Boolean UpdateUserLog(Biz_UserLog userLog)
        {
            Boolean isSuccess = false;
            if (userLog != null)
            {
                isSuccess = userLogData.Update(userLog);
            }
            return isSuccess;
        }
        
        public Boolean DeleteUserLog(long userLogId)
        {
            Boolean isSuccess = false;
            if (userLogId != 0)
            {
                isSuccess = userLogData.Delete(userLogId);
            }
            return isSuccess;
        }

        public Biz_UserLog ReadUserLogById(long userLogId)
        {
            return userLogData.ReadUserLogById(userLogId);
        }

        public List<Biz_UserLog> ReadAllUserLogs()
        {
            return userLogData.ReadAllUserLogs();
        }


    }
}
