using BzFlexer.SAMS.Biz.Security;
using BzFlexer.SAMS.Data.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Security
{
    public class Biz_PasswordHistoryService
    {
        Biz_PasswordsData _passwordHistoryData = new Biz_PasswordsData();
       // CommonData commonData = new CommonData();

        public Boolean CreatePasswordHistory(Biz_PasswordHistory passwordHistory)
        {
            Boolean isSuccess = false;
            if (passwordHistory != null)
            {
                isSuccess = _passwordHistoryData.Create(passwordHistory);
            }
            return isSuccess;
        }

        public Boolean UpdatePasswordHistory(Biz_PasswordHistory passwordHistory)
        {
            Boolean isSuccess = false;
            if (passwordHistory != null)
            {
                isSuccess = _passwordHistoryData.Update(passwordHistory);
            }
            return isSuccess;
        }

        public Boolean DeletePasswordHistory(long passwordHistoryId)
        {
            Boolean isSuccess = false;
            if (passwordHistoryId != 0)
            {
                isSuccess = _passwordHistoryData.Delete(passwordHistoryId);
            }
            return isSuccess;
        }

        public Biz_PasswordHistory ReadPasswordHistoryById(long passwordHistoryId)
        {
            return _passwordHistoryData.ReadPasswordHistoryById(passwordHistoryId);
        }

        public List<Biz_PasswordHistory> ReadAllPasswordHistoryies()
        {
            return _passwordHistoryData.ReadAllPasswordHistoryies();
        }

        public Biz_PasswordHistory ReadPasswordHistoryByLoginIdAndPassword(string loginId, string password)
        {
            return _passwordHistoryData.ReadPasswordHistoryByLoginIdAndPassword(loginId, password);
        }

        public Biz_PasswordHistory ReadValidPassword(long stkId, string eMail, string oldPassword)
        {
            return _passwordHistoryData.ReadValidPassword(stkId, eMail, oldPassword);
        }


    }
}
