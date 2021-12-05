using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_BranchPriceBookService
    {
        Biz_BranchesPriceBookData _branchPriceBookData = new Biz_BranchesPriceBookData();
     
        public Boolean CreateBranchPriceBook(Biz_BranchPriceBook _branchPriceBook)
        {
            Boolean isSuccess = false;
            if (_branchPriceBook != null)
            {
                isSuccess = _branchPriceBookData.Create(_branchPriceBook);
            }
            return isSuccess;
        }

   public Boolean UpdateBranchPriceBook(Biz_BranchPriceBook _branchPriceBook)
        {
            Boolean isSuccess = false;
            if (_branchPriceBook != null)
            {
                isSuccess = _branchPriceBookData.Update(_branchPriceBook);
            }
            return isSuccess;
        }

       public Boolean DeleteBranchPriceBook(long branchPriceBookId)
        {
            Boolean isSuccess = false;
            if (branchPriceBookId != 0)
            {
                isSuccess = _branchPriceBookData.Delete(branchPriceBookId);
            }
            return isSuccess;
        }

        public Biz_BranchPriceBook GetByBranchPriceBookId(long branchPriceBookId)
        {
            return _branchPriceBookData.ReadByBranchPriceBookId(branchPriceBookId);
        }

       
        public List<Biz_BranchPriceBook> ReadAllBranchPriceBook()
        {
            return _branchPriceBookData.ReadAllBranchPriceBook();
        }

        public List<Biz_BranchPriceBook> ReadMappedBranchPriceBookByBranchId(long branchId)
        {
            return _branchPriceBookData.ReadMappedBranchPriceBookByBranchId(branchId);
        }
        //Biz_PriceBook to be change
        Biz_PriceBookData _PriceBookData = new Biz_PriceBookData();
        public List<Biz_PriceBook> ReadUnMappedBranchPriceBookByBranchId(long branchId)
        {
            return _PriceBookData.ReadUnMappedBranchPriceBookByBranchId(branchId);
        }

        public List<Biz_PriceBook> ReadBranchWisePriceBook(long branchId)
        {
            return _PriceBookData.ReadBranchWisePriceBook(branchId);
        }

    }
}
