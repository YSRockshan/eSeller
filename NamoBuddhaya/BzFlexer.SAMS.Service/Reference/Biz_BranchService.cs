using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Reference
{
    public class Biz_BranchService
    {
        Biz_BranchesData _branchdata = new Biz_BranchesData();

        public void CreateBranch(Biz_Branch branch)
        {
            if (branch != null)
            {
                _branchdata.Create(branch);
            }
        }

        public void UpdateBranch(Biz_Branch branch)
        {
            if (branch != null)
            {
                _branchdata.Update(branch);
            }
        }

        public void DeleteBranches(long branchId)
        {
            if (branchId != 0)
            {
                _branchdata.Delete(branchId);
            }
        }

        public Biz_Branch ReadBranchById(long branchId)
        {
            return _branchdata.ReadBranchById(branchId);
        }

        public List<Biz_Branch> ReadAllBranch()
        {
            return _branchdata.ReadAllBranch();
        }

        public List<Biz_Branch> ReadBranchByBranhCode(string branchCode)
        {
            return _branchdata.ReadBranchByBranhCode(branchCode);
        }

    }
}
