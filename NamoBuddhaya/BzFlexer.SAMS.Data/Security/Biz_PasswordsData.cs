using System;
using System.Collections.Generic;
using System.Linq;
using BzFlexer.SAMS.Biz.Security;
using System.Data;
using BzFlexer.SAMS.Data.Reference;
using BzFlexer.SAMS.Biz.Connection;

namespace BzFlexer.SAMS.Data.Security
{
    public partial class Biz_PasswordsData
    {
        public bool Create(Biz_PasswordHistory passwordHistory)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_PasswordHistories.AddObject(passwordHistory);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Update(Biz_PasswordHistory passwordHistory)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_PasswordHistories", passwordHistory);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, passwordHistory);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Delete(long passwordHistoryId)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var passwordHistoryList = from Biz_PasswordHistory in _context.Biz_PasswordHistories
                                          where Biz_PasswordHistory.Id == passwordHistoryId
                                          select Biz_PasswordHistory;

                foreach (Biz_PasswordHistory passwordHistory in passwordHistoryList)
                {
                    _context.DeleteObject(passwordHistory);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Biz_PasswordHistory ReadPasswordHistoryById(long passwordHistoryId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var passwordHistoryList = from Biz_PasswordHistory in _context.Biz_PasswordHistories
                                          where Biz_PasswordHistory.Id == passwordHistoryId
                                          select Biz_PasswordHistory;

                foreach (Biz_PasswordHistory passwordHistory in passwordHistoryList)
                {
                    return passwordHistory;
                }
                return null;
            }
        }

        public List<Biz_PasswordHistory> ReadAllPasswordHistoryies()
        {
            List<Biz_PasswordHistory> passwordHistoryList = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                passwordHistoryList =
                    (from Biz_PasswordHistory in _context.Biz_PasswordHistories
                     select Biz_PasswordHistory).ToList();
            }
            return passwordHistoryList;
        }

        public Biz_PasswordHistory ReadPasswordHistoryByLoginIdAndPassword(string loginId, string password)
        {
            List<Biz_PasswordHistory> passwordHistoryList = new List<Biz_PasswordHistory>();
            List<Biz_PasswordHistory> passwordHistoryListNew = new List<Biz_PasswordHistory>();

            passwordHistoryList = this.ReadAllPasswordHistoryies();
            passwordHistoryList = (from passwordHistory in passwordHistoryList
                                   where
                                       passwordHistory.User_Name == loginId
                                     && passwordHistory.New_Password == GeneralData.Encrypt(password)
                                     && passwordHistory.Status.Trim() == "A"
                                   select passwordHistory).ToList();
            foreach (Biz_PasswordHistory passwordHistory in passwordHistoryList)
            {
                passwordHistory.Biz_Stakeholders =
                    new Biz_EmployeeDetailData().ReadEmployeeDetailsById(passwordHistory.IdStakeholder);

                passwordHistoryListNew.Add(passwordHistory);
            }

            foreach (Biz_PasswordHistory passwordHistory in passwordHistoryListNew)
            {
                return passwordHistory;
            }
            return null;
        }

        public Biz_PasswordHistory ReadValidPassword(long stkId, string eMail, string oldPassword)
        {
            Biz_PasswordHistory passwordHistory = new Biz_PasswordHistory();
            List<Biz_PasswordHistory> passwordHistoryList = new List<Biz_PasswordHistory>();
            passwordHistoryList = this.ReadAllPasswordHistoryies();
            passwordHistoryList = (from history in passwordHistoryList
                                   where
                                       history.IdStakeholder == stkId &&
                                       history.User_Name == eMail.Trim() &&
                                       history.New_Password == GeneralData.Encrypt(oldPassword) && history.Status == "A"
                                   select history).ToList();
            passwordHistory = passwordHistoryList.FirstOrDefault();
            return passwordHistory;
        }

    }
}
