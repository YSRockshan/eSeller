using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public class Biz_CommissionsData
    {
        public Boolean Create(Biz_Commission commission)
        {
            Boolean isSuccess = false;
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_Commissions.AddObject(commission);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

       public Boolean Update(Biz_Commission commission)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_Commissions", commission);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, commission);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Delete(long commissionId)
        {
            Boolean isSuccess = false;
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var commissionList = from Commission in _context.Biz_Commissions
                                     where Commission.Id == commissionId
                                     select Commission;

                foreach (Biz_Commission commission in commissionList)
                {
                    _context.DeleteObject(commission);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Biz_Commission ReadCommissionById(long commissionId)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var commissionList = from Commission in _context.Biz_Commissions
                                     where Commission.Id == commissionId
                                     select Commission;

                foreach (Biz_Commission commission in commissionList)
                {
                    return commission;
                }
                return null;
            }
        }

        public List<Biz_Commission> ReadAllCommissions()
        {
            List<Biz_Commission> commissionList = null;

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                commissionList =
                    (from Commission in _context.Biz_Commissions
                     select Commission).ToList();
            }
            return commissionList;
        }

        public List<Biz_Commission> ReadCommissionByCode(string commissionCode)
        {
            List<Biz_Commission> commissionList = new List<Biz_Commission>();
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                commissionList = (from Commission in _context.Biz_Commissions
                                  where Commission.Code == commissionCode
                                  select Commission).ToList();

            }
            return commissionList;
        }
    }
}
