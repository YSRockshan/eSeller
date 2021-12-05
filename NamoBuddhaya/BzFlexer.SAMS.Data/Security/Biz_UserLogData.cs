using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.Security
{
    public class Biz_UserLogData
    {
        public Boolean Create(Biz_UserLog userLog)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_UserLogs.AddObject(userLog);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }
        public Boolean Update(Biz_UserLog userLog)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_UserLogs", userLog);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, userLog);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }
        public Boolean Delete(long userLogId)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var userLogList = from UserLog in _context.Biz_UserLogs
                                  where UserLog.Login_Id == userLogId
                                  select UserLog;

                foreach (Biz_UserLog userLog in userLogList)
                {
                    _context.DeleteObject(userLog);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }
        public Biz_UserLog ReadUserLogById(long userLogId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var userLogList = from UserLog in _context.Biz_UserLogs
                                  where UserLog.Login_Id == userLogId
                                  select UserLog;

                foreach (Biz_UserLog userLog in userLogList)
                {
                    return userLog;
                }
                return null;
            }
        }
        public List<Biz_UserLog> ReadAllUserLogs()
        {
            List<Biz_UserLog> userLogList = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                userLogList =
                    (from UserLog in _context.Biz_UserLogs
                     select UserLog).ToList();
            }
            return userLogList;
        }

    }
}
