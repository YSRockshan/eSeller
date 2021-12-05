using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Reference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.Reference
{
    public partial class Biz_StakeholdersBranchData
    {
        public Boolean Add(Biz_StakeholderBranch stakeholderBranch)
        {
            Boolean isSuccess = false;
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_StakeholderBranches.AddObject(stakeholderBranch);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

       public Boolean Modify(Biz_StakeholderBranch stakeholderBranch)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_StakeholderBranches", stakeholderBranch);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, stakeholderBranch);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Delete(long stakeholderBranchId)
        {
            Boolean isSuccess = false;
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var stakeholderBranchList = from StakeholderBranch in _context.Biz_StakeholderBranches
                                            where StakeholderBranch.Id == stakeholderBranchId
                                            select StakeholderBranch;

                foreach (Biz_StakeholderBranch stakeholderBranch in stakeholderBranchList)
                {
                    _context.DeleteObject(stakeholderBranch);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

       public Biz_StakeholderBranch ReadStakeholderBranchById(long stakeholderBranchId)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var stakeholderBranchList = from StakeholderBranch in _context.Biz_StakeholderBranches
                                            where StakeholderBranch.Id == stakeholderBranchId
                                            select StakeholderBranch;

                foreach (Biz_StakeholderBranch stakeholderBranch in stakeholderBranchList)
                {
                    return stakeholderBranch;
                }
                return null;
            }
        }

        public List<Biz_StakeholderBranch> ReadAllStakeholderBranchs()
        {
            List<Biz_StakeholderBranch> stakeholderBranchList = null;

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                stakeholderBranchList =
                    (from StakeholderBranch in _context.Biz_StakeholderBranches
                     select StakeholderBranch).ToList();
            }
            return stakeholderBranchList;
        }
        public void DeleteStakeholderByStakeholderAndBranch(long stakeholderId, long branchId)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var stakeholderBranchList = from StakeholderBranch in _context.Biz_StakeholderBranches
                                            where StakeholderBranch.IdStakeholder == stakeholderId && StakeholderBranch.IdBranch == branchId
                                            select StakeholderBranch;

                foreach (Biz_StakeholderBranch stakeholderBranch in stakeholderBranchList)
                {
                    _context.DeleteObject(stakeholderBranch);
                }
                _context.SaveChanges();
            }
        }
    }
}
