using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Reference;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.Reference
{
    public partial class Biz_BranchesData
    {
        public List<Biz_Branch> GetBranchesByBranhCode(string _branchCode)
        {
            List<Biz_Branch> _branchList = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {//_context.Branch is ObjectSet name in context
                _branchList = (from Biz_Branch in _context.Biz_Branches where Biz_Branch.Code == _branchCode select Biz_Branch).ToList();
            }
            return _branchList;
        }

        public void Create(Biz_Branch branch)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
               _context.Biz_Branches.AddObject(branch);
                _context.SaveChanges();
            }
        }

      public void Update(Biz_Branch branch)
        {
            EntityKey key = null;
            object original = null;

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_Branches", branch);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, branch);
                }
                _context.SaveChanges();
            }
        }

        public void Delete(long branchId)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var branchList = from Branch in _context.Biz_Branches  where Branch.Id == branchId select Branch;

                foreach (Biz_Branch branch in branchList)
                {
                    _context.DeleteObject(branch);
                }
                _context.SaveChanges();
            }
        }

        public Biz_Branch ReadBranchById(long branchId)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var branchList = from Branch in _context.Biz_Branches where Branch.Id == branchId select Branch;
                foreach (Biz_Branch branch in branchList)
                {
                    return branch;
                }
                return null;
            }
        }

      
        public List<Biz_Branch> ReadAllBranch()
        {
            List<Biz_Branch> branchList = null;
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                branchList = (from Branch in _context.Biz_Branches select Branch).ToList();
            }
            return branchList;
        }
        public List<Biz_Branch> ReadBranchByBranhCode(string branchCode)
        {
            List<Biz_Branch> branchList = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                branchList = (from Branch in _context.Biz_Branches where Branch.Code == branchCode select Branch).ToList();
            }
            return branchList;
        }

    }
}
