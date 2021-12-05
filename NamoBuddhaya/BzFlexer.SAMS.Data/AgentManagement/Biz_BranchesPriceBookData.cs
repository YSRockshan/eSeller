using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public partial class Biz_BranchesPriceBookData
    {
        public Boolean Create(Biz_BranchPriceBook branchPriceBook)
        {
            Boolean isSuccess = false;
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_BranchPriceBooks.AddObject(branchPriceBook);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public bool Update(Biz_BranchPriceBook _branchPriceBook)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_BranchPriceBooks", _branchPriceBook);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, _branchPriceBook);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public bool Delete(long branchPriceBookId)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var _branchPriceBookList = from Biz_BranchPriceBook in _context.Biz_BranchPriceBooks
                                           where Biz_BranchPriceBook.Id == branchPriceBookId
                                          select Biz_BranchPriceBook;

                foreach (Biz_BranchPriceBook bpBook in _branchPriceBookList)
                {
                    _context.DeleteObject(bpBook);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

       public Biz_BranchPriceBook ReadByBranchPriceBookId(long branchPriceBookId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var _branchPriceBookList = from Biz_BranchPriceBook in _context.Biz_BranchPriceBooks
                                          where Biz_BranchPriceBook.Id == branchPriceBookId
                                          select Biz_BranchPriceBook;

                foreach (Biz_BranchPriceBook bpBook in _branchPriceBookList)
                {
                    return bpBook;
                }
                return null;
            }
        }

        public List<Biz_BranchPriceBook> ReadAllBranchPriceBook()
        {
            List<Biz_BranchPriceBook> _branchPriceBookList = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _branchPriceBookList =
                    (from Biz_BranchPriceBook in _context.Biz_BranchPriceBooks
                     select Biz_BranchPriceBook).ToList();
            }
            return _branchPriceBookList;
        }
        public List<Biz_BranchPriceBook> ReadMappedBranchPriceBookByBranchId(long branchId)
        {
            List<Biz_BranchPriceBook> branchPriceBooks = new List<Biz_BranchPriceBook>();
            List<Biz_BranchPriceBook> branchPriceBookList = new List<Biz_BranchPriceBook>();
            branchPriceBooks = ReadAllBranchPriceBook();
            branchPriceBooks = (from Biz_BranchPriceBook in branchPriceBooks
                                where Biz_BranchPriceBook.IdBranch == branchId
                                select Biz_BranchPriceBook).ToList();
            foreach (Biz_BranchPriceBook branchPriceBook in branchPriceBooks)
            {
                branchPriceBook.Biz_PriceBooks = new Biz_PriceBookData().ReadPriceBookById(branchPriceBook.IdPriceBook);
                branchPriceBookList.Add(branchPriceBook);
            }
            return branchPriceBookList;
        }
        
        


    }
}
